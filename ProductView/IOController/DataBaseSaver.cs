using System;
using System.Collections.Generic;
using System.Linq;


namespace ProductView.IOController
{
    class DataBaseSaver : IDataSaver
    {
        public List<T> Load<T>() where T : class
        {
            using (var db = new ProductContext())
            {
                var result = db.Set<T>().Where(x => true).ToList();
                return result;
            }
        }

        public void Save<T>(List<T> item) where T : class
        {
            using (var db = new ProductContext())
            {
                var result = db.Set<T>().AddRange(item);
                db.SaveChanges();
            }

        }
    }
}
