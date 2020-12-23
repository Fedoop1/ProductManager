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
        
        static void Main(string[] args)
        {
            string Path = $"{Environment.CurrentDirectory}\\UserData.dat";
            Console.WriteLine("Добро пожаловать в ProductView.\n " +
                "Данная программа разработана специально для того, " +
                "чтобы помочь вам выбрать правильный план питания\n" +
                " в зависимости от ваших целей и предпочтений.\n Начнём же!");
            Console.WriteLine("Введите ваш NickName:");
            string Login = Console.ReadLine();
            var _IOUserControl = new IOUserControl(Path, Login);
            Console.WriteLine();
            Console.WriteLine("Авторизация успешно выполнена!");
            User CurrentUser = _IOUserControl.CurrentUser;
            Console.WriteLine(CurrentUser);
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
            

        }
    }
}
