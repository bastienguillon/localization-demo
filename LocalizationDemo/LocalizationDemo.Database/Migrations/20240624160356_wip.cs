using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalizationDemo.Database.Migrations
{
    /// <inheritdoc />
    public partial class wip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormElement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FormElementDiscriminator = table.Column<string>(type: "TEXT", maxLength: 13, nullable: false),
                    FormElementStructureDiscriminator = table.Column<string>(type: "TEXT", nullable: false),
                    ReferenceCulture = table.Column<string>(type: "TEXT", nullable: false),
                    FormElementStructureDiscriminator1 = table.Column<string>(type: "TEXT", maxLength: 21, nullable: false),
                    ListFormElementStructure_ReferenceCulture = table.Column<string>(type: "TEXT", nullable: true),
                    RangeFormElementStructure_ReferenceCulture = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormElement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "I18nFormElement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FormElementId = table.Column<int>(type: "INTEGER", nullable: false),
                    CultureCode = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_I18nFormElement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_I18nFormElement_FormElement_FormElementId",
                        column: x => x.FormElementId,
                        principalTable: "FormElement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "I18nListFormElementStructure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FormElementId = table.Column<int>(type: "INTEGER", nullable: false),
                    CultureCode = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_I18nListFormElementStructure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_I18nListFormElementStructure_FormElement_FormElementId",
                        column: x => x.FormElementId,
                        principalTable: "FormElement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "I18nRangeFormElementStructure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FormElementId = table.Column<int>(type: "INTEGER", nullable: false),
                    CultureCode = table.Column<string>(type: "TEXT", nullable: false),
                    MinLabel = table.Column<string>(type: "TEXT", nullable: false),
                    MaxLabel = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_I18nRangeFormElementStructure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_I18nRangeFormElementStructure_FormElement_FormElementId",
                        column: x => x.FormElementId,
                        principalTable: "FormElement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_I18nFormElement_FormElementId",
                table: "I18nFormElement",
                column: "FormElementId");

            migrationBuilder.CreateIndex(
                name: "IX_I18nListFormElementStructure_FormElementId",
                table: "I18nListFormElementStructure",
                column: "FormElementId");

            migrationBuilder.CreateIndex(
                name: "IX_I18nRangeFormElementStructure_FormElementId",
                table: "I18nRangeFormElementStructure",
                column: "FormElementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "I18nFormElement");

            migrationBuilder.DropTable(
                name: "I18nListFormElementStructure");

            migrationBuilder.DropTable(
                name: "I18nRangeFormElementStructure");

            migrationBuilder.DropTable(
                name: "FormElement");
        }
    }
}
