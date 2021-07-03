using desafio_crud_series.Enums;

namespace desafio_crud_series.Models
{
    public abstract class BaseEntity
    {
        private int ID { get; set; }
        private string Title { get; set; }
        private Genre Genre { get; set; }
        private bool Deleted { get; set; }

        public BaseEntity(int id, string title, Genre genre)
        {
            this.ID = id;
            this.Title = title;
            this.Genre = genre;
            this.Deleted = false;
        }

        public int GetID() { return ID; }
        public void SetID(int id) { this.ID = id; }

        public bool GetDeleted() { return Deleted; }
        public void SetDeleted() { this.Deleted = true; }

        public string GetTitle() { return this.Title; }
        public Genre GetGenre() { return this.Genre; }
    }
}