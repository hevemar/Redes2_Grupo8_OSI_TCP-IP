using System.Diagnostics;

namespace ModeloRede.ModeloOSI
{
    /// <summary>
    /// Camada 5: Sessão
    /// <para>Negociação e conexão com outros nós, analogia</para>
    /// </summary>
    public class Sessao
    {
        /// <summary>
        /// Camada superior
        /// </summary>
        public Apresentacao Apresentacao { get; set; }

        /// <summary>
        /// Camada inferior
        /// </summary>
        public Transporte Transporte { get; set; }

        public void Enviar(string dadosDoPacote)
        {
            Debug.Print("Sessão: Recebendo dado da camada de Apresentação");
            Debug.Print("Sessão: Enviando dado para a camada de Transporte");
            Transporte.Enviar(dadosDoPacote);
        }
    }
}