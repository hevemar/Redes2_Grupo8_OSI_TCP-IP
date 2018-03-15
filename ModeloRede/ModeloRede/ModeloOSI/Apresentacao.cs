namespace ModeloRede.ModeloOSI
{
    /// <summary>
    /// Camada 6: Apresentação
    /// <para>Formatação dos dados, conversão de códigos e caracteres</para>
    /// </summary>
    public class Apresentacao
    {
        /// <summary>
        /// Camada superior
        /// </summary>
        public Aplicacao Aplicacao { get; set; }

        /// <summary>
        /// Camada inferior
        /// </summary>
        public Sessao Sessao { get; set; }
    }
}