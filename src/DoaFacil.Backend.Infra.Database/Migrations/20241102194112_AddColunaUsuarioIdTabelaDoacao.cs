using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoaFacil.Backend.Infra.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddColunaUsuarioIdTabelaDoacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "doacao",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_doacao_UsuarioId",
                table: "doacao",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_doacao_usuario_UsuarioId",
                table: "doacao",
                column: "UsuarioId",
                principalTable: "usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doacao_usuario_UsuarioId",
                table: "doacao");

            migrationBuilder.DropIndex(
                name: "IX_doacao_UsuarioId",
                table: "doacao");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "doacao");
        }
    }
}
