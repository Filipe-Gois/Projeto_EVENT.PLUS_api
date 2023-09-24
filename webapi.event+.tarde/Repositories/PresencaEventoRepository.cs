using Microsoft.EntityFrameworkCore;
using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class PresencaEventoRepository : IPresencaEvento
    {
        private EventContext ctx { get; set; }
        public PresencaEventoRepository()
        {
            ctx = new EventContext();
        }
        public void Atualizar(Guid id, PresencaEvento presencaEvento)
        {
            try
            {
                PresencaEvento presencaEventoBuscada = BuscarPorId(id);


                presencaEventoBuscada.Situacao = presencaEvento.Situacao;

                ctx.Update(presencaEventoBuscada);
                ctx.SaveChanges();


            }
            catch (Exception)
            {

                throw;
            }
        }

        public PresencaEvento BuscarPorId(Guid id)
        {
            try
            {
                return ctx.PresencaEvento.FirstOrDefault(p => p.IdUsuario == id)!;
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
                ctx.PresencaEvento.Remove(BuscarPorId(id));
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Inscrever(PresencaEvento inscricao)
        {
            try
            {
                ctx.PresencaEvento.Add(inscricao);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<PresencaEvento> Listar()
        {
            try
            {
                return ctx.PresencaEvento.Select(p => new PresencaEvento
                {
                    IdPresencaEvento = p.IdPresencaEvento,
                    IdUsuario = p.IdUsuario,
                    IdEvento = p.IdEvento,
                    Situacao = p.Situacao
                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id do usuário</param>
        /// <returns></returns>
        public List<PresencaEvento> ListarMinhas(Guid id)
        {
            try
            {
                return ctx.PresencaEvento.Where(u => u.IdUsuario == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
