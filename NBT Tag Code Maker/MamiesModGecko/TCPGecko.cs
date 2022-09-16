using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using MamiesModGecko;

namespace MamiesModGecko
{
    public class ByteSwap
    {
        public static UInt16 Swap(UInt16 input)
        {
            if (BitConverter.IsLittleEndian)
                return ((UInt16)(
                    ((0xFF00 & input) >> 8) |
                    ((0x00FF & input) << 8)));
            else
                return input;
        }

        public static UInt32 Swap(UInt32 input)
        {
            if (BitConverter.IsLittleEndian)
                return ((UInt32)(
                    ((0xFF000000 & input) >> 24) |
                    ((0x00FF0000 & input) >> 8) |
                    ((0x0000FF00 & input) << 8) |
                    ((0x000000FF & input) << 24)));
            else
                return input;
        }

        public static UInt64 Swap(UInt64 input)
        {
            if (BitConverter.IsLittleEndian)
                return ((UInt64)(
                    ((0xFF00000000000000 & input) >> 56) |
                    ((0x00FF000000000000 & input) >> 40) |
                    ((0x0000FF0000000000 & input) >> 24) |
                    ((0x000000FF00000000 & input) >> 8) |
                    ((0x00000000FF000000 & input) << 8) |
                    ((0x0000000000FF0000 & input) << 24) |
                    ((0x000000000000FF00 & input) << 40) |
                    ((0x00000000000000FF & input) << 56)));
            else
                return input;
        }
    }

    public enum ETCPErrorCode
    {
        noTCPGeckoFound,
        FTDICommandSendError,
        FTDIReadDataError,
        TooManyRetries
    }

    public enum FTDICommand
    {
        CMD_ResultError,
        CMD_FatalError,
        CMD_OK
    }

    public delegate void GeckoProgress(UInt32 address, UInt32 currentchunk, UInt32 allchunks, UInt32 transferred, UInt32 length, bool okay, bool dump);

    public class ETCPGeckoException : Exception
    {
        private ETCPErrorCode PErrorCode;

        public ETCPGeckoException(ETCPErrorCode code)
        {
            PErrorCode = code;
        }
    }

    public class TCPGecko
    {
        #region Original code with some modifications
        private TCPConn ptcp;

        #region base constants
        private const UInt32 packetsize = 0x400;
        private const Byte cmd_poke08 = 0x01;
        private const Byte cmd_poke16 = 0x02;
        private const Byte cmd_pokemem = 0x03;
        private const Byte cmd_readmem = 0x04;
        private const Byte cmd_writekern = 0x0B;
        private const Byte cmd_readkern = 0x0C;
        private const Byte cmd_rpc = 0x70;
        private const Byte cmd_os_version = 0x9A;

        private const Byte GCFAIL = 0xCC;

        private const Byte BlockZero = 0xB0;

        private uint maximumMemoryChunkSize = 0x400;
        #endregion

        private event GeckoProgress PChunkUpdate;

        private bool Connected { get; set; }

        private bool CancelDump { get; set; }

        public TCPGecko(string ip)
        {
            ptcp = new TCPConn(ip, 7331);
            Connected = false;
            PChunkUpdate = null;
        }

        ~TCPGecko()
        {
            if (Connected)
                Disconnect();
        }

        private bool InitGecko()
        {
            //Reset device
            return true;
        }

        public bool Connect()
        {
            if (Connected)
            {
                Disconnect();
            }

            Connected = false;

            //Open TCP Gecko
            try
            {
                ptcp.Connect();
            }
            catch (IOException)
            {
                // Don't disconnect if there's nothing connected
                Disconnect();
                throw new ETCPGeckoException(ETCPErrorCode.noTCPGeckoFound);
            }

            System.Threading.Thread.Sleep(150);
            Connected = true;

            return true;
        }

        public bool Disconnect()
        {
            Connected = false;
            ptcp.Close();

            return false;
        }

        //Send update on a running process to the parent class
        protected void SendUpdate(UInt32 address, UInt32 currentchunk, UInt32 allchunks, UInt32 transferred, UInt32 length, bool okay, bool dump)
        {
            if (PChunkUpdate != null)
                PChunkUpdate(address, currentchunk, allchunks, transferred, length, okay, dump);
        }

