using System;
using System.Collections.Generic;
using System.Text;
using Unosquare.Course.REST.CoreLib.DataAccess;
using Unosquare.Course.REST.Models;

namespace Unosquare.Course.REST.CoreLib.Repository
{
    public class WarehouseRepository
    {
        public List<WarehouseInfo> getListOfWarehouses(string alternativeFilePath=null)
        {
            JsonDataAccess jsonData = new JsonDataAccess();
            if(alternativeFilePath != null) jsonData.FilePath = alternativeFilePath;
            return jsonData.GetWarehousesData();
        }

        public WarehouseInfo getWarehouseInfo(string codename, string alternativeFilePath = null)
        {
            List<WarehouseInfo> data = getListOfWarehouses();
            WarehouseInfo warehouse= data.Find(item => item.warehouseCodeName == codename);

            return warehouse;
        }

        public void saveWarehousesInformation(List<WarehouseInfo> data)
        {
            JsonDataAccess jsonData = new JsonDataAccess();
            jsonData.saveJsonWarehouseData(data);

        }
    }
}
