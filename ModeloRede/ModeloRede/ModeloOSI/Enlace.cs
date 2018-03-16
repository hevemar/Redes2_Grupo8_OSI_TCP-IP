using System.Diagnostics;

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

        public void Enviar(string dadosDoPacote)
        {
            Debug.Print("Enlace: Recebendo dado da camada de Rede");
            Debug.Print("Enlace: Enviando dado para a camada Física");
            Fisica.Enviar(dadosDoPacote);
        }
    }
}