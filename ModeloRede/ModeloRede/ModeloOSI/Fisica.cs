using System.Diagnostics;
using System.Net.NetworkInformation;

namespace ModeloRede.ModeloOSI
{
    /// <summary>
    /// Camada 1: Física
    /// <para>Transmissão e recepção dos bits brutos através do meio físico de transmissão</para>
    /// </summary>
    public class Fisica
    {
        /// <summary>
        /// Camada superior
        /// </summary>
        public Enlace Enlace { get; set; }

        public PhysicalAddress MAC { get; set; }
        public IMeioDeTransmissao MeioDeTransmissao { get; set; }

        public void Enviar(string dadosDoPacote)
        {
            Debug.Print("Recebendo dado para a camada de Enlace");
            throw new System.NotImplementedException();
        }
    }
}