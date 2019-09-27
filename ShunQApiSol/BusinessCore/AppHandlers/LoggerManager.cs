using BusinessCore.AppHandlers.Contracts;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BusinessCore.AppHandlers
{
    public class AzureLogService : ILoggerManager
    {
        string accountName;
        string storageKey;
        string tableName;
        public AzureLogService(string accountConStr)
        {
            var arr = (accountConStr ?? string.Empty).Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
             if (arr.Length>=3)
            {
                accountName = arr[0];
                storageKey = arr[1];
                tableName = arr[2];
            }
        }

        public async void EnsureTableExists()
        {
            var table = GetTable();
            await table.CreateIfNotExistsAsync();
        }

        private CloudTable GetTable()
        {
            //Account  
            CloudStorageAccount account = new CloudStorageAccount(
                new StorageCredentials(accountName, storageKey), true);

            //Client  
            CloudTableClient tableClient = account.CreateCloudTableClient();

            //Table  
            CloudTable table = tableClient.GetTableReference(tableName);
           // await table.CreateIfNotExistsAsync();

            return table;
        }

        private void log(string logLevel, string message)
        {
            //Table  
            var table = GetTable();

            //Operation  
            var operation = TableOperation.Insert(new LogEntity(logLevel, message));

            // Execute
            table.ExecuteAsync(operation);
        }

        public void LogError(string message)
        {
            log("ERROR", message);
        }

        public void LogInfo(string message)
        {
            log("INFO", message);
        }

        public void LogWarning(string message)
        {
            log("WARNING", message);
        }

        private class LogEntity : TableEntity
        {
            public LogEntity(string message)
            {
                var dt = DateTime.Now;
                this.PartitionKey = dt.ToString("MMMM-yyyy");
                this.RowKey = dt.Ticks.ToString();
                this.Message = message;
            }
            public LogEntity(string logLevel, string message):this(message)
            {
                this.LogLevel = logLevel;
            }
            public string Message { get; set; }
            public string LogLevel { get; set; }
        }
    }
   
    public class MyLocalLogService : ILoggerManager
    {
        string fileName;
         
        public MyLocalLogService(string fileName)
        {
            this.fileName = fileName;
            if (!File.Exists(fileName))
                File.Create(fileName);
        }

        public void LogError(string message)
        {
            File.AppendAllLinesAsync(fileName, new string[] { message });
        }

        public void LogInfo(string message)
        {
            LogError(message);
        }
        public void LogWarning(string message)
        {
            LogError(message);
        }
    }

}
