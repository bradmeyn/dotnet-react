using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AddTemporaryUuidColumn : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        // Add new UUID column first
        migrationBuilder.AddColumn<Guid>(
            name: "NewId",
            table: "Clients",
            type: "uuid",
            nullable: false,
            defaultValueSql: "gen_random_uuid()");

        // Generate UUIDs for existing rows
        migrationBuilder.Sql("UPDATE \"Clients\" SET \"NewId\" = gen_random_uuid()");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "NewId",
            table: "Clients");
    }
}
}
