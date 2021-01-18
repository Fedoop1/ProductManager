using ProductView.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductView.IOController
{
    [Serializable]
    public class EatingControl : BaseSerialize
    {
        private User CurrentUser { get; }
        public Eating UserEating { get; }
        public List<Food> UserFoodList { get; }

        public EatingControl(User user)
        {
            CurrentUser = user ?? throw new ArgumentNullException("User cant be Null");
            UserEating = LoadEating();
            UserFoodList = LoadFoodList();
            SaveData();
        }

        private Eating LoadEating()
        {
            return Load<Eating>().FirstOrDefault() ?? new Eating(CurrentUser);
        }

        private List<Food> LoadFoodList()
        {
            return Load<Food>() ?? new List<Food>();
        }

        private void SaveData()
        {
            Save(new List<Eating>() { UserEating });
            Save(UserFoodList);
        }

        public void EatingAdd(Food food, double weight)
        {
            var product = UserFoodList.SingleOrDefault(fd => fd.Name == food.Name);
            if(product == null)
            {
                UserFoodList.Add(food);
                UserEating.AddFoodList(food, weight);
                SaveData();
            }
            else
            {
                UserEating.AddFoodList(product, weight);
                SaveData();
            }
        }
      
        public void FoodInList()
        {
            foreach(var items in UserFoodList)
            {
                Console.WriteLine();
                Console.WriteLine(items);
                Console.WriteLine("Грамм: " + UserEating.FoodList.SingleOrDefault(x=> x.Key.Name == items.Name).Value);
            }
        }
    }
}
