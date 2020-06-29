using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EL.API.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COMPLAIN_TBL",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    COMPLAIN_NAME = table.Column<string>(nullable: true),
                    COMPLAIN_DESCTIPTION = table.Column<long>(nullable: false),
                    COMPLAINT_FROM = table.Column<string>(nullable: true),
                    COMPLAIN_STATUS = table.Column<string>(nullable: true),
                    COMPLAINT_DATE = table.Column<string>(nullable: true),
                    CREATED_ON = table.Column<DateTime>(nullable: true),
                    MODIFIED_ON = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPLAIN_TBL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DECISIONS_LOOP_TBL",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    Main_Story_NAME = table.Column<string>(nullable: true),
                    SUB_STORY_ID = table.Column<long>(nullable: false),
                    SUB_STORY_NAME = table.Column<string>(nullable: true),
                    QUESTION_ID = table.Column<long>(nullable: false),
                    QUESTION_NAME = table.Column<string>(nullable: true),
                    OPTION1 = table.Column<string>(nullable: true),
                    OPTION2 = table.Column<string>(nullable: true),
                    OPTION3 = table.Column<string>(nullable: true),
                    OPTION4 = table.Column<string>(nullable: true),
                    RESULT = table.Column<string>(nullable: true),
                    CREATED_ON = table.Column<DateTime>(nullable: true),
                    MODIFIED_ON = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DECISIONS_LOOP_TBL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ICC_EMP_TBL",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    EMP_NAME = table.Column<string>(nullable: true),
                    EMP_JOB_TITLE = table.Column<string>(nullable: true),
                    EMP_MAIL = table.Column<string>(nullable: true),
                    EMP_PHONE_NO = table.Column<long>(nullable: false),
                    EMP_DEPART_TYPE = table.Column<string>(nullable: true),
                    EMP_QULIFICATION = table.Column<string>(nullable: true),
                    EMP_STATUS = table.Column<string>(nullable: true),
                    CREATED_ON = table.Column<DateTime>(nullable: true),
                    MODIFIED_ON = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICC_EMP_TBL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "POSH_GAME_PLAY_TBL",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    GAME_NAME = table.Column<string>(nullable: true),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    BACKGROUNDAUDIO = table.Column<string>(nullable: true),
                    MAXSCORE = table.Column<string>(nullable: true),
                    NOOFCASES = table.Column<string>(nullable: true),
                    OBJECTIVE = table.Column<string>(nullable: true),
                    OUTCOME = table.Column<string>(nullable: true),
                    DURATION = table.Column<string>(nullable: true),
                    GAME_TYPE = table.Column<string>(nullable: true),
                    IS_ACTIVE = table.Column<string>(nullable: true),
                    CREATED_ON = table.Column<DateTime>(nullable: true),
                    MODIFIED_ON = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POSH_GAME_PLAY_TBL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TIMEUP_LOOP_TBL",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    Main_Story_NAME = table.Column<string>(nullable: true),
                    SUB_STORY_ID = table.Column<long>(nullable: false),
                    SUB_STORY_NAME = table.Column<string>(nullable: true),
                    QUESTION_ID = table.Column<long>(nullable: false),
                    QUESTION_NAME = table.Column<string>(nullable: true),
                    OPTION1 = table.Column<string>(nullable: true),
                    OPTION2 = table.Column<string>(nullable: true),
                    OPTION3 = table.Column<string>(nullable: true),
                    OPTION4 = table.Column<string>(nullable: true),
                    RESULT = table.Column<string>(nullable: true),
                    CREATED_ON = table.Column<DateTime>(nullable: true),
                    MODIFIED_ON = table.Column<DateTime>(nullable: true),
                    TIME_START_ON = table.Column<DateTime>(nullable: false),
                    TIME_END_ON = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIMEUP_LOOP_TBL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USER_TBL",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Avatar = table.Column<string>(nullable: true),
                    Profession = table.Column<string>(nullable: true),
                    MODIFIED_ON = table.Column<DateTime>(nullable: true),
                    CREATED_ON = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_TBL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SCHEDULE_TBL",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TimeStart = table.Column<DateTime>(nullable: false),
                    TimeEnd = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false, defaultValue: 3),
                    Status = table.Column<int>(nullable: false, defaultValue: 1),
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: false),
                    CreatorId = table.Column<byte[]>(nullable: true),
                    ModifierId = table.Column<byte[]>(nullable: true),
                    CREATED_ON = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 6, 27, 17, 3, 32, 94, DateTimeKind.Local).AddTicks(5111))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCHEDULE_TBL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SCHEDULE_TBL_USER_TBL_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "USER_TBL",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SCHEDULE_TBL_USER_TBL_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "USER_TBL",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ATTENDEE_TBL",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    UserId = table.Column<byte[]>(nullable: false),
                    ScheduleId = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATTENDEE_TBL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ATTENDEE_TBL_SCHEDULE_TBL_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "SCHEDULE_TBL",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ATTENDEE_TBL_USER_TBL_UserId",
                        column: x => x.UserId,
                        principalTable: "USER_TBL",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ATTENDEE_TBL_ScheduleId",
                table: "ATTENDEE_TBL",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ATTENDEE_TBL_UserId",
                table: "ATTENDEE_TBL",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SCHEDULE_TBL_CreatorId",
                table: "SCHEDULE_TBL",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_SCHEDULE_TBL_ModifierId",
                table: "SCHEDULE_TBL",
                column: "ModifierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ATTENDEE_TBL");

            migrationBuilder.DropTable(
                name: "COMPLAIN_TBL");

            migrationBuilder.DropTable(
                name: "DECISIONS_LOOP_TBL");

            migrationBuilder.DropTable(
                name: "ICC_EMP_TBL");

            migrationBuilder.DropTable(
                name: "POSH_GAME_PLAY_TBL");

            migrationBuilder.DropTable(
                name: "TIMEUP_LOOP_TBL");

            migrationBuilder.DropTable(
                name: "SCHEDULE_TBL");

            migrationBuilder.DropTable(
                name: "USER_TBL");
        }
    }
}
