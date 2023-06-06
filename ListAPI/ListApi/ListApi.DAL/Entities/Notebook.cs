namespace ListApi.DAL.Entities
{
    public class Notebook : Entity
    {
        public virtual List<Line> Lines { get; set; }
    }
}
