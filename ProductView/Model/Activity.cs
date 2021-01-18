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
        public string Name { get; set; }

        public double CaloriesPerMinute { get; set; }
        public virtual ICollection<Excercise> Excercises { get; set; }
        public int Id { get; set; }

        public Activity(string name, double calories)
        {
            if (!string.IsNullOrWhiteSpace(name)) Name = name;

            CaloriesPerMinute = calories;
        }

        
        public Activity() { }
    }
}
