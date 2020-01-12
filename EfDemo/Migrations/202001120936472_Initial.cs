namespace EfDemo.Migrations
{
    using EfDemo.Models;
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        private readonly string _tableWithPrincipalKeyName;
        private readonly string _tableWithForeignKey1Name;
        private readonly string _tableWithForeignKey2Name;
        private readonly string _foreignKey1ColumnName;
        private readonly string _foreignKey2ColumnName;

        public Initial()
        {
            _tableWithPrincipalKeyName = GetTableName(nameof(TableWithPrincipalKey));
            _tableWithForeignKey1Name = GetTableName(nameof(TableWithForeignKey1));
            _tableWithForeignKey2Name = GetTableName(nameof(TableWithForeignKey2));
            _foreignKey1ColumnName = _foreignKey2ColumnName = nameof(TableWithForeignKey1.TableWithPrincipalKeyId);
        }

        public override void Up()
        {
            CreateTable(
                _tableWithPrincipalKeyName,
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                _tableWithForeignKey1Name,
                c => new
                    {
                        Id = c.Int(nullable: false),
                        TableWithPrincipalKeyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey(_tableWithPrincipalKeyName, t => t.TableWithPrincipalKeyId)
                .Index(t => t.TableWithPrincipalKeyId, unique: true);
            
            CreateTable(
                _tableWithForeignKey2Name,
                c => new
                    {
                        Id = c.Int(nullable: false),
                        TableWithPrincipalKeyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey(_tableWithPrincipalKeyName, t => t.TableWithPrincipalKeyId)
                .Index(t => t.TableWithPrincipalKeyId, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey(_tableWithForeignKey1Name, _foreignKey1ColumnName, _tableWithPrincipalKeyName);
            DropForeignKey(_tableWithForeignKey2Name, _foreignKey2ColumnName, _tableWithPrincipalKeyName);
            
            DropIndex(_tableWithForeignKey1Name, new[] { _foreignKey1ColumnName });
            DropIndex(_tableWithForeignKey2Name, new[] { _foreignKey2ColumnName });

            DropTable(_tableWithForeignKey1Name);
            DropTable(_tableWithForeignKey2Name);
            DropTable(_tableWithPrincipalKeyName);
        }

        private string GetTableName(string name)
        {
            return $"dbo.{name}";
        }
    }
}
