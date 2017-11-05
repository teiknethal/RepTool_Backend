using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RepToolService.DataObjects
{
    public class Rep
    {
        [Key]
        public int ID { get; set; }

        // Do we need some ID in here to validate against the AD b2c authentication???
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsManager { get; set; }
        public virtual List<Action> Actions { get; set; }
        public virtual List<Customer> Customers { get; set; }
    }
}