        public UInt32 OsVersionRequest()
        {
            if (RawCommand(cmd_os_version) != FTDICommand.CMD_OK)
                throw new ETCPGeckoException(ETCPErrorCode.FTDICommandSendError);

            Byte[] buffer = new Byte[4];

            if (GeckoRead(buffer, 4) != FTDICommand.CMD_OK)
                throw new ETCPGeckoException(ETCPErrorCode.FTDICommandSendError);

            return ByteSwap.Swap(BitConverter.ToUInt32(buffer, 0));
        }

        #region FTDICommand
        protected FTDICommand GeckoRead(Byte[] recbyte, UInt32 nobytes)
        {
            UInt32 bytes_read = 0;

            try
            {
                ptcp.Read(recbyte, nobytes, ref bytes_read);
            }
            catch (IOException)
            {
                Disconnect();
                return FTDICommand.CMD_FatalError;       // fatal error
            }
            if (bytes_read != nobytes)
            {
                return FTDICommand.CMD_ResultError;   // lost bytes in transmission
            }

            return FTDICommand.CMD_OK;
        }

        protected FTDICommand GeckoWrite(Byte[] sendbyte, Int32 nobytes)
        {
            UInt32 bytes_written = 0;

            try
            {
                ptcp.Write(sendbyte, nobytes, ref bytes_written);
            }
            catch (IOException)
            {
                Disconnect();
                return FTDICommand.CMD_FatalError;       // fatal error
            }
            if (bytes_written != nobytes)
            {
                return FTDICommand.CMD_ResultError;   // lost bytes in transmission
            }

            return FTDICommand.CMD_OK;
        }

        //Allows sending a basic one byte command to the Wii U
        public FTDICommand RawCommand(Byte id)
        {
            return GeckoWrite(BitConverter.GetBytes(id), 1);
        }
        #endregion

        #region Dump
        public void Dump(UInt32 startdump, UInt32 enddump, Stream saveStream)
        {
            Stream[] tempStream = { saveStream };
            Dump(startdump, enddump, tempStream);
        }

