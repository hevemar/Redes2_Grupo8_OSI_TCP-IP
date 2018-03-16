using System;
using System.Diagnostics;

namespace ModeloRede.ModeloOSI
{
    /// <summary>
    /// Camada 7: Aplicação
    /// <para>Funções especialistas (transferência de arquivos, envio de e-mail, terminal virtual)</para>
    /// </summary>
    public class Aplicacao
    {

        public event EventHandler<EventArgs> ReceberDados;

        /// <summary>
        /// Camada inferior
        /// </summary>
        public Apresentacao Apresentacao { get; set; }

        public void Enviar(string dadosDoPacote)
        {
            Debug.Print("Aplicação: Enviando dado para camada de Apresentação");
            Apresentacao.Enviar(dadosDoPacote);
        }
    }
}