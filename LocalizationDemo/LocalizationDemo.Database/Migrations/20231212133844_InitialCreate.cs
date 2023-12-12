using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalizationDemo.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsdPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTranslations",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    CultureCode = table.Column<string>(type: "TEXT", maxLength: 16, nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTranslations", x => new { x.ProductId, x.CultureCode });
                    table.ForeignKey(
                        name: "FK_ProductTranslations_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductTranslations_ProductId_IsDefault",
                table: "ProductTranslations",
                columns: new[] { "ProductId", "IsDefault" },
                unique: true,
                filter: "[IsDefault] = 1");
            
            // Available cultures view
            migrationBuilder.Sql(@"
                CREATE VIEW [AvailableCultures]([CultureCode]) AS
					SELECT 'fr-FR' AS [CultureCode] UNION ALL
					SELECT 'en-US' AS [CultureCode] UNION ALL
					SELECT 'es-ES' AS [CultureCode] UNION ALL
					SELECT 'it-IT' AS [CultureCode] UNION ALL
					SELECT 'de-DE' AS [CultureCode] UNION ALL
					SELECT 'nl-NL' AS [CultureCode] UNION ALL
					SELECT 'nl-BE' AS [CultureCode] UNION ALL
					SELECT 'pt-PT' AS [CultureCode]
            ");

            // Localized products view
            migrationBuilder.Sql(@"
                CREATE VIEW [LocalizedProducts] AS
				SELECT
				    [Id],
				    [UsdPrice],
				    [Category],
				    [cultures].[CultureCode],
			        IIF(
	                    [translations].[Name] IS NULL OR LENGTH(TRIM([translations].[Name])) = 0,
	                    [defaultI18n].[Name],
	                    [translations].[Name]
			        ) AS [Name],
				    IIF(
		                [cultures].[CultureCode] = [defaultI18n].[CultureCode],
		                [defaultI18n].[Description],
		                [translations].[Description]
				    ) AS [Description]
				FROM [Products] [core]
				     INNER JOIN [AvailableCultures] [cultures]
				                ON 1 = 1
				     INNER JOIN [ProductTranslations] [defaultI18n]
				                ON [defaultI18n].[ProductId] = [core].[Id] AND [defaultI18n].[IsDefault] = 1
				     LEFT JOIN [ProductTranslations] [translations]
				               ON [translations].[ProductId] = [core].[Id] AND [cultures].[CultureCode] = [translations].[CultureCode] AND [translations].[IsDefault] = 0
            ");
            
            // Add test data
            migrationBuilder.Sql(@"
                INSERT INTO [Products]([UsdPrice], [Category])
				VALUES
				(12, 'Toy'),
				(35, 'Food'),
				(899, 'MedievalSiegeEngine'),
				(16, 'Clothes'),
				(1638, 'Music'),
				(27, 'Weapons')
			");

            migrationBuilder.Sql(@"
				INSERT INTO [ProductTranslations]([ProductId], [CultureCode], [IsDefault], [Name], [Description])
				VALUES
				(1, 'en-US', 1, 'SpongeBob SquarePants plush', ''),
				(1, 'fr-FR', 0, 'Peluche Bob l''éponge', ''),

				(2, 'en-US', 1, 'Golden oysters', 'Better than caviar'),
				(2, 'fr-FR', 0, 'Huîtres en or', 'Mieux que le caviar'),

				(3, 'en-US', 1, 'Trechuchet', ''),
				(3, 'fr-FR', 0, 'Trébuchet', 'Construction médiévale capable de lancer un projectile de 90 kilogrammes sur une distance de 300 mètres.'),

				(4, 'en-US', 1, 'Tie', ''),
				(4, 'fr-FR', 0, 'Cravate', ''),

				(5, 'en-US', 1, 'Yellow Fender Stratocaster', 'Who knew single-coil pickups were so expensive?'),

				(6, 'en-US', 1, 'Nerf gun', 'Now with a Fortnite theme'),
				(6, 'fr-FR', 0, 'Pistolet nerf', 'Maintenant avec un thème Fortnite')
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.Sql(@"DROP VIEW IF EXISTS [AvailableCultures]");
	        migrationBuilder.Sql(@"DROP VIEW IF EXISTS [LocalizedProducts]");
	        
            migrationBuilder.DropTable(
                name: "ProductTranslations");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
