using System;

namespace SearchFight.Services
{
    class SanitizerService
    {
        public string SanitizeInput(string raw)
        {
            return Uri.EscapeDataString(raw);
        }

        public long SanitizeOutput(string raw)
        {
            string preRaw = raw.Replace(" ", "").Replace(".", "").Replace(",", "");
            return IsNumeric(preRaw) ? Convert.ToInt64(preRaw) : -1;
        }

        private bool IsNumeric(string text)
        {
            long result;
            return long.TryParse(text, out result);
        }
    }
}
