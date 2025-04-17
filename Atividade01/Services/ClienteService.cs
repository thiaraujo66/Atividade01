using Atividade01.DAO;
using Atividade01.Interfaces;
using Atividade01.Models;
using System.Reflection.PortableExecutable;

namespace Atividade01.Services
{
    public class ClienteService : IClienteService
    {
        private ClienteDAO _clienteDAO;

        public ClienteService(string connectionString)
        {
            _clienteDAO = new ClienteDAO(connectionString);
        }

        public void AdicionarCliente(string pNome, string pEmail)
        {
            if (string.IsNullOrWhiteSpace(pNome) || string.IsNullOrWhiteSpace(pEmail))
                throw new Exception("Nome e o Email são obrigatórios.");

            _clienteDAO.Incluir(pNome, pEmail);
        }

        // || - OU - Se isso ou aquilo { faça isso }
        // && - E - Se isso e Aquilo { faça isso }
        // NOT - Não - ! - 

        public void AtualizarCliente(Cliente pCliente)
        {
            if (pCliente == null)
                throw new Exception("Cliente Inválido");

            if (string.IsNullOrWhiteSpace(pCliente.Nome) || string.IsNullOrWhiteSpace(pCliente.Email))
                throw new Exception("Nome e o Email são obrigatórios.");

            _clienteDAO.Atualizar(pCliente);
        }

        public Cliente BuscarCliente(int pId)
        {
            return _clienteDAO.BuscarPorId(pId);
        }

        public List<Cliente> ListarClientes()
        {
            return _clienteDAO.ListarTodos();
        }

        public void RemoverCliente(int pId)
        {
            Cliente cliente = _clienteDAO.BuscarPorId(pId);

            if (cliente == null)
                throw new Exception("O Cliente não foi encontrado");

            _clienteDAO.Deletar(pId);
        }
    }
}
