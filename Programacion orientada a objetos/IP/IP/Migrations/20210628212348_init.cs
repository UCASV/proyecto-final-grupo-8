using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace IP.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cabin",
                columns: table => new
                {
                    id_cabin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    phone = table.Column<int>(type: "int", nullable: true),
                    email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    id_employee = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_cabin);
                });

            migrationBuilder.CreateTable(
                name: "side_effect",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    disease = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_side_effect", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "type_employee",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    tipo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_type_employee", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "work_sector",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    sector = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_work_sector", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    address = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    id_type_employee = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.id);
                    table.ForeignKey(
                        name: "FK_Emxtype",
                        column: x => x.id_type_employee,
                        principalTable: "type_employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "citizen",
                columns: table => new
                {
                    dui = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    age = table.Column<int>(type: "int", nullable: true),
                    phone = table.Column<int>(type: "int", nullable: true),
                    email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    id_work_sector = table.Column<int>(type: "int", nullable: true),
                    id_appointment = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.dui);
                    table.ForeignKey(
                        name: "fk_Cityxsector",
                        column: x => x.id_work_sector,
                        principalTable: "work_sector",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "employeexcabin",
                columns: table => new
                {
                    id_employee = table.Column<int>(type: "int", nullable: false),
                    id_cabin = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "date", nullable: true),
                    hora = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.id_employee, x.id_cabin });
                    table.ForeignKey(
                        name: "FK_empox",
                        column: x => x.id_employee,
                        principalTable: "employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_empoxcabin",
                        column: x => x.id_cabin,
                        principalTable: "cabin",
                        principalColumn: "id_cabin",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "appointment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    dui_citizen = table.Column<int>(type: "int", nullable: true),
                    id_side_effect = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    type_dose = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment", x => x.id);
                    table.ForeignKey(
                        name: "FK_apoxcity",
                        column: x => x.dui_citizen,
                        principalTable: "citizen",
                        principalColumn: "dui",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "employeexappo",
                columns: table => new
                {
                    id_employee = table.Column<int>(type: "int", nullable: false),
                    id_appointment = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.id_employee, x.id_appointment });
                    table.ForeignKey(
                        name: "FK_appoxid",
                        column: x => x.id_appointment,
                        principalTable: "appointment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKemploxid",
                        column: x => x.id_employee,
                        principalTable: "employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vaccination",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    dui_citizen = table.Column<int>(type: "int", nullable: true),
                    fecha = table.Column<DateTime>(type: "date", nullable: true),
                    id_appointment = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vaccination", x => x.id);
                    table.ForeignKey(
                        name: "FK_Vacixapo",
                        column: x => x.id_appointment,
                        principalTable: "appointment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "effectxvacunnaion",
                columns: table => new
                {
                    id_side = table.Column<int>(type: "int", nullable: false),
                    id_vaci = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.id_side, x.id_vaci });
                    table.ForeignKey(
                        name: "FK_efecxvacu",
                        column: x => x.id_vaci,
                        principalTable: "vaccination",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sidexvacci",
                        column: x => x.id_side,
                        principalTable: "side_effect",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "FK_apoxcity",
                table: "appointment",
                column: "dui_citizen");

            migrationBuilder.CreateIndex(
                name: "fk_Cityxsector",
                table: "citizen",
                column: "id_work_sector");

            migrationBuilder.CreateIndex(
                name: "FK_efecxvacu",
                table: "effectxvacunnaion",
                column: "id_vaci");

            migrationBuilder.CreateIndex(
                name: "FK_Emxtype",
                table: "employee",
                column: "id_type_employee");

            migrationBuilder.CreateIndex(
                name: "FK_appoxid",
                table: "employeexappo",
                column: "id_appointment");

            migrationBuilder.CreateIndex(
                name: "FK_empoxcabin",
                table: "employeexcabin",
                column: "id_cabin");

            migrationBuilder.CreateIndex(
                name: "FK_Vacixapo",
                table: "vaccination",
                column: "id_appointment");

            migrationBuilder.CreateIndex(
                name: "FK_Vacixdui",
                table: "vaccination",
                column: "dui_citizen");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "effectxvacunnaion");

            migrationBuilder.DropTable(
                name: "employeexappo");

            migrationBuilder.DropTable(
                name: "employeexcabin");

            migrationBuilder.DropTable(
                name: "vaccination");

            migrationBuilder.DropTable(
                name: "side_effect");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "cabin");

            migrationBuilder.DropTable(
                name: "appointment");

            migrationBuilder.DropTable(
                name: "type_employee");

            migrationBuilder.DropTable(
                name: "citizen");

            migrationBuilder.DropTable(
                name: "work_sector");
        }
    }
}
