using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IInstituicao
    {
        void Cadastrar(Instituicao instituicao);
        List<Instituicao> ListarTodas();
        void Deletar(Guid id);
        void Atualizar(Guid id, Instituicao instituicao);
        Instituicao BuscarPorId(Guid id);
    }
}
