using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductView.Model
{
    public class Food
    {
        public string Name { get; }
        public double Callories { get; } = 0;

        public double Fats { get; } = 0;

        public double CarboHydrates { get; } = 0;

        public Food(string name) : this(name, 0, 0, 0) 
        {
            Name = name; 
        }

        public Food(string name, double callories, double fats, double carbo)
        {
            Name = name;
            Callories = callories / 100;
            Fats = fats / 100;
            CarboHydrates = carbo / 100;
        }
    }
}
