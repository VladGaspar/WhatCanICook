using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WhatCanICook.Models;
using System.IO;

namespace WhatCanICook.Controllers
{
   
    public class HomeController : Controller
    {
        WhatCanICookDBEntities entity = new WhatCanICookDBEntities();

        public static IngredientsListModel ingredientsListModel = new IngredientsListModel();

        public static List<ReciepeModel> reciepeModels = new List<ReciepeModel>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Account()
        {

            return View();
        }
 
        public ActionResult Recipe()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Edit()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

     
        [HttpPost]
        public ActionResult Edit(UserViewModel user)
        {
            var userTemp = entity.Users.FirstOrDefault(u => u.user_email == user.Email);
            if (userTemp != null)
            {
                userTemp.user_email = user.Email;
                userTemp.user_firstName = user.FirstName;
                userTemp.user_lastName = user.LastName;
                userTemp.user_password = user.Password;
                userTemp.user_foodType = user.FoodPreferance;
                entity.SaveChanges();

                WebApplication1.Controllers.AccountController.userModel.Email = user.Email;
                WebApplication1.Controllers.AccountController.userModel.FirstName = user.FirstName;
                WebApplication1.Controllers.AccountController.userModel.LastName = user.LastName;
                WebApplication1.Controllers.AccountController.userModel.Password = user.Password;
                WebApplication1.Controllers.AccountController.userModel.FoodPreferance = user.FoodPreferance;
                // It will redirect to
                // the Read method
                return RedirectToAction("Account");
            }
            else
                return View();
        }

        [HttpPost]
        public ActionResult Index(IngredientsListModel listModel) {

            List<string> list = new List<string>();

            bool ingredient1Exist = entity.Ingredients.Any(i => i.ingredient_name == listModel.Ingredient1);
            bool ingredient2Exist = entity.Ingredients.Any(i => i.ingredient_name == listModel.Ingredient2);
            bool ingredient3Exist = entity.Ingredients.Any(i => i.ingredient_name == listModel.Ingredient3);
            bool ingredient4Exist = entity.Ingredients.Any(i => i.ingredient_name == listModel.Ingredient4);
            bool ingredient5Exist = entity.Ingredients.Any(i => i.ingredient_name == listModel.Ingredient5);

            if (listModel.Ingredient1 != "Empty")
                list.Add(listModel.Ingredient1.ToString());
            else
                ingredient1Exist = true;

            if (listModel.Ingredient2 != "Empty")
                list.Add(listModel.Ingredient2.ToString());
            else
                ingredient2Exist = true;

            if (listModel.Ingredient3 != "Empty")
                list.Add(listModel.Ingredient3.ToString());
            else
                ingredient3Exist = true;

            if (listModel.Ingredient4 != "Empty")
                list.Add(listModel.Ingredient4.ToString());
            else
                ingredient4Exist = true;

            if (listModel.Ingredient5 != "Empty")
                list.Add(listModel.Ingredient5.ToString());
            else
                ingredient5Exist = true;

            List<bool> existentialList = new List<bool>
            {
                ingredient1Exist, ingredient2Exist, ingredient3Exist, ingredient4Exist, ingredient5Exist
            };

           string message = "";
           for(int i = 0; i<existentialList.Count; i++)
            {
                if (existentialList[i] ==  false)
                message += i+1 + ", ";
            }
           

           if (ingredient1Exist && ingredient2Exist && ingredient3Exist && ingredient4Exist && ingredient5Exist ) {
               
                var ing = entity.Ingredients_Recipes
                    .Where(l => list.Contains(l.ingredient_name))
                    .GroupBy(l => l.recipe_name)
                    .Where(g => g.Select(l => l.ingredient_name).Distinct().Count() == list.Count)
                    .Select(g => g.Key)
                    .ToList();

                ingredientsListModel.recipeList = ing;

              var retete = entity.Recipes.Where(l => ing.Contains(l.recipe_name)).ToList();

                List<ReciepeModel> reciepeModelsTemp = new List<ReciepeModel>();

                foreach(Recipe r in retete)
                {
                    ReciepeModel x = new ReciepeModel();
                    x.Name = r.recipe_name;
                    x.Description = r.recipe_description;
                    x.Instructions = r.recipe_instructions;
                    x.Author = r.recipe_author;
                    x.Image = System.IO.File.ReadAllBytes("C:\\Users\\Vlad\\Desktop\\Facultate\\II\\Proiect\\WhatCanICook\\WhatCanICook\\WhatCanICook\\Images\\" + r.recipe_name + ".jpg");
                    x.ImageUrl = Convert.ToBase64String(x.Image);
                    reciepeModelsTemp.Add(x);
                }

                reciepeModels = reciepeModelsTemp;
            }
            else
            {
                message.Remove(message.Length - 2);
                ModelState.AddModelError("", "We are sorry but the ingredients " + message + " dosen't exist in our DataBase");
                return View();
            }
          
            return View();
        }

