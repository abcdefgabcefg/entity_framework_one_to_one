using System.ComponentModel.DataAnnotations.Schema;

namespace EfDemo.Models
{
    public class TableWithForeignKey2
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey(nameof(TableWithPrincipalKey))]
        public int Id { get; set; }

        public virtual TableWithPrincipalKey TableWithPrincipalKey { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} has relationship with {nameof(TableWithPrincipalKey)}[ID: {TableWithPrincipalKey.Id}]";
        }
    }
}