        public void Dump(UInt32 startdump, UInt32 enddump, Stream[] saveStream)
        {
            //Reset connection
            InitGecko();

            if (ValidMemory.RangeCheckId(startdump) != ValidMemory.RangeCheckId(enddump))
            {
                enddump = ValidMemory.ValidAreas[ValidMemory.RangeCheckId(startdump)].High;
            }

            if (!ValidMemory.ValidAddress(startdump)) return;

            //How many bytes of data have to be transferred
            UInt32 memlength = enddump - startdump;

            //How many chunks do I need to split this data into
            //How big ist the last chunk
            UInt32 fullchunks = memlength / packetsize;
            UInt32 lastchunk = memlength % packetsize;

            //How many chunks do I need to transfer
            UInt32 allchunks = fullchunks;
            if (lastchunk > 0)
                allchunks++;

            UInt64 GeckoMemRange = ByteSwap.Swap((UInt64)(((UInt64)startdump << 32) + ((UInt64)enddump)));
            if (GeckoWrite(BitConverter.GetBytes(cmd_readmem), 1) != FTDICommand.CMD_OK)
                throw new ETCPGeckoException(ETCPErrorCode.FTDICommandSendError);

            //Read reply - expcecting GCACK -- nope, too slow, TCP is reliable!
            Byte retry = 0;

            //Now let's send the dump information
            if (GeckoWrite(BitConverter.GetBytes(GeckoMemRange), 8) != FTDICommand.CMD_OK)
                throw new ETCPGeckoException(ETCPErrorCode.FTDICommandSendError);

            //We start with chunk 0
            UInt32 chunk = 0;
            retry = 0;

            // Reset cancel flag
            bool done = false;
            CancelDump = false;

            Byte[] buffer = new Byte[packetsize]; //read buffer
            while (chunk < fullchunks && !done)
            {
                //No output yet availible
                SendUpdate(startdump + chunk * packetsize, chunk, allchunks, chunk * packetsize, memlength, retry == 0, true);
                //Set buffer
                Byte[] response = new Byte[1];
                if (GeckoRead(response, 1) != FTDICommand.CMD_OK)
                {
                    //Major fail, give it up
                    GeckoWrite(BitConverter.GetBytes(GCFAIL), 1);
                    throw new ETCPGeckoException(ETCPErrorCode.FTDIReadDataError);
                }
                Byte reply = response[0];
                if (reply == BlockZero)
                {
                    for (int i = 0; i < packetsize; i++)
                    {
                        buffer[i] = 0;
                    }
                }
                else
                {
                    FTDICommand returnvalue = GeckoRead(buffer, packetsize);
                    if (returnvalue == FTDICommand.CMD_ResultError)
                    {
                        retry++;
                        if (retry >= 3)
                        {
                            //Give up, too many retries
                            GeckoWrite(BitConverter.GetBytes(GCFAIL), 1);
                            throw new ETCPGeckoException(ETCPErrorCode.TooManyRetries);
                        }
                        //GeckoWrite(BitConverter.GetBytes(GCRETRY), 1);
                        continue;
                    }
                    else if (returnvalue == FTDICommand.CMD_FatalError)
                    {
                        //Major fail, give it up
                        GeckoWrite(BitConverter.GetBytes(GCFAIL), 1);
                        throw new ETCPGeckoException(ETCPErrorCode.FTDIReadDataError);
                    }
                }
                //write received package to output stream
                foreach (Stream stream in saveStream)
                {
                    stream.Write(buffer, 0, ((Int32)packetsize));
                }

                //reset retry counter
                retry = 0;
                //next chunk
                chunk++;

                if (!CancelDump)
                {
                    //ackowledge package -- nope, too slow, TCP is reliable!
                    //GeckoWrite(BitConverter.GetBytes(GCACK), 1);
                }
                else
                {
                    // User requested a cancel
                    GeckoWrite(BitConverter.GetBytes(GCFAIL), 1);
                    done = true;
                }
            }

            //Final package?
            while (!done && lastchunk > 0)
            {
                //No output yet availible
                SendUpdate(startdump + chunk * packetsize, chunk, allchunks, chunk * packetsize, memlength, retry == 0, true);
                //Set buffer
                // buffer = new Byte[lastchunk];
                Byte[] response = new Byte[1];
                if (GeckoRead(response, 1) != FTDICommand.CMD_OK)
                {
                    //Major fail, give it up
                    GeckoWrite(BitConverter.GetBytes(GCFAIL), 1);
                    throw new ETCPGeckoException(ETCPErrorCode.FTDIReadDataError);
                }
                Byte reply = response[0];
                if (reply == BlockZero)
                {
                    for (int i = 0; i < lastchunk; i++)
                    {
                        buffer[i] = 0;
                    }
                }
                else
                {
                    FTDICommand returnvalue = GeckoRead(buffer, lastchunk);
                    if (returnvalue == FTDICommand.CMD_ResultError)
                    {
                        retry++;
                        if (retry >= 3)
                        {
                            //Give up, too many retries
                            GeckoWrite(BitConverter.GetBytes(GCFAIL), 1);
                            throw new ETCPGeckoException(ETCPErrorCode.TooManyRetries);
                        }
                        //GeckoWrite(BitConverter.GetBytes(GCRETRY), 1);
                        continue;
                    }
                    else if (returnvalue == FTDICommand.CMD_FatalError)
                    {
                        //Major fail, give it up
                        GeckoWrite(BitConverter.GetBytes(GCFAIL), 1);
                        throw new ETCPGeckoException(ETCPErrorCode.FTDIReadDataError);
                    }
                }
                //write received package to output stream
                foreach (Stream stream in saveStream)
                {
                    stream.Write(buffer, 0, ((Int32)lastchunk));
                }
                //reset retry counter
                retry = 0;
                //cancel while loop
                done = true;
                //ackowledge package -- nope, too slow, TCP is reliable!
                //GeckoWrite(BitConverter.GetBytes(GCACK), 1);
            }
            SendUpdate(enddump, allchunks, allchunks, memlength, memlength, true, true);
        }
        #endregion

