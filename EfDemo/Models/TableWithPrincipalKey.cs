namespace EfDemo.Models
{
    public class TableWithPrincipalKey
    {
        public int Id { get; set; }

        public TableWithForeignKey1 TableWithForeignKey1 { get; set; }
    }
}
