﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProductView.Model;

namespace ProductView.IOController
{
    [Serializable]
    public class IOUserControl : BaseSerialize
    {

        public User CurrentUser;

        private List<User> UserList;
        public IOUserControl(string UserName)
        {
            UserList = LoadUserData();
            CurrentUser = UserList.SingleOrDefault(u => u._nickname == UserName);
            if(CurrentUser == null)
            {
                Console.WriteLine("Пользователь с текущим именем не найден!");
                CurrentUser = this.UserCreate();
                UserList.Add(CurrentUser);
                SaveUserData();
            }
        }

        public IOUserControl(User user)
        {
            UserList = LoadUserData();
            CurrentUser = user;
        }

        public User UserCreate()
        {
            //string name, string nick, DateTime birth, double weigth, Gender gender
            Gender gender;
            Console.WriteLine("Введите имя");
            var name = Console.ReadLine();
            Console.WriteLine("Введите ваш NickName");
            var nick = Console.ReadLine();
            Console.WriteLine("Введите дату рождения в формате ДД/ММ/ГГ");
            var birth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Введите ваш вес");
            double weigth = Double.Parse(Console.ReadLine());
            Console.WriteLine("Выберите пол: 1.Male / 2.Female");
            int ch = int.Parse(Console.ReadLine());
            while (ch != 1 && ch != 2)
            {
                Console.WriteLine("Ошибка выбора пола, введите корректное число!");
                ch = int.Parse(Console.ReadLine());
            }
            if (ch == 1)
            {
                gender = User.Male;
            }
            else gender = User.Female;
            var user = new User(name, nick, birth, weigth, gender);
            SaveUserData();
            return user;
        }

        //public void GetUsers()
        //{
        //    foreach(var items in UserList)
        //    {
        //        Console.WriteLine(items);
        //    }
        //}

        public void SaveUserData()
        {
            Save(UserList);
        }
        public List<User> LoadUserData()
        {
            return Load<User>() ?? new List<User>();
        }
    
    }
}
