using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bytebank_atendimento.Modelos.Conta
{
    public class SaldoInsuficienteException: OperacaoFinanceiraException
    {
        public SaldoInsuficienteException(string msg): base(msg) 
        {}
    }
}