using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MeaningsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meanings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Definition = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Example = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Phonetics = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false),
                    PhoneticsAudio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SynonymId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meanings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meanings_Synonyms_SynonymId",
                        column: x => x.SynonymId,
                        principalTable: "Synonyms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meanings_SynonymId",
                table: "Meanings",
                column: "SynonymId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meanings");
        }
    }
}
