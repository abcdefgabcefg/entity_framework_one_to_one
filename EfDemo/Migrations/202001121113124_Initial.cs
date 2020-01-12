﻿namespace EfDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TableWithForeignKey1",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        TableWithPrincipalKeyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TableWithPrincipalKey", t => t.TableWithPrincipalKeyId)
                .Index(t => t.TableWithPrincipalKeyId, unique: true);
            
            CreateTable(
                "dbo.TableWithPrincipalKey",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TableWithForeignKey2",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        TableWithPrincipalKeyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TableWithPrincipalKey", t => t.TableWithPrincipalKeyId)
                .Index(t => t.TableWithPrincipalKeyId, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TableWithForeignKey1", "Id", "dbo.TableWithPrincipalKey");
            DropForeignKey("dbo.TableWithForeignKey2", "Id", "dbo.TableWithPrincipalKey");
            DropIndex("dbo.TableWithForeignKey2", new[] { "TableWithPrincipalKeyId" });
            DropIndex("dbo.TableWithForeignKey1", new[] { "TableWithPrincipalKeyId" });
            DropTable("dbo.TableWithForeignKey2");
            DropTable("dbo.TableWithPrincipalKey");
            DropTable("dbo.TableWithForeignKey1");
        }
    }
}
