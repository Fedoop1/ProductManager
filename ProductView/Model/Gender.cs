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
