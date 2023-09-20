using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly EventContext ctx;

        public TipoUsuarioRepository()
        {
            ctx = new EventContext();
        }

        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = BuscarPorId(id);

                if (tipoUsuarioBuscado != null)
                {
                    tipoUsuarioBuscado.Titulo = tipoUsuario.Titulo;

                    ctx.Update(tipoUsuarioBuscado);
                    ctx.SaveChanges();
                }

                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            try
            {
                return ctx.TipoUsuario.FirstOrDefault(t => t.IdTipoUsuario == id)!;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                ctx.TipoUsuario.Add(tipoUsuario);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = BuscarPorId(id);

                if (tipoUsuarioBuscado != null)
                {
                    ctx.TipoUsuario.Remove(tipoUsuarioBuscado);
                    ctx.SaveChanges();
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuario.ToList();
        }
    }
}
