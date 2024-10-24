using System.Text.RegularExpressions;

namespace DoaFacil.Backend.Infra.Crosscutting.Extensions
{
    public static class StringExtensions
    {
        public static bool IsValidCpf(this string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", "").Trim();

            if (cpf.Length != 11 || !long.TryParse(cpf, out _))
                return false;

            if (cpf.Distinct().Count() == 1)
                return false;

            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum += (cpf[i] - '0') * (10 - i);
            }

            int remainder = sum % 11;
            int firstDigit = (remainder < 2) ? 0 : 11 - remainder;

            if (firstDigit != (cpf[9] - '0'))
                return false;

            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += (cpf[i] - '0') * (11 - i);
            }

            remainder = sum % 11;
            int secondDigit = (remainder < 2) ? 0 : 11 - remainder;

            return secondDigit == (cpf[10] - '0');
        }

        public static bool IsValidCnpj(this string cnpj)
        {
            cnpj = cnpj.Replace(".", "").Replace("/", "").Replace("-", "").Trim();

            if (cnpj.Length != 14 || !long.TryParse(cnpj, out _))
                return false;

            if (cnpj.Distinct().Count() == 1)
                return false;

            int[] multiplicadores1 = [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
            int soma = 0;

            for (int i = 0; i < 12; i++)
            {
                soma += (cnpj[i] - '0') * multiplicadores1[i];
            }

            int resto = soma % 11;
            int primeiroDigito = (resto < 2) ? 0 : 11 - resto;

            if (primeiroDigito != (cnpj[12] - '0'))
                return false;

            int[] multiplicadores2 = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
            soma = 0;

            for (int i = 0; i < 13; i++)
            {
                soma += (cnpj[i] - '0') * multiplicadores2[i];
            }

            resto = soma % 11;
            int segundoDigito = (resto < 2) ? 0 : 11 - resto;

            return segundoDigito == (cnpj[13] - '0');
        }

        public static bool IsValidEmail(this string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new(pattern);

            return regex.IsMatch(email);
        }

        public static byte[] Base64ImageToBytes(this string base64)
        {
            try
            {
                string base64Content = base64.Contains(',') ? base64.Split(',')[1] : base64;
                byte[] imageBytes = Convert.FromBase64String(base64Content);

                return imageBytes;
            }
            catch (Exception)
            {
                return new byte[base64.Length];
            }
        }
    }
}
