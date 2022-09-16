using System;
using System.IO;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Forms;

namespace MamiesModGecko
{

    public class TCPConn
    {
        private TcpClient client;
        private NetworkStream stream;

        public TCPConn(string host, int port)
        {
            Host = host;
            Port = port;
            client = null;
            stream = null;
        }

        private string Host { get; set; }

        private int Port { get; set; }

        public void Connect()
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            client = new TcpClient { NoDelay = true };
            var ar = client.BeginConnect(Host, Port, null, null);
            var wh = ar.AsyncWaitHandle;
            try
            {
                if (!ar.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(5), false))
                {
                    client.Close();
                    throw new IOException("Connection timeout.", new TimeoutException());
                }

                client.EndConnect(ar);
            }
            finally
            {
                wh.Close();
            }

            stream = client.GetStream();
            stream.ReadTimeout = 10000;
            stream.WriteTimeout = 10000;
        }

        public void Close()
        {
            try
            {
                if (client == null)
                {
                    return;
                    throw new IOException("Not connected.", new NullReferenceException());
                }

                client.Close();
            }
            finally
            {
                client = null;
            }
        }

        public void Read(byte[] buffer, uint nobytes, ref uint bytesRead)
        {
            try
            {
                var offset = 0;
                if (stream == null)
                {
                    throw new IOException("Not connected.", new NullReferenceException());
                }

                bytesRead = 0;
                while (nobytes > 0)
                {
                    var read = stream.Read(buffer, offset, (int)nobytes);
                    if (read >= 0)
                    {
                        bytesRead += (uint)read;
                        offset += read;
                        nobytes -= (uint)read;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (ObjectDisposedException e)
            {
                throw new IOException("Connection closed.", e);
            }
        }


        public void ReadLong(byte[] buffer, ulong nobytes, ref uint bytesRead)
        {
            try
            {
                int num = 0;
                if (stream == null)
                {
                    throw new IOException("The NetworkStream was null", new NullReferenceException());
                }
                bytesRead = 0u;
                while (nobytes > 0L)
                {
                    int num2 = stream.Read(buffer, num, (int)nobytes);
                    if (num2 < 0)
                    {
                        break;
                    }
                    bytesRead += (uint)num2;
                    num += num2;
                    nobytes -= (uint)num2;
                }
            }
            catch (Exception innerException)
            {
                throw new IOException("Connection closed", innerException);
            }
        }

        public void Write(byte[] buffer, int nobytes, ref uint bytesWritten)
        {
            try
            {
                if (stream == null)
                {
                    throw new IOException("Not connected.", new NullReferenceException());
                }

                stream.Write(buffer, 0, nobytes);
                if (nobytes >= 0)
                {
                    bytesWritten = (uint)nobytes;
                }
                else
                {
                    bytesWritten = 0;
                }

                stream.Flush();
            }
            catch (ObjectDisposedException e)
            {
                throw new IOException("Connection closed.", e);
            }
        }
    }
}
