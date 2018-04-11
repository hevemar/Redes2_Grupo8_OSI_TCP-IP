using System;

namespace ModeloDeRede.Redes.Enderecos
{
    public class Octeto
    {
        private bool[] bits;

        public Octeto()
            : this(0)
        {
        }

        public Octeto(int valor) => SetValor(valor);

        public Octeto(Octeto octeto)
        {
            bits = new bool[8];

            for (var i = 7; i >= 0; --i)
                bits[i] = octeto.bits[i];
        }

        private void SetValor(int valor)
        {
            if (valor < 0 && valor > 255)
                throw new ArgumentOutOfRangeException(nameof(valor), $"Valor incorreto: {valor}");

            bits = new bool[8];

            for (var i = 7; i >= 0; i--)
            {
                bits[i] = valor % 2 == 1;
                valor /= 2;
            }
        }

        /// <summary>
        /// Set "1" para o byte. "1111 1111"
        /// </summary>
        public void SetUm() => SetUm(8);

        /// <summary>
        /// Seta "1" para a quantidade de bits informada.
        /// </summary>
        /// <param name="numeroDeUns">Quantidade de bits a ser setada</param>
        public void SetUm(int numeroDeUns)
        {
            if (numeroDeUns < 0 || numeroDeUns > 8)
                throw new ArgumentOutOfRangeException("Número de bits incorreto.");

            for (var i = 0; i < numeroDeUns; ++i)
                bits[i] = true;
        }

        /// <summary>
        /// Retorna se é letra, de acordo com tabela ASCII
        /// </summary>
        /// <returns></returns>
        public bool EhLetra()
        {
            var value = (char)GetValor();

            //return value > 96 && value < 123 || value > 64 && value < 91;
            return char.IsLetter(value);
        }

        /// <summary>
        /// Retorna se é um "." (ponto)
        /// </summary>
        public bool EhPonto => GetValor() == 46;

        public bool EhEspaco => char.IsWhiteSpace((char)GetValor());

        public bool MenorQue(int value) => GetValor() < value;

        public int GetValor()
        {
            var res = 0;
            var pontencia = 1;

            for (var i = 7; i >= 0; --i)
            {
                if (bits[i])
                    res += pontencia;

                pontencia *= 2;
            }

            return res;
        }


        /// <summary>
        /// Inver os valores do byte. 0 >> 1 e 1 >> 0
        /// </summary>
        public void InverterValores()
        {
            for (var i = 7; i >= 0; --i)
                bits[i] = !bits[i];
        }

        //TODO: Remover método....
        public void Mascarar(Octeto mascara)
        {
            if (mascara == null)
                throw new ArgumentNullException(nameof(mascara), "Máscara não pode ser nula");

            for (var i = 7; i >= 0; --i)
                bits[i] = bits[i] && mascara.bits[i];
        }

        public void Adicionar(int i) => SetValor(GetValor() + i);

        public override string ToString() => GetValor().ToString();

        public void AplicarMascaraDeRede(Octeto mascara)
        {
            if (mascara == null)
                throw new ArgumentNullException(nameof(mascara), "Máscara não pode ser nula.");

            for (var i = 7; i >= 0; --i)
                bits[i] = bits[i] && mascara.bits[i];
        }
    }
}