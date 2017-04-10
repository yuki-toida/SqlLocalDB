using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SqlLocalDB.UI
{
    public class Processor
    {
        private readonly Settings _settings;
        private readonly ProcessStartInfo _info;

        public Processor(Settings settings)
        {
            _settings = settings;

            _info = new ProcessStartInfo()
            {
                FileName = settings.ExeFileName,
                WorkingDirectory = settings.ExeWorkingDirectory,
            };
        }

        public void Stop()
        {
            _info.Arguments = $"stop {_settings.InstanceName}";
            StartAndWaitForExit();
        }

        public void Delete()
        {
            _info.Arguments = $"delete {_settings.InstanceName}";
            StartAndWaitForExit();
        }

        public void Create()
        {
            _info.Arguments = $"create {_settings.InstanceName}";
            StartAndWaitForExit();
        }

        public void Info()
        {
            _info.Arguments = "info";
            StartAndWaitForExit();
        }

        /// <summary>
        /// Process start synchronous
        /// </summary>
        private void StartAndWaitForExit()
        {
            using (var process = Process.Start(_info))
            {
                process.WaitForExit();
            }
        }
    }
}
