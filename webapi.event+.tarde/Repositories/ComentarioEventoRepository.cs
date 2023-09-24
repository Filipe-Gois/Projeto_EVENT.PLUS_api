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
                ctx.ComentarioEvento.Remove(BuscarPorId(id));
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ComentarioEvento> Listar()
        {
            return ctx.ComentarioEvento.Select(x => new ComentarioEvento
            {
                IdComentarioEvento = x.IdComentarioEvento,
                IdUsuario = x.IdUsuario,
                IdEvento = x.IdEvento,
                Descricao = x.Descricao,
                Exibe = x.Exibe
            }).ToList();
        }
    }
}
