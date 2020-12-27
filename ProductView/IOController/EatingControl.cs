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

        private const string EATING_PATH = "EatingData.dat";
        private const string FOODLIST_PATH = "FoodList.dat";

        public EatingControl(User user)
        {
            CurrentUser = user ?? throw new ArgumentNullException("User cant be Null");
            UserEating = LoadEating();
            UserFoodList = LoadFoodList();
        }

        private Eating LoadEating()
        {
            return LoadData<Eating>(EATING_PATH) ?? new Eating(CurrentUser);
        }

        private List<Food> LoadFoodList()
        {
            return LoadData<List<Food>>(FOODLIST_PATH) ?? new List<Food>();
        }

        private void SaveData()
        {
            SaveData(EATING_PATH, UserEating);
            SaveData(FOODLIST_PATH, UserFoodList);
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
            }
        }
    }
}
