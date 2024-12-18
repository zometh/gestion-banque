using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_banque.entities
{
    public class CompteSimple : Compte
    {
        private double taux_decouvert;
        
        public CompteSimple(double solde, Client client, double taux_decouvert) : base(solde, client)
        {
            this.taux_decouvert = taux_decouvert;

        }

        public double TauxDecouvert
        {
            get
            {
                return this.taux_decouvert;
            }
            set
            {

                this.taux_decouvert = value;
            }
        }

        public override String GetAccountInfos()
        {
            return $"Id: {this.Id} - Numero: {this.NumeroCompte} - Solde: {this.Solde}FCFA - Taux: {this.TauxDecouvert} ";
        }
    }
}
