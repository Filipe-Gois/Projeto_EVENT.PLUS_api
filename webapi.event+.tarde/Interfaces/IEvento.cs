using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IEvento
    {
        void Cadastrar(Evento evento);
        void Deletar(Guid id);
        List<Evento> ListarEventos();
        Evento BuscarPorId(Guid id);
        void Atualizar(Guid id, Evento evento);
    }
}
