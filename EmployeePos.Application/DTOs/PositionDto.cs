namespace EmployeePos.Application.DTOs
{
    public class PositionDto
    {
        // public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public Guid? ParentId { get; set; }
    }

    public class GetPo : PositionDto
    {
        public Guid Id { get; set; }
    }
}
