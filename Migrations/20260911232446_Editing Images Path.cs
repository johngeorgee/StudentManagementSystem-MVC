using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class EditingImagesPath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/Images/male_avatar.jpeg");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/Images/female.jpeg");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/Images/male_avatar.jpeg");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "/Images/female.jpeg");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/Images/female.jpeg");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "/Images/male_avatar.jpeg");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "/Images/female.jpeg");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "/Images/male_avatar.jpeg");

            migrationBuilder.UpdateData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/Images/male_trainee.jpeg");

            migrationBuilder.UpdateData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/Images/female_trainee.jpeg");

            migrationBuilder.UpdateData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/Images/male_trainee.jpeg");

            migrationBuilder.UpdateData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "/Images/male_trainee.jpeg");

            migrationBuilder.UpdateData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/Images/male_trainee.jpeg");

            migrationBuilder.UpdateData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "/Images/female_trainee.jpeg");

            migrationBuilder.UpdateData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "/Images/male_trainee.jpeg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/images/instructors/ahmed.jpg");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/images/instructors/hala.jpg");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/images/instructors/tarek.jpg");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "/images/instructors/mona.jpg");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/images/instructors/rania.jpg");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "/images/instructors/youssef.jpg");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "/images/instructors/sara.jpg");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "/images/instructors/khaled.jpg");

            migrationBuilder.UpdateData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/images/trainees/ali.jpg");

            migrationBuilder.UpdateData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/images/trainees/salma.jpg");

            migrationBuilder.UpdateData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/images/trainees/omar.jpg");

            migrationBuilder.UpdateData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "/images/trainees/nour.jpg");

            migrationBuilder.UpdateData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/images/trainees/yousef.jpg");

            migrationBuilder.UpdateData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "/images/trainees/hana.jpg");

            migrationBuilder.UpdateData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "/images/trainees/karim.jpg");
        }
    }
}
