using Atividade01.Models;
using Atividade01.Services;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder()
    .SetBasePath("Z:\\Aulas\\dotnet\\Csharp\\Atividade01\\Atividade01")
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var configuration = builder.Build();

// Obtenção da string de conexão
string connectionString = configuration.GetConnectionString("ConexaoPadrao");

ClienteService clienteService = new ClienteService(connectionString);

int opcao;
do
{
    Console.Clear();
    Console.WriteLine("==== MENU ====");
    Console.WriteLine("1 - Cadastrar Cliente");
    Console.WriteLine("2 - Listar Clientes");
    Console.WriteLine("3 - Atualizar Cliente");
    Console.WriteLine("4 - Remover Cliente");
    Console.WriteLine("5 - Cadastrar Pedido");
    Console.WriteLine("6 - Listar Pedidos por Cliente");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha uma opção: ");
    opcao = int.Parse(Console.ReadLine());

    switch (opcao)
    {
        case 1: CadastrarCliente(); break;
        case 2: ListarClientes(); break;
        case 3: AtualizarCliente(); break;
        case 4: RemoverCliente(); break;
        case 0: Console.WriteLine("Saindo..."); break;
        default: Console.WriteLine("Opção inválida!"); break;
    }

    if (opcao != 0)
    {
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

} while (opcao != 0);


void CadastrarCliente()
{
    Console.WriteLine("\n== Cadastro de Cliente ==");
    Console.Write("Nome: ");
    string nome = Console.ReadLine();
    Console.Write("Email: ");
    string email = Console.ReadLine();

    clienteService.AdicionarCliente(nome, email);
    Console.WriteLine("Cliente cadastrado com sucesso!");
}

void ListarClientes()
{
    Console.WriteLine("\n== Lista de Clientes ==");
    List<Cliente> clientes = clienteService.ListarClientes();

    foreach (Cliente c in clientes)
    {
        Console.WriteLine($"ID: {c.Id} | Nome: {c.Nome} | Email: {c.Email}");
    }
}

void AtualizarCliente()
{
    Console.WriteLine("\n== Atualizar Cliente ==");
    Console.Write("ID do Cliente: ");
    int id = int.Parse(Console.ReadLine());

    Cliente cliente = clienteService.BuscarCliente(id);
    if (cliente == null)
    {
        Console.WriteLine("Cliente não encontrado.");
        return;
    }

    Console.Write("Novo Nome: ");
    cliente.Nome = Console.ReadLine();
    Console.Write("Novo Email: ");
    cliente.Email = Console.ReadLine();

    clienteService.AtualizarCliente(cliente);
    Console.WriteLine("Cliente atualizado com sucesso!");
}

void RemoverCliente()
{
    Console.WriteLine("\n== Remover Cliente ==");
    Console.Write("ID do Cliente: ");
    int id = int.Parse(Console.ReadLine());

    clienteService.RemoverCliente(id);
    Console.WriteLine("Cliente removido com sucesso!");
}
