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
        public DateTime beginTime { get; }
        public DateTime endTime { get; }
        public Activity activity { get; }
        public Excercise(User user, DateTime begin, DateTime end, Activity act)
        {
            beginTime = begin;
            endTime = end;
            activity = act ?? throw new Exception("Null activity!");
        }

        public override string ToString()
        {
            return $"{activity.Name} с {beginTime.ToShortTimeString()} до {endTime.ToShortTimeString()}.\nКалорий в минуту: {activity.CaloriesPerMinute}.";
        }
    }
}
