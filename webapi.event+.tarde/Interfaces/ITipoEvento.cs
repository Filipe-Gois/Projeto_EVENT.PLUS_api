using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface ITipoEvento
    {
        void Cadastrar(TipoEvento tipoEvento);
        void Deletar(Guid id);
        List<TipoEvento> ListarTipos();
        TipoEvento BuscarPorId(Guid id);
        void Atualizar(Guid id, TipoEvento tipoEvento);

    }
}
