using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductView.Model
{

    [Serializable]
    public class Gender
    {
        public virtual ICollection<User> Users { get; set; }
        public Gender() { }
        public int Id { get; set; }
        private string _gendertype { get; }

        public Gender(string gender)
        {
            _gendertype = gender;
        }

        public override string ToString()
        {
            return $"{_gendertype}";
        }
    }
}
