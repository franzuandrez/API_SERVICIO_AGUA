using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_SERVICIO_AGUA.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nit = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Motivo",
                columns: table => new
                {
                    IdMotivo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motivo", x => x.IdMotivo);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Medidor",
                columns: table => new
                {
                    IdMedidor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoMedidor = table.Column<string>(nullable: true),
                    IdCliente = table.Column<int>(nullable: false),
                    ClienteIdCliente = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medidor", x => x.IdMedidor);
                    table.ForeignKey(
                        name: "FK_Medidor_Cliente_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    IdOrden = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoOrden = table.Column<string>(nullable: true),
                    Estado = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    IdMotivo = table.Column<int>(nullable: false),
                    MotivoIdMotivo = table.Column<int>(nullable: true),
                    IdMedidor = table.Column<int>(nullable: false),
                    MedidorIdMedidor = table.Column<int>(nullable: true),
                    IdUsuarioAsignador = table.Column<int>(nullable: false),
                    UsuarioAsignadorIdUsuario = table.Column<int>(nullable: true),
                    IdUsuarioDespacha = table.Column<int>(nullable: false),
                    UsuarioDespachaIdUsuario = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden", x => x.IdOrden);
                    table.ForeignKey(
                        name: "FK_Orden_Medidor_MedidorIdMedidor",
                        column: x => x.MedidorIdMedidor,
                        principalTable: "Medidor",
                        principalColumn: "IdMedidor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orden_Motivo_MotivoIdMotivo",
                        column: x => x.MotivoIdMotivo,
                        principalTable: "Motivo",
                        principalColumn: "IdMotivo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orden_Usuario_UsuarioAsignadorIdUsuario",
                        column: x => x.UsuarioAsignadorIdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orden_Usuario_UsuarioDespachaIdUsuario",
                        column: x => x.UsuarioDespachaIdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Foto",
                columns: table => new
                {
                    IdFoto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(nullable: true),
                    IdOrden = table.Column<int>(nullable: false),
                    OrdenIdOrden = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foto", x => x.IdFoto);
                    table.ForeignKey(
                        name: "FK_Foto_Orden_OrdenIdOrden",
                        column: x => x.OrdenIdOrden,
                        principalTable: "Orden",
                        principalColumn: "IdOrden",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foto_OrdenIdOrden",
                table: "Foto",
                column: "OrdenIdOrden");

            migrationBuilder.CreateIndex(
                name: "IX_Medidor_ClienteIdCliente",
                table: "Medidor",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_MedidorIdMedidor",
                table: "Orden",
                column: "MedidorIdMedidor");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_MotivoIdMotivo",
                table: "Orden",
                column: "MotivoIdMotivo");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_UsuarioAsignadorIdUsuario",
                table: "Orden",
                column: "UsuarioAsignadorIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_UsuarioDespachaIdUsuario",
                table: "Orden",
                column: "UsuarioDespachaIdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foto");

            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.DropTable(
                name: "Medidor");

            migrationBuilder.DropTable(
                name: "Motivo");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
