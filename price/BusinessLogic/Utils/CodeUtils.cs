using System.Text.RegularExpressions;

namespace BusinessLogic.Utils
{
    public static class CodeUtils
    {
        private static readonly Regex emptyStringRegex = new Regex("\\s+");

        public static string CreateCode(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            string transformed = text.Trim().ToLowerInvariant();

            transformed = StringUtils.Normalize(transformed);

            transformed = transformed.Replace(".", "").Replace(',', ' ');

            transformed = emptyStringRegex.Replace(transformed, "_");

            return transformed;
        }
    }
}
