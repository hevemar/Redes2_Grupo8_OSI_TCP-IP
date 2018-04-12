using System;

namespace ModeloTcpIp.Camada
{
    /// <summary>
    /// Camada 3
    /// </summary>
    public class Transporte
    {
        /// <summary>
        /// Camada superior
        /// </summary>
        public Aplicacao Aplicacao { get; set; }

        /// <summary>
        /// Camada inferior
        /// </summary>
        public Internet Internet { get; set; }

        private string Maquina => Aplicacao.NomeMaquina;

        public void EnviarCamadaInferior(string dados)
        {
            Console.WriteLine($"{Maquina}: Recebendo dados da camada superior \"{nameof(Aplicacao)}\". Dados: {dados}");
            Console.WriteLine($"{Maquina}: Enviando para camada inferior \"{Internet}\"");
            Internet.EnviarCamadaInferior(dados);
        }

        public void EnviarCamadaSuperior(string dados)
        {
            Console.WriteLine($"{Maquina}: Recebendo dados da camada inferior \"{nameof(Internet)}\". Dados: {dados}");
            Console.WriteLine($"{Maquina}: Enviando dados para a camada superior \"{nameof(Aplicacao)}\"");
            Aplicacao.EnviarParaAplicacao(dados);
        }
    }
}