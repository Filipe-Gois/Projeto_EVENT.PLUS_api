using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class ComentarioEventoRepository : IComentarioEvento
    {
        private EventContext ctx { get; set; }
        public ComentarioEventoRepository()
        {
            ctx = new EventContext();
        }
        public ComentarioEvento BuscarPorId(Guid id)
        {
            try
            {
                return ctx.ComentarioEvento.FirstOrDefault(x => x.IdComentarioEvento == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            try
            {
                ctx.ComentarioEvento.Add(comentarioEvento);
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
                ComentarioEvento comentarioBuscado = BuscarPorId(id);

                if (comentarioBuscado != null)
                {
                    ctx.ComentarioEvento.Remove(comentarioBuscado);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ComentarioEvento> Listar()
        {
            return ctx.ComentarioEvento.ToList();
        }
    }
}
