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
                    Url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
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
                    { 1, true, "F-0001", "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 957, DateTimeKind.Local).AddTicks(3266), "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 957, DateTimeKind.Local).AddTicks(3274), "Valor X" },
                    { 2, true, "F-0002", "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 957, DateTimeKind.Local).AddTicks(3307), "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 957, DateTimeKind.Local).AddTicks(3307), "Valor Y" },
                    { 3, true, "F-0003", "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 957, DateTimeKind.Local).AddTicks(3309), "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 957, DateTimeKind.Local).AddTicks(3310), "Resultado Suma" },
                    { 4, true, "F-0004", "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 957, DateTimeKind.Local).AddTicks(3311), "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 957, DateTimeKind.Local).AddTicks(3312), "Resultado Resta" },
                    { 5, true, "F-0005", "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 957, DateTimeKind.Local).AddTicks(3313), "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 957, DateTimeKind.Local).AddTicks(3314), "Resultado Multiplicación" },
                    { 6, true, "F-0006", "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 957, DateTimeKind.Local).AddTicks(3315), "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 957, DateTimeKind.Local).AddTicks(3316), "Resultado División" },
                    { 7, true, "F-0007", "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 957, DateTimeKind.Local).AddTicks(3317), "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 957, DateTimeKind.Local).AddTicks(3318), "Resultado Compuesta" }
                });

            migrationBuilder.InsertData(
                table: "Flow",
                columns: new[] { "Id", "Active", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[] { 1, true, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 957, DateTimeKind.Local).AddTicks(7266), "Flujo con operaciones matematicas que dependen de la primera entrada de variables", "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 957, DateTimeKind.Local).AddTicks(7269), "Flujo de Prueba" });

            migrationBuilder.InsertData(
                table: "Step",
                columns: new[] { "Id", "Active", "Code", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name", "Url" },
                values: new object[,]
                {
                    { 1, true, "STP-0001", "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(5701), "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(5704), "Enviar Valores", "https://localhost:7285/api/Parameters/inputparameters" },
                    { 2, true, "STP-0002", "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(5705), "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(5706), "Sumar", "https://localhost:7285/api/Operation/adittion" },
                    { 3, true, "STP-0003", "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(5707), "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(5708), "Restar", "https://localhost:7285/api/Operation/subtraction" },
                    { 4, true, "STP-0004", "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(5709), "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(5710), "Multiplicar", "https://localhost:7285/api/Operation/multiplication" },
                    { 5, true, "STP-0005", "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(5711), "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(5712), "Dividir", "https://localhost:7285/api/Operation/division" },
                    { 6, true, "STP-0005", "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(5713), "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(5714), "Operacion Compuesta", "https://localhost:7285/api/Operation/compound" }
                });

            migrationBuilder.InsertData(
                table: "FlowStep",
                columns: new[] { "Id", "Active", "CreatedBy", "CreatedOn", "IdFlow", "IdStep", "ModifiedBy", "ModifiedOn" },
                values: new object[,]
                {
                    { 1, true, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 958, DateTimeKind.Local).AddTicks(9037), 1, 1, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 958, DateTimeKind.Local).AddTicks(9041) },
                    { 2, true, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 958, DateTimeKind.Local).AddTicks(9043), 1, 2, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 958, DateTimeKind.Local).AddTicks(9043) },
                    { 3, true, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 958, DateTimeKind.Local).AddTicks(9045), 1, 3, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 958, DateTimeKind.Local).AddTicks(9045) },
                    { 4, true, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 958, DateTimeKind.Local).AddTicks(9046), 1, 4, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 958, DateTimeKind.Local).AddTicks(9047) },
                    { 5, true, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 958, DateTimeKind.Local).AddTicks(9048), 1, 5, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 958, DateTimeKind.Local).AddTicks(9049) },
                    { 6, true, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 958, DateTimeKind.Local).AddTicks(9050), 1, 6, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 958, DateTimeKind.Local).AddTicks(9051) }
                });

            migrationBuilder.InsertData(
                table: "FlowStepField",
                columns: new[] { "Id", "Active", "CreatedBy", "CreatedOn", "IdField", "IdFlowStep", "IsOutput", "ModifiedBy", "ModifiedOn" },
                values: new object[,]
                {
                    { 1, true, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4114), 1, 1, false, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4120) },
                    { 2, true, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4122), 2, 1, false, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4123) },
                    { 3, true, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4124), 1, 2, false, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4125) },
                    { 4, true, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4126), 2, 2, false, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4127) },
                    { 5, true, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4128), 3, 2, true, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4129) },
                    { 6, true, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4130), 1, 3, false, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4131) },
                    { 7, true, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4132), 2, 3, false, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4133) },
                    { 8, true, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4134), 4, 3, true, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4135) },
                    { 9, true, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4136), 1, 4, false, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4137) },
                    { 10, true, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4138), 2, 4, false, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4139) },
                    { 11, true, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4140), 5, 4, true, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4141) },
                    { 12, true, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4142), 1, 5, false, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4143) },
                    { 13, true, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4144), 2, 5, false, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4144) },
                    { 14, true, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4189), 6, 5, true, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4190) },
                    { 15, true, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4191), 3, 6, false, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4192) },
                    { 16, true, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4193), 4, 6, false, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4194) },
                    { 17, true, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4195), 5, 6, false, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4196) },
                    { 18, true, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4197), 6, 6, false, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4198) },
                    { 19, true, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4199), 7, 6, true, "unknow", new DateTime(2023, 8, 14, 20, 12, 21, 959, DateTimeKind.Local).AddTicks(4200) }
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
