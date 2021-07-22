using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GS.Persistance.Migrations
{
    public partial class RemovedUnncessesaryFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ProductWishList",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<long>(
                name: "ByteSize",
                table: "Images",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductWishList");

            migrationBuilder.DropColumn(
                name: "ByteSize",
                table: "Images");
        }
    }
}
