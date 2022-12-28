using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IncomeService.Migrations
{
    /// <inheritdoc />
    public partial class IncomeRecordsReimplement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncomeRecords_IncomeCategories_CategoryId",
                table: "IncomeRecords");

            migrationBuilder.DropTable(
                name: "IncomeCategories");

            migrationBuilder.DropIndex(
                name: "IX_IncomeRecords_CategoryId",
                table: "IncomeRecords");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "IncomeRecords");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "IncomeRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "IncomeRecords");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "IncomeRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "IncomeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IncomeRecords_CategoryId",
                table: "IncomeRecords",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeRecords_IncomeCategories_CategoryId",
                table: "IncomeRecords",
                column: "CategoryId",
                principalTable: "IncomeCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
