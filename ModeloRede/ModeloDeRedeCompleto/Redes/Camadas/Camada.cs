namespace ModeloDeRede.Redes.Camadas
{
    /// <summary>
    /// Classe base para definicação de uma camada de rede.
    /// </summary>
    public abstract class Camada
    {
        protected Camada maisUm;
        protected Camada menosUm;

        protected Camada()
        {
        }

        protected Camada(Camada maisUm, Camada menosUm)
        {
            this.maisUm = maisUm;
            this.menosUm = menosUm;
        }

        public void SetCamadaSuperior(Camada maisUm) => this.maisUm = maisUm;
        public void SetCamadaInferior(Camada menosUm) => this.menosUm = menosUm;
        public string Nome => GetType().Name;
        public override string ToString() => $"Camada+1: {maisUm.Nome} - Camada-1: {menosUm.Nome}";
    }
}