        #region Kern commands
        //Poke a 32 bit value to kernel. note: address and value must be all in endianness of sending platform
        public void poke_kern(UInt32 address, UInt32 value)
        {
            //value = send [address in big endian] [value in big endian]
            UInt64 PokeVal = (((UInt64)address) << 32) | ((UInt64)value);

            PokeVal = ByteSwap.Swap(PokeVal);

            //Send poke
            if (RawCommand(cmd_writekern) != FTDICommand.CMD_OK)
                throw new ETCPGeckoException(ETCPErrorCode.FTDICommandSendError);

            //write value
            if (GeckoWrite(BitConverter.GetBytes(PokeVal), 8) != FTDICommand.CMD_OK)
                throw new ETCPGeckoException(ETCPErrorCode.FTDICommandSendError);
        }

        //Read a 32 bit value from kernel. note: address must be all in endianness of sending platform
        public UInt32 peek_kern(UInt32 address)
        {
            //value = send [address in big endian] [value in big endian]
            address = ByteSwap.Swap(address);

            //Send read
            if (RawCommand(cmd_readkern) != FTDICommand.CMD_OK)
                throw new ETCPGeckoException(ETCPErrorCode.FTDICommandSendError);

            //write value
            if (GeckoWrite(BitConverter.GetBytes(address), 4) != FTDICommand.CMD_OK)
                throw new ETCPGeckoException(ETCPErrorCode.FTDICommandSendError);

            Byte[] buffer = new Byte[4];
            if (GeckoRead(buffer, 4) != FTDICommand.CMD_OK)
                throw new ETCPGeckoException(ETCPErrorCode.FTDICommandSendError);

            return ByteSwap.Swap(BitConverter.ToUInt32(buffer, 0));
        }
        #endregion

        #region Poke commands
        //Poke a 32 bit value - note: address and value must be all in endianness of sending platform
        public void poke(UInt32 address, UInt32 value)
        {
            //Lower address
            address &= 0xFFFFFFFC;

            //value = send [address in big endian] [value in big endian]
            UInt64 PokeVal = (((UInt64)address) << 32) | ((UInt64)value);

            PokeVal = ByteSwap.Swap(PokeVal);

            //Send poke
            if (RawCommand(cmd_pokemem) != FTDICommand.CMD_OK)
            {
                //throw new ETCPGeckoException(ETCPErrorCode.FTDICommandSendError);
                System.Windows.Forms.MessageBox.Show("Your Wii U have crash or you are disconnected !");
            }

            //write value
            if (GeckoWrite(BitConverter.GetBytes(PokeVal), 8) != FTDICommand.CMD_OK)
            {
                //throw new ETCPGeckoException(ETCPErrorCode.FTDICommandSendError);
            }
        }

        //Copy of poke, just poke32 to make clear it is a 32-bit poke
        public void poke32(UInt32 address, UInt32 value)
        {
            poke(address, value);
        }

        //Poke a 16 bit value - note: address and value must be all in endianness of sending platform
        public void poke16(UInt32 address, UInt16 value)
        {
            //Lower address
            address &= 0xFFFFFFFE;

            //value = send [address in big endian] [value in big endian]
            UInt64 PokeVal = (((UInt64)address) << 32) | ((UInt64)value);

            PokeVal = ByteSwap.Swap(PokeVal);

            //Send poke16
            if (RawCommand(cmd_poke16) != FTDICommand.CMD_OK)
            {
                //throw new ETCPGeckoException(ETCPErrorCode.FTDICommandSendError);
                System.Windows.Forms.MessageBox.Show("Your Wii U have crash or you are disconnected !");
            }

            //write value
            if (GeckoWrite(BitConverter.GetBytes(PokeVal), 8) != FTDICommand.CMD_OK)
            {
                //throw new ETCPGeckoException(ETCPErrorCode.FTDICommandSendError);
            }
        }

        //Poke a 08 bit value - note: address and value must be all in endianness of sending platform
        public void poke08(UInt32 address, Byte value)
        {
            //value = send [address in big endian] [value in big endian]
            UInt64 PokeVal = (((UInt64)address) << 32) | ((UInt64)value);

            PokeVal = ByteSwap.Swap(PokeVal);

            //Send poke08
            if (RawCommand(cmd_poke08) != FTDICommand.CMD_OK)
            {
                //throw new ETCPGeckoException(ETCPErrorCode.FTDICommandSendError);
                System.Windows.Forms.MessageBox.Show("Your Wii U have crash or you are disconnected !");
            }

            //write value
            if (GeckoWrite(BitConverter.GetBytes(PokeVal), 8) != FTDICommand.CMD_OK)
            {
                //throw new ETCPGeckoException(ETCPErrorCode.FTDICommandSendError);
            }
        }
        #endregion

