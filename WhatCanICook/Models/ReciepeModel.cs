using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatCanICook.Models
{
    public class ReciepeModel
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public string Author { get; set; }
        public byte[] Image { get; set; }
        public string ImageUrl { get; set; }

        public string Ingredient1 { get; set; }
        public string Ingredient2 { get; set; }
        public string Ingredient3 { get; set; }
        public string Ingredient4 { get; set; }
        public string Ingredient5 { get; set; }

    }
}