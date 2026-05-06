namespace RecipeManager.Domain.Models;

public class Ingredient
{
    public string Name { get; set; } = string.Empty;
    public double Amount { get; set; }
    public string Unit { get; set; } = "g";
    
    public Ingredient() { }

    public Ingredient(string name, double amount, string unit)
    {
        Name = name;
        Amount = amount;
        Unit = unit;
    }
}