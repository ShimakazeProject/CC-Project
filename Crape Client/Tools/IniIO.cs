using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Crape_Client.Tools
{
    class IniIO
    {
        static object IOLock = new object();
        [DllImport("kernel32", CharSet = CharSet.Unicode)] private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32", CharSet = CharSet.Unicode)] private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        static void Writevalue(string Section, string Key, string value) => WritePrivateProfileString(Section, Key, value, AppDomain.CurrentDomain.BaseDirectory + "ra2md.ini");
        public static void Writevalue(string Section, string Key, string value, string Path) => WritePrivateProfileString(Section, Key, value, Path);

        static string Readvalue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(500);
            try
            {
                int i = GetPrivateProfileString(Section, Key, "", temp, 500, AppDomain.CurrentDomain.BaseDirectory + "ra2md.ini");
                return temp.ToString();
            }
            catch (FormatException) { return ""; }
        }

        public static string Readvalue(string Section, string Key, string Path)
        {
            StringBuilder temp = new StringBuilder(500);
            try
            {
                int i = GetPrivateProfileString(Section, Key, "", temp, 500, Path);
                return temp.ToString();
            }
            catch (FormatException) { return ""; }
        }
        #region
        public static void I(string Section, string Key, bool value)
        {
            if (value)
                Writevalue(Section, Key, "1");
            else Writevalue(Section, Key, "0");
        }
        public static void I(string Section, string Key, Int64 value)
        {
            Writevalue(Section, Key, value.ToString());
        }
        public static void I(string Section, string Key, double value)
        {
            Writevalue(Section, Key, value.ToString());
        }
        public static void I(string Section, string Key, string value)
        {
            Writevalue(Section, Key, value);
        }
        public static bool Obool(string Section, string Key)
        {
            lock (IOLock)
            {
            string value = Readvalue(Section, Key);
            if (
                value.StartsWith("t", StringComparison.OrdinalIgnoreCase) ||
                value.StartsWith("y", StringComparison.OrdinalIgnoreCase) ||
                value.StartsWith("1", StringComparison.OrdinalIgnoreCase))
                return true;
            else if (
                value.StartsWith("f", StringComparison.OrdinalIgnoreCase) ||
                value.StartsWith("n", StringComparison.OrdinalIgnoreCase) ||
                value.StartsWith("0", StringComparison.OrdinalIgnoreCase))
                return false;
            return false;
            }
        }
        public static int Oint(string Section, string Key)
        {
            lock (IOLock)
            {
                try
                {
                    return Convert.ToInt32(Readvalue(Section, Key));
                }
                catch (FormatException) { return -1; }
            }
        }
        public static double Odouble(string Section, string Key)
        {
            lock (IOLock)
            {
                try
                {
                    return Convert.ToDouble(Readvalue(Section, Key));
                }
                catch (FormatException) { return -1; }
            }
        }
        public static string Ostring(string Section, string Key)
        {
            lock (IOLock)
            {
                try
                {
                    return Readvalue(Section, Key);
                }
                catch (FormatException) { return string.Empty; }
            }
        }
        #endregion

    }
}
