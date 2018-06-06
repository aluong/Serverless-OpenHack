using System;

namespace BFYOC
{
    public class Order
    {
        public Guid id { get; set; }
        public Guid productid { get; set; }
        public string productname { get; set; }
        public string productdescription { get; set; }
        public string ponumber { get; set; }
        public int quantity { get; set; }
        public double unitcost { get; set; }
        public double totalcost { get; set; }
        public double totaltax { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid LocationId { get; set; }
        public string locationname { get; set; }
        public string locationaddress { get; set; } 
        public string locationpostcode { get; set; }


    }
}