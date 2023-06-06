namespace ListApi.DAL.Entities
{
    public class Line : Entity
    {
        public bool isComplete { get; set; }

        public virtual Notebook Notebooks { get; set; }

        public Guid NotebookId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime CompletedAt { get; set;}
    }
}
