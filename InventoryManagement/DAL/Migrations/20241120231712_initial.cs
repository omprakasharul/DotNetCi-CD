using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    is_delete = table.Column<bool>(type: "bit", nullable: false),
                    created_by = table.Column<string>(type: "varchar(125)", nullable: false),
                    updated_by = table.Column<string>(type: "varchar(125)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(75)", nullable: false),
                    role_name = table.Column<string>(type: "varchar(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "supplier",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", nullable: false),
                    contact_info = table.Column<string>(type: "varchar(255)", nullable: false),
                    email = table.Column<string>(type: "varchar(75)", nullable: false),
                    phone = table.Column<string>(type: "varchar(25)", nullable: false),
                    address = table.Column<string>(type: "varchar(255)", nullable: false),
                    notes = table.Column<string>(type: "text", nullable: false),
                    last_order_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_delete = table.Column<bool>(type: "bit", nullable: false),
                    created_by = table.Column<string>(type: "varchar(125)", nullable: false),
                    updated_by = table.Column<string>(type: "varchar(125)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplier", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    item_name = table.Column<string>(type: "varchar(250)", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.id);
                    table.ForeignKey(
                        name: "FK_items_category_category_id",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(75)", nullable: false),
                    roleId = table.Column<string>(type: "varchar(75)", nullable: false),
                    first_name = table.Column<string>(type: "varchar(25)", nullable: false),
                    last_name = table.Column<string>(type: "varchar(25)", nullable: false),
                    user_name = table.Column<string>(type: "varchar(50)", nullable: false),
                    email = table.Column<string>(type: "varchar(75)", nullable: false),
                    password = table.Column<string>(type: "varchar(125)", nullable: false),
                    street = table.Column<string>(type: "varchar(100)", nullable: false),
                    city = table.Column<string>(type: "varchar(100)", nullable: false),
                    zipcode = table.Column<string>(type: "varchar(25)", nullable: false),
                    country = table.Column<string>(type: "varchar(25)", nullable: false),
                    profile_pic = table.Column<string>(type: "varchar(125)", nullable: false),
                    mobile_number = table.Column<string>(type: "varchar(25)", nullable: false),
                    status = table.Column<string>(type: "varchar(25)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    is_delete = table.Column<bool>(type: "bit", nullable: false),
                    created_by = table.Column<string>(type: "varchar(125)", nullable: false),
                    updated_by = table.Column<string>(type: "varchar(125)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_roles_roleId",
                        column: x => x.roleId,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_name = table.Column<string>(type: "varchar(100)", nullable: false),
                    order_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    status = table.Column<string>(type: "varchar(25)", nullable: false),
                    total_amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    supplier_id = table.Column<int>(type: "int", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    is_delete = table.Column<bool>(type: "bit", nullable: false),
                    created_by = table.Column<string>(type: "varchar(125)", nullable: false),
                    updated_by = table.Column<string>(type: "varchar(125)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_supplier_supplier_id",
                        column: x => x.supplier_id,
                        principalTable: "supplier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inventory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sku = table.Column<string>(type: "varchar(50)", nullable: false),
                    item_id = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    supplier_id = table.Column<int>(type: "int", nullable: false),
                    reorder_level = table.Column<int>(type: "int", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    is_delete = table.Column<bool>(type: "bit", nullable: false),
                    created_by = table.Column<string>(type: "varchar(125)", nullable: false),
                    updated_by = table.Column<string>(type: "varchar(125)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory", x => x.id);
                    table.ForeignKey(
                        name: "FK_inventory_category_category_id",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_inventory_items_item_id",
                        column: x => x.item_id,
                        principalTable: "items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_inventory_supplier_supplier_id",
                        column: x => x.supplier_id,
                        principalTable: "supplier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "order_item",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<int>(type: "int", nullable: false),
                    Item_Id = table.Column<int>(type: "int", nullable: false),
                    inventory_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    is_delete = table.Column<bool>(type: "bit", nullable: false),
                    created_by = table.Column<string>(type: "varchar(125)", nullable: false),
                    updated_by = table.Column<string>(type: "varchar(125)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_item_inventory_inventory_id",
                        column: x => x.inventory_id,
                        principalTable: "inventory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_item_items_Item_Id",
                        column: x => x.Item_Id,
                        principalTable: "items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_item_order_order_id",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_inventory_category_id",
                table: "inventory",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_item_id",
                table: "inventory",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_supplier_id",
                table: "inventory",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_items_category_id",
                table: "items",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_supplier_id",
                table: "order",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_item_inventory_id",
                table: "order_item",
                column: "inventory_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_item_Item_Id",
                table: "order_item",
                column: "Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_order_item_order_id",
                table: "order_item",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_roleId",
                table: "users",
                column: "roleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_item");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "inventory");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "supplier");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
