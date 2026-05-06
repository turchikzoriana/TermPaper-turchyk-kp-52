using System;
using System.Collections.Generic;

namespace RecipeManager.Domain.Models;

public enum RecipeCategory
{
    Breakfast,
    MainCourse,
    Dessert,
    Beverage,
    Snack
}

public class Recipe
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public RecipeCategory Category { get; set; }
    public int Servings { get; set; } = 1;

    private readonly List<Ingredient> _ingredients = new();

    public IReadOnlyList<Ingredient> Ingredients => _ingredients.AsReadOnly();

    public void AddIngredient(Ingredient ingredient)
    {
        if (ingredient == null) 
            throw new ArgumentNullException(nameof(ingredient));
            
        _ingredients.Add(ingredient);
    }

    public void Scale(int targetServings)
    {
        if (targetServings <= 0)
        {
            throw new ArgumentException("Кількість порцій має бути більшою за нуль.");
        }

        double factor = (double)targetServings / Servings;
        foreach (var ingredient in _ingredients)
        {
            ingredient.Amount = ingredient.Amount * factor;
        }
        Servings = targetServings;
    }
}