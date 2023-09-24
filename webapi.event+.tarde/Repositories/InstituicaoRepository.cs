using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class InstituicaoRepository : IInstituicao
    {
        private EventContext ctx { get; set; }
        public InstituicaoRepository()
        {
            ctx = new EventContext();
        }
        public void Atualizar(Guid id, Instituicao instituicao)
        {
            try
            {
                Instituicao instituicaoBuscada = BuscarPorId(id);

                instituicaoBuscada.NomeFantasia = instituicao.NomeFantasia;
                instituicaoBuscada.Endereco = instituicao.Endereco;

                ctx.Update(instituicaoBuscada);
                ctx.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Instituicao BuscarPorId(Guid id)
        {
            try
            {
                return ctx.Instituicao.FirstOrDefault(i => i.IdInstituicao == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Instituicao instituicao)
        {
            try
            {
                ctx.Instituicao.Add(instituicao);
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
                ctx.Instituicao.Remove(BuscarPorId(id));
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }


        }

        public List<Instituicao> ListarTodas()
        {
            try
            {
                return ctx.Instituicao.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
