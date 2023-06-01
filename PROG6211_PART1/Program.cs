using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6211_PART1
{
   public class Program
    {
        static Ingredient[] ingredients;
        static Step[] steps;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Recipe App!");

            while (true)
            {
                Console.WriteLine("\nPlease enter the recipe details:");
                Console.Write("Number of ingredients: ");
                int numIngredients = Convert.ToInt32(Console.ReadLine());

                ingredients = new Ingredient[numIngredients];
                for (int i = 0; i < numIngredients; i++)
                {
                    Console.WriteLine($"\nIngredient {i + 1}:");
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Quantity: ");
                    double quantity = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Unit of Measurement: ");
                    string unit = Console.ReadLine();

                    ingredients[i] = new Ingredient
                    {
                        Name = name,
                        Quantity = quantity,
                        Unit = unit
                    };
                }

                Console.Write("\nNumber of steps: ");
                int numSteps = Convert.ToInt32(Console.ReadLine());

                steps = new Step[numSteps];
                for (int i = 0; i < numSteps; i++)
                {
                    Console.WriteLine($"\nStep {i + 1}:");
                    Console.Write("Description: ");
                    string description = Console.ReadLine();

                    steps[i] = new Step
                    {
                        Description = description
                    };
                }

                DisplayRecipe();

                Console.WriteLine("\nOptions:");
                Console.WriteLine("1. Scale recipe");
                Console.WriteLine("2. Reset quantities");
                Console.WriteLine("3. Clear data and enter a new recipe");
                Console.WriteLine("4. Exit");
                Console.Write("Enter option: ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        ScaleRecipe();
                        break;
                    case 2:
                        ResetQuantities();
                        break;
                    case 3:
                        ClearData();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void DisplayRecipe()
        {
            Console.WriteLine("\nRecipe Details:");
            Console.WriteLine("Ingredients:");
            foreach (Ingredient ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i].Description}");
            }
        }

        static void ScaleRecipe()
        {
            Console.Write("\nEnter scaling factor (0.5, 2, or 3): ");
            double factor = Convert.ToDouble(Console.ReadLine());

            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }

            DisplayRecipe();
        }

        static void ResetQuantities()
        {
            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.Quantity /= ingredient.Quantity;
            }

            DisplayRecipe();
        }

        static void ClearData()
        {
            ingredients = null;
            steps = null;
        }
    }
}
