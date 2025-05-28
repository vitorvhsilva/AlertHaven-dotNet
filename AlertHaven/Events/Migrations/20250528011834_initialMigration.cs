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
                    TipoEvento = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    IntensidadeEvento = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    LatitudeEvento = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    LongitudeEvento = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    DataHoraEvento = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    IotIdIot = table.Column<string>(type: "VARCHAR2(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_EVENTO", x => x.IdEvento);
                    table.ForeignKey(
                        name: "FK_TB_EVENTO_TB_IOT_IotIdIot",
                        column: x => x.IotIdIot,
                        principalTable: "TB_IOT",
                        principalColumn: "IdIot");
                });

            migrationBuilder.CreateTable(
                name: "TB_ALERTA",
                columns: table => new
                {
                    IdAlerta = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    NivelAlerta = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    MensagemAlerta = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    DataHoraAlerta = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    EventoIdEvento = table.Column<string>(type: "VARCHAR2(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ALERTA", x => x.IdAlerta);
                    table.ForeignKey(
                        name: "FK_TB_ALERTA_TB_EVENTO_EventoIdEvento",
                        column: x => x.EventoIdEvento,
                        principalTable: "TB_EVENTO",
                        principalColumn: "IdEvento");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ALERTA_EventoIdEvento",
                table: "TB_ALERTA",
                column: "EventoIdEvento");

            migrationBuilder.CreateIndex(
                name: "IX_TB_EVENTO_IotIdIot",
                table: "TB_EVENTO",
                column: "IotIdIot");
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
