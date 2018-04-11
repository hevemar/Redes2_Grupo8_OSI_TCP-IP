using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ModeloDeRede.Redes.Enderecos
{
    public class Endereco : IEnumerable<Octeto>
    {
        protected Octeto[] octetos;

        public Octeto[] Octetos => octetos;

        public int Tamanho => octetos.Length * 8;

        public Endereco(Octeto[] octetos)
        {
            if (octetos == null)
                throw new ArgumentNullException(nameof(octetos));

            this.octetos = new Octeto[octetos.Length];
            this.SetOctetos(octetos);
        }

        public Endereco(int numeroBits)
        {
            if (numeroBits % 8 != 0 || numeroBits == 0)
                throw new ArgumentOutOfRangeException(nameof(numeroBits), "Número de bits deve ser múltiplo de 8");

            var qtdOctetos = numeroBits / 8;

            this.octetos = new Octeto[qtdOctetos];

            for (var i = 0; i < qtdOctetos; ++i)
                octetos[i] = new Octeto();
        }

        public Endereco(string s)
        {
            var array = s.Split('.');

            if (!(array.Length == 4 || array.Length == 6 || array.Length == 8))
                throw new ArgumentException();


            octetos = new Octeto[array.Length];
            var i = 0;

            foreach (var segmento in array)
            {
                var numero = int.Parse(segmento);

                if (numero > 255)
                    throw new ArgumentOutOfRangeException();

                octetos[i] = new Octeto(numero);
                i++;
            }
        }

        public Endereco(Endereco endereco)
        {
            if (endereco == null)
                throw new ArgumentNullException(nameof(endereco));

            octetos = new Octeto[endereco.Octetos.Length];
            Array.Copy(endereco.Octetos, octetos, endereco.octetos.Length);
        }

        protected Endereco()
        {
        }

        private void SetOctetos(Octeto[] octetos) =>
            this.octetos = octetos ?? throw new ArgumentNullException(nameof(octetos));


        public IEnumerator<Octeto> GetEnumerator() => (IEnumerator<Octeto>)octetos.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => octetos.GetEnumerator();

        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case null:
                    return false;
                case Endereco other:
                    return ToString().Equals(other.ToString());
            }

            return false;
        }

        protected bool Equals(Endereco other) => Equals(octetos, other.octetos);

        public override int GetHashCode() => octetos[0].GetValor();

        public override string ToString()
        {
            var sb = new StringBuilder();

            for (var i = 0; i < this.octetos.Length; i++)
                sb.Append(octetos[i] + ".");

            sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }

        public void AplicarMascara(Endereco mascaraDeRede)
        {
            if (mascaraDeRede.Tamanho != this.Tamanho)
                throw new InvalidOperationException("Tamanho da máscara incorreto.");

            for (var i = 0; i < Octetos.Length; ++i)
            {
                var item = new Octeto(Octetos[i]);
                item.AplicarMascaraDeRede(mascaraDeRede.Octetos[i]);
                SetOctetos(item, i);
            }
        }

        private void SetOctetos(Octeto octeto, int i)
        {
            if (octeto == null || 0 > i || i + 1 > octetos.Length)
                throw new ArgumentNullException();

            octetos[i] = octeto;
        }
    }
}