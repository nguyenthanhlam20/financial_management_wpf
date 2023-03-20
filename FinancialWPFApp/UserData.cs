using FinancialLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialWPFApp
{
    public class UserData
    {

        public static UserData Instance { get; set; }

        public User AuthenticatedUser { get; set; }

        public UserData()
        {

            Instance = new UserData();
        }


    }
}
