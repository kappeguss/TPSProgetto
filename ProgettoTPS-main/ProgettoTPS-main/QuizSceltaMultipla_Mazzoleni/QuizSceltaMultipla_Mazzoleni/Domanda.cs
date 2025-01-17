using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSceltaMultipla_Mazzoleni
{
    internal class Domanda
    {
        private string testo;
        private string[] opzioni;
        private int indiceRispostaCorretta;
        public string Testo { get { return testo; } }
        public string[] Opzioni { get { return opzioni; } }
        public int IndiceRispostaCorretta { get { return indiceRispostaCorretta; } }

        public Domanda(string testo, string[] opzioni, int indiceRispostaCorretta)
        {
            this.testo = testo;
            this.opzioni = opzioni;
            this.indiceRispostaCorretta = indiceRispostaCorretta;
        }
    }
}
