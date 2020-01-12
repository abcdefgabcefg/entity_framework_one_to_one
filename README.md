In the above repository TableWithForeignKey1(Id) has 1:1 with TableWithPrincipalKey(Id) as same as TableWithForeignKey2 
with TableWithPrincipalKey(Id), so the point is entity framework can build right proxy for TableWithPrincipalKey.TableWithForeignKey1 
as same as TableWithPrincipalKey.TableWithForeignKey2 for principal entity and TableWithForeignKey1.TableWithPrincipalKey and 
TableWithForeignKey2.TableWithPrincipalKey for dependent entity. It shows console output where we get all dependent/principal entity ids 
via navigation properties (navigation property is called in overrided ToString)
