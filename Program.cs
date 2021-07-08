using System;

namespace Notas.viagens
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						Listarlembranças();
						break;
					case "2":
						Inserirlembranças();
						break;
					case "3":
						Atualizarlembranças();
						break;
					case "4":
						Excluirlembranças();
						break;
					case "5":
						Visualizarlembranças();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void Excluirlembranças()
		{
			Console.Write("Digite o id da lembranças: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}

        private static void Visualizarlembranças()
		{
			Console.Write("Digite o id da lembranças: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void Atualizarlembranças()
		{
			Console.Write("Digite o id da lembranças: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			{
			}

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Lembranças atualizaSerie = new Lembranças(id: indiceSerie,
                                   titulo: entradaTitulo,
                                   ano: entradaAno,
                                   descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}
        private static void Listarlembranças()
		{
			Console.WriteLine("Minhas Lembranças");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma lembrança cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*ferias esquecida*" : ""));
			}
		}

        private static void Inserirlembranças()
		{
			Console.WriteLine("Inserir nova lembranças");

			{
			}
			
			Console.Write(" onde foi suas ferias : ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("digite o ano: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da lembranças: ");
			string entradaDescricao = Console.ReadLine();

			Lembranças novaSerie = new Lembranças(id: repositorio.ProximoId(),
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("minhas lembranças!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar lembranças");
			Console.WriteLine("2- Inserir nova lembranças");
			Console.WriteLine("3- Atualizar lembranças");
			Console.WriteLine("4- Esquecer lembranças");
			Console.WriteLine("5- Visualizar lembranças");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
						Console.WriteLine();

			return opcaoUsuario;
		}
    }
}
