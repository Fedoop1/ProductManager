using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ProductView.IOController
{
   public abstract class BaseSerialize
    {
        protected void SaveData(string path, object data)
        {
            {
                using (var file = new FileStream(path, FileMode.OpenOrCreate))
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(file, data);
                    Console.WriteLine("Данные успешно сохранены.");
                }
            }

        }

        protected List<T> LoadData<T>(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Ошибка, файл с данными не найден!");
                return default(List<T>);
            }

            using (var file = new FileStream(path, FileMode.OpenOrCreate))
            {
                var formatter = new BinaryFormatter();
                Console.WriteLine("Данные успешно загружены");
                return formatter.Deserialize(file) as List<T>;
            }
        }

    }
}

    