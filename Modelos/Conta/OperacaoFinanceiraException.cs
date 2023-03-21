using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bytebank_atendimento.Modelos.Conta
{
    public class OperacaoFinanceiraException : Exception
    {
        public OperacaoFinanceiraException()
        {}
        public OperacaoFinanceiraException(string msg): base(msg)
        {}
        public OperacaoFinanceiraException(string msg, Exception innerEx): base(msg, innerEx)
        {}
    }
}