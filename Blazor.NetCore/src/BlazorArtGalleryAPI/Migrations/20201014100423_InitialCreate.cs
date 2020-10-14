using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorArtGalleryAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArtDetail",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    ArtistName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Private = table.Column<bool>(nullable: false),
                    Available = table.Column<bool>(nullable: false),
                    SendAFriend = table.Column<bool>(nullable: false),
                    SmallImageUrl = table.Column<string>(nullable: true),
                    LargeImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtDetail", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "ArtDetail",
                columns: new[] { "ID", "ArtistName", "Available", "Description", "LargeImageUrl", "Private", "SendAFriend", "SmallImageUrl", "Title" },
                values: new object[,]
                {
                    { 1, "Misti Vanni", true, "vel accumsan tellus nisi eu orci mauris lacinia sapien quis libero", "images/big-images/Rock_On_Stencil_by_spookyjthm777.jpg", true, true, "images/small-images/Rock_On_Stencil_by_spookyjthm777.jpg", "Love Is the Devil" },
                    { 2, "Kassi Grist", true, "ipsum ac tellus semper interdum mauris ullamcorper purus sit amet nulla quisque", "images/big-images/Rock_On_Stencil_by_spookyjthm777.jpg", true, true, "images/small-images/Rock_On_Stencil_by_spookyjthm777.jpg", "Way We Laughed, The (Così Ridevano)" },
                    { 3, "Mallissa Barhams", true, "fermentum donec ut mauris eget massa tempor convallis nulla neque libero convallis eget eleifend luctus ultricies eu nibh", "images/big-images/Rock_On_Stencil_by_spookyjthm777.jpg", true, true, "images/small-images/Rock_On_Stencil_by_spookyjthm777.jpg", "Undertaker and His Pals" },
                    { 4, "Cathe Pallaske", true, "posuere cubilia curae donec pharetra magna vestibulum aliquet ultrices erat tortor sollicitudin", "images/big-images/Rock_On_Stencil_by_spookyjthm777.jpg", true, true, "images/small-images/Rock_On_Stencil_by_spookyjthm777.jpg", "Being Elmo: A Puppeteer's Journey" },
                    { 5, "Misti Vanni", true, "vel accumsan tellus nisi eu orci mauris lacinia sapien quis libero", "images/big-images/Rock_On_Stencil_by_spookyjthm777.jpg", true, true, "images/small-images/Rock_On_Stencil_by_spookyjthm777.jpg", "Love Is the Devil" },
                    { 6, "Kassi Grist", true, "ipsum ac tellus semper interdum mauris ullamcorper purus sit amet nulla quisque", "images/big-images/Rock_On_Stencil_by_spookyjthm777.jpg", true, true, "images/small-images/Rock_On_Stencil_by_spookyjthm777.jpg", "Way We Laughed, The (Così Ridevano)" },
                    { 7, "Mallissa Barhams", true, "fermentum donec ut mauris eget massa tempor convallis nulla neque libero convallis eget eleifend luctus ultricies eu nibh", "images/big-images/Rock_On_Stencil_by_spookyjthm777.jpg", true, true, "images/small-images/Rock_On_Stencil_by_spookyjthm777.jpg", "Undertaker and His Pals" },
                    { 8, "Cathe Pallaske", true, "posuere cubilia curae donec pharetra magna vestibulum aliquet ultrices erat tortor sollicitudin", "images/big-images/Rock_On_Stencil_by_spookyjthm777.jpg", true, true, "images/small-images/Rock_On_Stencil_by_spookyjthm777.jpg", "Being Elmo: A Puppeteer's Journey" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtDetail");
        }
    }
}
