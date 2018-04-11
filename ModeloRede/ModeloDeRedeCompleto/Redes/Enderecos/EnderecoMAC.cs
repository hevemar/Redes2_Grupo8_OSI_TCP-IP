using System;
using System.Text;

namespace ModeloDeRede.Redes.Enderecos
{
    public class EnderecoMAC : Endereco
    {
        public EnderecoMAC()
            : base(48)
        {
        }

        public EnderecoMAC(Octeto[] octetos) : base(octetos)
        {
            if (octetos == null)
                throw new ArgumentNullException(nameof(octetos));

            this.octetos = new Octeto[octetos.Length];
            this.octetos = octetos;
        }

        public EnderecoMAC(string valor)
        {
            var array = valor.Split('.');
            if (array.Length != 6)
                throw new ArgumentOutOfRangeException(nameof(valor), "Quantidade de octetos inválido.");

            octetos = new Octeto[6];
            var k = 0;
            var arr = array;
            var len = array.Length;

            for (var i = 0; i < len; ++i)
            {
                var oc = arr[i];
                var val = Convert.ToInt32(oc, 16);
                Octetos[k] = new Octeto(val);
                ++k;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var arr = octetos;
            var len = arr.Length;

            for (var i = 0; i < len; ++i)
            {
                var o = arr[i];
                var val = o.GetValor();

                sb.Append($"{Convert.ToString(val, 16)}.");
            }

            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }
    }
}