using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eduhub.StudentService.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Educators",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    work_experience = table.Column<int>(type: "integer", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    surname = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    first_name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    patronymic = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    gender = table.Column<string>(type: "text", nullable: false, defaultValue: "None"),
                    phone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educators", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    birth_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    city = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    street = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    house_number = table.Column<int>(type: "integer", nullable: true),
                    avatar = table.Column<string>(type: "text", nullable: false),
                    surname = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    first_name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    patronymic = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    gender = table.Column<string>(type: "text", nullable: false, defaultValue: "None"),
                    phone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    educator_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.id);
                    table.ForeignKey(
                        name: "FK_Courses_Educators_educator_id",
                        column: x => x.educator_id,
                        principalTable: "Educators",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    student_id = table.Column<Guid>(type: "uuid", nullable: false),
                    course_id = table.Column<Guid>(type: "uuid", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_course_id",
                        column: x => x.course_id,
                        principalTable: "Courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_student_id",
                        column: x => x.student_id,
                        principalTable: "Students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_educator_id",
                table: "Courses",
                column: "educator_id");

            migrationBuilder.CreateIndex(
                name: "IX_Educators_phone",
                table: "Educators",
                column: "phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_course_id",
                table: "Enrollments",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_student_id",
                table: "Enrollments",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_email",
                table: "Students",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_phone",
                table: "Students",
                column: "phone",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Educators");
        }
    }
}
