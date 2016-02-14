namespace GyCPersonal.EFContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.nombre, unique: true, name: "AK_Categoria_Nombre");
            
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        codProducto = c.String(nullable: false, maxLength: 20),
                        descripcion = c.String(nullable: false, maxLength: 80),
                        ultimoPrecioCoste = c.Decimal(nullable: false, precision: 18, scale: 2),
                        categoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categorias", t => t.categoriaId)
                .Index(t => t.codProducto, unique: true, name: "AK_Producto_CodigoProducto")
                .Index(t => t.descripcion, unique: true, name: "AK_Producto_Descripcion")
                .Index(t => t.categoriaId);
            
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        observaciones = c.String(maxLength: 100),
                        proveedorId = c.Int(nullable: false),
                        fechaCompra = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Proveedores", t => t.proveedorId)
                .Index(t => t.proveedorId);
            
            CreateTable(
                "dbo.DetalleCompras",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        compraId = c.Int(nullable: false),
                        productoId = c.Int(nullable: false),
                        cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Compras", t => t.compraId)
                .ForeignKey("dbo.Productos", t => t.productoId, cascadeDelete: true)
                .Index(t => t.compraId)
                .Index(t => t.productoId);
            
            CreateTable(
                "dbo.Proveedores",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 50,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "index",
                                    new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { Name: AK_Proveedor_Nombre, IsUnique: True }")
                                },
                            }),
                        direccion = c.String(maxLength: 100),
                        telefono = c.String(maxLength: 12),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Compras", "proveedorId", "dbo.Proveedores");
            DropForeignKey("dbo.DetalleCompras", "productoId", "dbo.Productos");
            DropForeignKey("dbo.DetalleCompras", "compraId", "dbo.Compras");
            DropForeignKey("dbo.Productos", "categoriaId", "dbo.Categorias");
            DropIndex("dbo.DetalleCompras", new[] { "productoId" });
            DropIndex("dbo.DetalleCompras", new[] { "compraId" });
            DropIndex("dbo.Compras", new[] { "proveedorId" });
            DropIndex("dbo.Productos", new[] { "categoriaId" });
            DropIndex("dbo.Productos", "AK_Producto_Descripcion");
            DropIndex("dbo.Productos", "AK_Producto_CodigoProducto");
            DropIndex("dbo.Categorias", "AK_Categoria_Nombre");
            DropTable("dbo.Proveedores",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "nombre",
                        new Dictionary<string, object>
                        {
                            { "index", "IndexAnnotation: { Name: AK_Proveedor_Nombre, IsUnique: True }" },
                        }
                    },
                });
            DropTable("dbo.DetalleCompras");
            DropTable("dbo.Compras");
            DropTable("dbo.Productos");
            DropTable("dbo.Categorias");
        }
    }
}
