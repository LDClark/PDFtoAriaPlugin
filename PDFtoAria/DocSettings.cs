using System;
using System.Text.RegularExpressions;

namespace PDFtoAria
{
    public class DocSettings
    {
        public String HostName { get; private set; } 
        public String Port { get; private set; } 
        public String DocKey { get; private set; } 
        public String ImportDir { get; private set; } 

        public bool ReadSettings(String settingLine)
        {
            Match m = Regex.Match(settingLine, @"HostName:\s*(.*?)\s*,");
            if (m.Success) { HostName = m.Groups[1].Value; }
            else return false;
            m = Regex.Match(settingLine, @"Port:\s*(.*?)\s*,");
            if (m.Success) { Port = m.Groups[1].Value; }
            else return false;
            m = Regex.Match(settingLine, @"DocKey:\s*(.*?)\s*,");
            if (m.Success) { DocKey = m.Groups[1].Value; }
            else return false;
            m = Regex.Match(settingLine, @"ImportDir:\s*(.*?)\s*,");
            if (m.Success) { ImportDir = m.Groups[1].Value; }
            else return false;
            // Everything is read successfully
            return true;
        }
    }
}
