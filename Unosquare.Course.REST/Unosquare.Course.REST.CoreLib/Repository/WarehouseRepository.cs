using System;
using System.Collections.Generic;
using System.Text;
using Unosquare.Course.REST.CoreLib.DataAccess;
using Unosquare.Course.REST.CoreLib.Models;

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
    }
}
