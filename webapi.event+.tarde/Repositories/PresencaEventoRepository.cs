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

                if (presencaEventoBuscada != null)
                {
                    presencaEventoBuscada.Situacao = presencaEvento.Situacao;

                    ctx.Update(presencaEventoBuscada);
                    ctx.SaveChanges();
                }

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
                PresencaEvento presencaEventoBuscada = BuscarPorId(id);

                if (presencaEventoBuscada != null)
                {
                    ctx.PresencaEvento.Remove(presencaEventoBuscada);
                    ctx.SaveChanges();
                }
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
            return ctx.PresencaEvento.ToList();
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
