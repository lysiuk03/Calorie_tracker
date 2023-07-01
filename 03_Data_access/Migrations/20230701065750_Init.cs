using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _03_Data_access.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Coefficient = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Proteins = table.Column<double>(type: "float", nullable: false),
                    Fats = table.Column<double>(type: "float", nullable: false),
                    Carbs = table.Column<double>(type: "float", nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Goal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coefficient = table.Column<double>(type: "float", nullable: false),
                    Share_proteins = table.Column<double>(type: "float", nullable: false),
                    Share_fats = table.Column<double>(type: "float", nullable: false),
                    Share_carbs = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sex",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sex", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Login = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    SexId = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    GoalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Login);
                    table.ForeignKey(
                        name: "FK_Accounts_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_Goal_GoalId",
                        column: x => x.GoalId,
                        principalTable: "Goal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_Sex_SexId",
                        column: x => x.SexId,
                        principalTable: "Sex",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodDiary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Portion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodDiary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodDiary_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Login",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodDiary_Food_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Food",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WaterDiary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Portion = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterDiary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaterDiary_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Login",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Activity",
                columns: new[] { "Id", "Coefficient", "Name" },
                values: new object[,]
                {
                    { 1, 1.2, "Sedentary" },
                    { 2, 1.375, "Light" },
                    { 3, 1.55, "Moderate" },
                    { 4, 1.7250000000000001, "High" },
                    { 5, 1.8999999999999999, "Very High" }
                });

            migrationBuilder.InsertData(
                table: "Food",
                columns: new[] { "Id", "Calories", "Carbs", "Fats", "Name", "Proteins" },
                values: new object[,]
                {
                    { 1, 46, 11.1, 0.0, "Cherry", 0.90000000000000002 },
                    { 2, 46, 9.6999999999999993, 0.69999999999999996, "Kiwi", 1.0 },
                    { 3, 30, 7.0, 0.40000000000000002, "Strawberry", 0.59999999999999998 },
                    { 4, 30, 3.2999999999999998, 0.0, "Lemon", 0.90000000000000002 },
                    { 5, 48, 11.4, 0.0, "Apple", 0.5 },
                    { 6, 41, 8.8000000000000007, 0.0, "Bilberry", 1.2 },
                    { 7, 42, 10.1, 0.0, "Peach", 0.90000000000000002 },
                    { 8, 43, 9.1999999999999993, 0.0, "Raspberry", 0.69999999999999996 },
                    { 9, 69, 11.800000000000001, 0.40000000000000002, "Mango", 0.59999999999999998 },
                    { 10, 41, 10.6, 0.0, "Pear", 0.5 }
                });

            migrationBuilder.InsertData(
                table: "Goal",
                columns: new[] { "Id", "Coefficient", "Name", "Share_carbs", "Share_fats", "Share_proteins" },
                values: new object[,]
                {
                    { 1, 0.84999999999999998, "Lose weight", 0.42999999999999999, 0.28999999999999998, 0.28000000000000003 },
                    { 2, 1.0, "Maintain weight", 0.48999999999999999, 0.26000000000000001, 0.25 },
                    { 3, 1.1000000000000001, "Increase weight", 0.46999999999999997, 0.28000000000000003, 0.25 }
                });

            migrationBuilder.InsertData(
                table: "Sex",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Login", "ActivityId", "Age", "GoalId", "Height", "Password", "SexId", "Weight" },
                values: new object[] { "Wukas", 2, 19, 1, 165, "QWERTY1234", 2, 60.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ActivityId",
                table: "Accounts",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_GoalId",
                table: "Accounts",
                column: "GoalId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_SexId",
                table: "Accounts",
                column: "SexId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_Name",
                table: "Activity",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Food_Name",
                table: "Food",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FoodDiary_AccountId",
                table: "FoodDiary",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodDiary_FoodId",
                table: "FoodDiary",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Sex_Name",
                table: "Sex",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WaterDiary_AccountId",
                table: "WaterDiary",
                column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodDiary");

            migrationBuilder.DropTable(
                name: "WaterDiary");

            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "Goal");

            migrationBuilder.DropTable(
                name: "Sex");
        }
    }
}
