using System;

namespace AgonylDropEditor
{
    public class BinaryDataBuilder
    {
        private const int DefaultSize = 4;

        private byte[] _buffer;
        private int _ptr;

        public BinaryDataBuilder()
        {
            this._buffer = new byte[DefaultSize];
            this._ptr = 0;
        }

        private void EnsureSpace(int needed)
        {
            if (this._ptr + needed > this._buffer.Length)
            {
                Array.Resize(ref this._buffer, this._buffer.Length + needed);
            }
        }

        public void PutBytes(byte[] val)
        {
            for (var i = 0; i < val.Length; i++)
            {
                this.PutByte(val[i]);
            }
        }

        public void PutByte(byte val)
        {
            this.EnsureSpace(1);
            this._buffer[this._ptr++] = val;
        }

        public byte[] GetBuffer()
        {
            return this._buffer;
        }
    }
}
