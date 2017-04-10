using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace SqlLocalDB.UI
{
    public class Program
    {
        private static readonly Settings Settings;

        static Program()
        {
            // Apply Shift-JIS
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // Configuration
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            // AppSettings
            Settings = new Settings(
                configuration["LocalDBInstanceName"]
                , configuration["LocalDBInstanceVersion"]
                , configuration["LocalDBExeFileName"]
                , configuration["LocalDBExeWorkingDirectory"]
                );
        }

        static void Main(string[] args)
        {
            // LocalDB操作
            var processor = new Processor(Settings);

            // Stop
            processor.Stop();

            // Delete
            processor.Delete();

            // Create
            processor.Create();
            
            // Info
            processor.Info();

            Console.ReadKey();
        }
    }
}