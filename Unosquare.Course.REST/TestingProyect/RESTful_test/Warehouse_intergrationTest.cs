using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Unosquare.Course.REST;
using Xunit;
using Xunit.Abstractions;
using Unosquare.Course.REST.Models;
using System.Net.Http.Headers;

namespace TestingProyect.RESTful_test
{
    public class Warehouse_intergrationTest
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly ITestOutputHelper _output;

        public Warehouse_intergrationTest(ITestOutputHelper output)
        {
            _output = output;
            _factory = new WebApplicationFactory<Startup>();
        }

        [Fact]
        public async void test_getWarehouses_JsonListWarehouses()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/warehouse");
            var json = await response.Content.ReadAsStringAsync();

            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEmpty(json);
            Assert.StartsWith("[", json);

            _output.WriteLine(json);
        }

        [Fact]
        public async void test_searchWarehouseByCode_getWarehouse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/warehouse/search?code=rwdc");
            var json = await response.Content.ReadAsStringAsync();

            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEmpty(json);
            Assert.StartsWith("[", json);

            _output.WriteLine(json);
        }

        [Fact]
        public async void test_addWarehouse_addnewWarehouse()
        {
            var client = _factory.CreateClient();
            WarehouseInfo newWarehouse = new WarehouseInfo()
            {
                warehouseCodeName = "YWC",
                warehouseLocation = "Merida, Yucatan",
                warehouseName = "Merida Warehouse Center"
            };


            HttpContent content = new StringContent(JsonSerializer.Serialize<WarehouseInfo>(newWarehouse));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responsePost = await client.PostAsync("api/warehouse/add",content);
            var responseList = await client.GetAsync("api/warehouse/search?code=ywc");
            var json = await responseList.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK,responsePost.StatusCode);
            Assert.NotNull(responseList);
            Assert.Equal(HttpStatusCode.OK, responseList.StatusCode);
            Assert.NotEmpty(json);
            Assert.Contains("YWC", json);
        }
    }
}
