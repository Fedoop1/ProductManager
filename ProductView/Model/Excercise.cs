using ProductView.IOController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductView.Model
{
    [Serializable]
    public class Excercise
    {
        public DateTime beginTime { get; set; }
        public DateTime endTime { get; set; }

        public int Id { get; set; }
        public int UserId { get; set; }

        public int ActivityId { get; set; }

        public virtual User User { get; set; }

        public virtual Activity Activity { get; set; }
        public Excercise(User user, DateTime begin, DateTime end, Activity act)
        {
            beginTime = begin;
            endTime = end;
            Activity = act ?? throw new Exception("Null activity!");
            User = user;
        }

        public Excercise() { }

        public override string ToString()
        {
            return $"{Activity.Name} с {beginTime.ToShortTimeString()} до {endTime.ToShortTimeString()}.\nКалорий в минуту: {Activity.CaloriesPerMinute}.";
        }
    }
}
