using System.Net;

namespace ModeloRede.ModeloOSI
{
    /// <summary>
    /// Camada 3: Rede
    /// <para>Roteamento de pacotes em uma ou várias redes</para>
    /// </summary>
    public class Rede
    {
        /// <summary>
        /// Camada superior
        /// </summary>
        public Transporte Transporte { get; set; }

        /// <summary>
        /// Cada inferior
        /// </summary>
        public Enlace Enlace { get; set; }

        public IPAddress IpAddress { get; set; }
    }
}