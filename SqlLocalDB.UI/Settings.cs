using System;
using System.Collections.Generic;
using System.Text;

namespace SqlLocalDB.UI
{
    /// <summary>
    /// SqlLocalDB.exe locate C:\Program Files\Microsoft SQL Server\130\Tools
    /// </summary>
    public class Settings
    {
        public Settings(string instanceName, string instanceVersion, string exeFileName, string exeWorkingDirectory)
        {
            InstanceName = instanceName;
            InstanceVersion = instanceVersion;
            ExeFileName = exeFileName;
            ExeWorkingDirectory = exeWorkingDirectory;
        }

        public string InstanceName { get; }
        public string InstanceVersion { get; }
        public string ExeFileName { get; }
        public string ExeWorkingDirectory { get; }
    }
}