        #region Peek commands
        public UInt32 peek(UInt32 address)
        {
            if (!ValidMemory.ValidAddress(address))
            {
                return 0;
            }

            //address will be alligned to 4
            UInt32 paddress = address & 0xFFFFFFFC;

            //Create a memory stream for the actual dump
            MemoryStream stream = new MemoryStream();

            //make sure to not send data to the output
            GeckoProgress oldUpdate = PChunkUpdate;
            PChunkUpdate = null;

            try
            {
                //dump data
                Dump(paddress, paddress + 4, stream);

                //go to beginning
                stream.Seek(0, SeekOrigin.Begin);
                Byte[] buffer = new Byte[4];
                stream.Read(buffer, 0, 4);

                //Read buffer
                UInt32 result = BitConverter.ToUInt32(buffer, 0);

                //Swap to machine endianness and return
                result = ByteSwap.Swap(result);

                return result;
            }
            finally
            {
                PChunkUpdate = oldUpdate;

                //make sure the Stream is properly closed
                stream.Close();
            }
        }

        //Shortcut for using peek
        public UInt32 peek32(UInt32 address)
        {
            return peek(address);
        }

        public UInt32 peek16(UInt32 address)
        {
            if (!ValidMemory.ValidAddress(address))
            {
                return 0;
            }

            //address will be alligned to 4
            UInt32 paddress = address & 0xFFFFFFFC;

            //Create a memory stream for the actual dump
            MemoryStream stream = new MemoryStream();

            //make sure to not send data to the output
            GeckoProgress oldUpdate = PChunkUpdate;
            PChunkUpdate = null;

            try
            {
                //dump data
                Dump(paddress, paddress + 4, stream);

                //go to beginning
                stream.Seek(0, SeekOrigin.Begin);
                Byte[] buffer = new Byte[2];
                stream.Read(buffer, 0, 2);

                //Read buffer
                UInt16 result = BitConverter.ToUInt16(buffer, 0);

                //Swap to machine endianness and return
                result = ByteSwap.Swap(result);

                return result;
            }
            finally
            {
                PChunkUpdate = oldUpdate;

                //make sure the Stream is properly closed
                stream.Close();
            }
        }
        #endregion
        #endregion

        #region Make by nt games
        #region Connection
        public void simplyConnect()
        {
            try
            {
                ptcp.Connect();
            }
            catch (IOException)
            {
                Disconnect();
                throw new ETCPGeckoException(ETCPErrorCode.noTCPGeckoFound);
            }

            Thread.Sleep(150);
            Connected = true;
        }
        #endregion

        #region Poke commands
        //Poke a 64 bit value - note: address and value must be all in endianness of sending platform
        public void poke64(UInt32 address, long value)
        {
            //Convert value in long to a string
            string stringValue = convertToHexString(value, 16);

            //Separates the two values
            uint valueA = Convert.ToUInt32(stringValue.Substring(0, 8), 16);
            uint valueB = Convert.ToUInt32(stringValue.Substring(8, 8), 16);

            //Poke the two values
            poke(address, valueA);
            poke(address + 0x4, valueB);
        }

        //Poke a big (infinite) value - note: address must be all in endianness of sending platform and value must be all in hexadecimal in a string
        public void pokeHexString(uint address, string input) //or makeAssembly
        {
            List<uint> values = new List<uint> { };
            int totalValuesNumber = input.Length / 8;

            for (int number = 0; number <= totalValuesNumber; number++)
            {
                if (number == totalValuesNumber & input.Substring(number * 8).Length != 8)
                {
                    while (input.Substring(number * 8).Length != 8)
                    {
                        input = input + "0";
                    }
                }
                values.Add((uint)Convert.ToInt32(input.Substring(number * 8, 8), 16));
            }


            for (int valueNumber = 0; valueNumber < values.Count; valueNumber++)
            {
                poke32(address + ((uint)valueNumber * 0x4), values[valueNumber]);
            }
        }

        //Little shortcut for pokeHexString
        public void makeAssembly(uint address, string input)
        {
            pokeHexString(address, input);
        }

