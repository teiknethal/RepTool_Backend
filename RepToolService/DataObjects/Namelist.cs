using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RepToolService.DataObjects
{
    public class Namelist
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public Product Product { get; set; }
        public virtual List<Names> Names { get; set; }
    }
}