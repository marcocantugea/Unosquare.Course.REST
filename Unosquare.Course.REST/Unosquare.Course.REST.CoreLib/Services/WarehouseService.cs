using System;
using System.Collections.Generic;
using System.Text;
using Unosquare.Course.REST.CoreLib.Contracts;
using Unosquare.Course.REST.CoreLib.Repository;
using Unosquare.Course.REST.Models;

namespace Unosquare.Course.REST.CoreLib.Services
{
    public class WarehouseService : IWarehouseService
    {
        private WarehouseRepository repository = new WarehouseRepository();

        public List<WarehouseInfo> getListOfWarehouses(string alternativeFilePath = null)
        {
            return repository.getListOfWarehouses(alternativeFilePath);
        }

        public WarehouseInfo getWarehouseInfo(string codename, string alternativeFilePath = null)
        {
            return repository.getWarehouseInfo(codename, alternativeFilePath);
        }

        public void saveWarehousesInformation(List<WarehouseInfo> data)
        {
            repository.saveWarehousesInformation(data);
        }
    }
}
