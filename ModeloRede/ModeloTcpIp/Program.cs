using ModeloTcpIp.Camada;

namespace ModeloTcpIp
{
    class Program
    {
        static void Main(string[] args)
        {
            var aplicacaoDesktop = new Aplicacao("Desktop");
            var aplicacaoNotebook = new Aplicacao("Notebook");

            //Monta as camadas sobre a aplicacaoDesktop
            {
                var transporte = new Transporte();
                var internet = new Internet();
                var interfaceDeRede = new InterfaceDeRede();

                //Relacionar as camadas
                {
                    //relaciona as camadas superiores
                    interfaceDeRede.Internet = internet;
                    internet.Transporte = transporte;
                    transporte.Aplicacao = aplicacaoDesktop;

                    //relaciona as camadas inferiores
                    aplicacaoDesktop.Transporte = transporte;
                    transporte.Internet = internet;
                    internet.InterfaceDeRede = interfaceDeRede;
                }
            }

            //Monta as camadas sobre a aplicacaoNotebook
            {
                var transporte = new Transporte();
                var internet = new Internet();
                var interfaceDeRede = new InterfaceDeRede();

                //Relacionar as camadas
                {
                    //relaciona as camadas superiores
                    interfaceDeRede.Internet = internet;
                    internet.Transporte = transporte;
                    transporte.Aplicacao = aplicacaoNotebook;

                    //relaciona as camadas inferiores
                    aplicacaoNotebook.Transporte = transporte;
                    transporte.Internet = internet;
                    internet.InterfaceDeRede = interfaceDeRede;
                }
            }

            //"Conecta" as máquinas/interfaces de rede
            {
                aplicacaoNotebook.Transporte.Internet.InterfaceDeRede.Vizinho = aplicacaoDesktop.Transporte.Internet.InterfaceDeRede;
                aplicacaoDesktop.Transporte.Internet.InterfaceDeRede.Vizinho = aplicacaoNotebook.Transporte.Internet.InterfaceDeRede;
            }

            aplicacaoDesktop.EnviarCamadaInferior("Teste de mensagem TCP/IP");
        }
    }
}
