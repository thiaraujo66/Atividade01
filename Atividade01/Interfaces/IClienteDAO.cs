using Atividade01.Models;

namespace Atividade01.Interfaces
{
    public interface IClienteDAO
    {
        public void Incluir(string pNome, string pEmail);
        public List<Cliente> ListarTodos();
        public Cliente BuscarPorId(int pId);
        public void Atualizar(Cliente pCliente);
        public void Deletar(int pId);
    }
}
