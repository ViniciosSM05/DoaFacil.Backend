namespace DoaFacil.Backend.Infra.Crosscutting.Extensions
{
    public static class ByteExtensions
    {
        public static string ConvertImgToBase64(this byte[] bytes, string tipo)
        {
            if (bytes == null || bytes.Length == 0 || string.IsNullOrWhiteSpace(tipo))
                return null;

            string base64String = Convert.ToBase64String(bytes);
            return $"data:{tipo};base64,{base64String}";
        }
    }
}
