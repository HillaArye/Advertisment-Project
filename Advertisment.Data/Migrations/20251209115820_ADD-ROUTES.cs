using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Advertisment.Data.Migrations
{
    /// <inheritdoc />
    public partial class ADDROUTES : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "codeRoute",
                table: "advertisers",
                newName: "Routeid");

            migrationBuilder.RenameColumn(
                name: "codeAdvertiser",
                table: "advers",
                newName: "Advertiserid");

            migrationBuilder.CreateIndex(
                name: "IX_advertisers_Routeid",
                table: "advertisers",
                column: "Routeid");

            migrationBuilder.CreateIndex(
                name: "IX_advers_Advertiserid",
                table: "advers",
                column: "Advertiserid");

            migrationBuilder.AddForeignKey(
                name: "FK_advers_advertisers_Advertiserid",
                table: "advers",
                column: "Advertiserid",
                principalTable: "advertisers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_advertisers_routes_Routeid",
                table: "advertisers",
                column: "Routeid",
                principalTable: "routes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_advers_advertisers_Advertiserid",
                table: "advers");

            migrationBuilder.DropForeignKey(
                name: "FK_advertisers_routes_Routeid",
                table: "advertisers");

            migrationBuilder.DropIndex(
                name: "IX_advertisers_Routeid",
                table: "advertisers");

            migrationBuilder.DropIndex(
                name: "IX_advers_Advertiserid",
                table: "advers");

            migrationBuilder.RenameColumn(
                name: "Routeid",
                table: "advertisers",
                newName: "codeRoute");

            migrationBuilder.RenameColumn(
                name: "Advertiserid",
                table: "advers",
                newName: "codeAdvertiser");
        }
    }
}
