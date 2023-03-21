using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bytebank_atendimento.Modelos.ADM.Funcionarios
{
    public class Designer : Funcionario
    {
        public Designer(string nome, string cpf) : base(nome, cpf, 3000)
        {
        }

        public Designer(string nome, string cpf, double salario) : base(nome, cpf, salario)
        {
        }

        public override double GetBonificacao()
        {
            return this.Salario * 0.17;
        }

        public override void AumentarSalario()
        {
            this.Salario *= 1.11;
        }
    }
}