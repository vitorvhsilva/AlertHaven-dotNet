using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Events.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_IOT",
                columns: table => new
                {
                    IdIot = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    TipoIot = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    LatitudeIot = table.Column<string>(type: "VARCHAR2(255)", nullable: true),
                    LongitudeIot = table.Column<string>(type: "VARCHAR2(255)", nullable: true),
                    UltimaLeituraIot = table.Column<decimal>(type: "NUMBER(38,17)", nullable: false),
                    DataHoraUltimaLeituraIot = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    UnidadeMedidaIot = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    StatusIot = table.Column<string>(type: "VARCHAR2(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_IOT", x => x.IdIot);
                });

            migrationBuilder.CreateTable(
                name: "TB_EVENTO",
                columns: table => new
                {
                    IdEvento = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    IdIot = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    TipoEvento = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    IntensidadeEvento = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    LatitudeEvento = table.Column<string>(type: "VARCHAR2(255)", nullable: true),
                    LongitudeEvento = table.Column<string>(type: "VARCHAR2(255)", nullable: true),
                    DataHoraEvento = table.Column<DateTime>(type: "TIMESTAMP", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_EVENTO", x => x.IdEvento);
                    table.ForeignKey(
                        name: "FK_TB_EVENTO_TB_IOT_IdIot",
                        column: x => x.IdIot,
                        principalTable: "TB_IOT",
                        principalColumn: "IdIot",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_ALERTA",
                columns: table => new
                {
                    IdAlerta = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    IdEvento = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    NivelAlerta = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    MensagemAlerta = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    DataHoraAlerta = table.Column<string>(type: "VARCHAR2(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ALERTA", x => x.IdAlerta);
                    table.ForeignKey(
                        name: "FK_TB_ALERTA_TB_EVENTO_IdEvento",
                        column: x => x.IdEvento,
                        principalTable: "TB_EVENTO",
                        principalColumn: "IdEvento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ALERTA_IdEvento",
                table: "TB_ALERTA",
                column: "IdEvento");

            migrationBuilder.CreateIndex(
                name: "IX_TB_EVENTO_IdIot",
                table: "TB_EVENTO",
                column: "IdIot");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ALERTA");

            migrationBuilder.DropTable(
                name: "TB_EVENTO");

            migrationBuilder.DropTable(
                name: "TB_IOT");
        }
    }
}
