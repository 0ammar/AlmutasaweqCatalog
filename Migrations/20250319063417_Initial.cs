using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlmutasaweqCatalog.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.CheckConstraint("CH_Name_Length", "Len(Name) >= 3");
                });

            migrationBuilder.CreateTable(
                name: "SubOnes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubOnes", x => x.Id);
                    table.CheckConstraint("CH_Name_Length2", "Len(Name) >= 3");
                    table.ForeignKey(
                        name: "FK_SubOnes_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubTwos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    SubOneId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTwos", x => x.Id);
                    table.CheckConstraint("CH_Name_Length4", "Len(Name) >= 3");
                    table.ForeignKey(
                        name: "FK_SubTwos_SubOnes_SubOneId",
                        column: x => x.SubOneId,
                        principalTable: "SubOnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubThrees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    SubTwoId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubThrees", x => x.Id);
                    table.CheckConstraint("CH_Name_Length3", "Len(Name) >= 3");
                    table.ForeignKey(
                        name: "FK_SubThrees_SubTwos_SubTwoId",
                        column: x => x.SubTwoId,
                        principalTable: "SubTwos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0m),
                    Image = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SubThreeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemNo);
                    table.CheckConstraint("CH_Name_Length1", "Len(Name) >= 3");
                    table.CheckConstraint("CH_Price_Positive", "[Price] >= 0");
                    table.ForeignKey(
                        name: "FK_Items_SubThrees_SubThreeId",
                        column: x => x.SubThreeId,
                        principalTable: "SubThrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Name",
                table: "Groups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_Name",
                table: "Items",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_SubThreeId",
                table: "Items",
                column: "SubThreeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubOnes_GroupId",
                table: "SubOnes",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SubOnes_Name",
                table: "SubOnes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubThrees_Name",
                table: "SubThrees",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubThrees_SubTwoId",
                table: "SubThrees",
                column: "SubTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_SubTwos_Name",
                table: "SubTwos",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubTwos_SubOneId",
                table: "SubTwos",
                column: "SubOneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "SubThrees");

            migrationBuilder.DropTable(
                name: "SubTwos");

            migrationBuilder.DropTable(
                name: "SubOnes");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
