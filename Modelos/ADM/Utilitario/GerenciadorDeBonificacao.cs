using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bytebank_atendimento.Modelos.ADM.Funcionarios;

namespace bytebank_atendimento.Modelos.ADM.Utilitario
{
    public class GerenciadorDeBonificacao
    {
        public double TotalDeBonificacao { get; private set; }

        public void Registrar(Funcionario func) {
            this.TotalDeBonificacao += func.GetBonificacao();
        }
    }
}