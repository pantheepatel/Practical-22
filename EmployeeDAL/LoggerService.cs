using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL
{
    public interface ILoggerService
    {
        void Log(string message);
    }

    public class FileLoggerService : ILoggerService
    {
        private readonly string logFile = "log.txt";

        public FileLoggerService()
        {
            if (!File.Exists(logFile))
                File.Create(logFile).Close();
        }

        public void Log(string message)
        {
            File.AppendAllText(logFile, $"{DateTime.Now}: {message}{Environment.NewLine}");
        }
    }
}
