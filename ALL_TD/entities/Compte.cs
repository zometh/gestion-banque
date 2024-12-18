using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_banque.entities
{
    public abstract class Compte
    {
        public static int idCompte = 0;
        private int id;
        private String numero_compte;
        private double solde;
        private Client client;

        public Compte(double solde, Client client)
        {
            this.id = ++idCompte;
            this.Solde = solde;
            this.client = client;
            
            this.numero_compte = GenNumeroCompte();
        }

        public int Id { get { return this.id; } }
        public String NumeroCompte
        {
            get
            {
                return this.numero_compte;
            }
            set
            {
                this.numero_compte = value;
            }
        }
        public double Solde { get { return this.solde; } set { this.solde = value; } }
        private String GenNumeroCompte()
        {

            return "000" + this.client.Id + this.client.Tel;
        }
        public Client CClient
        {
            get { return this.client; }
            set
            {
                this.client = value;
                this.NumeroCompte = GenNumeroCompte();
            }
        }
        public abstract String GetAccountInfos();
    }
}
