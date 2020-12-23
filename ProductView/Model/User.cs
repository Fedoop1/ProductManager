using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductView.Model
{
    [Serializable]
    public class User
    {
        
        public static Gender Male = new Gender("Male");
        public static Gender Female = new Gender("Female");

        public string _name { get; } = "Unknown";
        public string _nickname { get; } = "Unknown";
        private DateTime _birthdate { get; } = DateTime.Parse("01.01.2000");
        private double _weigth { get; } = 21;
        private Gender _gender { get; } = new Gender("Unknown");

        public User() { }

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
        public override string ToString()
        {
            return $"Имя:{_name}.\nNickName:{_nickname}.\nДата рождения:{_birthdate}.\nВес:{_weigth}.\nПол:{_gender}";
        }
    }
}
