using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class migNotificationcolloraddcolumnduzeltme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NotificationTyprSymbol",
                table: "Notifications",
                newName: "NotificationTypeSymbol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NotificationTypeSymbol",
                table: "Notifications",
                newName: "NotificationTyprSymbol");
        }
    }
}
