using bytebank_atendimento.Exceptions;
using bytebank_atendimento.Modelos.Conta;

namespace bytebank_atendimento.Atendimento
{
  public class ByteBankAtendimento
  {
    private List<ContaCorrente> _listaDeContas = new List<ContaCorrente>()
        {
          new ContaCorrente(new Cliente("Cliente 3", "356776548"), 95, "345678-X"){ Saldo = 60 },
          new ContaCorrente(new Cliente("Cliente 1", "123456789"), 95, "123456-X"){ Saldo = 100 },
          new ContaCorrente(new Cliente("Cliente 2", "345677864"), 95, "567898-X"){ Saldo = 200 },
        };

    public void AtendimentoCliente()
    {
      char? opcao = '0';

      while (opcao != '6')
      {
        try
        {
          Console.Clear();
          Console.WriteLine("======================================");
          Console.WriteLine("===          Atendimento           ===");
          Console.WriteLine("=== 1 - Cadastrar Conta            ===");
          Console.WriteLine("=== 2 - Listar Contas              ===");
          Console.WriteLine("=== 3 - Remover Conta              ===");
          Console.WriteLine("=== 4 - Ordenar Contas             ===");
          Console.WriteLine("=== 5 - Pesquisar Conta            ===");
          Console.WriteLine("=== 6 - Sair do Sistema            ===");
          Console.WriteLine("======================================");
          Console.WriteLine("\n\n");
          Console.Write("Digite a opção desejada: ");
          try
          {
            opcao = (char?)Console.ReadLine()?[0];
          }
          catch (Exception)
          {
            throw new ByteBankException("Identificamos que você não informou uma opção!\nPor favor informe uma.");
          }

          switch (opcao)
          {
            case '1':
              CadastrarConta();
              break;
            case '2':
              ListarContas();
              break;
            case '3':
              RemoverConta();
              break;
            case '4':
              OrdenarContas();
              break;
            case '5':
              PesquisarConta();
              break;
            case '6':
              Console.WriteLine("Saindo");
              Console.ReadKey();
              break;
            default:
              Console.WriteLine("Opção não identificada ou implementada.");
              Console.ReadKey();
              break;
          }
        }
        catch (ByteBankException ex)
        {
          Console.WriteLine(ex.Message);
          Console.ReadKey();
        }
      }
    }

    private void ListarContas()
    {
      Console.Clear();
      Console.WriteLine("======================================");
      Console.WriteLine("===        LISTA DE CONTAS         ===");
      Console.WriteLine("======================================");
      Console.WriteLine("\n");

      ExibirListaDeContas(_listaDeContas);
    }

    private void CadastrarConta()
    {
      Console.Clear();
      Console.WriteLine("======================================");
      Console.WriteLine("===       CADASTRO DE CONTAS       ===");
      Console.WriteLine("======================================");
      Console.WriteLine("\n");
      Console.WriteLine("===     Informe dados da conta     ===");

      Console.Write("Nome do Cliente: ");
      string? nome = Console.ReadLine();

      Console.Write("CPF do Cliente: ");
      string? cpf = Console.ReadLine();

      Console.Write("Número da Agência: ");
      string? vlDigitado = Console.ReadLine();
      int? numeroAgencia = vlDigitado != null ? int.Parse(vlDigitado!) : null;

      if (nome == null || cpf == null || numeroAgencia == null)
      {
        Console.WriteLine("Necessário informar os campos acima!");
        return;
      }

      ContaCorrente conta = new ContaCorrente(new Cliente(nome, cpf), (int)numeroAgencia);

      Console.Write("Informe o saldo inicial: ");
      conta.SetSaldo(double.Parse(Console.ReadLine()!));

      _listaDeContas.Add(conta);

      Console.WriteLine("... Conta cadastrada com sucesso! ...");
      Console.WriteLine($"Número da conta [NOVA] : {conta.Conta}");

      Console.ReadKey();
    }

    private void RemoverConta()
    {
      Console.Clear();
      Console.WriteLine("======================================");
      Console.WriteLine("===       CADASTRO DE CONTAS       ===");
      Console.WriteLine("======================================");
      Console.WriteLine("\n");

      Console.WriteLine("Informe o número da Conta: ");
      string numeroConta = Console.ReadLine();

      ContaCorrente conta = null;

      foreach (var item in _listaDeContas)
      {
        if (item.Conta.Equals(numeroConta))
        {
          conta = item;
        }
      }

      if (conta != null)
      {
        _listaDeContas.Remove(conta);
        Console.WriteLine("... Conta removida da lista! ...");
      }
      else
      {
        Console.WriteLine("... Conta para remoção não encontrada ...");
      }

      Console.ReadKey();
    }

    private void OrdenarContas()
    {
      _listaDeContas.Sort();
      Console.WriteLine("... Lista de contas ordenada ...");
      Console.ReadKey();
    }

    private void PesquisarConta()
    {
      Console.Clear();
      Console.WriteLine("======================================");
      Console.WriteLine("===        LISTA DE CONTAS         ===");
      Console.WriteLine("======================================");
      Console.WriteLine("\n");
      Console.Write("Deseja pesquisar por\n " +
        "(1) NUMERO DA CONTA\n " +
        "(2) CPF DO TITULAR?\n " +
        "(3) NUMERO AGENCIA\n " +
        "Sua escolha: ");

      int opcao = int.Parse(Console.ReadLine() ?? "0");

      ContaCorrente? consultaConta = null;
      switch (opcao)
      {
        case 1:
          Console.Write("Informe o número da Conta: ");
          string _numeroConta = Console.ReadLine();
          consultaConta = ConsultaPorNumeroConta(_numeroConta);
          break;
        case 2:
          Console.Write("Informe o CPF do Titular: ");
          string _cpf = Console.ReadLine();
          consultaConta = ConsultaPorCPFTitular(_cpf);
          break;
        case 3:
          Console.Write("Informe o Numero da Agencia: ");
          int _agencia = int.Parse(Console.ReadLine());
          var consultaContas = ConsultaPorAgencia(_agencia);

          ExibirListaDeContas(consultaContas);

          return;
        default:
          Console.Write("Opção Inválida!");
          Console.ReadKey();
          return;
      }

      if (consultaConta != null)
      {
        Console.WriteLine(consultaConta.ToString());
      }
      else
      {
        Console.WriteLine("Conta não encontrada");
      }
      Console.ReadKey();
    }

    private List<ContaCorrente> ConsultaPorAgencia(int? agencia)
    {
      var consulta = (
        from conta in _listaDeContas
        where conta.NumeroAgencia == agencia
        select conta).ToList();

      return consulta;
    }

    private ContaCorrente? ConsultaPorCPFTitular(string? cpf)
    {
      return _listaDeContas.Find(conta => conta.Titular.CPF.Equals(cpf));
    }

    private ContaCorrente? ConsultaPorNumeroConta(string? numeroConta)
    {
      return _listaDeContas.Find(conta => conta.Conta.Equals(numeroConta));
    }

    private void ExibirListaDeContas(List<ContaCorrente> consultaContas)
    {
      if (consultaContas.Count <= 0)
      {
        Console.WriteLine("... Não há contas para exibir! ...");
        Console.ReadKey();
        return;
      }

      foreach (ContaCorrente conta in consultaContas)
      {
        Console.WriteLine(conta.ToString());
      }
      Console.ReadKey();
    }

  }
}