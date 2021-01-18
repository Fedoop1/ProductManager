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
        public DateTime Moment { get; set; } = DateTime.UtcNow;

        public Dictionary<Food, double> FoodList { get; set; }

        public virtual User CurrUser { get; set; }

        public int UserId { get; set; }
        public int Id { get; set; }


        public Eating(User user)
        {
            CurrUser = user ?? throw new ArgumentNullException("Null user");
            Moment = DateTime.UtcNow;
            FoodList = new Dictionary<Food, double>();
        }

        public Eating() { }

        public void AddFoodList(Food product, double Weight)
        {
            var check = FoodList.Keys.FirstOrDefault(pr => pr.Name.Equals(product.Name));
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
