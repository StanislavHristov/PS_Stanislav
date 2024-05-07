using DataLayer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Model;

namespace DataLayer.Loggers
{
    public class LoggerToDB
    {
        private readonly DatabaseContext _context;

        public LoggerToDB(DatabaseContext context)
        {
            _context = context;
        }

        public void LogMessage(string message)
        {
            var logEntry = new LogEntry { Message = message };
            _context.LogEntries.Add(logEntry);
            _context.SaveChanges();
        }
    }
}
