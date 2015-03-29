﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageFeatures.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        
        private string name;
        public string Name
        {
            get { return ProductID + name; }
            set { name = value; } 
        }

        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}