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
            this.Host = host;
            this.Port = port;
            this.client = null;
            this.stream = null;
        }

        private string Host { get; set; }

        private int Port { get; set; }

        public void Connect()
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.client = new TcpClient { NoDelay = true };
            var ar = this.client.BeginConnect(this.Host, this.Port, null, null);
            var wh = ar.AsyncWaitHandle;
            try
            {
                if (!ar.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(5), false))
                {
                    this.client.Close();
                    throw new IOException("Connection timeout.", new TimeoutException());
                }

                this.client.EndConnect(ar);
            }
            finally
            {
                wh.Close();
            }

            this.stream = this.client.GetStream();
            this.stream.ReadTimeout = 10000;
            this.stream.WriteTimeout = 10000;
        }

        public void Close()
        {
            try
            {
                if (this.client == null)
                {
                    return;
                    throw new IOException("Not connected.", new NullReferenceException());
                }

                this.client.Close();
            }
            finally
            {
                this.client = null;
            }
        }

        public void Read(byte[] buffer, uint nobytes, ref uint bytesRead)
        {
            try
            {
                var offset = 0;
                if (this.stream == null)
                {
                    throw new IOException("Not connected.", new NullReferenceException());
                }

                bytesRead = 0;
                while (nobytes > 0)
                {
                    var read = this.stream.Read(buffer, offset, (int)nobytes);
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
                if (this.stream == null)
                {
                    throw new IOException("The NetworkStream was null", new NullReferenceException());
                }
                bytesRead = 0u;
                while (nobytes > 0L)
                {
                    int num2 = this.stream.Read(buffer, num, (int)nobytes);
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
                if (this.stream == null)
                {
                    throw new IOException("Not connected.", new NullReferenceException());
                }

                this.stream.Write(buffer, 0, nobytes);
                if (nobytes >= 0)
                {
                    bytesWritten = (uint)nobytes;
                }
                else
                {
                    bytesWritten = 0;
                }

                this.stream.Flush();
            }
            catch (ObjectDisposedException e)
            {
                throw new IOException("Connection closed.", e);
            }
        }
    }
}
