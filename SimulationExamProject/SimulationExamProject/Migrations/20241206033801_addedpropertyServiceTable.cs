using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimulationExamProject.Migrations
{
    /// <inheritdoc />
    public partial class addedpropertyServiceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainImageUrl",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainImageUrl",
                table: "Services");
        }
    }
}
