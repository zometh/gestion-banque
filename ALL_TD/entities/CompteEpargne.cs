using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_banque.entities
{
    public class CompteEpargne : Compte
    {
        private int duree;
        private Client client;
        public CompteEpargne(int duree, double solde, Client client) : base(solde, client)
        {
            this.Duree = duree;
        }

        public int Duree
        {
            get { return this.duree; }
            set { this.duree = value; }
        }

        public override String GetAccountInfos()
        {
            return $"Id: {this.Id} - Numero: {this.NumeroCompte} - Solde: {this.Solde}FCFA - Durée: {this.Duree} ";
        }
    }
}
