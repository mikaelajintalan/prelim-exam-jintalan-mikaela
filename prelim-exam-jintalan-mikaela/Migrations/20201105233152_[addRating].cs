using Microsoft.EntityFrameworkCore.Migrations;

namespace prelim_exam_jintalan_mikaela.Migrations
{
    public partial class addRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "Movies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "Rating",
               table: "Movies");
        }
    }
}
