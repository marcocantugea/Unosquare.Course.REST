using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Unosquare.Course.REST.CoreLib.Models;

namespace Unosquare.Course.REST.CoreLib.DataAccess
{
    public class JsonDataAccess
    {

        private string fileName = "dataWarehouses.json";
        private string filePath = "./";

        public string FileName { get => fileName; set => fileName = value; }
        public string FilePath { get => filePath; set => filePath = value; }

        public List<WarehouseInfo> GetWarehousesData()
        {
             return JsonSerializer.Deserialize<List<WarehouseInfo>>(getFileContent());
        }

        public string getDataFile()
        {
            return FilePath + fileName;
        }

        private string getFileContent()
        {
            return System.IO.File.ReadAllText(getDataFile());
        }
    }
}
