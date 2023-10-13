using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructura.Data.Migrations
{
    /// <inheritdoc />
    public partial class InicialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Auditorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreUsuario = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DesAccion = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditorias", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EstadoNotificacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreEstado = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoNotificacion", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Formatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreFormato = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formatos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HiloRespuestaNotificacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreTipo = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiloRespuestaNotificacion", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ModulosMaestros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreModulo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModulosMaestros", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PermisosGenericos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombrePermiso = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermisosGenericos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Radicados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radicados", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SubModulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreSubmodulo = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubModulos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoNotificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreTipo = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoNotificaciones", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoRequerimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRequerimiento", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RolVsMaestro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdRolFk = table.Column<int>(type: "int", nullable: false),
                    IdMaestros = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolVsMaestro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolVsMaestro_ModulosMaestros_IdMaestros",
                        column: x => x.IdMaestros,
                        principalTable: "ModulosMaestros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolVsMaestro_Roles_IdRolFk",
                        column: x => x.IdRolFk,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MaestrosvsSubModulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdMaestro = table.Column<int>(type: "int", nullable: false),
                    IdSubModulo = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaestrosvsSubModulos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaestrosvsSubModulos_ModulosMaestros_IdMaestro",
                        column: x => x.IdMaestro,
                        principalTable: "ModulosMaestros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaestrosvsSubModulos_SubModulos_IdSubModulo",
                        column: x => x.IdSubModulo,
                        principalTable: "SubModulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BlockChain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HashGenerado = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdAuditoriaFk = table.Column<int>(type: "int", nullable: false),
                    IdHiloRespuestaFk = table.Column<int>(type: "int", nullable: false),
                    IdNotificacionFk = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockChain", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlockChain_Auditorias_IdAuditoriaFk",
                        column: x => x.IdAuditoriaFk,
                        principalTable: "Auditorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlockChain_HiloRespuestaNotificacion_IdHiloRespuestaFk",
                        column: x => x.IdHiloRespuestaFk,
                        principalTable: "HiloRespuestaNotificacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlockChain_TipoNotificaciones_IdNotificacionFk",
                        column: x => x.IdNotificacionFk,
                        principalTable: "TipoNotificaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ModuloNoficaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AsuntoNotificacion = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TextoNotificacion = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdNotificacionFk = table.Column<int>(type: "int", nullable: false),
                    IdRadicadoFk = table.Column<int>(type: "int", nullable: false),
                    IdEstadoNotificacionFk = table.Column<int>(type: "int", nullable: false),
                    IdHiloRespuestaFk = table.Column<int>(type: "int", nullable: false),
                    IdFormatoFk = table.Column<int>(type: "int", nullable: false),
                    IdRequerimiento = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuloNoficaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuloNoficaciones_EstadoNotificacion_IdEstadoNotificacionFk",
                        column: x => x.IdEstadoNotificacionFk,
                        principalTable: "EstadoNotificacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuloNoficaciones_Formatos_IdFormatoFk",
                        column: x => x.IdFormatoFk,
                        principalTable: "Formatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuloNoficaciones_HiloRespuestaNotificacion_IdHiloRespuesta~",
                        column: x => x.IdHiloRespuestaFk,
                        principalTable: "HiloRespuestaNotificacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuloNoficaciones_Radicados_IdRadicadoFk",
                        column: x => x.IdRadicadoFk,
                        principalTable: "Radicados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuloNoficaciones_TipoNotificaciones_IdNotificacionFk",
                        column: x => x.IdNotificacionFk,
                        principalTable: "TipoNotificaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuloNoficaciones_TipoRequerimiento_IdRequerimiento",
                        column: x => x.IdRequerimiento,
                        principalTable: "TipoRequerimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GenericosvsSubModulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdPermisosFk = table.Column<int>(type: "int", nullable: false),
                    IdRolFk = table.Column<int>(type: "int", nullable: false),
                    IdSubModulos = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenericosvsSubModulos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenericosvsSubModulos_MaestrosvsSubModulos_IdSubModulos",
                        column: x => x.IdSubModulos,
                        principalTable: "MaestrosvsSubModulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenericosvsSubModulos_PermisosGenericos_IdPermisosFk",
                        column: x => x.IdPermisosFk,
                        principalTable: "PermisosGenericos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenericosvsSubModulos_Roles_IdRolFk",
                        column: x => x.IdRolFk,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BlockChain_IdAuditoriaFk",
                table: "BlockChain",
                column: "IdAuditoriaFk");

            migrationBuilder.CreateIndex(
                name: "IX_BlockChain_IdHiloRespuestaFk",
                table: "BlockChain",
                column: "IdHiloRespuestaFk");

            migrationBuilder.CreateIndex(
                name: "IX_BlockChain_IdNotificacionFk",
                table: "BlockChain",
                column: "IdNotificacionFk");

            migrationBuilder.CreateIndex(
                name: "IX_GenericosvsSubModulos_IdPermisosFk",
                table: "GenericosvsSubModulos",
                column: "IdPermisosFk");

            migrationBuilder.CreateIndex(
                name: "IX_GenericosvsSubModulos_IdRolFk",
                table: "GenericosvsSubModulos",
                column: "IdRolFk");

            migrationBuilder.CreateIndex(
                name: "IX_GenericosvsSubModulos_IdSubModulos",
                table: "GenericosvsSubModulos",
                column: "IdSubModulos");

            migrationBuilder.CreateIndex(
                name: "IX_MaestrosvsSubModulos_IdMaestro",
                table: "MaestrosvsSubModulos",
                column: "IdMaestro");

            migrationBuilder.CreateIndex(
                name: "IX_MaestrosvsSubModulos_IdSubModulo",
                table: "MaestrosvsSubModulos",
                column: "IdSubModulo");

            migrationBuilder.CreateIndex(
                name: "IX_ModuloNoficaciones_IdEstadoNotificacionFk",
                table: "ModuloNoficaciones",
                column: "IdEstadoNotificacionFk");

            migrationBuilder.CreateIndex(
                name: "IX_ModuloNoficaciones_IdFormatoFk",
                table: "ModuloNoficaciones",
                column: "IdFormatoFk");

            migrationBuilder.CreateIndex(
                name: "IX_ModuloNoficaciones_IdHiloRespuestaFk",
                table: "ModuloNoficaciones",
                column: "IdHiloRespuestaFk");

            migrationBuilder.CreateIndex(
                name: "IX_ModuloNoficaciones_IdNotificacionFk",
                table: "ModuloNoficaciones",
                column: "IdNotificacionFk");

            migrationBuilder.CreateIndex(
                name: "IX_ModuloNoficaciones_IdRadicadoFk",
                table: "ModuloNoficaciones",
                column: "IdRadicadoFk");

            migrationBuilder.CreateIndex(
                name: "IX_ModuloNoficaciones_IdRequerimiento",
                table: "ModuloNoficaciones",
                column: "IdRequerimiento");

            migrationBuilder.CreateIndex(
                name: "IX_RolVsMaestro_IdMaestros",
                table: "RolVsMaestro",
                column: "IdMaestros");

            migrationBuilder.CreateIndex(
                name: "IX_RolVsMaestro_IdRolFk",
                table: "RolVsMaestro",
                column: "IdRolFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlockChain");

            migrationBuilder.DropTable(
                name: "GenericosvsSubModulos");

            migrationBuilder.DropTable(
                name: "ModuloNoficaciones");

            migrationBuilder.DropTable(
                name: "RolVsMaestro");

            migrationBuilder.DropTable(
                name: "Auditorias");

            migrationBuilder.DropTable(
                name: "MaestrosvsSubModulos");

            migrationBuilder.DropTable(
                name: "PermisosGenericos");

            migrationBuilder.DropTable(
                name: "EstadoNotificacion");

            migrationBuilder.DropTable(
                name: "Formatos");

            migrationBuilder.DropTable(
                name: "HiloRespuestaNotificacion");

            migrationBuilder.DropTable(
                name: "Radicados");

            migrationBuilder.DropTable(
                name: "TipoNotificaciones");

            migrationBuilder.DropTable(
                name: "TipoRequerimiento");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "ModulosMaestros");

            migrationBuilder.DropTable(
                name: "SubModulos");
        }
    }
}
