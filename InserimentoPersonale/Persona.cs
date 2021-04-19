using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InserimentoPersonale
{
    public abstract class Persona
    {
        public string Nome { get; private set; }
        public string Cognome { get; private set; }
        public string CodiceFiscale { get; private set; }


        public Persona(string nome, string cognome, string codice)
        {
            CodiceFiscale = codice;
            Nome = nome;
            Cognome = cognome;

        }

        public override string ToString()
        {
            return $"{Nome} {Cognome} \n{CodiceFiscale}.";
        }
    }
}
