using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace blazor_server_dotnet6.Migrations
{
    public partial class AddProductToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(name: "products", 
                columns: (table) => new {
                        Id = table.Column<int>(type: "int", nullable: false)
                            .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Description = table.Column<string>(type: "varchar(255)", nullable: false),
                        ShopFavorites = table.Column<string>(type: "varchar(255)", nullable: false),
                        CustomerFavorites = table.Column<string>(type: "varchar(255)", nullable: false),
                        Color = table.Column<string>(type: "varchar(255)", nullable: false),
                        ImageUrl = table.Column<string>(type: "varchar(255)", nullable: false),
                        CategoryId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                }
            );

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "products");
        }
    }
}
