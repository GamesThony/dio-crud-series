using desafio_crud_series.Enums;
using System;
using System.Text;

namespace desafio_crud_series.Models
{
    public class Serie : BaseEntity
    {
        private string Description { get; set; }
        private int LaunchYear { get; set; }
        private int? EndYear { get; set; }

        public Serie(int id, Genre gender, string title, string description, int launchYear, int? endYear = null) : base(id, title, gender)
        {
            this.Description = description;
            this.LaunchYear = launchYear;
            this.EndYear = endYear;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            if (GetDeleted()) result.AppendLine("[DELETED]");
            result.AppendLine($"Title: {GetTitle()}");
            result.AppendLine($"Description: {Description}");
            result.Append($"Duration: {LaunchYear} - ");
            result.AppendLine(EndYear.HasValue ? EndYear.Value.ToString() : "Today");
            result.Append($"Genre: {GetGenre()}");
            return result.ToString();
        }
    }
}