        [HttpPost]
        public ActionResult Recipe(ReciepeModel reciepeModel)
        {
            List<string> list = new List<string>();



            bool ingredient1Exist = entity.Ingredients.Any(i => i.ingredient_name == reciepeModel.Ingredient1);
            bool ingredient2Exist = entity.Ingredients.Any(i => i.ingredient_name == reciepeModel.Ingredient2);
            bool ingredient3Exist = entity.Ingredients.Any(i => i.ingredient_name == reciepeModel.Ingredient3);
            bool ingredient4Exist = entity.Ingredients.Any(i => i.ingredient_name == reciepeModel.Ingredient4);
            bool ingredient5Exist = entity.Ingredients.Any(i => i.ingredient_name == reciepeModel.Ingredient5);

            if (reciepeModel.Ingredient1 != "Empty")
                list.Add(reciepeModel.Ingredient1.ToString());
            else
                ingredient1Exist = true;

            if (reciepeModel.Ingredient2 != "Empty")
                list.Add(reciepeModel.Ingredient2.ToString());
            else
                ingredient2Exist = true;

            if (reciepeModel.Ingredient3 != "Empty")
                list.Add(reciepeModel.Ingredient3.ToString());
            else
                ingredient3Exist = true;

            if (reciepeModel.Ingredient4 != "Empty")
                list.Add(reciepeModel.Ingredient4.ToString());
            else
                ingredient4Exist = true;

            if (reciepeModel.Ingredient5 != "Empty")
                list.Add(reciepeModel.Ingredient5.ToString());
            else
                ingredient5Exist = true;

            List<bool> existentialList = new List<bool>
            {
                ingredient1Exist, ingredient2Exist, ingredient3Exist, ingredient4Exist, ingredient5Exist
            };

            string message = "";
            for (int i = 0; i < existentialList.Count; i++)
            {
                if (existentialList[i] == false)
                    message += i + 1 + ", ";
            }

            bool recipeNameExist = entity.Recipes.Any(r => r.recipe_name == reciepeModel.Name);

           

            if (ingredient1Exist && ingredient2Exist && ingredient3Exist && ingredient4Exist && ingredient5Exist && !recipeNameExist && reciepeModel.Name != "Empty")
            {
                Recipe recipe = new Recipe();
                recipe.recipe_name = reciepeModel.Name;
                recipe.recipe_instructions = reciepeModel.Instructions;
                recipe.recipe_description = reciepeModel.Description;
                recipe.recipe_author = reciepeModel.Author;
                entity.Recipes.Add(recipe);
                entity.SaveChanges();


                Ingredients_Recipes ingredients_Recipes = new Ingredients_Recipes();
                for(int i = 0; i <list.Count; i++)
                {
                    ingredients_Recipes.recipe_name = reciepeModel.Name;
                    ingredients_Recipes.ingredient_name = list[i];
                    entity.Ingredients_Recipes.Add(ingredients_Recipes);
                    
                }
                entity.SaveChanges();
            }
            else
            {
                if (recipeNameExist == true)
                {
                    ModelState.AddModelError("", "We are sorry but the recipe already exist in our DataBase");
                    return View();
                }

                message.Remove(message.Length - 2);
                ModelState.AddModelError("", "We are sorry but the ingredients " + message + " dosen't exist in our DataBase");
                return View();
            }

            return View();
        }
    }
}