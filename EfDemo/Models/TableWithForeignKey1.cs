using System.ComponentModel.DataAnnotations.Schema;

namespace EfDemo.Models
{
    public class TableWithForeignKey1
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Index(IsUnique = true)]
        public int TableWithPrincipalKeyId { get; set; }

        public TableWithPrincipalKey TableWithPrincipalKey { get; set; }
    }
}
