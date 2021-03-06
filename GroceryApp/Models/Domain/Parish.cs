﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GroceryApp.Models.Domain
{
    /**domain Object that represents a parish**/
    public class Parish
    {
        public int ParishID { get; set; }//parish ID

        [Required]
        [Display(Name = "Parish Name")]
        public string name { get; set; }//parish name

        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}