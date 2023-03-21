using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bytebank_atendimento.Modelos.ADM.Funcionarios;
using bytebank_atendimento.Modelos.ADM.Parceria;

namespace bytebank_atendimento.Modelos.ADM.SistemaInterno
{
    public class SistemaInterno
    {
        public bool Logar(IAutenticavel funcionario, string login, string senha) 
        {
            bool usuarioAutenticado = funcionario.Autenticar(login, senha);

            if(usuarioAutenticado)
                Console.WriteLine("Boas Vindas as nosso sistema.");
            else
                Console.WriteLine("Senha incorreta!");

            return usuarioAutenticado;
        }
    }
}