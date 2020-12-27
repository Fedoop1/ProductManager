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
                }
            }

        }

        protected T LoadData<T>(string path)
        {
            var formatter = new BinaryFormatter();

            using (var file = new FileStream(path, FileMode.OpenOrCreate))
            {
                if (file.Length > 0 && formatter.Deserialize(file) is T items)
                {
                    return items;
                }
                else return default(T);
            }
        }

    }
}

    