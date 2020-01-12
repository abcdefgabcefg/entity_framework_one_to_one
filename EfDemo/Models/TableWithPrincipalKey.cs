using System.ComponentModel.DataAnnotations.Schema;

namespace EfDemo.Models
{
    [Table(nameof(TableWithPrincipalKey))]
    public class TableWithPrincipalKey
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public TableWithForeignKey1 TableWithForeignKey1 { get; set; }

        public TableWithForeignKey2 TableWithForeignKey2 { get; set; }
    }
}
