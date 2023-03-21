using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bytebank_atendimento.Modelos.ADM.SistemaInterno;

namespace bytebank_atendimento.Modelos.ADM.Parceria
{
    public class ParceiroComercial: IAutenticavel
    {
        public string Senha { get; private set; }
        public string Login { get; private set; }

        public ParceiroComercial(string login, string senha)
        {
            this.Login = login;
            this.Senha = senha;
        }
    }
}