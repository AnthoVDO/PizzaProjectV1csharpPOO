using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaProjectV1csharpPOO
{
    // Custom pizza 
    // user can add his own ingredients  
    // inherit from pizza  
    // constructor () empty
    // name = custom
    // price = 5
    // vegetarian = false
    // ask ingredient directly to the user
    // if empty string or null + enter the user have finished;
    class CustomPizza : Pizza
    {
        public CustomPizza()
        {

        }

        public static List<string> askIngredients()
        {
            List<string> ingredients = new List<string>();
            Console.WriteLine("Hello, welcome to the custom pizza generator");
            while (true)
            {
                Console.Write("Please add an ingredient (PRESS ENTER WHILE FINISHED: ");
                string ingredient = Console.ReadLine();
                if (string.IsNullOrEmpty(ingredient))
                {
                    break;
                }
                else
                {
                    ingredients.Add(ingredient);
                }
                
            }
            Console.WriteLine("Thank you, your custom pizza is now available");
            Console.WriteLine("");

            return ingredients;

        }
    }
    

    // Create pizza class with name, price, vegetarian or no, constructor, show function
    class Pizza
    {
        string name;
        public float price{ get; private set; }
        public bool vegetarian { get; private set; }
        public List<string> ingredients { get; private set; }
        public Pizza(string name = "Custom", float price = 5, bool vegetarian = false, List<string> ingredients = null)
        {
            this.name = name;
            this.price = price;
            this.vegetarian = vegetarian;
            this.ingredients = ingredients;

        }

        public void ShowPizza()
        {
            
            string vegetarianQuestion = vegetarian? " (V)" : "";

            List<string> transformedIngredient = new List<string>();
            ingredients.ForEach(e =>
            {
                string ingredientModified = WordWithFirstCapitalLetter(e);
                transformedIngredient.Add(ingredientModified);

            });

            string nameToShow = WordWithFirstCapitalLetter(name);
            Console.Write($"{nameToShow}{vegetarianQuestion} - {price}€\n {string.Join(", ", transformedIngredient)}");
            Console.WriteLine();
        }
        static string WordWithFirstCapitalLetter(string w)
        {
            if (string.IsNullOrEmpty(w))
                return w;
            string capitalName = w.ToUpper();
            string minusName = w.ToLower();
            string result = capitalName[0] + minusName[1..];
            return result; 
         }
    }

    

    
    class Program
    {
        

        static void Main(string[] args)
        {
            // To show euro symbole
            Console.OutputEncoding = Encoding.UTF8;


            // Ask ingredients

            List<string> ingredientsForCustom = askIngredients();
            // Creating the pizza
            var pizzaList = new List<Pizza>{
                new Pizza("Proscito", 9.5f, false, new List<string>{ "tomates", "mozzarella", "proscito"}),
                new Pizza("4 Cheese", 11, true, new List<string>{"Tomates", "mozzarella", "bel paese", "gorgonzola", "taleggio"}),
                new Pizza("Carlzone", 9, false, new List<string>{"Tomates", "mozzarella", "jambon", "champignons", "oeufs", "ail" }),
                new Pizza("Hunter", 13, false, new List<string>{"Tomates", "mozzarella", "champignons", "lardons", "oignons", "ail" }),
                new Pizza("Hawaï", 12.5f, true, new List<string>{"Tomates", "mozzarella", "jambon", "ananas" }),
                new Pizza("Margarita", 8.5f, true, new List<string>{"Tomates", "mozzarella" }),
                new CustomPizza("Custom", 5, false, )
            };

            //pizzaList = pizzaList.Where(p => p.ingredients.Contains("ail")).ToList();
            
            //foreach(Pizza p in pizzaList)
            //{
                
                
            //        p.ShowPizza();
                
                
            //}



        }
    }
}
