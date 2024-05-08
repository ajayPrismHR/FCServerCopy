
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCServer
{
    internal class Program
    {
        

        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                          .MinimumLevel.Debug()
                          .WriteTo.File("logs/FCServerSeriLog.txt", rollingInterval: RollingInterval.Day)
                          .CreateLogger();

            string sourceFileName = "DataBackup260120231143.bak";
            string destinationFileName = "DataBackup260120231143.bak";

            string sourceFilePath = ConfigurationManager.AppSettings["FileCopyS"] + sourceFileName;
           string destinationFilePath= ConfigurationManager.AppSettings["FileCopyD"] + destinationFileName;
            try
            {
              


                

                Log.Information("File Copy Start");
             
                File.Copy(sourceFilePath, destinationFilePath,true);
                Log.Information("File Copy End");

                Log.Information("File copied successfully.");
            }
            catch (IOException e)
            {
                Log.Error("An error occurred while copying the file:");
                Log.Error(e.Message);
            }
        }
    }
}

