using System;
using System.Collections.Generic;
using Notas.viagens.Interfaces;

namespace Notas.viagens
{
	public class SerieRepositorio : IRepositorio<Lembranças>
	{
        private List<Lembranças> listaSerie = new List<Lembranças>();
		public void Atualiza(int id, Lembranças objeto)
		{
			listaSerie[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaSerie[id].Excluir();
		}

		public void Insere(Lembranças objeto)
		{
			listaSerie.Add(objeto);
		}

		public List<Lembranças> Lista()
		{
			return listaSerie;
		}

		public int ProximoId()
		{
			return listaSerie.Count;
		}

		public Lembranças RetornaPorId(int id)
		{
			return listaSerie[id];
		}
	}
}