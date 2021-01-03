using ProductView.IOController;
using ProductView.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace ProductView
{
    
    class Program
    {
        
        public static void Main(string[] args)
        {
            var Culture = CultureInfo.CurrentCulture;

            Console.WriteLine("Добро пожаловать в ProductView.\n " +
                "Данная программа разработана специально для того, " +
                "чтобы помочь вам выбрать правильный план питания\n" +
                " в зависимости от ваших целей и предпочтений.\n Начнём же!\n");

            Console.WriteLine($"Текущая культура(язык): {CultureInfo.CurrentCulture.DisplayName}.\n");
            Console.WriteLine("Выберите язык интерфейса:\nR to Russian.\nE to English");
            
            var LangKey = Console.ReadKey();
            var resManager = new ResourceManager("ProductView.Languages.Language", typeof(Program).Assembly);
            if (LangKey.Key == ConsoleKey.R)
            {
                Culture = CultureInfo.CreateSpecificCulture("ru-ru");
                resManager = new ResourceManager("ProductView.Languages.Languageru-ru", typeof(Program).Assembly);
            }
            else if (LangKey.Key == ConsoleKey.E)
            {
                Culture = CultureInfo.CreateSpecificCulture("eng-us");
                resManager = new ResourceManager("ProductView.Languages.Languageen-us", typeof(Program).Assembly);
            }
            else
            {
                Console.WriteLine(resManager.GetString("Culture-successfull-update"),Culture);
            }

            
            Console.WriteLine(resManager.GetString("\nCulture-successfull-update", Culture));
            Console.WriteLine(resManager.GetString("Enter_nickname", Culture));
            string Login = Console.ReadLine();

            var ioUserControl = new IOUserControl(Login);
            EatingControl eatingControl = new EatingControl(ioUserControl.CurrentUser);                 //Model Creating
            ExcersiseControl excersiseControl = new ExcersiseControl(ioUserControl.CurrentUser);
            
            Console.WriteLine();
            Console.WriteLine(resManager.GetString("Autorization", Culture));
            Console.WriteLine(ioUserControl.CurrentUser);
            Console.WriteLine(resManager.GetString("Any_key_to_cont", Culture));
            Console.ReadKey();
            Console.WriteLine(resManager.GetString("ChoseAction", Culture));
            Console.WriteLine(resManager.GetString("add_eating", Culture));
            Console.WriteLine(resManager.GetString("AddExcersise", Culture));
            var input = Console.ReadLine();
            while(true)
            if (input == "/add")
            {
                var product = EatingAdd();
                var checkproduct = eatingControl.UserFoodList.SingleOrDefault(x => x.Name == product.food.Name);
                if(checkproduct != null)
                {
                  eatingControl.EatingAdd(product.food, product.weight);
                        Console.WriteLine(resManager.GetString("Product_add", Culture));
                }
                else
                {
                        Console.WriteLine(resManager.GetString("ProductNotFound", Culture));
                        var fats = ParseDouble(resManager.GetString("Fats", Culture));
                        var proteins = ParseDouble(resManager.GetString("Proteins", Culture));
                        var hydrates = ParseDouble(resManager.GetString("Carbo_hydrates", Culture));
                        var calories = ParseDouble(resManager.GetString("Calories", Culture));
                        product.food.Fats = fats;
                        product.food.Proteins = proteins;
                        product.food.CarboHydrates = hydrates;
                        product.food.Callories = calories;

                        eatingControl.EatingAdd(product.food, product.weight);
                        Console.WriteLine(resManager.GetString("SuccessfullAdd", Culture));
                }
                break;
            }
            else if(input == "/act")
            {
                var activity = ActivityAdd();
                excersiseControl.ExcerciseAdd(activity.activity, activity.begin, activity.end);
                    break;
            }
            else
            {
                Console.WriteLine(resManager.GetString("Unknown_comand", Culture)); 
                input = Console.ReadLine();
            }

            (Food food, double weight) EatingAdd()
            {
                Console.WriteLine(resManager.GetString("Enter product name", Culture));
                var name = Console.ReadLine();
                double weight = ParseDouble(resManager.GetString("Weigth_of_portion", Culture));
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

            DateTime ParseDataTime(string text)
            {
                Console.WriteLine($"Введите {text}: ");
                var data = Console.ReadLine();
                DateTime result;
                DateTime.TryParse(data, out result);
                return result;
            }

            (Activity activity, DateTime begin, DateTime end) ActivityAdd()
            {
                Console.WriteLine("Введите название активности: ");
                string actname = Console.ReadLine();
                DateTime begin = ParseDataTime("время начала тренировки");
                DateTime end = ParseDataTime("время окончания тренировки");
                double calories = ParseDouble("кол-во калорий в минуту");
                Activity act = new Activity(actname, calories);

                return (act, begin, end);

            }

            eatingControl.FoodInList();
            excersiseControl.ExcersiseInList();

            Console.ReadKey();

        }

        
    }
}
