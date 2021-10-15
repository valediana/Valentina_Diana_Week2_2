using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneAgenda
{
	public class Task
	{
		public string Descrizione { get; set; }
		public DateTime DataScadenza { get; set; }
		public Priorità LivelloPriorità { get; set; }
		public Task()
		{
		}

		public enum Priorità
		{
			Bassa = 1,
			Media = 2,
			Alta = 3
		}
	}
}