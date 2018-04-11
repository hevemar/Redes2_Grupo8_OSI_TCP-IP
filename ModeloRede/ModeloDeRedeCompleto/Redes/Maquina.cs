using System.Collections.Generic;
using ModeloDeRede.Redes.Camadas;
using ModeloDeRede.Redes.ClientesServidores;
using ModeloDeRede.Redes.Enderecos;

namespace ModeloDeRede.Redes
{
    public class Maquina
    {
        private string nome;
        private Endereco endereco;
        private EnderecoMAC enderecoMac;
        private Endereco mascara;
        private ClienteDNS clienteDNS;
        private Ethernet ethernet;
        private IP ip;
        private UDP udp;
        private IList<Aplicacao> aplicacoes;

        public ClienteDNS ClienteDNS => clienteDNS;
        public Ethernet Ethernet => ethernet;
        public string NomeMaquina => nome;
        public Endereco EnderecoIP => endereco;
        public EnderecoMAC EnderecoMAC => enderecoMac;
        public Endereco MascaraDeRede => mascara;
        public IP IP => ip;
        public UDP UDP => udp;

        public Maquina(string nome, Endereco ipAddress, EnderecoMAC enderecoMac, Endereco mascara)
        {
            this.nome = nome;
            endereco = ipAddress;
            this.enderecoMac = enderecoMac;
            this.mascara = mascara;


            /** Criação das camadas */
            ethernet = new Ethernet(enderecoMac);
            ip = new IP(endereco, mascara);
            udp = new UDP();
            aplicacoes = new List<Aplicacao>();

            /** Cliente DNS */
            clienteDNS = new ClienteDNS(1024, this);
            Adicionar(1024, clienteDNS);
        }

        public void Adicionar(int porta, Aplicacao aplicacao)
        {
            //Camadas superiores
            udp.SetCamadaSuperior(aplicacao);
            ip.SetCamadaSuperior(udp);
            ethernet.SetCamadaSuperior(ip);

            //Camadas inferiores
            aplicacao.SetCamadaInferior(udp);
            udp.SetCamadaInferior(ip);
            ip.SetCamadaInferior(ethernet);

            udp.Adicionar(porta, aplicacao);
            aplicacoes.Add(aplicacao);
        }

        /// <summary>
        /// Conecta este PC a outra máquina
        /// </summary>
        public void Conectar(Maquina maquina)
        {
            ethernet.SetVizinho(maquina.ethernet);
            maquina.ethernet.SetVizinho(ethernet);
        }
    }
}