using desafio_crud_series.Enums;
using System.Text;

namespace desafio_crud_series.Models
{
    public class Movie : BaseEntity
    {
        private string Synopsis { get; set; }
        private string Director { get; set; }
        private int Year { get; set; }

        public Movie(int id, Genre genre, string title, string director, string synopsis, int year) : base(id, title, genre)
        {
            this.Director = director;
            this.Synopsis = synopsis;
            this.Year = year;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            if (GetDeleted()) result.AppendLine("[DELETED]");
            result.AppendLine($"Title: {GetTitle()}");
            result.AppendLine($"Year: {Year}");
            result.AppendLine($"Director: {Director}");
            result.AppendLine($"Synopsis: {Synopsis}");
            result.Append($"Genre: {GetGenre()}");
            return result.ToString();
        }
    }
}