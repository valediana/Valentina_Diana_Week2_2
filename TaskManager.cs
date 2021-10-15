using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneAgenda
{
    public static class TaskManager
    {
        public static List<Task> elencoTask = new List<Task>();
        public static void VisualizzaTask()
        {
            StampaTaskDaLista(elencoTask);
        }

        public static void StampaTaskDaLista(List<Task> elencoTask)
        {
            if (elencoTask.Count == 0)
            {
                Console.WriteLine("Non sono presenti task");
            }
            else
            {
                Console.WriteLine("Descrizione, Data Scadenza, Priorità");
                foreach (var item in elencoTask)
                {
                    Console.WriteLine($"{item.Descrizione}, {item.DataScadenza}, {item.LivelloPriorità}");
                }
            }
        }

        public static void AggiungiTask()
        {
            Task task1 = new Task();
            Console.WriteLine("Inserisci la descrizione del task");
            task1.Descrizione = Console.ReadLine();
            //task1.Descrizione = InserisciDescrizioneTask();
            task1.DataScadenza = InserisciDataScadenza();
            task1.LivelloPriorità = InserisciLivelloPriorità();
            elencoTask.Add(task1);


        }

        //TODO Da sistemare.
        //Questo metodo dovrebbe controllare che l'utente non inserisca task con la
        //stessa descrizione
        /*private static string InserisciDescrizioneTask()
        {
            string descrizioneNuova;
            descrizioneNuova = Console.ReadLine();
            foreach (var item in elencoTask)
            {
                if (descrizioneNuova == item.Descrizione)
                {
                    Console.WriteLine("Questo task è già stato inserito");
                    return null;

                }
                
            }
            return descrizioneNuova;
        }*/



        private static Task.Priorità InserisciLivelloPriorità()
        {
            Console.WriteLine("Inserisci il livello di priorità");
            Console.WriteLine($"Premi {(int)Task.Priorità.Bassa} per {Task.Priorità.Bassa}");
            Console.WriteLine($"Premi {(int)Task.Priorità.Media} per {Task.Priorità.Media}");
            Console.WriteLine($"Premi {(int)Task.Priorità.Alta} per {Task.Priorità.Alta}");
            int livello;
            do
            {
                Console.WriteLine("Fai la tua scelta");
            } while (!(int.TryParse(Console.ReadLine(), out livello) && livello >= 1 && livello <= 3));
            return (Task.Priorità)livello;
        }

        internal static void SalvaTask()
        {
            string path = @"C:\Users\valem\Desktop\week1\GestioneAgenda\elencoTaskSalvati.txt";
            foreach (var item in elencoTask)
            {
                using (StreamWriter sw1 = new StreamWriter(path, true))
                {
                    sw1.WriteLine($"{item.Descrizione} {item.DataScadenza} {item.LivelloPriorità}");
                }
            }
        }

        public static DateTime InserisciDataScadenza()
        {
            DateTime data;
            do
            {
                Console.WriteLine("Inserisci la data di scadenza del task");
            } while (!(DateTime.TryParse(Console.ReadLine(), out data) && data > DateTime.Today));
            return data;
        }

        public static void EliminaTask()
        {
            Console.WriteLine("I task presenti sono:");
            VisualizzaTask();
            Console.WriteLine("Scrivi la descrizione del task che vuoi eliminare");
            string descrizioneDaEliminare = Console.ReadLine();
            Task taskDaCancellare = CercaTaskPerDescrizione(descrizioneDaEliminare);
            if (taskDaCancellare == null)
            {
                Console.WriteLine("Task non trovato");
            }
            else
            {
                elencoTask.Remove(taskDaCancellare);
            }
        }

        private static Task CercaTaskPerDescrizione(string descrizioneDaEliminare)
        {
            foreach (var item in elencoTask)
            {
                if (item.Descrizione == descrizioneDaEliminare)
                {
                    return item;
                }
            }
            return null;
        }

        public static void FiltraTask()
        {
            Task.Priorità p = InserisciLivelloPriorità();
            List<Task> tasksDaFiltrare = new List<Task>();
            foreach (var item in elencoTask)
            {
                if (item.LivelloPriorità == p)
                {
                    tasksDaFiltrare.Add(item);
                }
                StampaTaskDaLista(tasksDaFiltrare);
            }
        }
    }
}