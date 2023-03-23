using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialWPFApp.Constants
{
    public class AppConstants
    {
        public AppConstants()
        {
        }

        public enum Roles
        {
            Admin = 1, 
            User = 2
        }

        public enum Pages
        {
            SignIn,
            SignUp
        }

        public enum ActionType
        {
            View = 0,
            Edit = 1,
            Insert = 2,
        }

    }
}
