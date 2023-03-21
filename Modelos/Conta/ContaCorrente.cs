using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bytebank_atendimento.Modelos.Conta
{
  public class ContaCorrente : IComparable<ContaCorrente>
  {
    public static int TotalDeContasCriadas { get; set; }

    public static double TaxaOperacao { get; private set; }

    public Cliente Titular { get; set; }
    private int _numeroAgencia;
    public int NumeroAgencia
    {
      get { return _numeroAgencia; }
      private set
      {
        if (value <= 0) throw new ArgumentException("Numero Agência precisa ser maior que zero", nameof(NumeroAgencia));
        _numeroAgencia = value;
      }
    }
    public string Conta { get; set; }
    private double saldo = 100;
    public double Saldo { get { return saldo; } set { this.SetSaldo(value); } }
    public int ContadorSaquesNaoPermitidos { get; private set; }
    public int ContadorTransferenciasNaoPermitidas { get; private set; }

    public ContaCorrente(Cliente titular, int numeroAgencia, string numeroConta)
    {
      Titular = titular;
      NumeroAgencia = numeroAgencia;
      Conta = numeroConta;

      try
      {
        TaxaOperacao = 30 / TotalDeContasCriadas;
      }
      catch (DivideByZeroException)
      {
        System.Console.WriteLine("Ocorreu um erro! Foi feita a tentativa de uma divisão por zero.");
      }

      TotalDeContasCriadas++;
    }

    public ContaCorrente(Cliente titular, int numeroAgencia)
    {
      Titular = titular;
      NumeroAgencia = numeroAgencia;
      Conta = Guid.NewGuid().ToString().Substring(0, 8);

      try
      {
        TaxaOperacao = 30 / TotalDeContasCriadas;
      }
      catch (DivideByZeroException)
      {
        System.Console.WriteLine("Ocorreu um erro! Foi feita a tentativa de uma divisão por zero.");
      }

      TotalDeContasCriadas++;
    }

    public void SetSaldo(double valor)
    {
      saldo = valor < 0 ? saldo : valor;
    }

    public void Depositar(double valor)
    {
      saldo += valor;
    }

    public bool Sacar(double valor)
    {
      if (saldo < valor)
      {
        ContadorSaquesNaoPermitidos++;
        throw new SaldoInsuficienteException("Tentativa de sacar um valor maior que saldo disponivel.");
      }

      saldo -= valor;
      return true;
    }

    public bool Transferir(double valor, ContaCorrente destino)
    {
      // if (saldo < valor)
      // {
      //     ContadorSaquesNaoPermitidos++;
      //     throw new SaldoInsuficienteException("Tentativa de transferir um valor maior que saldo disponivel.");
      // }

      try
      {
        Sacar(valor);
      }
      catch (SaldoInsuficienteException ex)
      {
        ContadorTransferenciasNaoPermitidas++;
        throw new OperacaoFinanceiraException("Operação não realizada.", ex);
      }
      destino.Depositar(valor);
      return true;
    }

    public double GetSaldo()
    {
      return saldo;
    }

    public int CompareTo(ContaCorrente? other)
    {
      if (other == null) return 1;

      return this.Titular.Nome.CompareTo(other.Titular.Nome);
    }

    public override string ToString()
    {
      string text = "===  Dados da Conta ===";
      text += "\nTitular da Conta : " + this.Titular.Nome;
      text += "\nCPF do Titular   : " + this.Titular.CPF;
      text += "\nNúmero da Conta  : " + this.Conta;
      text += "\nNúmero da Agencia: " + this.NumeroAgencia;
      text += "\nSaldo da Conta   : " + this.GetSaldo();
      text += "\n>>>>>>>>>>>>>>>>>>>>>>>";

      return text;
    }
  }
}