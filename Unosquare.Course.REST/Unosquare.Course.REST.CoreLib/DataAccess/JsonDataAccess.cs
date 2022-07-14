using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Unosquare.Course.REST.Models.Interfaces;
using Unosquare.Course.REST.Models;

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

        public void saveJsonData(IEnumerable<IModel> dataToSave)
        {
            string jsonString = System.Text.Json.JsonSerializer.Serialize<IEnumerable<IModel>>(dataToSave);
            saveFileInfo(jsonString);
        }

        public void saveJsonWarehouseData(List<WarehouseInfo> datatoSave)
        {

            string jsonString = System.Text.Json.JsonSerializer.Serialize<List<WarehouseInfo>>(datatoSave, new JsonSerializerOptions { WriteIndented = true });
            saveFileInfo(jsonString);
        }

        private string getFileContent()
        {
            return System.IO.File.ReadAllText(getDataFile());
        }

        private void saveFileInfo(string content)
        {
            System.IO.File.WriteAllText(getDataFile(), content);
        }
    }
}
