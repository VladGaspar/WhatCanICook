using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatCanICook.Models
{
    public class IngredientsListModel
    {
        public string Ingredient1 { get; set; }
        public string Ingredient2 { get; set; }
        public string Ingredient3 { get; set; }
        public string Ingredient4 { get; set; }
        public string Ingredient5 { get; set; }
         /*public string Ingredient6 { get; set; }
          public string Ingredient7 { get; set; }
          public string Ingredient8 { get; set; }
          public string Ingredient9 { get; set; }
          public string Ingredient10 { get; set; }*/

        public List<string> recipeList { get; set; }
    }
}