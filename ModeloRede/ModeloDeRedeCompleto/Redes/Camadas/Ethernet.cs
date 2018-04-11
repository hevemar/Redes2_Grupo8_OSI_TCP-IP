using System;
using ModeloDeRede.Redes.Enderecos;

namespace ModeloDeRede.Redes.Camadas
{
    /// <summary>
    /// Camada 1 - Física
    /// </summary>
    public class Ethernet : Enlace
    {
        public Ethernet(EnderecoMAC macAddress) : base(macAddress)
        {
        }

        public override void EnviarMensagem(EnderecoMAC destino, Mensagem mensagem)
        {
            var cabecalho = GetCabecalho(destino, mensagem);
            var novaMensagem = new Mensagem(cabecalho);
            novaMensagem.Adicionar(mensagem);

            Console.WriteLine($"Eu sou {Nome} e envio {mensagem.Tamanho} bytes: {novaMensagem}");
            Console.WriteLine("***** Transmitindo para rede local... *****");

            rede.EnviarQuadro(novaMensagem);
        }

        public override void ReceberMensagem(Mensagem mensagem)
        {
            Teste.TesteDeRede.ExibirEtapa();
            if (mensagem.Tamanho > 5)
            {
                var mac = mensagem.ExtrairMacAdress();

                //Verifica se a mensagem é para este host.
                if (mac.Equals(macAddress))
                {
                    mensagem.Remover(6); //Remove os 48bits do cabeçalho, deixando o MAC de origem para depois.
                    Console.WriteLine($"Eu sou {Nome} depois de remover o cabeçalho tenho {mensagem.Tamanho} bytes: {mensagem}");
                    ((Rede)maisUm).ReceberMensagem(mensagem);
                }
                else
                    Console.WriteLine($"Esta mensagem não é para este host. Origem: {mac}. Este host: {macAddress}.");
            }
            else
                Console.WriteLine("A mensagem não contém bytes suficientes.");
        }

        protected virtual Mensagem GetCabecalho(EnderecoMAC enderecoMacDestino, Mensagem mensagem)
        {
            var novaMensagem = new Mensagem(enderecoMacDestino);
            novaMensagem.Adicionar(macAddress);

            return novaMensagem;
        }
    }
}