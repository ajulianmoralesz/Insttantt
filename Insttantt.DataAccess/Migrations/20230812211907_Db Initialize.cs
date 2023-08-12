using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insttantt.DataAccess.Migrations
{
    public partial class DbInitialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Field",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Field", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flow", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Step",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Step", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FieldOptionValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdField = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldOptionValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldOptionValue_Field",
                        column: x => x.IdField,
                        principalTable: "Field",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlowExecution",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFlow = table.Column<int>(type: "int", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowExecution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlowExecution_Flow",
                        column: x => x.IdFlow,
                        principalTable: "Flow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlowStep",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdStep = table.Column<int>(type: "int", nullable: false),
                    IdFlow = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlowStep_Flow",
                        column: x => x.IdFlow,
                        principalTable: "Flow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlowStep_Step",
                        column: x => x.IdStep,
                        principalTable: "Step",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlowStepField",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdField = table.Column<int>(type: "int", nullable: false),
                    IdFlowStep = table.Column<int>(type: "int", nullable: false),
                    DefaultValue = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, defaultValue: ""),
                    IsOutput = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowStepField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlowStepField_Field",
                        column: x => x.IdField,
                        principalTable: "Field",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlowStepField_FlowStep",
                        column: x => x.IdFlowStep,
                        principalTable: "FlowStep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlowExecutionField",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFlowStepField = table.Column<int>(type: "int", nullable: false),
                    IdFlowExecution = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowExecutionField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlowExecutionField_FlowExecution",
                        column: x => x.IdFlowExecution,
                        principalTable: "FlowExecution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlowExecutionField_FlowStepField",
                        column: x => x.IdFlowStepField,
                        principalTable: "FlowStepField",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Field",
                columns: new[] { "Id", "Active", "Code", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, true, "F-0001", "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1167), "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1176), "Primer Nombre" },
                    { 2, true, "F-0002", "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1178), "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1179), "Segundo Nombre" },
                    { 3, true, "F-0003", "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1181), "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1181), "Primer Apellido" },
                    { 4, true, "F-0004", "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1183), "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1184), "Segundo Apellido" },
                    { 5, true, "F-0005", "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1185), "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1186), "Tipo de Documento" },
                    { 6, true, "F-0006", "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1188), "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1188), "Numero Documento" },
                    { 7, true, "F-0007", "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1190), "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1191), "Correo Electronico" },
                    { 8, true, "F-0008", "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1192), "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1193), "Url" },
                    { 9, true, "F-0009", "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1195), "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1196), "Metodo" },
                    { 10, true, "F-00010", "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1197), "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1198), "Body" },
                    { 11, true, "F-0011", "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1200), "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1200), "Cliente SMTP" },
                    { 12, true, "F-0012", "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1202), "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1203), "Puerto" },
                    { 13, true, "F-0013", "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1204), "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1205), "Email From" },
                    { 14, true, "F-0014", "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1207), "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1207), "Password" },
                    { 15, true, "F-0015", "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1209), "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1210), "Mensaje" },
                    { 16, true, "F-0016", "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1211), "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1212), "Asunto" },
                    { 17, true, "F-0017", "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1214), "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1214), "Valor X" },
                    { 18, true, "F-0018", "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1216), "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1217), "Valor Y" },
                    { 19, true, "F-0019", "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1219), "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1219), "Resultado Suma" },
                    { 20, true, "F-0020", "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1223), "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1224), "Resultado Resta" },
                    { 21, true, "F-0021", "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1225), "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1226), "Resultado Multiplicación" },
                    { 22, true, "F-0022", "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1228), "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1228), "Resultado División" }
                });

            migrationBuilder.InsertData(
                table: "Step",
                columns: new[] { "Id", "Active", "Code", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, true, "STP-0001", "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 737, DateTimeKind.Local).AddTicks(6132), "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 737, DateTimeKind.Local).AddTicks(6146), "Formulario Usuario" },
                    { 2, true, "STP-0002", "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 737, DateTimeKind.Local).AddTicks(6148), "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 737, DateTimeKind.Local).AddTicks(6149), "Consumir Servicio Externo" },
                    { 3, true, "STP-0003", "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 737, DateTimeKind.Local).AddTicks(6150), "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 737, DateTimeKind.Local).AddTicks(6151), "Enviar Email" },
                    { 4, true, "STP-0004", "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 737, DateTimeKind.Local).AddTicks(6152), "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 737, DateTimeKind.Local).AddTicks(6153), "Enviar Valores" },
                    { 5, true, "STP-0005", "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 737, DateTimeKind.Local).AddTicks(6154), "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 737, DateTimeKind.Local).AddTicks(6155), "Ejecutar Ecuación" }
                });

            migrationBuilder.InsertData(
                table: "FieldOptionValue",
                columns: new[] { "Id", "Active", "CreatedBy", "CreatedOn", "IdField", "ModifiedBy", "ModifiedOn", "Value" },
                values: new object[,]
                {
                    { 1, true, "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(4791), 5, "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(4796), "CC" },
                    { 2, true, "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(4798), 5, "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(4798), "NIT" },
                    { 3, true, "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(4800), 5, "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(4800), "TI" },
                    { 4, true, "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(4802), 9, "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(4802), "GET" },
                    { 5, true, "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(4804), 9, "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(4804), "POST" },
                    { 6, true, "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(4806), 9, "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(4806), "PUT" },
                    { 7, true, "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(4808), 9, "unknow", new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(4808), "DELETE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FieldOptionValue_IdField",
                table: "FieldOptionValue",
                column: "IdField");

            migrationBuilder.CreateIndex(
                name: "IX_FlowExecution_IdFlow",
                table: "FlowExecution",
                column: "IdFlow");

            migrationBuilder.CreateIndex(
                name: "IX_FlowExecutionField_IdFlowExecution",
                table: "FlowExecutionField",
                column: "IdFlowExecution");

            migrationBuilder.CreateIndex(
                name: "IX_FlowExecutionField_IdFlowStepField",
                table: "FlowExecutionField",
                column: "IdFlowStepField");

            migrationBuilder.CreateIndex(
                name: "IX_FlowStep_IdFlow",
                table: "FlowStep",
                column: "IdFlow");

            migrationBuilder.CreateIndex(
                name: "IX_FlowStep_IdStep",
                table: "FlowStep",
                column: "IdStep");

            migrationBuilder.CreateIndex(
                name: "IX_FlowStepField_IdField",
                table: "FlowStepField",
                column: "IdField");

            migrationBuilder.CreateIndex(
                name: "IX_FlowStepField_IdFlowStep",
                table: "FlowStepField",
                column: "IdFlowStep");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FieldOptionValue");

            migrationBuilder.DropTable(
                name: "FlowExecutionField");

            migrationBuilder.DropTable(
                name: "FlowExecution");

            migrationBuilder.DropTable(
                name: "FlowStepField");

            migrationBuilder.DropTable(
                name: "Field");

            migrationBuilder.DropTable(
                name: "FlowStep");

            migrationBuilder.DropTable(
                name: "Flow");

            migrationBuilder.DropTable(
                name: "Step");
        }
    }
}
