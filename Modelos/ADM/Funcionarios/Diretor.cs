using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bytebank_atendimento.Modelos.ADM.SistemaInterno;

namespace bytebank_atendimento.Modelos.ADM.Funcionarios
{
    public class Diretor : FuncionarioAutenticavel
    {

        public Diretor(string nome, string cpf, string login, string senha) : base(nome, cpf, 5000, login, senha)
        {
        }
        public Diretor(string nome, string cpf, double salario, string login, string senha) : base(nome, cpf, salario, login, senha)
        {
        }

        public override double GetBonificacao()
        {
            return this.Salario * 0.5; // 100% + Bonifição de funcionarios
        }

        public override void AumentarSalario()
        {
            this.Salario *= 1.15; // 15%
        }
    }
}