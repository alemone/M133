using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Password
{
    public static class PasswordHelper
    {
        public static string HashPassword(string toHash)
        {
            return toHash.GetHashCode().ToString();
        }
        public static bool CompareStringWithHash(string compare, string hash)
        {
            var compareHash = HashPassword(compare);
            return compareHash == hash;
        }
    }
}
