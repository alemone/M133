namespace KDG.DataObjectHandler.Password
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
