using System;
using System.Diagnostics;

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

        public void Enviar(string dadosDoPacote)
        {
            Debug.Print("Apresentação: Recebendo dado da camada de Aplicação");
            Debug.Print("Apresentação: Enviando dado para a camada de Sessão");
            Sessao.Enviar(dadosDoPacote);
        }

        private string Criptografar(string dados)
        {
            throw new NotImplementedException();
        }

        private string Descriptografar(string dados)
        {
            throw new NotImplementedException();
        }
    }
}