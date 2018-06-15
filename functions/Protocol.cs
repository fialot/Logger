using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using myFunctions;

namespace COMunicator.Protocol
{
    static class Protocol
    {

        public static string MarsA(uint address, byte[] data)
        {
            string res = "";
            //if (address.Length > 0)                     // check correct address
            {
                ushort frameType = (ushort)(49152 + data.Length + 6);
                if (data.Length > 1626) return "";      // check max. data length
                ushort packetType = (ushort)(2432);

                byte[] array = BitConverter.GetBytes(address);
                ushort[] addr = Conv.ToUShort(array);


                array = data; //Encoding.Default.GetBytes(data);
                Array.Reverse(array);
                ushort[] shortData = Conv.ToUShort(array);

                


                List<ushort> items = new List<ushort>();
                items.Add(frameType);
                items.Add(packetType);
                items.Add(addr[1]);
                items.Add(addr[0]);
                for (int i = shortData.Length - 1; i >= 0; i--)
                    items.Add(shortData[i]);

                ushort crc = 0;
                for (int i = 0; i < items.Count; i++) crc ^= items[i];
                items.Add(crc);

                res = "\\x";
                for (int i = 0; i < items.Count; i++) res += items[i].ToString("X4");
                //string hexData = data.ToCharArray()
                //ushort[] shortData = Conv.HexToUShorts(hexData);

               ;

            }
            

            return res;
        }
    }
}
