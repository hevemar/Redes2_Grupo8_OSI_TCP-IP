using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using ModeloDeRede.Redes.Enderecos;

namespace ModeloDeRede.Redes
{
    public class Mensagem
    {
        private PhysicalAddress macAddressDestino;
        protected IList<Octeto> octetos;

        private Mensagem() => octetos = new List<Octeto>();

        public Mensagem(PhysicalAddress macAddressDestino)
        {
            this.macAddressDestino = macAddressDestino;
        }

        public Mensagem(Endereco endereco)
        : this()
        {
            for (var i = 0; i < endereco.Octetos.Length; i++)
                octetos.Add(endereco.Octetos[i]);
        }

        public Mensagem(Mensagem mensagem)
        {
            if (mensagem == null)
                throw new ArgumentNullException(nameof(mensagem));

            octetos = new List<Octeto>(mensagem.octetos);
        }

        public Mensagem(params int[] valores)
        : this()
        {
            var len = valores.Length;

            for (var i = 0; i < len; ++i)
            {
                var x = valores[i];
                Adicionar(x);
            }
        }

        public Mensagem(string texto)
        : this()
        {
            foreach (var letra in texto.ToCharArray())
                octetos.Add(new Octeto(letra));
        }

        private void Adicionar(int x)
        {
            var xForts = x / 128;
            var xFaibles = x % 128;
            octetos.Add(new Octeto(xForts));
            octetos.Add(new Octeto(xFaibles));
        }


        public int Tamanho => octetos.Count;

        public void Adicionar(EnderecoMAC enderecoMac)
        {
            if (enderecoMac == null)
                throw new ArgumentNullException();

            for (var i = 0; i < enderecoMac.Octetos.Length; i++)
                octetos.Add(enderecoMac.Octetos[i]);
        }

        public void Adicionar(Mensagem mensagem)
        {
            if (mensagem == null)
                throw new ArgumentNullException();

            using (var enumerator = mensagem.octetos.GetEnumerator())
                while (enumerator.MoveNext())
                {
                    var o = enumerator.Current;
                    Adicionar(o);
                }
        }

        private void Adicionar(Octeto octeto)
        {
            if (octeto == null)
                throw new ArgumentNullException();

            octetos.Add(octeto);
        }

        public EnderecoMAC ExtrairMacAdress()
        {
            if (octetos.Count < 8)
                throw new ArgumentException();

            var tab = new Octeto[6];

            for (var i = 0; i < 6; i++)
                tab[i] = octetos[i];

            var mac = new EnderecoMAC(tab);

            return mac;
        }

        public void Remover(int valor)
        {
            if (valor < 0 || valor > octetos.Count)
                throw new ArgumentException();

            //TODO: Verificar o que subList faz no Java.
            //this.alo.subList(0, i).clear();

            ((List<Octeto>)octetos).RemoveRange(0, valor);
        }

        public int ExtrairTudo(int index)
        {
            if (index < 0 || index > octetos.Count - 1)
                throw new ArgumentOutOfRangeException();

            var item = octetos[index];
            var proxItem = octetos[index + 1];

            return item.GetValor() * 128 + proxItem.GetValor();
        }

        public Endereco ExtrairEndereco(int nbOctets)
        {
            if (nbOctets > octetos.Count)
                throw new ArgumentNullException();

            var tab = new Octeto[nbOctets];

            for (var i = 0; i < nbOctets; i++)
                tab[i] = octetos[i];

            var endereco = new Endereco(tab);

            return endereco;
        }

        public string ExtrairTexto()
        {
            var sb = new StringBuilder();
            var i = octetos.GetEnumerator();

            while (i.MoveNext())
            {
                var o = i.Current;
                if (o.EhLetra() || o.EhPonto || o.EhEspaco)
                    sb.Append((char)o.GetValor());
            }

            return sb.ToString();
        }

        public void Adicionar(short valor) => octetos.Add(new Octeto(valor));

        public void Adicionar(Endereco enderecoIp)
        {
            if (enderecoIp == null)
                throw new ArgumentNullException(nameof(enderecoIp));

            for (var i = 0; i < enderecoIp.Octetos.Length; i++)
                octetos.Add(enderecoIp.Octetos[i]);
        }

        public override string ToString()
        {
            var i = 0;
            string res = "[";

            foreach (var octeto in octetos)
            {
                i++;
                if (i == octetos.Count)
                    res += octeto.ToString();
                else
                    res += octeto.ToString() + ", ";
            }


            return res + "]";
        }
    }
}