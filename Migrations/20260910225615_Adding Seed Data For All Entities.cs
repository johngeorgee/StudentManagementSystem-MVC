using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class AddingSeedDataForAllEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "ManagerName", "Name" },
                values: new object[,]
                {
                    { 1, "Dr. Ahmed Hassan", "Computer Science" },
                    { 2, "Dr. Mona Khalil", "Information Systems" },
                    { 3, "Dr. Youssef Adel", "Software Engineering" },
                    { 4, "Dr. Sara Ibrahim", "Artificial Intelligence" },
                    { 5, "Dr. Khaled Mostafa", "Cybersecurity" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Degree", "DepartmentId", "Name", "minDegree" },
                values: new object[,]
                {
                    { 1, 100, 1, "Introduction to Programming", 50 },
                    { 2, 100, 1, "Database Systems", 60 },
                    { 3, 100, 2, "Object-Oriented Design", 55 },
                    { 4, 100, 3, "Machine Learning Fundamentals", 65 },
                    { 5, 100, 4, "Network Security", 60 }
                });

            migrationBuilder.InsertData(
                table: "Trainees",
                columns: new[] { "Id", "DepartmentId", "Grade", "ImageUrl", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, 88.5m, "/images/trainees/ali.jpg", "Ali Mahmoud", "01011111111" },
                    { 2, 1, 92.0m, "/images/trainees/salma.jpg", "Salma Nabil", "01112222222" },
                    { 3, 2, 79.5m, "/images/trainees/omar.jpg", "Omar Tarek", "01213333333" },
                    { 4, 2, 85.0m, "/images/trainees/nour.jpg", "Nour Adel", "01014444444" },
                    { 5, 3, 74.0m, "/images/trainees/yousef.jpg", "Yousef Samir", "01115555555" },
                    { 6, 4, 90.0m, "/images/trainees/hana.jpg", "Hana Wael", "01216666666" },
                    { 7, 5, 68.0m, "/images/trainees/karim.jpg", "Karim Hossam", "01017777777" }
                });

            migrationBuilder.InsertData(
                table: "CourseResults",
                columns: new[] { "Id", "CourseId", "Degree", "TraineeId" },
                values: new object[,]
                {
                    { 1, 1, 90m, 1 },
                    { 2, 2, 78m, 1 },
                    { 3, 3, 82m, 1 },
                    { 4, 1, 95m, 2 },
                    { 5, 2, 88m, 2 },
                    { 6, 3, 70m, 3 },
                    { 7, 4, 55m, 3 },
                    { 8, 4, 72m, 4 },
                    { 9, 5, 62m, 5 },
                    { 10, 5, 80m, 6 },
                    { 11, 5, 58m, 7 }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Address", "CourseId", "DepartmentId", "Email", "ImageUrl", "Name", "Phone", "Salary" },
                values: new object[,]
                {
                    { 1, "Cairo, Nasr City", 1, 1, "ahmed.hassan@uni.edu", "/images/instructors/ahmed.jpg", "Dr. Ahmed Hassan", "01001234567", 15000.0 },
                    { 2, "Cairo, Heliopolis", 1, 1, "hala.sami@uni.edu", "/images/instructors/hala.jpg", "Dr. Hala Sami", "01002234567", 14500.0 },
                    { 3, "Giza, Haram", 1, 1, "tarek.fouad@uni.edu", "/images/instructors/tarek.jpg", "Dr. Tarek Fouad", "01103234567", 14800.0 },
                    { 4, "Giza, Dokki", 2, 1, "mona.khalil@uni.edu", "/images/instructors/mona.jpg", "Dr. Mona Khalil", "01102345678", 16000.0 },
                    { 5, "Cairo, Maadi", 2, 1, "rania.wagdy@uni.edu", "/images/instructors/rania.jpg", "Dr. Rania Wagdy", "01004567890", 15200.0 },
                    { 6, "Alexandria, Smouha", 3, 2, "youssef.adel@uni.edu", "/images/instructors/youssef.jpg", "Dr. Youssef Adel", "01203456789", 15500.0 },
                    { 7, "Cairo, Maadi", 4, 3, "sara.ibrahim@uni.edu", "/images/instructors/sara.jpg", "Dr. Sara Ibrahim", "01005567890", 17500.0 },
                    { 8, "Cairo, Heliopolis", 5, 4, "khaled.mostafa@uni.edu", "/images/instructors/khaled.jpg", "Dr. Khaled Mostafa", "01105678901", 16500.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CourseResults",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CourseResults",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CourseResults",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CourseResults",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CourseResults",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CourseResults",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CourseResults",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CourseResults",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CourseResults",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CourseResults",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CourseResults",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
