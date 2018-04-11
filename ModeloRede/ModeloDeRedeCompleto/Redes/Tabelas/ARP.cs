using System.Collections.Generic;
using ModeloDeRede.Redes.Enderecos;

namespace ModeloDeRede.Redes.Tabelas
{
    public class ARP
    {
        private IDictionary<Endereco, EnderecoMAC> ipToMac;
        private IDictionary<EnderecoMAC, Endereco> macToIp;

        public ARP()
        {
            ipToMac = new Dictionary<Endereco, EnderecoMAC>();
            macToIp = new Dictionary<EnderecoMAC, Endereco>();

            // O byte alto não deve ser ímpar em um endereço MAC, senão é multicast.

            Adicionar(new Endereco("192.23.23.23"), new EnderecoMAC("00.01.02.03.04.05"));
            Adicionar(new Endereco("192.23.12.12"), new EnderecoMAC("24.88.90.00.FF.AB"));
            Adicionar(new Endereco("192.23.89.41"), new EnderecoMAC("AA.CD.EF.00.AA.54"));
        }

        private void Adicionar(Endereco endereco, EnderecoMAC enderecoMac)
        {
            ipToMac.Add(endereco,enderecoMac);
            macToIp.Add(enderecoMac,endereco);
        }

        public bool ContemEndereco(Endereco endereco) => ipToMac.ContainsKey(endereco);
        public bool ContemEnderecoMAC(EnderecoMAC enderecoMac) => macToIp.ContainsKey(enderecoMac);
        public Endereco ObterEndereco(EnderecoMAC enderecoMac) => macToIp[enderecoMac];
        public EnderecoMAC ObterEnderecoMac(Endereco endereco) => ipToMac[endereco];
    }
}