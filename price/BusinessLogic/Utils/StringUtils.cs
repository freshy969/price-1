using System.Text;

namespace BusinessLogic.Utils
{
    public static class StringUtils
    {
        public static string Normalize(string input)
        {
            byte[] tempBytes;
            tempBytes = Encoding.GetEncoding("ISO-8859-8").GetBytes(input);
            string result = Encoding.UTF8.GetString(tempBytes);
            return result;
        }
    }
}
