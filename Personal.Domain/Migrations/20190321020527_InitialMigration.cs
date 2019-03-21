using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Personal.Domain.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:citext", ",,");

            migrationBuilder.CreateTable(
                name: "t_asp_net_roles",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(type: "citext", maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(type: "citext", maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(type: "citext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_asp_net_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_asp_net_users",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    user_name = table.Column<string>(type: "citext", maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(type: "citext", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "citext", maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(type: "citext", maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(nullable: false),
                    password_hash = table.Column<string>(type: "citext", nullable: true),
                    security_stamp = table.Column<string>(type: "citext", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "citext", nullable: true),
                    phone_number = table.Column<string>(type: "citext", nullable: true),
                    phone_number_confirmed = table.Column<bool>(nullable: false),
                    two_factor_enabled = table.Column<bool>(nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(nullable: true),
                    lockout_enabled = table.Column<bool>(nullable: false),
                    access_failed_count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_asp_net_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_job_positions",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    title = table.Column<string>(type: "citext", nullable: true),
                    company_name = table.Column<string>(type: "citext", nullable: true),
                    start_date = table.Column<DateTime>(nullable: false),
                    end_date = table.Column<DateTime>(nullable: false),
                    location = table.Column<string>(type: "citext", nullable: true),
                    duties_json = table.Column<string>(type: "jsonb", nullable: true, defaultValue: "[]"),
                    stack_json = table.Column<string>(type: "jsonb", nullable: true, defaultValue: "[]")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_job_positions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_asp_net_role_claims",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    role_id = table.Column<Guid>(nullable: false),
                    claim_type = table.Column<string>(type: "citext", nullable: true),
                    claim_value = table.Column<string>(type: "citext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_asp_net_role_claims", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_asp_net_role_claims_t_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "t_asp_net_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_asp_net_user_claims",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    user_id = table.Column<Guid>(nullable: false),
                    claim_type = table.Column<string>(type: "citext", nullable: true),
                    claim_value = table.Column<string>(type: "citext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_asp_net_user_claims", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_asp_net_user_claims_t_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "t_asp_net_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_asp_net_user_logins",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "citext", nullable: false),
                    provider_key = table.Column<string>(type: "citext", nullable: false),
                    provider_display_name = table.Column<string>(type: "citext", nullable: true),
                    user_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_asp_net_user_logins", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "FK_t_asp_net_user_logins_t_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "t_asp_net_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_asp_net_user_roles",
                columns: table => new
                {
                    user_id = table.Column<Guid>(nullable: false),
                    role_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_asp_net_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "FK_t_asp_net_user_roles_t_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "t_asp_net_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_asp_net_user_roles_t_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "t_asp_net_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_asp_net_user_tokens",
                columns: table => new
                {
                    user_id = table.Column<Guid>(nullable: false),
                    login_provider = table.Column<string>(type: "citext", nullable: false),
                    name = table.Column<string>(type: "citext", nullable: false),
                    value = table.Column<string>(type: "citext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_asp_net_user_tokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "FK_t_asp_net_user_tokens_t_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "t_asp_net_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_asp_net_role_claims_role_id",
                table: "t_asp_net_role_claims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "t_asp_net_roles",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_asp_net_user_claims_user_id",
                table: "t_asp_net_user_claims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_asp_net_user_logins_user_id",
                table: "t_asp_net_user_logins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_asp_net_user_roles_role_id",
                table: "t_asp_net_user_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "t_asp_net_users",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "t_asp_net_users",
                column: "normalized_user_name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_asp_net_role_claims");

            migrationBuilder.DropTable(
                name: "t_asp_net_user_claims");

            migrationBuilder.DropTable(
                name: "t_asp_net_user_logins");

            migrationBuilder.DropTable(
                name: "t_asp_net_user_roles");

            migrationBuilder.DropTable(
                name: "t_asp_net_user_tokens");

            migrationBuilder.DropTable(
                name: "t_job_positions");

            migrationBuilder.DropTable(
                name: "t_asp_net_roles");

            migrationBuilder.DropTable(
                name: "t_asp_net_users");
        }
    }
}
