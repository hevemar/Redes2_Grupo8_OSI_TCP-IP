using System;
using ModeloDeRede.Redes.Camadas;

namespace ModeloDeRede.Redes.ClientesServidores
{
    public class ServidorDeMaiusculizacao : Aplicacao
    {
        public ServidorDeMaiusculizacao(int porta, Maquina maquina, ClienteDNS clienteDns) 
            : base(porta, maquina, clienteDns)
        {
        }

        protected override Mensagem Tratar(Mensagem mensagem)
        {
            Console.WriteLine("Servidor: Maiusculização de mensagem");

            var texto = mensagem.ExtrairTexto();
            Console.WriteLine($"Texto: {texto}");
            texto = texto.ToUpper();
            return new Mensagem(texto);
        }
    }
}