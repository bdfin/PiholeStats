using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PiholeStats.App.Services
{
    public static class Validator
    {
        public static bool IpAddressIsValid(string ipString)
        {
            if (string.IsNullOrWhiteSpace(ipString))
            {
                return false;
            }

            string[] splitValues = ipString.Split('.');
            if (splitValues.Length != 4)
            {
                return false;
            }

            return true;
        }
    }
}
