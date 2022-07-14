using System;
using System.Collections.Generic;
using System.Text;
using Unosquare.Course.REST.CoreLib.Interfaces;
using Unosquare.Course.REST.Models;

namespace Unosquare.Course.REST.CoreLib.Contracts
{
    public interface IWarehouseService : IService
    {
        List<WarehouseInfo> getListOfWarehouses(string alternativeFilePath = null);
        WarehouseInfo getWarehouseInfo(string codename, string alternativeFilePath = null);
        void saveWarehousesInformation(List<WarehouseInfo> data, string alternativeFilePath = "./");
    }
}
