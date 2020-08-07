using Microsoft.EntityFrameworkCore;
using ReservaSala.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReservaSala.Api.Data
{
    public class RecipeDbOperations
    {
        AppDbContext rc;

        //To Get all recipes   
        public IEnumerable<Recipe> GetAllRecipes()
        {
            try
            {
                return rc.Recipe.ToList();
            }
            catch(Exception ex)
            {
                return rc.Recipe.ToList();
            }
        }

        //To Add new recipe     
        public void AddRecipe(Recipe recipe)
        {
            try
            {
                rc.Recipe.Add(recipe);
                rc.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //To Update particular recipe    
        public void UpdateRecipe(Recipe recipe)
        {
            try
            {
                rc.Entry(recipe).State = EntityState.Modified;
                rc.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //Get the particular recipe    
        public Recipe GetRecipeDetail(int id)
        {
            try
            {
                Recipe recipe = rc.Recipe.Find(id);
                return recipe;
            }
            catch
            {
                throw;
            }
        }

        //To Delete particular recipe    
        public void DeleteRecipe(int id)
        {
            try
            {
                Recipe recipe = rc.Recipe.Find(id);
                rc.Recipe.Remove(recipe);
                rc.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
