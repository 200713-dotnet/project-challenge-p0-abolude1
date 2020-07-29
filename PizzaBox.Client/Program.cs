using System;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var pr = new PizzaRepository();
            var pizza = new Pizza()
            
        {
            Name = "CheeZit Pizza",
            Crust = new Crust() { Name = "Thin Crust" },
            Size = new Size() { Name = "Large"},
            Toppings = new System.Collections.Generic.List<Topping>() { new Topping() { Name = "Cheese"}}
        };

        pr.Create(pizza);
        Console.ReadLine();

        foreach (var item in pr.ReadAll())
        {
            System.Console.WriteLine(item);
        }
        }
    }
}
