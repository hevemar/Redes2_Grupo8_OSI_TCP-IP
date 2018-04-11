using ModeloDeRede.Redes.Enderecos;

namespace ModeloDeRede.Redes.Camadas
{
    public abstract class Enlace : Camada
    {
        protected EnderecoMAC macAddress;
        protected Enlace vizinho;
        protected RedeLocal rede;

        public Enlace(EnderecoMAC macAddress) => this.macAddress = macAddress;

        public abstract void EnviarMensagem(EnderecoMAC destino, Mensagem mensagem);
        public abstract void ReceberMensagem(Mensagem mensagem);

        /// <summary>
        /// Setar rede física ligada a esta camada
        /// </summary>
        /// <param name="vizinho"></param>
        public void SetVizinho(Enlace vizinho) => this.vizinho = vizinho;

        public void SetRede(RedeLocal rede) => this.rede = rede;
    }
}