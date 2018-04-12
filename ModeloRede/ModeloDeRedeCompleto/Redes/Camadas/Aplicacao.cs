using System;
using ModeloDeRede.Redes.ClientesServidores;
using ModeloDeRede.Redes.Enderecos;
using ModeloDeRede.Redes.Teste;

namespace ModeloDeRede.Redes.Camadas
{
    /// <summary>
    /// Camada 7: Aplicação
    /// <para>Funções especialistas (transferência de arquivos, envio de e-mail, terminal virtual)</para>
    /// </summary>
    public class Aplicacao : Camada
    {
        private int porta;
        protected Mensagem resultado;
        private Maquina maquina;
        private ClienteDNS clienteDns;

        public Mensagem Resultado => resultado;

        public Aplicacao(int porta, Maquina maquina, ClienteDNS clienteDns)
        {
            this.porta = porta;
            this.maquina = maquina;
            this.clienteDns = clienteDns;
        }

        public Aplicacao(int porta, Maquina maquina)
        : this(porta, maquina, null)
        {
        }

        public virtual void EnviarMensagem(Endereco destino, int portaDestino, Mensagem mensagem)
        {
            TesteDeRede.ExibirEtapa();

            resultado = null; //Exclui o resultado da consulta anterior.

            Console.WriteLine($"Eu sou {Nome} e envio {mensagem.Tamanho} bytes: {mensagem}");

            ((Transporte)menosUm).EnviarMensagem(porta, destino, portaDestino, mensagem);
        }


        public void EnviarMensagem(string nomeMaquina, int portaDestino, Mensagem mensagem)
        {
            TesteDeRede.ExibirEtapa();

            resultado = null;

            clienteDns.ConsultarServidorDNS(new Mensagem(nomeMaquina));
            var infoDNS = clienteDns.resultado;

            if (infoDNS != null)
            {
                var destino = infoDNS.ExtrairEndereco(4);
                ((Transporte)menosUm).EnviarMensagem(porta, destino, portaDestino, mensagem);
            }
            else
                Console.WriteLine($"Máquina {nomeMaquina} desconhecida pelo servidor DNS");
        }


        /// <summary>
        /// Recebe mensagem de uma camada inferior
        /// </summary>
        /// <param name="enderecoOrigem"></param>
        /// <param name="portaOrigem"></param>
        /// <param name="mensagem"></param>
        public virtual void ReceberMensagem(Endereco enderecoOrigem, int portaOrigem, Mensagem mensagem)
        {
            TesteDeRede.ExibirEtapa();

            mensagem = Tratar(mensagem);
            resultado = mensagem;

            Console.WriteLine("\n - - - - - - - FIM DO TRATAMENTO - - - - - - - -");
            Console.WriteLine($"Eu sou {Nome} e envio {mensagem.Tamanho} bytes: {mensagem}");

            EnviarMensagem(enderecoOrigem, portaOrigem, mensagem);
        }



        protected virtual Mensagem Tratar(Mensagem mensagem) => mensagem;

        public Mensagem Mensagem => resultado;

        public int Porta => porta;

        public Maquina Maquina => maquina;
    }
}