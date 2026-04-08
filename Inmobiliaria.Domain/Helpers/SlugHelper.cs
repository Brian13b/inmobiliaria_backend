using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Inmobiliaria.Domain.Helpers
{
    public static class SlugHelper
    {
        public static string GenerateSlug(string titulo, int id)
        {
            if (string.IsNullOrWhiteSpace(titulo)) return $"propiedad-0{id}";

            string normalizedString = titulo.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            string str = stringBuilder.ToString().Normalize(NormalizationForm.FormC).ToLower().Trim();

            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");

            str = Regex.Replace(str, @"\s+", "-").Trim('-');

            str = Regex.Replace(str, @"-+", "-");

            return $"{str}-0{id}";
        }
    }
}
