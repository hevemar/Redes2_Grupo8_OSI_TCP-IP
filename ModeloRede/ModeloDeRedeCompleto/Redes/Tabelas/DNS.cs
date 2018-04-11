using System.Collections.Generic;
using System.Linq;
using ModeloDeRede.Redes.Enderecos;

namespace ModeloDeRede.Redes.Tabelas
{
    public class DNS
    {
        private IDictionary<string, Endereco> cache = new Dictionary<string, Endereco>();


        public Endereco ObterEndereco(string nomeMaquina) => cache[nomeMaquina];

        public string ObterNomeMaquina(Endereco endereco) => cache.FirstOrDefault(x => x.Value.Equals(endereco)).Key;

        public void Adicionar(string nomeMaquina, Endereco endereco) => cache.Add(nomeMaquina, endereco);

        public bool MaquinaConhecida(string nomeMaquina) => cache.ContainsKey(nomeMaquina);
    }
}