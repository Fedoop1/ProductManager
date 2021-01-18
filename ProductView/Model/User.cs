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
        public User() { }
        public int Id { get; set; }
        
        public static Gender Male = new Gender("Male");
        public static Gender Female = new Gender("Female");

        public string _name { get; }
        public string _nickname { get; } 
        private DateTime _birthdate { get; }
        private double _weigth { get; }
        private Gender _gender { get; }

        public virtual ICollection<Eating> Eatings { get; set; }
        public virtual ICollection<Excercise> Exercises { get; set; }

        public User(string name) : this(name: name, nick: "null", birth: DateTime.Parse("01.01.2001"), weigth: 999, gender: User.Male)
        {
            _name = name;
        }

        public User(string name, string nick, DateTime birth, double weigth, Gender gender)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("Name exception");
            if (string.IsNullOrWhiteSpace(nick)) throw new ArgumentNullException("Nick exception");
            if (DateTime.Now < birth || birth < DateTime.Parse("1.9.1939")) throw new ArgumentException("Birth exception");
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
