using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RepToolService.DataObjects
{
    public class ActionCode
    {
        [Key]
        public byte ID { get; set; }
        public string Description { get; set; }
    }
}