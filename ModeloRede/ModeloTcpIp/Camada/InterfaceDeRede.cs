using System;

namespace ModeloTcpIp.Camada
{
    public class InterfaceDeRede
    {
        /// <summary>
        /// Camada superior
        /// </summary>
        public Internet Internet { get; set; }

        /// <summary>
        /// A outra interface de rede (como se fosse a interface conecata a outra ponta do cabo de rede).
        /// </summary>
        public InterfaceDeRede Vizinho { get; set; }

        private string Maquina => Internet.Transporte.Aplicacao.NomeMaquina;

        public void EnviarParaVizinho(string dados)
        {
            Console.WriteLine($"{Maquina}: Recebendo dados da camada superior \"{nameof(Internet)}\". Dados: {dados}");
            Console.WriteLine($"{Maquina}: Enviando dados para outra maquina.");
            Vizinho.EnviarSuperior(dados);
        }

        private void EnviarSuperior(string dados)
        {
            Console.WriteLine($"{Maquina}: Recebendo dados de outra máquina. Dados {dados}");
            Console.WriteLine($"{Maquina}: Enviando dados para a camada superior \"{nameof(Internet)}\"");
            Internet.EnviarSuperior(dados);
        }
    }
}