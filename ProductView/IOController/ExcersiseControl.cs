using ProductView.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductView.IOController
{
    [Serializable]
    public class ExcersiseControl : BaseSerialize
    {
        public List<Activity> ActivitiList { get; }
        private List<Excercise> ExcerciseList { get; }
        private User CurrUser { get; }

        public ExcersiseControl(User user)
        {
            CurrUser = user ?? throw new Exception("Null User!");
            ActivitiList = LoadActivity();
            ExcerciseList = LoadExcercise();
        }

        private List<Activity> LoadActivity()
        {
            return Load<Activity>() ?? new List<Activity>(); 
        }

        private List<Excercise> LoadExcercise()
        {
            return Load<Excercise>() ?? new List<Excercise>();
        }

        private void SaveData()
        {
            Save(ActivitiList);
            Save(ExcerciseList);
        }

        public void ExcerciseAdd(Activity act, DateTime begin, DateTime end)
        {
            var activity = ActivitiList.SingleOrDefault(a => a.Name == act.Name);

            if (activity == null)
            {
                ActivitiList.Add(act);
                var excercise = new Excercise(CurrUser, begin, end, act);
                ExcerciseList.Add(excercise);
            }
            else
            {
                var excercise = new Excercise(CurrUser, begin, end, activity);
                ExcerciseList.Add(excercise);
            }

            SaveData();
        }
        public void ExcersiseInList()
        {
            foreach (var items in ExcerciseList)
            {
                Console.WriteLine();
                Console.WriteLine(items);
            }
        }
    }
}
