using System;
using ModeloDeRede.Redes.Camadas;
using ModeloDeRede.Redes.Enderecos;
using ModeloDeRede.Redes.Tabelas;

namespace ModeloDeRede.Redes.ClientesServidores
{
    public class ServidorDNS : Aplicacao
    {
        private readonly DNS tabelaDNS;

        public ServidorDNS(int porta, Maquina maquina, DNS tabelaDNS) : base(porta, maquina) =>
            this.tabelaDNS = tabelaDNS;

        protected override Mensagem Tratar(Mensagem mensagem)
        {
            var nomeMaquina = mensagem.ExtrairTexto();

            Console.WriteLine("Servidor: Acessando tabela DNS");

            if (tabelaDNS.MaquinaConhecida(nomeMaquina))
            {
                var dest = tabelaDNS.ObterEndereco(nomeMaquina);
                return new Mensagem(dest);
            }

            Console.WriteLine($"Máquina {nomeMaquina} desconhecida para o servidor DNS.");
            return null;
        }
    }
}