using gestion_banque;
using gestion_banque.entities;
using gestion_banque.metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALL_TD.metier
{
    public class IImplCompte
    {
        public static IImplClient implClient = new IImplClient();
        public static IImplAgence implAgence = new IImplAgence();
        public static void Add()
        {
            Console.WriteLine("Saisir les informations du client");
            String prenom, nom, tel;
            
            prenom = GestionAgence.InputString("Saisir prenom: ");
            nom = GestionAgence.InputString("Saisir nom: ");
            tel = GestionAgence.InputString("Saisir numéro téléphone: ");
            Client client = new Client(prenom, nom, tel);
            implClient.Add(client);

        }
        public static void Update()
        {
            int solde;
            bool isValid;
            
            Client client = implClient.ChooseClient();
            do
            {
                Console.WriteLine("Saisir le solde: ");
                isValid = int.TryParse(Console.ReadLine(), out solde);
                if (!isValid || solde < 0) Console.WriteLine("Choix incorrect!");
            }while (!isValid || solde < 0);
            if(client.Compte is CompteSimple)
            {
                double taux;
                do
                {
                    Console.WriteLine("Saisir le taux: ");
                    isValid = double.TryParse(Console.ReadLine(), out taux);
                    if (!isValid || taux < 0) Console.WriteLine("Choix incorrect!");
                }
                while (!isValid || taux < 0);
                CompteSimple compte = new CompteSimple(solde, client, taux);
                client.Compte = compte;
                Console.WriteLine("Compte mis à jour!");

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
                CompteEpargne compte = new CompteEpargne(duree, solde, client);
                client.Compte = compte;
            }
            Console.WriteLine("Infos mis à jour avec succès!");
        }
        public static void Delete()
        {
            Console.WriteLine("Choisissez une agence");
            Agence agence = IImplAgence.ChooseAgence();
            Client client = implClient.ChooseClient(agence);
            agence.AClients.Remove(client);
            Console.WriteLine("Compte supprimé");
        }
        public static void DisplayCompte()
        {
            Console.WriteLine("Choisissez une agence");
            Agence agence = IImplAgence.ChooseAgence();
            if(agence.AClients.Count == 0) Console.WriteLine("L'agence n'a pas de client");
            else {
                foreach (var client in agence.AClients)
                {
                    Console.WriteLine("#####");
                    String type = client.Compte is CompteSimple ? "Compte Simple" : "Compte épargne";
                    Console.WriteLine(client.Compte.GetAccountInfos() + $" - Type de compte: {type}");
                    Console.WriteLine($"Propriétaire: {client.Prenom} {client.Nom}");
                    Console.WriteLine();
                }
            }
        }
        
    }
}
