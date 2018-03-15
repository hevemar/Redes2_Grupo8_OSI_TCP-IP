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

        public string ProtocoloDeComunicacao { get; set; }
    }
}