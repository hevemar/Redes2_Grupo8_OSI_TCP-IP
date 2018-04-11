using System;
using System.Collections.Generic;
using ModeloDeRede.Redes.Enderecos;
using ModeloDeRede.Redes.Teste;

namespace ModeloDeRede.Redes.Camadas
{
    /// <summary>
    /// Camada 4: Transporte
    /// </summary>
    public abstract class Transporte : Camada
    {
        private readonly IDictionary<int, Aplicacao> portasPorAplicacao; //Associação das portas e aplicações

        public Transporte() => portasPorAplicacao = new Dictionary<int, Aplicacao>();

        public void Adicionar(int porta, Aplicacao aplicacao) => portasPorAplicacao.Add(porta, aplicacao);

        public Aplicacao this[int porta] => portasPorAplicacao[porta];

        public void EnviarMensagem(int portaOrigem, Endereco destino, int portaDestino, Mensagem mensagem)
        {
            TesteDeRede.ExibirEtapa();

            //Transmitir para a camada de Transporte
            var novaMensagem = new Mensagem(GetCabecalho(portaOrigem, destino, portaDestino, mensagem));
            novaMensagem.Adicionar(mensagem);
            Console.WriteLine($"Eu sou {Nome} e envio {mensagem.Tamanho} bytes: {novaMensagem}");
            ((Rede) menosUm).EnviarMensagem(destino, novaMensagem);
        }

        public void ReceberMensagem(Endereco enderecoOrigem, Mensagem mensagem)
        {
            TesteDeRede.ExibirEtapa();

            var portaOrigem = mensagem.ExtrairTudo(0);
            mensagem.Remover(2);

            var portaDest = mensagem.ExtrairTudo(0);
            mensagem.Remover(6); //Remove o resto do cabeçalho UDP.

            Console.WriteLine($"Eu sou {Nome} depois de excluir o cabeçalho tenho {mensagem.Tamanho} bytes: {mensagem}");

            var app = this[portaDest];
            if (app == null)
                Console.WriteLine($"Nenhuma aplicação escutando a porta {portaDest} nesta máquina.");
            else
                app.ReceberMensagem(enderecoOrigem, portaOrigem, mensagem);
        }

        protected abstract Mensagem GetCabecalho(int portaOrigem, Endereco destino, int portaDestino, Mensagem mensagem);
    }
}