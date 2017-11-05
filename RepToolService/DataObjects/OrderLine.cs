using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RepToolService.DataObjects
{
    public class OrderLine
    {
        [Key, Column(Order=0), ForeignKey("Order")]
        public int Order_ID { get; set; }
        [Key, Column(Order=1)]
        public string Name { get; set; }


        public int Qty { get; set; }


        public virtual Order Order { get; set; }
    }
}