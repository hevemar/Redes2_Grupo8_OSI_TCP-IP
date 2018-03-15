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
    }
}