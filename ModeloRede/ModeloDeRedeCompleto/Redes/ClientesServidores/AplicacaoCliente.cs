using System;
using ModeloDeRede.Redes.Camadas;
using ModeloDeRede.Redes.Enderecos;

namespace ModeloDeRede.Redes.ClientesServidores
{
    public class AplicacaoCliente : Aplicacao
    {
        public AplicacaoCliente(int porta, Maquina maquina, ClienteDNS clienteDns) : base(porta, maquina, clienteDns)
        {
        }

        /// <summary>
        /// Recebe mensagem de uma camada inferior
        /// </summary>
        /// <param name="enderecoOrigem"></param>
        /// <param name="portaOrigem"></param>
        /// <param name="mensagem"></param>
        public override void ReceberMensagem(Endereco enderecoOrigem, int portaOrigem, Mensagem mensagem)
        {
            Console.WriteLine($"Eu sou {Nome} e recebo {mensagem}.");
            resultado = mensagem;
        }
    }
}