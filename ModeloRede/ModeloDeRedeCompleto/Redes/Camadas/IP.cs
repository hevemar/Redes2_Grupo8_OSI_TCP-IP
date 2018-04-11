using System;
using ModeloDeRede.Redes.Enderecos;
using ModeloDeRede.Redes.Tabelas;
using ModeloDeRede.Redes.Teste;

namespace ModeloDeRede.Redes.Camadas
{
    /// <summary>
    /// Implementação da camada 3 - Rede
    /// </summary>
    public class IP : Rede
    {
        private static int contador = 0;
        protected Endereco mascaraDeRede;
        private ARP arp = new ARP();

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="enderecoIpLocal">Endereço IP desta máquina</param>
        /// <param name="mascaraDeRede">Máscara de Rede</param>
        public IP(Endereco enderecoIpLocal, Endereco mascaraDeRede) : base(enderecoIpLocal) =>
            this.mascaraDeRede = mascaraDeRede;

        public override void ReceberMensagem(Mensagem mensagem)
        {
            TesteDeRede.ExibirEtapa();

            var enderecoOrigem = arp.ObterEndereco(mensagem.ExtrairMacAdress());
            mensagem.Remover(15); //Remove o MAC + início do cabeçalho

            var enderecoDestino = mensagem.ExtrairEndereco(4);
            mensagem.Remover(4);

            Console.WriteLine($"Eu sou {Nome} depois de remover o cabeçalho recebo {mensagem.Tamanho} bytes {mensagem}");

            if (enderecoDestino.Equals(this.enderecoIp))
                ((Transporte)maisUm).ReceberMensagem(enderecoOrigem, mensagem); //Envia o endereço de origem
            else
                Console.WriteLine($"Endereço de IP incorreto. Destino {enderecoDestino}. Host: {enderecoIp}");
        }

        public override void EnviarMensagem(Endereco ipDestino, Mensagem mensagem)
        {
            TesteDeRede.ExibirEtapa();
            var novaMensagem = new Mensagem(GetCabecalho(ipDestino, mensagem));
            novaMensagem.Adicionar(mensagem);

            var mascaraOrigem = new Endereco(enderecoIp);
            mascaraOrigem.AplicarMascara(mascaraDeRede);

            var mascaraDestino = new Endereco(ipDestino);
            mascaraDestino.AplicarMascara(mascaraDeRede);

            // Verifica se ambos pertencem a mesma rede
            if (mascaraOrigem.Equals(mascaraDestino))
                if (arp.ContemEndereco(ipDestino))
                    ((Enlace)menosUm).EnviarMensagem(arp.ObterEnderecoMac(ipDestino), novaMensagem);
                else
                    Console.WriteLine($"Endereço IP: {ipDestino} não encontrado na tabela ARP.");
            else
                Console.WriteLine("A máquina de origem e destino não pertencem a mesma rede local.");
        }

        public Mensagem GetCabecalho(Endereco destino, Mensagem mensagem)
        {
            /*
             * Comprimento total: 16 bits
             * Identificação: 16 bits
             * Protocolo: 8 bits
             * Endereço IP de origem: 32 bits
             * Endereço IP de destino: 32 bits
             */

            var novaMensagem = new Mensagem(destino.Tamanho + mensagem.Tamanho, 0);
            short protocolo = 0;
            novaMensagem.Adicionar(protocolo);
            novaMensagem.Adicionar(enderecoIp);
            novaMensagem.Adicionar(destino);

            return novaMensagem;
        }
    }
}