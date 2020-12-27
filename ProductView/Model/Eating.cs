using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductView.Model
{
    [Serializable]
    public class Eating
    {
        public DateTime Moment { get; } = DateTime.UtcNow;

        public Dictionary<Food, double> FoodList { get; }

        public User CurrUser { get; }

        public Eating(User user)
        {
            CurrUser = user ?? throw new ArgumentNullException("Null user");
            Moment = DateTime.UtcNow;
            FoodList = new Dictionary<Food, double>();
        }

        public void AddFoodList(Food product, double Weight)
        {
            var check = FoodList.Keys.SingleOrDefault(pr => pr.Name == product.Name);
            if(check == null)
            {
                FoodList.Add(product, Weight);
            }
            else 
            {
                FoodList[check] += Weight;    
            }
        }

        public override string ToString()
        {
            return $"Пользователь: {CurrUser}.\nВремя приёма пиши: {Moment}.\nСписок продуктов{FoodList.Keys}.\nКоличество грамм: {FoodList.Values.Sum()}.";
        }
    }
}
