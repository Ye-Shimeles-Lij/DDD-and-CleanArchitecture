namespace EmployeePos.Domain.Models
{
    public class Position
    {
        public Position(string name, string description, Guid? parentId)
        {
            Name = name;
            Description = description;
            ParentId = parentId;
        }
        public Position()
        {

        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ParentId { get; set; }
        public Position Parent { get; set; }
        public ICollection<Position> Children { get; set; }
    }
}
