using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;
using webapi.event_.tarde.ViewModels;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(usuario.Email, usuario.Senha);

                if (usuarioBuscado != null)
                {
                    //Caso encontre o usuário buscado, prossegue para a criação do tolken

                    //1 - Definir as informações/clains que serão fornecidas no tolken (Payload)
                    var claims = new[]
                    {
                        //formato da claim(tipo, valor) - parece o parameters
                        //Jti - indica que é um id
                        //Usa-se ToString no valor pois espera-se que o valor seja uma string
                        new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),

                        //.Email indica que será um email a ser passado
                        new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),

                        //o Role indica o tipo de permissão e vem do usuarioBuscado pq ele é que tem a permissão
                        new Claim(ClaimTypes.Role, usuarioBuscado.TipoUsuario.Titulo)




                        //Existe a possibilidade de criar uma Claim personalizada
                        //primeiro vem o tipo e depois o valor
                        //new Claim("Claim Personalizada", "Valor personalizado")
                    };

                    //2 - Defenir a chave de acesso ao token
                    //chave de segurança simétrica - a mesma chave que codifica a mensagem é a responsável por decodificá-la
                    //o segredoda chave está dentro do GetBytes() como um parâmetro em string
                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("event+-chave-autenticacao-webapi-dev_codeFirst"));

                    //3 - Definir as credenciais    (tipo de algorítimo que vou usar) do token - (Heder)
                    //dentro do Signing definimos que se trata de uma chave e qual o tipo do algorítmo
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    //4 - Gerar o token em si
                    var token = new JwtSecurityToken(
                        //emissor do token - quem está enviando este token
                        issuer: "senai.event+.webApi_codeFirst",

                        //destinatário do token - quem vai recebr este token
                        audience: "senai.event+.webApi_codeFirst",

                        //dados definidos nas claims (Payload) - o primieiro é do token e o segundo é da claim lá em cima
                        claims: claims,

                        //tempo de expiração do token - a partir do momento que gerá-lo e quanto momento irá durar
                        expires: DateTime.Now.AddMinutes(5),

                        //credenciais do token - as credenciais definidas acima
                        signingCredentials: creds
                    );

                    //5 - retornar o token criado
                    return Ok(new
                    {
                        //cria o manipulador para gerar o token passando como referência o token criado
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    });


                }

                else
                {
                    return StatusCode(401, "E-mail ou senha inválidos.");
                }


            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
