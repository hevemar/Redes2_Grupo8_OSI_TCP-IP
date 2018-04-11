using System;
using ModeloDeRede.Redes.Camadas;

namespace ModeloDeRede.Redes.ClientesServidores
{
    public class ServidorMultiplicaPorDois : Aplicacao
    {
        public ServidorMultiplicaPorDois(int porta, Maquina maquina, ClienteDNS clienteDns)
            : base(porta, maquina, clienteDns)
        {
        }

        protected override Mensagem Tratar(Mensagem mensagem)
        {
            Console.WriteLine("Servidor: Calcular o dobro do valor");
            var valor = mensagem.ExtrairTudo(0);
            var result = valor * 2;

            return new Mensagem(result);
        }
    }
}