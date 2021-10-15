using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneAgenda
{
    public static class MenuAgenda
    {
        public static void Start()
        {
            Console.WriteLine("Benvenuto nella GestioneAgenda\n");

            bool continua = true;
            do
            {
                Console.WriteLine("\n**************MENU******************\n");
                Console.WriteLine("Premi 1 per visualizzare i task");
                Console.WriteLine("Premi 2 per aggiungere un task");
                Console.WriteLine("Premi 3 eliminare un task");
                Console.WriteLine("Premi 4 per filtrare i task per priorità");
                Console.WriteLine("Premi 0 per uscire");

                int scelta;
                do
                {
                    Console.WriteLine("Scegli tra le possibili opzioni");
                } while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta <= 4));

                switch (scelta)
                {
                    case 1:
                        TaskManager.VisualizzaTask();
                        break;
                    case 2:
                        TaskManager.AggiungiTask();
                        break;
                    case 3:
                        TaskManager.EliminaTask();
                        break;
                    case 4:
                        TaskManager.FiltraTask();
                        break;
                    case 0:
                        TaskManager.SalvaTask();
                        Console.WriteLine("Arrivederci!");
                        continua = false;
                        break;

                }
            } while (continua);
        }

    }
}