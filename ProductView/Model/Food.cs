using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductView.Model
{
    [Serializable]
    public class Food
    {
        public string Name { get; set; }
        public double Callories { get; set; }

        public double Fats { get; set; }

        public double CarboHydrates { get; set; }

        public double Proteins { get; set; }

        public Food(string name) : this(name, 0, 0, 0, 0) 
        {
            Name = name; 
        }

        public Food(string name, double callories, double fats, double carbo, double proteins)
        {
            Name = name;
            Callories = callories / 100;
            Fats = fats / 100;
            CarboHydrates = carbo / 100;
            Proteins = proteins / 100;
        }

        public override string ToString()
        {
            return $"Название продукта: {Name}.\nБелки: {Proteins}.\nЖиры: {Fats}.\nУглеводы: {CarboHydrates}.\nКалорийность: {Callories}.\n\n*Белки, жири, углеводы, калории в 1 грамме продукта";
        }
    }
}
