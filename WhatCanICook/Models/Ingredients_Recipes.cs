//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WhatCanICook.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ingredients_Recipes
    {
        public int ingredient_recipe_id { get; set; }
        public int recipe_id { get; set; }
        public int ingredient_id { get; set; }
    
        public virtual Ingredient Ingredient { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
