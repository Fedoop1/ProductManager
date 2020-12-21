using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductView.Model
{
    public class User
    {
        private string _name { get;}
        private string _nickname { get; }
        private DateTime _birthdate { get; }
        private double _weigth { get; }
        private Gender _gender { get; }

        public User(string name, string nick, DateTime birth, double weigth, Gender gender)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("Name exception");
            if (string.IsNullOrWhiteSpace(nick)) throw new ArgumentNullException("Nick exception");
            if (DateTime.Now < birth || birth < DateTime.Parse("1.12.1950")) throw new ArgumentException("Birth exception");
            if (weigth < 20) throw new ArgumentException("Weigth exception");
            if (gender == null) throw new ArgumentNullException("Gender exception");
            _name = name;
            _nickname = nick;
            _birthdate = birth;
            _weigth = weigth;
            _gender = gender;
        }

    }
}
