using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
   public partial class ReplaceIdWithUuid : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        // Drop old primary key
        migrationBuilder.DropPrimaryKey(
            name: "PK_Clients",
            table: "Clients");

        // Drop old Id column
        migrationBuilder.DropColumn(
            name: "Id",
            table: "Clients");

        // Rename NewId to Id
        migrationBuilder.RenameColumn(
            name: "NewId",
            table: "Clients",
            newName: "Id");

        // Add primary key to new Id column
        migrationBuilder.AddPrimaryKey(
            name: "PK_Clients",
            table: "Clients",
            column: "Id");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        // Add old id column back
        migrationBuilder.RenameColumn(
            name: "Id",
            table: "Clients",
            newName: "NewId");

        migrationBuilder.AddColumn<int>(
            name: "Id",
            table: "Clients",
            type: "integer",
            nullable: false)
            .Annotation("Npgsql:ValueGenerationStrategy", 
                NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

        migrationBuilder.AddPrimaryKey(
            name: "PK_Clients",
            table: "Clients",
            column: "Id");
    }
}
}
