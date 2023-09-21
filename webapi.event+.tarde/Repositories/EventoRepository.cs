using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class EventoRepository : IEvento
    {
        private EventContext ctx { get; set; }
        public EventoRepository()
        {
            ctx = new EventContext();
        }
        public void Atualizar(Guid id, Evento evento)
        {
            try
            {
                Evento eventoBuscado = BuscarPorId(id);

                if (eventoBuscado != null)
                {
                    eventoBuscado.Descricao = evento.Descricao;
                    eventoBuscado.DataEventp = evento.DataEventp;
                    eventoBuscado.IdTipoEvento = evento.IdTipoEvento;
                    eventoBuscado.NomeEvento = evento.NomeEvento;
                    eventoBuscado.IdInstituicao = evento.IdInstituicao;

                    ctx.Update(eventoBuscado);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Evento BuscarPorId(Guid id)
        {
            try
            {
                return ctx.Evento.FirstOrDefault(e => e.IdEvento == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Evento evento)
        {
            try
            {
                ctx.Evento.Add(evento);
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
                Evento eventoBuscado = BuscarPorId(id);

                if (eventoBuscado != null)
                {
                    ctx.Evento.Remove(eventoBuscado);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        public List<Evento> ListarEventos()
        {
            try
            {
                return ctx.Evento.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
