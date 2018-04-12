using System;

namespace ModeloTcpIp.Camada
{
    /// <summary>
    /// Camada 4
    /// </summary>
    public class Aplicacao
    {
        public string NomeMaquina { get; }

        public Aplicacao(string nomeMaquina)
        {
            NomeMaquina = nomeMaquina;
        }

        /// <summary>
        /// Camada inferior
        /// </summary>
        public Transporte Transporte { get; set; }



        public void EnviarCamadaInferior(string dados)
        {
            Console.WriteLine($"Enviando para a camada inferior {nameof(Transporte)}. Dados: {dados}");
            Transporte.EnviarCamadaInferior(dados);
        }

        public void EnviarParaAplicacao(string dados)
        {
            Console.WriteLine($"{NomeMaquina} Camada 4 - Aplicação:  Dados recebidos: {dados}");
        }
    }
}