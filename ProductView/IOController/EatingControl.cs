using ProductView.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductView.IOController
{
    public class EatingControl : BaseSerialize
    {
        private User CurrentUser { get; }

        public EatingControl(User user)
        {
            CurrentUser = user ?? throw new ArgumentNullException("User Null");
        }
        
    }
}
