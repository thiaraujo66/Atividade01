using Atividade01.DAO;
using Atividade01.Interfaces;

namespace Atividade01.Services
{
    public class ClienteService : IClienteService
    {
        private ClienteDAO _clienteDAO;
        public ClienteService(string connectionString)
        {
            _clienteDAO = new ClienteDAO(connectionString);
        }
    }
}
