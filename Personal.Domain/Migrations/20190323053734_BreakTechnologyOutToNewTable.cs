using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Personal.Domain.Migrations
{
    public partial class BreakTechnologyOutToNewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "stack_json",
                table: "t_job_positions");

            migrationBuilder.CreateTable(
                name: "t_technologies",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(type: "citext", nullable: true),
                    ordinal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_technologies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_position_technology",
                columns: table => new
                {
                    position_id = table.Column<Guid>(nullable: false),
                    technology_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_position_technology", x => new { x.position_id, x.technology_id });
                    table.ForeignKey(
                        name: "FK_t_position_technology_t_job_positions_position_id",
                        column: x => x.position_id,
                        principalTable: "t_job_positions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_position_technology_t_technologies_technology_id",
                        column: x => x.technology_id,
                        principalTable: "t_technologies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_position_technology_technology_id",
                table: "t_position_technology",
                column: "technology_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_position_technology");

            migrationBuilder.DropTable(
                name: "t_technologies");

            migrationBuilder.AddColumn<string>(
                name: "stack_json",
                table: "t_job_positions",
                type: "jsonb",
                nullable: true);
        }
    }
}
