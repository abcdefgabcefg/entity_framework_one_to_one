namespace EfDemo.Models
{
    public class TableWithForeignKey1
    {
        public int Id { get; set; }

        public int TableWithPrincipalKeyId { get; set; }

        public TableWithPrincipalKey TableWithPrincipalKey { get; set; }
    }
}
