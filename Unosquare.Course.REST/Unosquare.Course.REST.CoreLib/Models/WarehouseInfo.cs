using System;
using System.Collections.Generic;
using System.Text;
using Unosquare.Course.REST.CoreLib.Interfaces;

namespace Unosquare.Course.REST.CoreLib.Models
{
    public class WarehouseInfo : Interfaces.IModel 
    {
        public string warehouseName { get; set; }  
        public string warehouseCodeName { get; set; }  
        public string warehouseLocation { get; set; }  
    }
}
