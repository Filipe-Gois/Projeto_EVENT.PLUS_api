using BCrypt.Net;

namespace webapi.event_.tarde.Utils
{
    public static class Criptografia
    {
        /// <summary>
        /// Gera uma Hash a partir de uma senha
        /// </summary>
        /// <param name="senha">Senha que receberá a Hash</param>
        /// <returns>Senha criptografada com a Hash</returns>
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        /// <summary>
        /// Verifica se a Hash da senha informada é igual à Hash salva no BD
        /// </summary>
        /// <param name="senhaForm">Senha passada no formulário de login</param>
        /// <param name="senhaBanco">Senha cadastrada no banco</param>
        /// <returns>True ou False</returns>
        public static bool CompararHash(string senhaForm, string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaForm, senhaBanco);
        }
    }
}
