using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);
        void Deletar(Guid id);
        List<Usuario> Listar();

        void Atualizar(Guid id, Usuario usuario);

        Usuario BuscarPorId(Guid id);
        Usuario BuscarPorEmailESenha(string email, string senha);
    }
}
