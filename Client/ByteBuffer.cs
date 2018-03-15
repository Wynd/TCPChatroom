using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class ByteBuffer
    {
        List<byte> buffer;
        byte[] readBuffer;
        int readPosition;
        bool bufferUpdate = false;

        public ByteBuffer()
        {
            buffer = new List<byte>();
            readPosition = 0;
        }

        public int GetReadPosition()
        {
            return readPosition;
        }

        public byte[] ToArray()
        {
            return buffer.ToArray();
        }

        public int Count()
        {
            return buffer.Count;
        }

        public int Length()
        {
            return Count() - readPosition;
        }

        public void Clear()
        {
            buffer.Clear();
            readPosition = 0;
        }

        #region "Write Data"
        public void WriteByte(byte input)
        {
            buffer.Add(input);
            bufferUpdate = true;
        }

        public void WriteBytes(byte[] input)
        {
            buffer.AddRange(input);
            bufferUpdate = true;
        }

        public void WriteShort(short input)
        {
            buffer.AddRange(BitConverter.GetBytes(input));
            bufferUpdate = true;
        }

        public void WriteInteger(int input)
        {
            buffer.AddRange(BitConverter.GetBytes(input));
            bufferUpdate = true;
        }

        public void WriteFloat(float input)
        {
            buffer.AddRange(BitConverter.GetBytes(input));
            bufferUpdate = true;
        }

        public void WriteString(string input)
        {
            buffer.AddRange(BitConverter.GetBytes(input.Length));
            buffer.AddRange(Encoding.ASCII.GetBytes(input));
            bufferUpdate = true;
        }
        #endregion

        #region "Read Data"
        public byte ReadByte()
        {
            if (buffer.Count > readPosition)
            {
                if (bufferUpdate)
                {
                    readBuffer = buffer.ToArray();
                    bufferUpdate = false;
                }

                byte ret = readBuffer[readPosition];
                readPosition += 1;

                return ret;
            }
            else
            {
                throw new Exception("ByteBuffer is past it's limit !");
            }
        }

        public byte[] ReadBytes(int length)
        {
            if (bufferUpdate)
            {
                readBuffer = buffer.ToArray();
                bufferUpdate = false;
            }

            byte[] ret = buffer.GetRange(readPosition, length).ToArray();
            readPosition += length;

            return ret;
        }

        public int ReadInteger()
        {
            if (buffer.Count > readPosition)
            {
                if (bufferUpdate)
                {
                    readBuffer = buffer.ToArray();
                    bufferUpdate = false;
                }

                int ret = BitConverter.ToInt32(readBuffer, readPosition);
                readPosition += 4;

                return ret;
            }
            else
            {
                throw new Exception("ByteBuffer is past it's limit !");
            }
        }

        public float ReadFloat()
        {
            if (buffer.Count > readPosition)
            {
                if (bufferUpdate)
                {
                    readBuffer = buffer.ToArray();
                    bufferUpdate = false;
                }

                float ret = BitConverter.ToSingle(readBuffer, readPosition);
                readPosition += 4;

                return ret;
            }
            else
            {
                throw new Exception("ByteBuffer is past it's limit !");
            }
        }

        public string ReadString()
        {
            int len = ReadInteger();
            if (bufferUpdate)
            {
                readBuffer = buffer.ToArray();
                bufferUpdate = false;
            }

            string ret = Encoding.ASCII.GetString(readBuffer, readPosition, len);
            if (ret.Length > 0)
                readPosition += len;

            return ret;
        }

        #endregion
    }
}
