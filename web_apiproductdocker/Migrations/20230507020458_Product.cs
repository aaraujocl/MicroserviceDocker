using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace web_apiproductdocker.Migrations
{
    public partial class Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Codigo = table.Column<string>(type: "text", nullable: true),
                    Nomarticulo = table.Column<string>(type: "text", nullable: true),
                    Codmarca = table.Column<int>(type: "integer", nullable: false),
                    Codfamilia = table.Column<int>(type: "integer", nullable: false),
                    Codunidadmedida = table.Column<int>(type: "integer", nullable: false),
                    Codimpuesto = table.Column<int>(type: "integer", nullable: false),
                    Codtipoproducto = table.Column<int>(type: "integer", nullable: false),
                    Codigobarraprincipal = table.Column<string>(type: "text", nullable: true),
                    Serial = table.Column<string>(type: "text", nullable: true),
                    Referencia = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    Imagen = table.Column<string>(type: "text", nullable: true),
                    Preciosugerido = table.Column<double>(type: "double precision", nullable: false),
                    Iva = table.Column<double>(type: "double precision", nullable: false),
                    Precioconiva = table.Column<double>(type: "double precision", nullable: false),
                    Codnegocio = table.Column<long>(type: "bigint", nullable: false),
                    Descripcionlarga = table.Column<string>(type: "text", nullable: true),
                    Stockminimo = table.Column<double>(type: "double precision", nullable: false),
                    Stockmaximo = table.Column<double>(type: "double precision", nullable: false),
                    Cantidadreorden = table.Column<double>(type: "double precision", nullable: false),
                    Peso = table.Column<double>(type: "double precision", nullable: false),
                    Talla = table.Column<double>(type: "double precision", nullable: false),
                    Costounitario = table.Column<double>(type: "double precision", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: true),
                    Tipoiva = table.Column<string>(type: "text", nullable: true),
                    Esimpoconsumo = table.Column<string>(type: "text", nullable: true),
                    Valorimpoconsumo = table.Column<double>(type: "double precision", nullable: false),
                    Porcentajeimpoconsumo = table.Column<double>(type: "double precision", nullable: false),
                    Ivaincluido = table.Column<string>(type: "text", nullable: true),
                    Escompuesto = table.Column<bool>(type: "boolean", nullable: false),
                    Stock = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producto");
        }
    }
}
