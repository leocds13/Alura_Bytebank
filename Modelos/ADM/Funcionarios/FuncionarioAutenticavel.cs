using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bytebank_atendimento.Modelos.ADM.SistemaInterno;

namespace bytebank_atendimento.Modelos.ADM.Funcionarios
{
    public abstract class FuncionarioAutenticavel : Funcionario, IAutenticavel
    {
        public string Login { get; private set; }
        public string Senha { get; private set; }

        public FuncionarioAutenticavel(string nome, string cpf, double salario, string login, string senha) : base(nome, cpf, salario)
        {
            this.Login = login;
            this.Senha = senha;
        }
    }
}