using System;
using System.Collections.Generic;

namespace ModeloDeRede.Redes
{
    public class RedeLocal
    {
        private IList<Maquina> maquinasNaRede = new List<Maquina>();

        /// <summary>
        /// Envia o Frame via rede
        /// </summary>
        /// <param name="mensagem"></param>
        public void EnviarQuadro(Mensagem mensagem)
        {
            foreach (var maquina in maquinasNaRede)
            {
                var original = new Mensagem(mensagem);
                Console.WriteLine($"Enviar mensagem para \"{maquina.NomeMaquina}\"");
                maquina.Ethernet.ReceberMensagem(original);
            }
        }

        public void Adicionar(params Maquina[] maquinas)
        {
            foreach (var maquina in maquinas)
            {
                maquina.Ethernet.SetRede(this);
                maquinasNaRede.Add(maquina);
            }
        }

        /// <summary>
        /// Conecta as máquinas na rede local
        /// </summary>
        public void ConectarMaquinas()
        {
            //Deve haver ao menos duas máquinas
            if (maquinasNaRede.Count > 1)
            {
                for (var i = 0; i < this.maquinasNaRede.Count - 1; i++)
                {
                    var atual = maquinasNaRede[i];
                    var proxima = maquinasNaRede[i + 1];
                    atual.Conectar(proxima);
                }
            }
            else
                throw new InvalidOperationException("A quantidade de máquinas na rede não é suficiente para o cabeamento");
        }
    }
}