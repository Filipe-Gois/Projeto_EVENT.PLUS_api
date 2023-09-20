using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IComentarioEvento
    {
        void Cadastrar(ComentarioEvento comentarioEvento);
        void Deletar(Guid id);
        List<ComentarioEvento> Listar();
        ComentarioEvento BuscarPorId(Guid id);
        void Atualizar(Guid id, ComentarioEvento comentario);
    }
}
