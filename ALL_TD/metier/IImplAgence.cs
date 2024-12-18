using gestion_banque.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_banque.metier
{
    public class IImplAgence
    {
        public static List<Agence> agences = new List<Agence>();
        public void Add(Agence entity)
        {

            bool exist = agences.Where((agence) => agence.Code == entity.Code).Any();
            if (exist)
            {
                Console.WriteLine("L'agence existe déja");
            }
            else
            {
                agences.Add(entity);
                DisplayAgences();
                Console.WriteLine("Agence ajoutée avec succès");
            }
            }
        public static Agence ChooseAgence()
        {
            int index = 0;
            bool isValid;
            do
            {
                DisplayAgences();
                Console.Write("Saisir l'id de l'agence: ");
                isValid = int.TryParse(Console.ReadLine(), out index);
                Console.Clear();
                if (!isValid || (checkId(index) == false)) Console.WriteLine("Choix incorrect!");
            } while (!isValid || (checkId(index) == false));
            return agences.Where((agence) => agence.Id == index).First();
        }
        public static int CountAgence()
        {
            return agences.Count;
        }
        public static bool checkId(int id)
        {
            bool exist = agences.Where((agence) => agence.Id == id).Any();
            return exist;
        }
        public void Delete(Agence entity)
        {
            agences.Remove(entity);
            Console.WriteLine("Agence supprimée avec succès");
           
        }

        public static void Display(Agence entity)
        {
            Console.WriteLine(entity);
        }

        public void Update(Agence entity)
        {
            int index = agences.IndexOf(entity);
            agences[index] = entity;
            Console.WriteLine("Agence modifiée avec succès");
            
        }
        public static void DisplayAgences()
        {
            
            if(CountAgence() == 0) Console.WriteLine("Veuillez ajouter d'abord une agence");
            else
            {
                foreach (var agence in agences)
                {
                    Display(agence);
                }
            }
        }
    }
}
