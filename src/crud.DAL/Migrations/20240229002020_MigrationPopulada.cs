using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crud.DAL.Migrations
{
    /// <inheritdoc />
    public partial class MigrationPopulada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Situacao = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");


            //Migration populando Marcas

            migrationBuilder.Sql("INSERT INTO crud.marcas(Id, Descricao, Situacao) VALUES('9652b405-38f6-40dc-a544-c923c1b3c704', 'AES', 'ATIVO')");
            migrationBuilder.Sql("INSERT INTO crud.marcas(Id, Descricao, Situacao) VALUES('f0298c34-6b06-473b-a4f6-53169bc1f10b', 'NEO QUIMICA', 'ATIVO')");
            migrationBuilder.Sql("INSERT INTO crud.marcas(Id, Descricao, Situacao) VALUES('2d27495e-6e09-42ae-8cf6-fc9c90186ce3', 'GEOLAB', 'INATIVO')");




            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Descricao = table.Column<string>(type: "varchar(300)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Preco = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Estoque = table.Column<int>(type: "int", nullable: false),
                    Situacao = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_Marca = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");



            //Populando Migration Produtos

            migrationBuilder.Sql("INSERT INTO crud.produtos(Id, Descricao, Preco, Estoque, Situacao, id_Marca) VALUES('dc2bc449-cfaa-42e0-9934-2107443e2ddb', 'DIPIRONA', 1.50, 10, 'ATIVO', 'f0298c34-6b06-473b-a4f6-53169bc1f10b')");
            migrationBuilder.Sql("INSERT INTO crud.produtos(Id, Descricao, Preco, Estoque, Situacao, id_Marca) VALUES('48ed9b6c-70a9-4a23-a0f3-55e659c25e62', 'SABONETE', 4.80, 55, 'ATIVO', '2d27495e-6e09-42ae-8cf6-fc9c90186ce3')");
            migrationBuilder.Sql("INSERT INTO crud.produtos(Id, Descricao, Preco, Estoque, Situacao, id_Marca) VALUES('afa985de-4c44-419d-8a3b-0a5ea783e88e', 'SHAMPOO', 10.15, 0, 'ATIVO', '9652b405-38f6-40dc-a544-c923c1b3c704')");
            migrationBuilder.Sql("INSERT INTO crud.produtos(Id, Descricao, Preco, Estoque, Situacao, id_Marca) VALUES('54479e73-0b85-4979-9809-90a34e7f6c89', 'ESCOVA DE DENTE', 3.50, 12, 'ATIVO', '2d27495e-6e09-42ae-8cf6-fc9c90186ce3')");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
