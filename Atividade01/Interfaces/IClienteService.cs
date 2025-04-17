using Atividade01.Models;

namespace Atividade01.Interfaces
{
    public interface IClienteService
    {
        public void AdicionarCliente(string pNome, string pEmail);
        List<Cliente> ListarClientes();
        Cliente BuscarCliente(int pId);
        void AtualizarCliente(Cliente pCliente);
        void RemoverCliente(int pId);
    }
}
