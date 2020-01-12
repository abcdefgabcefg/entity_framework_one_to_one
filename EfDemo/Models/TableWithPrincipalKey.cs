using System.ComponentModel.DataAnnotations.Schema;

namespace EfDemo.Models
{
    [Table(nameof(TableWithPrincipalKey))]
    public class TableWithPrincipalKey
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public virtual TableWithForeignKey1 TableWithForeignKey1 { get; set; }

        public virtual TableWithForeignKey2 TableWithForeignKey2 { get; set; }

        public override string ToString()
        {
            var @string = $"ID: {Id} ";

            if (TableWithForeignKey1 != null)
            {
                @string += $"has relationship with {nameof(TableWithForeignKey1)}[ID: {TableWithForeignKey1.Id}]";
            }
            else
            {
                @string += $"doesn't have relationship with {nameof(TableWithForeignKey1)}";
            }

            @string += " and ";

            if (TableWithForeignKey2 != null)
            {
                @string += $"has relationship with {nameof(TableWithForeignKey2)}[ID: {TableWithForeignKey2.Id}], ";
            }
            else
            {
                @string += $"doesn't have relationship with {nameof(TableWithForeignKey2)}";
            }

            return @string;
        }
    }
}
