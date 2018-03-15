namespace ModeloRede.ModeloOSI
{
    /// <summary>
    /// Camada 2: Enlace de Dados
    /// <para>Detecção de erros</para>
    /// </summary>
    public class Enlace
    {
        /// <summary>
        /// Cada inferior
        /// </summary>
        public Fisica Fisica { get; set; }

        /// <summary>
        /// Cada superior
        /// </summary>
        public Rede Rede { get; set; }
    }
}