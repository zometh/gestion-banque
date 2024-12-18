using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_banque.entities
{
    public class Agence
    {
        public static int idAgence = 0;
        private List<Client> clients;
        private int id;
        private String code;
        private String libelle;

        public Agence(string code)
        {
            this.clients = new List<Client>();
            this.id = ++idAgence;
            this.Code = code;
            this.libelle = GenerateLibelle();
        }
        public List<Client> AClients{
            get{ return clients; }
            }
        public int Id { get { return this.id; } }
        public String Code { get { return this.code; } set {
                this.code = value;
                this.libelle = GenerateLibelle();
            } }
        public String Libelle { get { return this.libelle; } }
        private String GenerateLibelle()
        {
            String code = this.Id + "_" + this.Code.Substring(0, 3);
            return code;
        }

        public override string ToString()
        {
            return $"Id: {this.Id} - Code: {this.Code} - Libelle: {this.Libelle} - Nombre de clients: {this.clients.Count}";
        }
    }
}
