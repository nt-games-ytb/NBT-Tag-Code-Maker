namespace MamiesModGecko
{
    using System;

    public enum AddressType
    {
        Rw,
        Ro,
        Ex,
        Unknown
    }

    public class AddressRange
    {
        public AddressType Description { get; private set; }

        private byte Id { get; set; }

        public uint Low { get; private set; }

        public uint High { get; private set; }

        private AddressRange(AddressType desc, byte id, uint low, uint high)
        {
            this.Id = id;
            this.Description = desc;
            this.Low = low;
            this.High = high;
        }

        public AddressRange(AddressType desc, uint low, uint high)
            : this(desc, (Byte)(low >> 24), low, high)
        {
            
        }
    }

    public static class ValidMemory
    {
        private const bool AddressDebug = false;

        public static readonly AddressRange[] ValidAreas =
        {
            new AddressRange(AddressType.Ex, 0x01000000, 0x01800000),
            new AddressRange(AddressType.Ex, 0x0e300000, 0x10000000),
            new AddressRange(AddressType.Rw, 0x10000000, 0x50000000),
            new AddressRange(AddressType.Ro, 0xe0000000, 0xe4000000),
            new AddressRange(AddressType.Ro, 0xe8000000, 0xea000000),
            new AddressRange(AddressType.Ro, 0xf4000000, 0xf6000000),
            new AddressRange(AddressType.Ro, 0xf6000000, 0xf6800000),
            new AddressRange(AddressType.Ro, 0xf8000000, 0xfb000000),
            new AddressRange(AddressType.Ro, 0xfb000000, 0xfb800000),
            new AddressRange(AddressType.Rw, 0xfffe0000, 0xffffffff)
        };

        public static AddressType RangeCheck(uint address)
        {
            var id = RangeCheckId(address);
            return id == -1 ? AddressType.Unknown : ValidAreas[id].Description;
        }

        public static int RangeCheckId(uint address)
        {
            for (var i = 0; i < ValidAreas.Length; i++)
            {
                var range = ValidAreas[i];
                if (address >= range.Low && address < range.High)
                {
                    return i;
                }
            }

            return -1;
        }

        private static bool ValidAddress(uint address, bool debug)
        {
            if (debug)
            {
                return true;
            }

            return RangeCheckId(address) >= 0;
        }

        public static bool ValidAddress(uint address)
        {
            return ValidAddress(address, AddressDebug);
        }

        private static bool ValidRange(uint low, uint high, bool debug)
        {
            if (debug)
            {
                return true;
            }

            return RangeCheckId(low) == RangeCheckId(high - 1);
        }

        public static bool ValidRange(uint low, uint high)
        {
            return ValidRange(low, high, AddressDebug);
        }

        public static void SetDataUpper(TCPGecko upper)
        {
            uint mem;
            switch (upper.OsVersionRequest())
            {
                case 400:
                case 410:
                    mem = upper.peek_kern(0xffe8619c);
                    break;
                case 500:
                case 510:
                    return;
                // TODO: This doesn't work for some reason - crashes on connection?
                //mem = upper.peek_kern(0xffe8591c);
                //break;
                default:
                    return;
            }

            var tbl = upper.peek_kern(mem + 4);
            var lst = upper.peek_kern(tbl + 20);

            var initStart = upper.peek_kern(lst + 0 + 0x00);
            var initLen = upper.peek_kern(lst + 4 + 0x00);
            var codeStart = upper.peek_kern(lst + 0 + 0x10);
            var codeLen = upper.peek_kern(lst + 4 + 0x10);
            var dataStart = upper.peek_kern(lst + 0 + 0x20);
            var dataLen = upper.peek_kern(lst + 4 + 0x20);

            ValidAreas[0] = new AddressRange(AddressType.Ex, initStart, initStart + initLen);
            ValidAreas[1] = new AddressRange(AddressType.Ex, codeStart, codeStart + codeLen);
            ValidAreas[2] = new AddressRange(AddressType.Rw, dataStart, dataStart + dataLen);
        }
    }
}