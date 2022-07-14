﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20190814_Class_General
{
    class csCRC
    {
        #region  CRC16
        public static byte[] CRC16(byte[] data)
        {
            int len = data.Length;
            if (len > 0)
            {
                //  Prepare a 2 bytes memory and set all bits to 1
                //  let's cal it crc, so the rsult will be 0xFFFF.
                ushort crc = 0xFFFF;

                //Do crc calculation for each byte
                for (int i = 0; i < len; i++)
                {
                    //Use the lower byte of that crc to do xor with one byte of data which need to be checked.
                    // 0^1=1, 0^0=0, so upper 8 bits won't change, only lower 8 bits changed
                    crc = (ushort)(crc ^ (data[i]));

                    //Shift to right for one bit and check each moved out bit for 8 times
                    for (int j = 0; j < 8; j++)
                    {

                        // Check the last bit first
                        // if =0, just shift the code and do nothing
                        // if =1, do xor with shifted CRC
                        // 0xA001 and 0x8005 can be used, you will get "0xABCD" or "0xCDAB" while use different value
                        // Some standard use 0x8005 some use 0xA001 in different standard.
                        crc = (crc & 1) != 0 ? (ushort)((crc >> 1) ^ 0xA001) : (ushort)(crc >> 1);
                    }
                }

                //crc & 0xFF00: clear lower byte to 0, shift lower byte out, so only higher byte remained
                byte hi = (byte)((crc & 0xFF00) >> 8);  //High Byte
                //crc & 0x00FF: clear higher byte to 0
                byte lo = (byte)(crc & 0x00FF);         //Low Byte

                return new byte[] { hi, lo };
            }
            return new byte[] { 0, 0 };
        }
        #endregion

        #region  ToCRC16
        public static string ToCRC16(string content)
        {
            return ToCRC16(content, Encoding.UTF8);
        }

        public static string ToCRC16(string content, bool isReverse)
        {
            return ToCRC16(content, Encoding.UTF8, isReverse);
        }

        public static string ToCRC16(string content, Encoding encoding)
        {
            return ByteToString(CRC16(encoding.GetBytes(content)), true);
        }

        public static string ToCRC16(string content, Encoding encoding, bool isReverse)
        {
            return ByteToString(CRC16(encoding.GetBytes(content)), isReverse);
        }

        public static string ToCRC16(byte[] data)
        {
            return ByteToString(CRC16(data), true);
        }

        public static string ToCRC16(byte[] data, bool isReverse)
        {
            return ByteToString(CRC16(data), isReverse);
        }
        #endregion

        #region  ToModbusCRC16
        public static string ToModbusCRC16(string s)
        {
            return ToModbusCRC16(s, true);
        }

        public static string ToModbusCRC16(string s, bool isReverse)
        {
            return ByteToString(CRC16(StringToHexByte(s)), isReverse);
        }

        public static string ToModbusCRC16(byte[] data)
        {
            return ToModbusCRC16(data, true);
        }

        public static string ToModbusCRC16(byte[] data, bool isReverse)
        {
            return ByteToString(CRC16(data), isReverse);
        }
        #endregion

        #region  ByteToString
        public static string ByteToString(byte[] arr, bool isReverse)
        {
            try
            {
                byte hi = arr[0], lo = arr[1];
                return Convert.ToString(isReverse ? hi + lo * 0x100 : hi * 0x100 + lo, 16).ToUpper().PadLeft(4, '0');
            }
            catch (Exception ex) { throw (ex); }
        }

        public static string ByteToString(byte[] arr)
        {
            try
            {
                return ByteToString(arr, true);
            }
            catch (Exception ex) { throw (ex); }
        }
        #endregion

        #region  StringToHexString
        public static string StringToHexString(string str)
        {
            StringBuilder s = new StringBuilder();
            foreach (short c in str.ToCharArray())
            {
                s.Append(c.ToString("X4"));
            }
            return s.ToString();
        }
        #endregion

        #region  StringToHexByte
        private static string ConvertChinese(string str)
        {
            StringBuilder s = new StringBuilder();
            foreach (short c in str.ToCharArray())
            {
                if (c <= 0 || c >= 127)
                {
                    s.Append(c.ToString("X4"));
                }
                else
                {
                    s.Append((char)c);
                }
            }
            return s.ToString();
        }

        private static string FilterChinese(string str)
        {
            StringBuilder s = new StringBuilder();
            foreach (short c in str.ToCharArray())
            {
                //Only ASCII value been added
                if (c > 0 && c < 127)
                {
                    s.Append((char)c);
                }
            }
            return s.ToString();
        }

        public static byte[] StringToHexByte(string str)
        {
            return StringToHexByte(str, false);
        }


        /// </summary>
        /// <param name="str"></param>
        /// <param name="isFilterChinese">Filter Chinese character or not</param>
        /// <returns></returns>
        public static byte[] StringToHexByte(string str, bool isFilterChinese)
        {
            string hex = isFilterChinese ? FilterChinese(str) : ConvertChinese(str);
            //Clear space
            hex = hex.Replace(" ", "");
            //make sure length is even number, if not add 0 to last, when data received
            hex += hex.Length % 2 != 0 ? "-" : ""; //Add a "-" to bottom make it even
            byte[] result = new byte[hex.Length / 2];
            for (int i = 0; i < result.Length; i++)
            {
                //Convert it to byte, if a "-" added to bottom, remove it.
                result[i] = Convert.ToByte(hex.Substring(i * 2, 2).Replace("-", ""), 16);
            }
            return result;
        }
        #endregion

    }
}