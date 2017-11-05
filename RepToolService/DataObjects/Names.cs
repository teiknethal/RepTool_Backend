using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RepToolService.DataObjects
{
    public class Names
    {
        // Primary Key
        [Key, Column(Order=0)]
        public string Name { get; set; }

        [Key, Column(Order=1), ForeignKey("Namelist")]
        public int Namelist_ID { get; set; }

        [Key, Column(Order = 2), ForeignKey("Product")]
        public int Product_ID { get; set; }


        public virtual Namelist Namelist { get; set; }
        public virtual Product Product { get; set; }
    }
}