using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CreatedRestOfTheModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Budget",
                columns: table => new
                {
                    BudgetId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BudgetMonth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TotalIncome = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    TotalExpense = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    MonthlyNet = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budget", x => x.BudgetId);
                    table.ForeignKey(
                        name: "FK_Budget_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expense",
                columns: table => new
                {
                    ExpenseId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExpenseName = table.Column<string>(type: "text", nullable: false),
                    ExpenseAmount = table.Column<int>(type: "integer", nullable: false),
                    ExpenseMonth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpenseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpenseCategory = table.Column<string>(type: "text", nullable: false),
                    ExpenseDescription = table.Column<string>(type: "text", nullable: false),
                    RecurringFlag = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    BudgetId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense", x => x.ExpenseId);
                    table.ForeignKey(
                        name: "FK_Expense_Budget_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budget",
                        principalColumn: "BudgetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Income",
                columns: table => new
                {
                    IncomeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IncomeName = table.Column<string>(type: "text", nullable: false),
                    IncomeAmount = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    IncomeDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IncomeMonth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IncomeDescription = table.Column<string>(type: "text", nullable: false),
                    RecurringFlag = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    BudgetId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Income", x => x.IncomeId);
                    table.ForeignKey(
                        name: "FK_Income_Budget_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budget",
                        principalColumn: "BudgetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Saving",
                columns: table => new
                {
                    SavingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TotalSave = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    BudgetId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saving", x => x.SavingId);
                    table.ForeignKey(
                        name: "FK_Saving_Budget_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budget",
                        principalColumn: "BudgetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Budget_UserId",
                table: "Budget",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_BudgetId",
                table: "Expense",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Income_BudgetId",
                table: "Income",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Saving_BudgetId",
                table: "Saving",
                column: "BudgetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expense");

            migrationBuilder.DropTable(
                name: "Income");

            migrationBuilder.DropTable(
                name: "Saving");

            migrationBuilder.DropTable(
                name: "Budget");
        }
    }
}
