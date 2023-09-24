using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class TipoEventoRepository : ITipoEvento
    {
        private EventContext ctx { get; set; }
        public TipoEventoRepository()
        {
            ctx = new EventContext();
        }
        public void Atualizar(Guid id, TipoEvento tipoEvento)
        {
            TipoEvento tipoEventoBuscado = BuscarPorId(id);

            tipoEventoBuscado.Titulo = tipoEvento.Titulo;

            ctx.Update(tipoEventoBuscado);
            ctx.SaveChanges();

        }

        public TipoEvento BuscarPorId(Guid id)
        {
            try
            {
                return ctx.TipoEvento.FirstOrDefault(t => t.IdTipoEvento == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(TipoEvento tipoEvento)
        {
            try
            {
                ctx.TipoEvento.Add(tipoEvento);
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
                ctx.TipoEvento.Remove(BuscarPorId(id));
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<TipoEvento> ListarTipos()
        {
            try
            {
                return ctx.TipoEvento.Select(t => new TipoEvento
                {
                    IdTipoEvento = t.IdTipoEvento,
                    Titulo = t.Titulo
                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
