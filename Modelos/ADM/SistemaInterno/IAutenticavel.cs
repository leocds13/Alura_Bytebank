using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bytebank_atendimento.Modelos.ADM.Funcionarios;

namespace bytebank_atendimento.Modelos.ADM.SistemaInterno
{
    // public abstract class Autenticavel
    public interface IAutenticavel
    {
        public string Login { get; }
        public string Senha { get; }

        // protected Autenticavel(string login, string senha)
        // {
        //     this.Login = login.ToLower();
        //     this.Senha = senha;
        // }

        public virtual bool Autenticar(string login, string senha)
        {
            return this.Senha == senha && this.Login.ToLower() == login.ToLower();
        }
    }
}