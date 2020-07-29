using domain = PizzaBox.Domain.Models;
using System.Linq; //add using System.Linq bcos of the _db.Pizza.ToList() for compile time awareness if the table name, Pizza, gets changed.
using System;
using System.Collections.Generic;
using PizzaBox.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace PizzaBox.Storing.Repositories
{
    public class PizzaRepository
    {
        private PizzaBoxDbContext _db = new PizzaBoxDbContext();

        public void Create(domain.Pizza pizza)
        {
            var newPizza = new Pizza();

            newPizza.Crust = new Crust() { Name = pizza.Crust.Name };
            newPizza.Size = new Size() {Name = pizza.Size.Name };
            newPizza.Name = pizza.Name;
            var orderDate = DateTime.UtcNow;

            _db.Pizza.Add(newPizza); //Here, you can add a new Pizza table to C#
            _db.SaveChanges();
        }

        public List<domain.Pizza> ReadAll()
        {
            var domainPizzaList = new List<domain.Pizza>();
            
            var pizzas = _db.Pizza;
            var pizzasWithCrust = _db.Pizza.Include(t => t.Crust).Include(t => t.Size);
                 
            foreach(var item in _db.Pizza.ToList())
        {
            domainPizzaList.Add(new domain.Pizza()
            {
                Crust = new domain.Crust() { Name = item.Crust.Name },
                Size = new domain.Size() { Name = item.Size.Name },
                Toppings = new List<domain.Topping>()
            });
        };
    
        return domainPizzaList;
    }

    public void Update() {}

    public void Delete() {}
    }
}
