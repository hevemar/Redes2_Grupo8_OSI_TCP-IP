using System;

namespace ModeloTcpIp.Camada
{
    /// <summary>
    /// Camada 2: Internet
    /// <para>Corresponde a camada Rede do Modelo OSI</para>
    /// </summary>
    public class Internet
    {
        /// <summary>
        /// Camada superior
        /// </summary>
        public Transporte Transporte { get; set; }

        /// <summary>
        /// Camada inferior
        /// </summary>
        public InterfaceDeRede InterfaceDeRede { get; set; }

        private string Maquina => Transporte.Aplicacao.NomeMaquina;

        public void EnviarCamadaInferior(string dados)
        {
            Console.WriteLine($"{Maquina}: Recebendo dados da camada superior \"{nameof(Transporte)}\". Dados: {dados}");
            Console.WriteLine($"{Maquina}: Enviando dados para a camada inferior \"{nameof(InterfaceDeRede)}\"");
            InterfaceDeRede.EnviarParaVizinho(dados);
        }

        public void EnviarSuperior(string dados)
        {
            Console.WriteLine($"{Maquina}: Recebendo dados da camada inferior \"{nameof(InterfaceDeRede)}\". Dados: {dados}");
            Console.WriteLine($"{Maquina}: Enviando dados para a camada superior \"{nameof(Transporte)}\"");
            Transporte.EnviarCamadaSuperior(dados);
        }
    }
}