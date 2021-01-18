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
        private readonly IDataSaver serializemanager = new SerilalizableSaver();

        public List<T> Load<T>() where T : class
        {
            return serializemanager.Load<T>();
        }

        public void Save<T>(List<T> item) where T : class
        {
            serializemanager.Save(item);
        }

   }
}

    