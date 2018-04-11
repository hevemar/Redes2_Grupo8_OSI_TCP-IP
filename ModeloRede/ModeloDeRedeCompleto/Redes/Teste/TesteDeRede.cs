using System;
using ModeloDeRede.Redes.Camadas;
using ModeloDeRede.Redes.ClientesServidores;
using ModeloDeRede.Redes.Enderecos;
using ModeloDeRede.Redes.Tabelas;

namespace ModeloDeRede.Redes.Teste
{
    public class TesteDeRede
    {
        private static int etapa;

        public TesteDeRede()
        {
            //Cria o servidor DNS
            var dns = new DNS();
            var mascara = new Endereco("255.255.0.0");


            //Cria um cliente "Notebook"
            var ipNotebook = new Endereco("192.23.23.23");
            var macNotebook = new EnderecoMAC("00.01.02.03.04.05");
            var portaMackBook = 45;

            var notebook = new Maquina("Notebook", ipNotebook, macNotebook, mascara);

            var clientDNS = notebook.ClienteDNS;
            Aplicacao client = new AplicacaoCliente(portaMackBook, notebook, clientDNS);
            notebook.Adicionar(portaMackBook, client);


            //Criação dos Servidores
            var ipServidorHP = new Endereco("192.23.12.12");
            var macServidorHP = new EnderecoMAC("24.88.90.00.FF.AB");
            var portaServidorHP = 888;

            var servidorHP = new Maquina("ServidorHP", ipServidorHP, macServidorHP, mascara);
            Aplicacao servidor = new ServidorMultiplicaPorDois(portaServidorHP, servidorHP, servidorHP.ClienteDNS);
            servidorHP.Adicionar(portaServidorHP, servidor);

            //Adiciona uma nova aplicação ao servidor
            portaServidorHP = 42;
            servidor = new ServidorDeMaiusculizacao(portaServidorHP, servidorHP, servidorHP.ClienteDNS);
            servidorHP.Adicionar(portaServidorHP, servidor);






            //DNS
            var ipServidorOpenDNS = new Endereco("192.23.89.41");
            var macServidorOpenDNS = new EnderecoMAC("AA.CD.EF.00.AA.54");
            var portaServidorOpenDNS = 53; //porta DNS padrão

            var servidorOpenDNS = new Maquina("ServidorOpenDNS", ipServidorOpenDNS, macServidorOpenDNS, mascara);
            var servidorDns = new ServidorDNS(portaServidorOpenDNS, servidorOpenDNS, dns);
            servidorOpenDNS.Adicionar(portaServidorOpenDNS, servidorDns);

            {
                //Adiciona ás máquinas no Cache DNS

                dns.Adicionar(notebook.NomeMaquina, notebook.EnderecoIP);
                dns.Adicionar(servidorHP.NomeMaquina, servidorHP.EnderecoIP);
                dns.Adicionar(servidorOpenDNS.NomeMaquina, servidorOpenDNS.EnderecoIP);
            }




            //Criação da rede local

            var redeLocal = new RedeLocal();
            redeLocal.Adicionar(notebook, servidorHP, servidorOpenDNS);



            Console.WriteLine("\n\n\r\r");

            //*** Utilização das aplicações ***

            {
               /* .1) Servidor de duplicação
                * Descrição: O cliente envia uma mensagem (valor inteiro) ao servidor
                * que irá duplicar o valor
                */

                var valor = 10;
                var mensagem = new Mensagem(valor);
                Console.WriteLine($"Valor a ser duplicado: {valor}");

                client.EnviarMensagem("ServidorHP", 888, mensagem);
                var resul = client.Resultado;
                Console.WriteLine($"O servidor de duplicação retornou o valor {resul.ExtrairTudo(0)}");

                etapa = 0;
            }

            Console.WriteLine("\n\n\n\n");

            {
                /* 2.) Servidor de Maiusulilazação
                 * Descrição: O cliente envia uma mensagem (string) para o servidor que
                 * retorna o texto em caixa alta.
                 */

                //var texto = "Pneumoultramicroscopicossilicovulcanoconiótico";
                var texto = "um dia para testar rede";
                var mensagem = new Mensagem(texto);
                Console.WriteLine($"Maiusculalização de \"{texto}\"");

                client.EnviarMensagem("ServidorHP", 42, mensagem);
                var result = client.Resultado;
                Console.WriteLine($"O servidor retornou: {result.ExtrairTexto()}");
            }

            Console.ReadKey();
        }

        public static void ExibirEtapa() => Console.WriteLine($"Etapa número [{++etapa}]");
    }
}