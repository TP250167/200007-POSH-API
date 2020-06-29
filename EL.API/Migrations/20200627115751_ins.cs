using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EL.API.Migrations
{
    public partial class ins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "SCHEDULE_TBL",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 27, 17, 27, 51, 6, DateTimeKind.Local).AddTicks(6757),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2020, 6, 27, 17, 3, 32, 94, DateTimeKind.Local).AddTicks(5111));

            migrationBuilder.CreateTable(
                name: "TEAM_EMP_TBL",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    TEAM_EMP_NAME = table.Column<string>(nullable: true),
                    TEAM_EMP_ID = table.Column<string>(nullable: true),
                    TEAM_DESCRIPTION = table.Column<string>(nullable: true),
                    TEAM_ID = table.Column<string>(nullable: true),
                    TEAM_TYPE = table.Column<string>(nullable: true),
                    IS_ACTIVE = table.Column<long>(nullable: false),
                    CREATED_ON = table.Column<DateTime>(nullable: true),
                    MODIFIED_ON = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEAM_EMP_TBL", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TEAM_EMP_TBL");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "SCHEDULE_TBL",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 27, 17, 3, 32, 94, DateTimeKind.Local).AddTicks(5111),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 27, 17, 27, 51, 6, DateTimeKind.Local).AddTicks(6757));
        }
    }
}
