using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductView.Model
{
    [Serializable]
    public class Activity
    {
        public string Name { get; }

        public double CaloriesPerMinute { get; }

        public Activity(string name, double  calories)
        {
            if(!string.IsNullOrWhiteSpace(name)) Name = name;

            CaloriesPerMinute = calories;
        }
    }
}
