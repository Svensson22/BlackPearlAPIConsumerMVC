using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbContextLib
{
    public sealed class DBConnection
    {
        private static DBConnection _instance = null;
        private static readonly object instanceLock = new();
        private static IConfigurationRoot _configuration;

        public static string DbConnectionsDirectory
        {
            get
            {
                //LocalApplicationData is a good place to store configuration files.
                //Copy appsettings.json to the folder in documentPath
                var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                documentPath = Path.Combine(documentPath, "AOOP2", "EFC", "DbConnections");
                if (!Directory.Exists(documentPath)) Directory.CreateDirectory(documentPath);
                return documentPath;
            }
        }

        private DBConnection()
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(DbConnectionsDirectory)
                                .AddJsonFile("DbConnections.json", optional: true, reloadOnChange: true);

            _configuration = builder.Build();
        }

        public static IConfigurationRoot ConfigurationRoot
        {
            get
            {
                lock (instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new DBConnection();
                    }
                    return _configuration;
                }
            }
        }
    }
}
