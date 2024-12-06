using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeePos.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Positions_ParentId",
                table: "Positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Positions",
                table: "Positions");

            migrationBuilder.EnsureSchema(
                name: "pos");

            migrationBuilder.RenameTable(
                name: "Positions",
                newName: "postions",
                newSchema: "pos");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "pos",
                table: "postions",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "pos",
                table: "postions",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "pos",
                table: "postions",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Positions_ParentId",
                schema: "pos",
                table: "postions",
                newName: "IX_postions_ParentId");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "pos",
                table: "postions",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_postions",
                schema: "pos",
                table: "postions",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_postions_postions_ParentId",
                schema: "pos",
                table: "postions",
                column: "ParentId",
                principalSchema: "pos",
                principalTable: "postions",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_postions_postions_ParentId",
                schema: "pos",
                table: "postions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_postions",
                schema: "pos",
                table: "postions");

            migrationBuilder.RenameTable(
                name: "postions",
                schema: "pos",
                newName: "Positions");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Positions",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Positions",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Positions",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_postions_ParentId",
                table: "Positions",
                newName: "IX_Positions_ParentId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Positions",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Positions",
                table: "Positions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Positions_ParentId",
                table: "Positions",
                column: "ParentId",
                principalTable: "Positions",
                principalColumn: "Id");
        }
    }
}