        //Poke a UTF16 string value - note: address must be all in endianness of sending platform and value must be all in a string
        public void pokeStringUTF16(uint address, string text)
        {
            Encoding unicode = Encoding.Unicode;
            Encoding utf16 = Encoding.BigEndianUnicode;

            byte[] unicodeBytes = unicode.GetBytes(text);
            byte[] utf16Bytes = Encoding.Convert(unicode, utf16, unicodeBytes);

            for (int valueNumber = 0; valueNumber < text.Length * 2; valueNumber++)
            {
                poke08(address + ((uint)valueNumber), utf16Bytes[valueNumber]);
            }
        }

        //Poke a UTF8 string value - note: address must be all in endianness of sending platform and value must be all in a string
        public void pokeStringUTF8(uint address, string text)
        {
            Encoding unicode = Encoding.Unicode;
            Encoding utf8 = Encoding.UTF8;

            byte[] unicodeBytes = unicode.GetBytes(text);
            byte[] utf8Bytes = Encoding.Convert(unicode, utf8, unicodeBytes);

            for (int valueNumber = 0; valueNumber < text.Length; valueNumber++)
            {
                poke08(address + ((uint)valueNumber), utf8Bytes[valueNumber]);
            }

        }
        #endregion

        #region Peek commands
        public string peekHexString(uint startAddress, uint endAddress)
        {
            string result = "";
            for (int x = 0; x < endAddress - startAddress;)
            {
                result = result + String.Format("{0:x8}", peek(startAddress + Convert.ToUInt32(x)));
                x = x + 4;
            }
            return result;
        }

        public string peekStringUTF16(UInt32 address)
        {
            char character1 = ' ';
            char character2 = ' ';
            string result = "";
            uint value = peek(address);
            string hexString = convertToHexString(value, 8);

            if (hexString == "0") //0 characters
            { }
            else if (hexString.Length > 4) //2 characters
            {
                character1 = (char)Convert.ToInt32(hexString.Substring(0, 4), 16);
                character2 = (char)Convert.ToInt32(hexString.Substring(4, 4), 16);
                result = $"{character1}{character2}";
            }
            else //1 characters
            {
                character1 = (char)Convert.ToInt32(hexString, 16);
                result = $"{character1}";
            }

            return result;
        }

        public string peekStringUTF8(UInt32 address)
        {
            char character1 = ' ';
            char character2 = ' ';
            char character3 = ' ';
            char character4 = ' ';
            string result = "";
            uint value = peek(address);
            string hexString = convertToHexString(value, 8);

            if (hexString == "0") //0 characters
            { }
            else if (hexString.Length == 7 || hexString.Length == 8) //4 characters
            {
                character1 = (char)Convert.ToInt32(hexString.Substring(0, 2), 16);
                character2 = (char)Convert.ToInt32(hexString.Substring(2, 2), 16);
                character3 = (char)Convert.ToInt32(hexString.Substring(4, 2), 16);
                character4 = (char)Convert.ToInt32(hexString.Substring(6, 2), 16);
                result = $"{character1}{character2}{character3}{character4}";
            }
            else if (hexString.Length == 5 || hexString.Length == 6) //3 characters
            {
                character1 = (char)Convert.ToInt32(hexString.Substring(0, 2), 16);
                character2 = (char)Convert.ToInt32(hexString.Substring(2, 2), 16);
                character3 = (char)Convert.ToInt32(hexString.Substring(4, 2), 16);
                result = $"{character1}{character2}{character3}";
            }
            else if (hexString.Length == 3 || hexString.Length == 4) //2 characters
            {
                character1 = (char)Convert.ToInt32(hexString.Substring(0, 2), 16);
                character2 = (char)Convert.ToInt32(hexString.Substring(2, 2), 16);
                result = $"{character1}{character2}";
            }
            else //1 characters
            {
                character1 = (char)Convert.ToInt32(hexString, 16);
                result = $"{character1}";
            }

            return result;
        }

