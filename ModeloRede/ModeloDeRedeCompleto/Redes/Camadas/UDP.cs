using ModeloDeRede.Redes.Enderecos;

namespace ModeloDeRede.Redes.Camadas
{
    /// <inheritdoc />
    /// <summary>
    /// Implementação da camada 4 - Transporte
    /// </summary>
    public class UDP : Transporte
    {
        protected override Mensagem GetCabecalho(int portaOrigem, Endereco destino, int portaDestino, Mensagem mensagem)
        {
            /*
             * Porta de origem(16 bits)
             * Porta de destino(16 bits)
             * Comprimento de cabeçalho + dados(16 bits)
             * Soma de verificação(16 bits)

             * Tamanho do cabeçalho: temos 4 segmentos
             * Cada segmento é composto por 2 bytes sendo 8 bits para ser multiplicado por 2 para o número de bits por segmento que multiplica por 4, ou seja, o número de segmentos do cabeçalho
             */

            var novaMensagem = new Mensagem(portaOrigem, portaDestino, 2 * 4 + mensagem.Tamanho, 0);
            return novaMensagem;
        }
    }
}