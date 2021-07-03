using desafio_crud_series.Enums;
using desafio_crud_series.Models;
using desafio_crud_series.Repository;
using System;

namespace desafio_crud_series
{
    class Program
    {
        static DataRepository<BaseEntity> serieRepository = new DataRepository<BaseEntity>();
        static DataRepository<BaseEntity> movieRepository = new DataRepository<BaseEntity>();
        static DataRepository<BaseEntity> repositoryAtual;

        static void Main(string[] args)
        {
            string tipo = ObterTipo();
            string dataType;

            while (tipo != "X")
            {
                switch (tipo)
                {
                    case "1":
                        repositoryAtual = serieRepository;
                        dataType = "serie";
                        break;
                    case "2":
                        repositoryAtual = movieRepository;
                        dataType = "movie";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                string opcao = ObterOpcao(dataType);
                while (opcao != "X")
                {
                    switch (opcao)
                    {
                        case "1":
                            Listar();
                            break;
                        case "2":
                            Inserir(dataType[0]);
                            break;
                        case "3":
                            Atualizar(dataType[0]);
                            break;
                        case "4":
                            Excluir();
                            break;
                        case "5":
                            Visualizar();
                            break;
                        case "C":
                            Console.Clear();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    opcao = ObterOpcao(dataType);
                }

                Console.Clear();
                tipo = ObterTipo();
            }

            Console.WriteLine("Thank you for using our services!");
            Console.ReadLine();
        }

        private static void Atualizar(char type)
        {
            Console.Write("Item ID: ");
            int index = int.Parse(Console.ReadLine());

            BaseEntity item = ObterItem(type);
            item.SetID(index);
            repositoryAtual.Update(index, item);
        }

        private static void Listar()
        {
            var items = repositoryAtual.GetItems();

            if (items.Count == 0) Console.WriteLine("None found. :(");
            else
            {
                foreach (var item in items)
                {
                    var deleted = item.GetDeleted() ? "[DELETED]" : "";
                    Console.WriteLine($"ID {item.GetID()}: {item.GetTitle()} {deleted}");
                }
            }
        }

        private static void Visualizar()
        {
            Console.Write("Item ID: ");
            int index = int.Parse(Console.ReadLine());
            var item = repositoryAtual.GetByID(index);
            Console.WriteLine(item);
        }

        private static void Excluir()
        {
            Console.Write("Item ID to delete: ");
            int index = int.Parse(Console.ReadLine());
            repositoryAtual.RemoveByID(index);
        }

        private static void Inserir(char type)
        {
            BaseEntity item = ObterItem(type);
            repositoryAtual.Add(item);
        }

        private static BaseEntity ObterItem(char type)
        {
            if (type == 's') return ObterSerie();
            else return ObterFilme();
        }

        private static Serie ObterSerie()
        {
            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.Write("Genre ID: ");
            int genre = int.Parse(Console.ReadLine());

            Console.Write("Title: ");
            string title = Console.ReadLine();

            Console.Write("Description: ");
            string description = Console.ReadLine();

            Console.Write("Launch Year: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("End Year (use '-' for series in development): ");
            if (int.TryParse(Console.ReadLine(), out int endYear)) return new Serie(repositoryAtual.AvailableID(), (Genre)genre, title, description, year, endYear);
            else return new Serie(repositoryAtual.AvailableID(), (Genre)genre, title, description, year);
        }

        private static Movie ObterFilme()
        {
            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.Write("Genre ID: ");
            int genre = int.Parse(Console.ReadLine());

            Console.Write("Title: ");
            string title = Console.ReadLine();

            Console.Write("Synopsis: ");
            string description = Console.ReadLine();

            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Director: ");
            string director = Console.ReadLine();

            return new Movie(repositoryAtual.AvailableID(), (Genre)genre, title, director, description, year);
        }

        private static string ObterTipo()
        {
            Console.WriteLine();
            Console.WriteLine("Thonyflix - Series and movies at any and all times!");
            Console.WriteLine("Desired service:");
            Console.WriteLine("1 - Show all series options...");
            Console.WriteLine("2 - Show all movies options...");
            Console.WriteLine("X - Close");
            Console.WriteLine();

            string tipo = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return tipo;
        }

        private static string ObterOpcao(string tipo)
        {
            Console.WriteLine();
            Console.WriteLine("Type in the desired service:");
            Console.WriteLine($"1 - Show all {tipo}s");
            Console.WriteLine($"2 - Add new {tipo}");
            Console.WriteLine($"3 - Update {tipo}");
            Console.WriteLine($"4 - Remove {tipo}");
            Console.WriteLine($"5 - Show {tipo} details");
            Console.WriteLine("C - Clear screen");
            Console.WriteLine("X - Back");
            Console.WriteLine();

            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        }
    }
}