        public string peekIP(uint address)
        {
            uint value = peek(address);
            string hexString = convertToHexString(value, 8);

            if (value == 0)
            {
                return "0.0.0.0";
            }
            else
            {
                string number1 = Convert.ToInt32(hexString.Substring(0, 2), 16).ToString();
                string number2 = Convert.ToInt32(hexString.Substring(2, 2), 16).ToString();
                string number3 = Convert.ToInt32(hexString.Substring(4, 2), 16).ToString();
                string number4 = Convert.ToInt32(hexString.Substring(6, 2), 16).ToString();

                return number1 + "." + number2 + "." + number3 + "." + number4;
            }
        }
        #endregion

        #region Code Handler commands
        //or JGecko U Code
        public void addCodeToCodesList(List<uint> codesList, string codeText)
        {
            string[] code = codeText.Replace(Environment.NewLine, ",").Replace(" ", ",").Replace("\n", ",").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int number = 0; number < code.Length; number++)
            {
                codesList.Add(uint.Parse(code[number].Trim(), NumberStyles.HexNumber));
            }
        }

        public void enableCodes(List<uint> codesList)
        {
            disableCodes();
            for (int codeNumber = 0; codeNumber < codesList.Count; codeNumber++)
            {
                poke32(0x01133000 + uint.Parse(codeNumber.ToString()) * 0x4, codesList[codeNumber]);
            }
            poke32(0x10014CFC, 0x00000001);
        }

        public void disableCodes()
        {
            poke32(0x10014CFC, 0x00000000);
            clearMemory(0x01133000, 0x01134300); //à améliorer
        }
        #endregion

        #region Call function commands
        public UInt64 CallFunction64(uint address, params uint[] args)
        {
            byte[] buffer = new Byte[4 + 8 * 4];//36

            address = ByteSwap.Swap(address);//prend l'adresse

            BitConverter.GetBytes(address).CopyTo(buffer, 0);

            for (int i = 0; i < 8; i++)
            {
                if (i < args.Length)
                {
                    BitConverter.GetBytes(ByteSwap.Swap(args[i])).CopyTo(buffer, 4 + i * 4);
                }
                else
                {
                    BitConverter.GetBytes(0xfecad0ba).CopyTo(buffer, 4 + i * 4);
                }
            }

            if (RawCommand(cmd_rpc) != FTDICommand.CMD_OK)
            {
                //throw new ETCPGeckoException(ETCPErrorCode.FTDICommandSendError);
                System.Windows.Forms.MessageBox.Show("Your Wii U have crash or you are disconnected !");
            }

            if (GeckoWrite(buffer, buffer.Length) != FTDICommand.CMD_OK)
            {
                //throw new ETCPGeckoException(ETCPErrorCode.FTDICommandSendError);
            }

            if (GeckoRead(buffer, 8) != FTDICommand.CMD_OK)
            {
                //throw new ETCPGeckoException(ETCPErrorCode.FTDICommandSendError);
            }

            return ByteSwap.Swap(BitConverter.ToUInt64(buffer, 0));
        }

        public uint CallFunction(uint address, params uint[] args)
        {
            return (uint)(CallFunction64(address, args) >> 32);
        }
        #endregion

        #region Others commands
        #region Change value
        public uint changeValue(uint baseValue, decimal value) //or Mix
        {
            return baseValue + (uint)value;
        }

        public uint customChangeValue(uint baseValue, decimal value, decimal increment)
        {
            return baseValue + (uint)(increment * value);
        }
        #endregion

        #region Clear memory
        public void clearMemory(uint startAddress, uint endAddress) 
        {
            for (int x = 0; x < endAddress - startAddress;)
            {
                poke32(startAddress + Convert.ToUInt32(x), 0x00000000);
                x = x + 4;
            }
        }
        #endregion
        #endregion

        #region Conversion
        public string convertToHexString(long value, int maxLength)
        {
            string result = Convert.ToString(value, 16);

            while (result.Length != maxLength)
            {
                result = "0" + result;
            }

            return result;
        }
        #endregion
    }

    public class BeforeConnect
    {
        public BeforeConnect()
        {
        }

        public bool ValidateIPv4(string ipString)
        {
            if (String.IsNullOrWhiteSpace(ipString))
            {
                return false;
            }

            if (ipString == "127.0.0.1")
            {
                return false;
            }

            string[] splitValues = ipString.Split('.');

            if (splitValues.Length != 4)
            {
                return false;
            }

            return splitValues.All(r => byte.TryParse(r, out byte tempForParsing));
        }
    }
    #endregion
}