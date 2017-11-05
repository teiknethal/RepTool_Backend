using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RepToolService.DataObjects
{
    public class Action
    {
        [Key]
        public int ID { get; set; }
        public ActionCode Code { get; set; }
        public DateTime Date { get; set; }
    }
}