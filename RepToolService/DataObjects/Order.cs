using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RepToolService.DataObjects
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public Product Product { get; set; }
        public Rep Rep { get; set; }
        public Customer Customer { get; set; }
        public string PO { get; set; }
        public DateTime PlacedOn { get; set; }
        public DateTime? FullfulBy { get; set; }
        public DateTime? CompletedOn { get; set; }
        public DateTime? ShippedOn { get; set; }
        public OrderStatus Status { get; set; }
        public virtual List<OrderLine> OrderLines { get; set; }
    }
}