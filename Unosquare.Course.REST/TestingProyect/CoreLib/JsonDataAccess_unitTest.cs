using System;
using System.Collections.Generic;
using System.Text;
using Unosquare.Course.REST.CoreLib.DataAccess;
using Unosquare.Course.REST.Models;
using Xunit;

namespace TestingProyect.CoreLib
{
    public class JsonDataAccess_unitTest
    {
        [Fact]
        public void test_JsonDataAccessUnitTest_loadJsonFile()
        {
            JsonDataAccess jsonDataAcces = new JsonDataAccess();
            jsonDataAcces.FilePath = "../../../";
            List<WarehouseInfo> data= jsonDataAcces.GetWarehousesData();

            Assert.NotEmpty(data);
        }

        [Fact]
        public void test_JsonDataAccessUnittest_saveContent()
        {
            JsonDataAccess jsonDataAcces = new JsonDataAccess();
            jsonDataAcces.FilePath = "../../../";
            List<WarehouseInfo> data = jsonDataAcces.GetWarehousesData();

            WarehouseInfo warehouseInfo = new WarehouseInfo() { 
                warehouseCodeName="TWI",
                warehouseLocation="informacion de warehouse de prueba",
                warehouseName="Test warehouse information"
            };

            data.Add(warehouseInfo);

            //guardamos la informacion
            jsonDataAcces.saveJsonWarehouseData(data);

            //volvemos a obtener la informacion para revisar si lo guardo el item
            // que agregamos
            List<WarehouseInfo> dataUpdated = jsonDataAcces.GetWarehousesData();

            WarehouseInfo itemfound= dataUpdated.Find(item => item.warehouseCodeName == "TWI");

            Assert.NotNull(itemfound);

            //jsonDataAcces.
        }
    }
}
