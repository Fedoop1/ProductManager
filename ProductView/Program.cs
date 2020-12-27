using ProductView.IOController;
using ProductView.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductView
{
    
    class Program
    {
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в ProductView.\n " +
                "Данная программа разработана специально для того, " +
                "чтобы помочь вам выбрать правильный план питания\n" +
                " в зависимости от ваших целей и предпочтений.\n Начнём же!");
            Console.WriteLine();
            Console.WriteLine("Введите ваш nickname:");
            string Login = Console.ReadLine();
            var ioUserControl = new IOUserControl(Login);
            EatingControl eatingControl = new EatingControl(ioUserControl.CurrentUser);
            Console.WriteLine();
            Console.WriteLine("Авторизация успешно выполнена!");
            Console.WriteLine(ioUserControl.CurrentUser);
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.WriteLine(@"/add для добавления нового приёма пищи");
            var input = Console.ReadLine();
            while(true)
            if (input == "/add")
            {
                var product = EatingAdd();
                var checkproduct = eatingControl.UserFoodList.SingleOrDefault(x => x.Name == product.food.Name);
                if(checkproduct != null)
                {
                  eatingControl.EatingAdd(product.food, product.weight);
                        Console.WriteLine("Продукт был найден и успешно добавлен!");
                }
                else
                {
                        Console.WriteLine("Продукт в списке не найден. Введите данные о продукте: \n");
                        var fats = ParseDouble("жиры");
                        var proteins = ParseDouble("белки");
                        var hydrates = ParseDouble("углеводы");
                        var calories = ParseDouble("калории");
                        product.food.Fats = fats;
                        product.food.Proteins = proteins;
                        product.food.CarboHydrates = hydrates;
                        product.food.Callories = calories;

                        eatingControl.EatingAdd(product.food, product.weight);
                        Console.WriteLine("Продукт успешно добавлен!");
                }
                break;
            }
            else
            {
                Console.WriteLine("Неизвестная команда, введите корректную команду: ");
                    input = Console.ReadLine();
            }

            (Food food, double weight) EatingAdd()
            {
                Console.WriteLine("Введите название продукта:");
                var name = Console.ReadLine();
                double weight = ParseDouble("вес порции");
                Food food = new Food(name);
                return (food, weight);
            }

            double ParseDouble(string text)
            {
                Console.WriteLine($"Введите {text}: ");
                var data = Console.ReadLine();
                double result;
                double.TryParse(data, out result);
                return result;
            }

            eatingControl.FoodInList();

            Console.ReadKey();

        }
    }
}
