using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StyleMate.API.Migrations
{
    /// <inheritdoc />
    public partial class FinalModelSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Utilizadores",
                columns: table => new
                {
                    IdUtilizador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FotoPerfil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preferencias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataRegisto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimoAcesso = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizadores", x => x.IdUtilizador);
                });

            migrationBuilder.CreateTable(
                name: "Conjuntos",
                columns: table => new
                {
                    IdConjunto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estilo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUtilizador = table.Column<int>(type: "int", nullable: false),
                    UtilizadorIdUtilizador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conjuntos", x => x.IdConjunto);
                    table.ForeignKey(
                        name: "FK_Conjuntos_Utilizadores_UtilizadorIdUtilizador",
                        column: x => x.UtilizadorIdUtilizador,
                        principalTable: "Utilizadores",
                        principalColumn: "IdUtilizador",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    IdEvento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEvento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoEvento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUtilizador = table.Column<int>(type: "int", nullable: false),
                    UtilizadorIdUtilizador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.IdEvento);
                    table.ForeignKey(
                        name: "FK_Eventos_Utilizadores_UtilizadorIdUtilizador",
                        column: x => x.UtilizadorIdUtilizador,
                        principalTable: "Utilizadores",
                        principalColumn: "IdUtilizador",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Malas",
                columns: table => new
                {
                    IdMala = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUtilizador = table.Column<int>(type: "int", nullable: false),
                    UtilizadorIdUtilizador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Malas", x => x.IdMala);
                    table.ForeignKey(
                        name: "FK_Malas_Utilizadores_UtilizadorIdUtilizador",
                        column: x => x.UtilizadorIdUtilizador,
                        principalTable: "Utilizadores",
                        principalColumn: "IdUtilizador",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roupas",
                columns: table => new
                {
                    IdRoupa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaIA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaConfidence = table.Column<double>(type: "float", nullable: true),
                    CorIA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstacaoSugeridaIA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstacaoUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataAdicao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUtilizador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roupas", x => x.IdRoupa);
                    table.ForeignKey(
                        name: "FK_Roupas_Utilizadores_IdUtilizador",
                        column: x => x.IdUtilizador,
                        principalTable: "Utilizadores",
                        principalColumn: "IdUtilizador",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MalaConjuntos",
                columns: table => new
                {
                    IdMala = table.Column<int>(type: "int", nullable: false),
                    IdConjunto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MalaConjuntos", x => new { x.IdMala, x.IdConjunto });
                    table.ForeignKey(
                        name: "FK_MalaConjuntos_Conjuntos_IdConjunto",
                        column: x => x.IdConjunto,
                        principalTable: "Conjuntos",
                        principalColumn: "IdConjunto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MalaConjuntos_Malas_IdMala",
                        column: x => x.IdMala,
                        principalTable: "Malas",
                        principalColumn: "IdMala",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConjuntoRoupas",
                columns: table => new
                {
                    IdConjunto = table.Column<int>(type: "int", nullable: false),
                    IdRoupa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConjuntoRoupas", x => new { x.IdConjunto, x.IdRoupa });
                    table.ForeignKey(
                        name: "FK_ConjuntoRoupas_Conjuntos_IdConjunto",
                        column: x => x.IdConjunto,
                        principalTable: "Conjuntos",
                        principalColumn: "IdConjunto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConjuntoRoupas_Roupas_IdRoupa",
                        column: x => x.IdRoupa,
                        principalTable: "Roupas",
                        principalColumn: "IdRoupa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConjuntoRoupas_IdRoupa",
                table: "ConjuntoRoupas",
                column: "IdRoupa");

            migrationBuilder.CreateIndex(
                name: "IX_Conjuntos_UtilizadorIdUtilizador",
                table: "Conjuntos",
                column: "UtilizadorIdUtilizador");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_UtilizadorIdUtilizador",
                table: "Eventos",
                column: "UtilizadorIdUtilizador");

            migrationBuilder.CreateIndex(
                name: "IX_MalaConjuntos_IdConjunto",
                table: "MalaConjuntos",
                column: "IdConjunto");

            migrationBuilder.CreateIndex(
                name: "IX_Malas_UtilizadorIdUtilizador",
                table: "Malas",
                column: "UtilizadorIdUtilizador");

            migrationBuilder.CreateIndex(
                name: "IX_Roupas_IdUtilizador",
                table: "Roupas",
                column: "IdUtilizador");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConjuntoRoupas");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "MalaConjuntos");

            migrationBuilder.DropTable(
                name: "Roupas");

            migrationBuilder.DropTable(
                name: "Conjuntos");

            migrationBuilder.DropTable(
                name: "Malas");

            migrationBuilder.DropTable(
                name: "Utilizadores");
        }
    }
}
