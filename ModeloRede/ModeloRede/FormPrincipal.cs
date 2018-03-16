using System.Windows.Forms;
using ModeloRede.ModeloOSI;

namespace ModeloRede
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal() => InitializeComponent();

        private void btnTeste_Click(object sender, System.EventArgs e) => Teste();

        private static void Teste()
        {
            var fisica = new Fisica();
            var enlace = new Enlace();
            var rede = new Rede();
            var transporte = new Transporte();
            var sessao = new Sessao();
            var apresentacao = new Apresentacao();
            var aplicacao = new Aplicacao();

            fisica.Enlace = enlace;

            enlace.Fisica = fisica;
            enlace.Rede = rede;

            rede.Enlace = enlace;
            rede.Transporte = transporte;

            transporte.Rede = rede;
            transporte.Sessao = sessao;

            sessao.Transporte = transporte;
            sessao.Apresentacao = apresentacao;

            apresentacao.Sessao = sessao;
            apresentacao.Aplicacao = aplicacao;

            aplicacao.Apresentacao = apresentacao;

            aplicacao.Enviar("Hello Word!!");
            aplicacao.ReceberDados += Aplicacao_ReceberDados;
        }

        private static void Aplicacao_ReceberDados(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
