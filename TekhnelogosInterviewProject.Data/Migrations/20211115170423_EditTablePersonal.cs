using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TekhnelogosInterviewProject.Data.Migrations
{
    public partial class EditTablePersonal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Personal",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021,11,10));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Personal");
        }
    }
}
