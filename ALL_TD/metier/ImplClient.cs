using gestion_banque.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_banque.metier
{
    public class IImplClient
    {
        static IImplAgence implAgence = new IImplAgence();
        

        public void Add(Client entity)
        {
            int choix, solde;
            bool isValid;
        
            Console.WriteLine("Choisissez une agence pour le client");
            Agence agence = IImplAgence.ChooseAgence();

            do
            {
                Console.WriteLine("Choisissez un type de compte: ");
                Console.WriteLine("1 - Compte Simple\n2 - Compte Epargne");
                Console.Write("Choix: ");
                isValid = int.TryParse(Console.ReadLine(), out choix);
                if (!isValid || (choix > 2 || choix < 1)) Console.WriteLine("Choix incorrect!");
            }
            while (!isValid  || (choix > 2 || choix < 1) );
            do
            {
                Console.WriteLine("Saisir le solde: ");
                isValid = int.TryParse(Console.ReadLine(), out solde);
                if(!isValid || solde < 0) Console.WriteLine("Choix incorrect!");
            }
            while (!isValid || solde < 0);
            if (choix == 1)
            {
                double taux;
                do
                {
                    Console.WriteLine("Saisir le taux: ");
                    isValid = double.TryParse(Console.ReadLine(),out taux);
                    if(!isValid || taux < 0) Console.WriteLine("Choix incorrect!");
                }
                while (!isValid || taux < 0);
                CompteSimple compte = new CompteSimple(solde, entity, taux);
                entity.Compte = compte;
                agence.AClients.Add(entity);
            }
            else
            {
                int duree;
                do
                {
                    Console.WriteLine("Saisir la duree: ");
                    isValid = int.TryParse(Console.ReadLine(), out duree);
                    if (!isValid || duree < 0) Console.WriteLine("Choix incorrect!");
                } while (!isValid || duree < 0);
                CompteEpargne compte = new CompteEpargne(duree, solde, entity);
                entity.Compte = compte;
                agence.AClients.Add(entity);
            }
            Console.WriteLine($"Client ajouté avec succès à l'agence {agence.Code}");

        }

        public void Delete(Client entity, Agence agence)
        {
            agence.AClients.Remove(entity);
            Console.WriteLine("Client supprimé avec succès");
        }

        public void Display(Client entity)
        {
            Console.WriteLine("####");
            Console.WriteLine($"Id: {entity.Id} - Prénom: {entity.Prenom} - Nom: {entity.Nom} - Tel: {entity.Tel}");
            Console.WriteLine($"Informations du compte: {entity.Compte.GetAccountInfos()}");
            Console.WriteLine();
          
        }

        public void Update(Client entity, Agence agence)
        {
            entity.Compte.CClient = entity;
            int index = agence.AClients.IndexOf(entity);
            agence.AClients[index] = entity;
            Console.WriteLine("Modification réussie");
        }
            
        public  Client ChooseClient(Agence agence = null)
        {
            Console.WriteLine("Choisissez une agence");
            if(agence == null) agence = IImplAgence.ChooseAgence();
            Client client = GestionAgence.ChooseClient(agence);
            return client;
        }
        
    }
}
