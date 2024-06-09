using IniParser.Model;
using IniParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingWeatherWpf.ViewModel
{
    public static class SecretHelper
    {
        private static string iniPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Secrets.ini");

        private static FileIniDataParser iniParser = new FileIniDataParser();

        public static string ReadIniValue(string section, string key)
        {
            IniData data = iniParser.ReadFile(iniPath);
            return data[section][key];
        }
    }
}
