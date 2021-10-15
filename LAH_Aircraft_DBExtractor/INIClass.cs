using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LAH_Aircraft_DBExtractor
{
    class INIClass
    {
        string Path;
        public INIClass(string _path)
        {
            Path = _path;
        }

        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public string GetINIValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, Path);
            return temp.ToString();
        }
    }
}
