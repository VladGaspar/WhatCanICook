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
    
    public partial class Recipe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Recipe()
        {
            this.Favorite_Recipes = new HashSet<Favorite_Recipes>();
            this.Ingredients_Recipes = new HashSet<Ingredients_Recipes>();
        }
    
        public string recipe_name { get; set; }
        public string recipe_description { get; set; }
        public string recipe_instructions { get; set; }
        public byte[] reciepe_image { get; set; }
        public string recipe_author { get; set; }
        public Nullable<bool> approved { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Favorite_Recipes> Favorite_Recipes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ingredients_Recipes> Ingredients_Recipes { get; set; }
    }
}
