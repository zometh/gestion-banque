using ALL_TD.metier;
using gestion_banque.entities;
using gestion_banque.metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace gestion_banque
{
    internal class GestionAgence
    {
        public static IImplAgence implAgence = new IImplAgence();
        public static IImplClient implClient = new IImplClient();
        public static IImplCompte implCompte = new IImplCompte();
        static void Main(string[] args)
        {

            int choix_menu;
            do
            {
                choix_menu = Menu();

                switch (choix_menu)
                {
                    case 1:

                        AgenceService();

                        break;
                    case 2:
                        ClientService();
                        break;
                    case 3:
                        CompteService();
                        break;
                    case 4:
                        Console.WriteLine("Au revoir");
                        break;
                    default:
                        Console.WriteLine("Choix incorrect!");
                        break;
                }
            } while (choix_menu != 4);


        }
        private static void AgenceService()
        {
            int choix;
            do
            {
                 choix = SousMenu();
                switch (choix)
                {
                    case 1:
                        AddAgence();
                        break;
                    case 2:
                        EditAgence();
                        break;
                    case 3:
                        DeleteAgence();
                        break;
                    case 4:
                        IImplAgence.DisplayAgences();
                        break;
                    case 5:
                        break;
                }
            } while (choix != 5);
        }
        private static void ClientService()
        {
            int choix;
            do
            {
                 choix = SousMenu();
                switch (choix)
                {
                    case 1:
                        AddClient();
                        break;
                    case 2:
                        EditClient();
                        break;
                    case 3:
                        DeleteClient();
                        break;
                    case 4:
                        DisplayClients();
                        break;
                    case 5:
                        break;
                }
            } while (choix != 5);
        }
        public static void CompteService()
        {
            int choix;
            do
            {
                choix = SousMenu();
                switch (choix)
                {
                    case 1:
                        AddCompte();
                        break;
                    case 2:
                        EditCompte();
                        break;
                    case 3:
                        DeleteCompte();
                        break;
                    case 4:
                        DisplayCompte();
                        break;
                    case 5:
                        break;
                }
            } while (choix != 5);
        }
        private static void AddCompte()
        {
            if(IImplAgence.CountAgence() == 0) Console.WriteLine("Veuillez ajouter d'abord une agence");
            else
            {
                IImplCompte.Add();
            }
        }
        private static void EditCompte()
        {
            if (IImplAgence.CountAgence() == 0) Console.WriteLine("Veuillez ajouter d'abord une agence");
            else
            {
                IImplCompte.Update();
            }
        }
        public static void DisplayCompte()
        {
            if (IImplAgence.CountAgence() == 0) Console.WriteLine("Veuillez ajouter d'abord une agence");
            else
            {
                IImplCompte.DisplayCompte();
            }
        }
        public static void DeleteCompte()
        {
            if (IImplAgence.CountAgence() == 0) Console.WriteLine("Veuillez ajouter d'abord une agence");
            else
            {
                IImplCompte.Delete();
            }
        }
        public static String InputString(String message = "Saisir une chaine")
        {
            String value;

            //bool isValid;
            do
            {
                Console.Write(message + ": ");
                value = Console.ReadLine();
                if(value == null || value.Length == 0) Console.WriteLine("Choix incorrect");
                
            }
            while (value == null || value.Length == 0);
            return value.Trim();
        }
        private static int Menu()
        {
            String menu = "1 - GESTION AGENCE\n" +
                         "2 - GESTION CLIENT\n" +
                         "3 - GESTION COMPTE\n" +
                         "4 - Quitter";
            bool isValid = false;
            int choix = 0;
            do
            {
                Console.WriteLine(menu);
                Console.Write("Votre choix: ");
                isValid = int.TryParse(Console.ReadLine(), out choix);
                Console.Clear();
                if(isValid == false) Console.WriteLine("Choix incorrect!");

            }
            while (!isValid || (choix < 1 || choix > 4));
            return choix;
        }
        private static int SousMenu()
        {
            String s_menu = "1 - Ajouter\n" +
                            "2 - Modifier\n" +
                            "3 - Supprimer\n" +
                            "4 - Afficher\n" +
                            "5 - Retour";
            int choix;
            bool isValid = false;
            do
            {
                Console.WriteLine(s_menu);
                Console.Write("Votre choix: ");
                isValid |= int.TryParse(Console.ReadLine(),out choix);
                Console.Clear();
                if (isValid == false) Console.WriteLine("Choix incorrect!");
            }
            while (!isValid || (choix <1 || choix > 5));
            return choix;
        }
        private static void AddAgence()
        {

            String code = InputString("Saisir le code de l'agence").ToUpper();
            Agence agence = new Agence(code);
            implAgence.Add(agence);
           
        }
        private static void AddClient()
        {
            if(IImplAgence.CountAgence() == 0)
            {
                Console.WriteLine("Veuillez ajouter d'abord une agence");
            }
            else
            {
                String prenom = InputString("Saisir le prénom");
                String nom = InputString("Saisir le nom");
                String telephone = InputString("Saisir le numéro de téléphone");
                Client client = new Client(prenom, nom, telephone);
                implClient.Add(client);
            }
            

        }

        private static void DeleteAgence()
        {
            if (IImplAgence.CountAgence() == 0) Console.WriteLine("Veuillez ajouter d'abord une agence!");

            else implAgence.Delete(IImplAgence.ChooseAgence());
        }
        
        private static void EditAgence()
        {
            if (IImplAgence.agences.Count == 0) Console.WriteLine("Veuillez ajouter d'abord une agence!");
            else
            {
                Agence agence = IImplAgence.ChooseAgence();
                String code;

                do
                {
                    Console.Write("Saisir le nouveau code de l'agence: ");
                    code = Console.ReadLine();
                }
                while (code == null);   
                agence.Code = code;
                implAgence.Update(agence);
            }
            
        }
        private static void EditClient()
        {
            if (IImplAgence.CountAgence() == 0) Console.WriteLine("Veuillez ajouter d'abord une agence!");
            else
            {
                Agence agence = IImplAgence.ChooseAgence();
                if (agence.AClients.Count == 0) Console.WriteLine("Veuillez ajouter d'abord des clients");
                else
                {
                    Client client = ChooseClient(agence);
                    String prenom = InputString("Saisir le nouveau prénom");
                    String nom = InputString("Saisir le nouveau nom");
                    String telephone = InputString("Saisir le nouveau numéro de téléphone");
                    client.Nom = nom;
                    client.Prenom = prenom;
                    client.Tel = telephone;
                    implClient.Update(client, agence);

                }
            }

        }
        private static void DeleteClient()
        {
            if (IImplAgence.CountAgence() == 0) Console.WriteLine("Veuillez ajouter d'abord une agence!");
            else
            {
                Agence agence = IImplAgence.ChooseAgence();
                if (agence.AClients.Count == 0) Console.WriteLine("Veuillez ajouter d'abord des clients");
                else
                {
                    Client client = ChooseClient(agence);
                    
                    
                    implClient.Delete(client, agence);

                }
            }

        }
        private static void DisplayClients()
        {
            if(IImplAgence.CountAgence() == 0) Console.WriteLine("Veuillez d'abord ajouter une agence");
            else
            {
                Console.WriteLine("Choissez une agence");
                Agence agence = IImplAgence.ChooseAgence();
                if (agence.AClients.Count == 0) Console.WriteLine("L'agence choisie n'a pas de clients");
                else agence.AClients.ForEach((client) => implClient.Display(client));
            }
        }
        public static Client ChooseClient(Agence agence)
        {
          
            int indexClient;
            bool isValidId;
            bool isValid;
            
            
                do
                {
                    agence.AClients.ForEach((client) => implClient.Display(client));
                    Console.Write("Saisir l'id du client: ");
                    isValid = int.TryParse(Console.ReadLine(), out indexClient);
                    Console.Clear();
                     isValidId = agence.AClients.Where((client) => client.Id == indexClient).Any();
                    if (!isValid || (!isValidId)) Console.WriteLine("Choix incorrect!");
                }
                while (!isValid || !isValidId);
                return agence.AClients.Where((client) => client.Id == indexClient).First();
            }
        }
    }
    

