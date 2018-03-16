using System.Diagnostics;

namespace ModeloRede.ModeloOSI
{
    /// <summary>
    /// Camada 4: Transporte
    /// <para>Oferece métodos para a entrega de dados ponto-a-ponto</para>
    /// </summary>
    public class Transporte
    {
        /// <summary>
        /// Camada superior
        /// </summary>
        public Sessao Sessao { get; set; }

        /// <summary>
        /// Camada inferior
        /// </summary>
        public Rede Rede { get; set; }

        public string ProtocoloDeComunicacao { get; set; } // TCP/UDP

        public void Enviar(string dadosDoPacote)
        {
            Debug.Print("Transporte: Recebendo dado da camada de Sessão");
            Debug.Print("Transporte: Enviando dado para a camada de Rede");
            Rede.Enviar(dadosDoPacote);
        }
    }
}