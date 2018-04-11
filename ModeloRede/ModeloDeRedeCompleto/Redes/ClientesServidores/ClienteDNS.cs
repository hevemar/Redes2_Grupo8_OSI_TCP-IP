using System;
using ModeloDeRede.Redes.Camadas;
using ModeloDeRede.Redes.Enderecos;

namespace ModeloDeRede.Redes.ClientesServidores
{
    public class ClienteDNS : Aplicacao
    {
        public ClienteDNS(int porta, Maquina maquina) : base(porta, maquina)
        {
        }

        public override void ReceberMensagem(Endereco origem, int portaOrigem, Mensagem mensagem)
        {
            Console.WriteLine($"Eu sou {Nome} e recebo {mensagem}");
            resultado = mensagem;
        }

        
        /// <summary>
        /// Consulta o servidor DNS da rede local. Seu endereço IP e porta são descobertos neste método.
        /// </summary>
        /// <param name="mensagemNomeMaquina"></param>
        public void ConsultarServidorDNS(Mensagem mensagemNomeMaquina)
        {
            var porta = 1024;
            var portaDestino = 53;
            var destino = new Endereco("192.23.89.41");
            EnviarMensagem(destino, portaDestino, mensagemNomeMaquina);
        }
    }
}