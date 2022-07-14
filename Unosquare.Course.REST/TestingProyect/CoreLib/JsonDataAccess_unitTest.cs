using System;
using System.Collections.Generic;
using System.Text;
using Unosquare.Course.REST.CoreLib.DataAccess;
using Unosquare.Course.REST.CoreLib.Models;
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
    }
}
