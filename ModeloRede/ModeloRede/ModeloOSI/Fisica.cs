using System.Net.NetworkInformation;

namespace ModeloRede.ModeloOSI
{
    /// <summary>
    /// Camada 1: Física
    /// <para>Transmissão e recepção dos bits brutos através do meio físico de transmissão</para>
    /// </summary>
    public class Fisica
    {
        public PhysicalAddress MAC { get; set; }
    }
}