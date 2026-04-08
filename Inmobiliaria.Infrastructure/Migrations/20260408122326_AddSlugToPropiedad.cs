using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inmobiliaria.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSlugToPropiedad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Disposicion",
                table: "Propiedades",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Propiedades",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Orientacion",
                table: "Propiedades",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TieneAgua",
                table: "Propiedades",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TieneAscensor",
                table: "Propiedades",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TieneBalcon",
                table: "Propiedades",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TieneCalefon",
                table: "Propiedades",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TieneCloacas",
                table: "Propiedades",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TieneCocina",
                table: "Propiedades",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TieneCocinaComedor",
                table: "Propiedades",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TieneComedor",
                table: "Propiedades",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TieneFondo",
                table: "Propiedades",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TieneGasEnvasado",
                table: "Propiedades",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TieneGasNatural",
                table: "Propiedades",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TieneImpMunicipales",
                table: "Propiedades",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TieneImpProvinciales",
                table: "Propiedades",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TieneInternet",
                table: "Propiedades",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TieneLavadero",
                table: "Propiedades",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TieneLavaderoSectorizado",
                table: "Propiedades",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TieneLiving",
                table: "Propiedades",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TieneLivingComedor",
                table: "Propiedades",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TieneLuz",
                table: "Propiedades",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TienePatio",
                table: "Propiedades",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TienePatioSeco",
                table: "Propiedades",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TienePavimento",
                table: "Propiedades",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TienePiscina",
                table: "Propiedades",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TieneQuincho",
                table: "Propiedades",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TieneSeguridad",
                table: "Propiedades",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TieneTelefono",
                table: "Propiedades",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TieneTerraza",
                table: "Propiedades",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TieneToilette",
                table: "Propiedades",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disposicion",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "Orientacion",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "TieneAgua",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "TieneAscensor",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "TieneBalcon",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "TieneCalefon",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "TieneCloacas",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "TieneCocina",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "TieneCocinaComedor",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "TieneComedor",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "TieneFondo",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "TieneGasEnvasado",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "TieneGasNatural",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "TieneImpMunicipales",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "TieneImpProvinciales",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "TieneInternet",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "TieneLavadero",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "TieneLavaderoSectorizado",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "TieneLiving",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "TieneLivingComedor",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "TieneLuz",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "TienePatio",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "TienePatioSeco",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "TienePavimento",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "TienePiscina",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "TieneQuincho",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "TieneSeguridad",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "TieneTelefono",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "TieneTerraza",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "TieneToilette",
                table: "Propiedades");
        }
    }
}
