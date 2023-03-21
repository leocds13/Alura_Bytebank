using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bytebank_atendimento.Modelos.Conta;

namespace bytebank_atendimento.Utils
{
  public class ListaDeContasCorrentes
  {
    private List<ContaCorrente> _itens = new List<ContaCorrente>();

    public void Adicionar(ContaCorrente item)
    {
      _itens.Add(item);
    }

    public void Remover(ContaCorrente item)
    {
      _itens.Remove(item);
    }

    public void ExibeLista()
    {
        _itens.ForEach(item => {
            System.Console.WriteLine($"Conta:{item.Conta}, Nº Agencia:{item.NumeroAgencia}");
        });
    }

    public ContaCorrente this[int indice]
    {
        get
        {
            return _itens[indice];
        }
    }
  }
}