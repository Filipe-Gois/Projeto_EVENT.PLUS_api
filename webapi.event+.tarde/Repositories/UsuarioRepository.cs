using Microsoft.EntityFrameworkCore;
using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Utils;

namespace webapi.event_.tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private EventContext ctx { get; set; }
        public UsuarioRepository()
        {
            ctx = new EventContext();
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha);
                ctx.Usuario.Add(usuario);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }


        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                //É o "select" do sqlserver no banco de dados. Estamos selecionando o que irá aparecer no json. Usado para deixar mais leve na hora de exibir no front
                Usuario usuarioBuscado = ctx.Usuario.Select(u => new Usuario
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,

                    TipoUsuario = new TipoUsuario
                    {
                        IdTipoUsuario = u.IdTipoUsuario,
                        Titulo = u.TipoUsuario.Titulo
                    }
                }).FirstOrDefault(u => u.IdUsuario == id)!;

                return usuarioBuscado;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {

            try
            {
                Usuario usuarioBuscado = ctx.Usuario.Include(u => u.TipoUsuario).FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }



                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
