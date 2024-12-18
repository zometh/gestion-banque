using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_banque.entities
{
    public class Client
    {
        public static int idClient = 0;
        private int id;
     
        private Compte compte;
        private String prenom;
        private String nom;
        private String tel;

        public Client(string prenom, string nom, string tel)
        {
            this.id = ++idClient;
            this.Prenom = prenom;
            this.Nom = nom;
            this.Tel = tel;
            
            
        }
        public int Id { get { return id; } }
        public String Prenom { get { return this.prenom; } set { this.prenom = value; } }
        public String Nom { get { return this.nom; } set { this.nom = value; } }
        public String Tel { get { return this.tel; } set { this.tel = value; } }
        public Compte Compte { get { return this.compte; } set { this.compte = value; } }
       

    }
}
