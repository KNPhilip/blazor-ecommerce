using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RoleSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "Publisher", "PUBLISHER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2", "0f39bc69-752a-495f-9e13-07b8d447e98f" },
                    { "2", "27045ac4-b1d1-4dbb-a13b-529456b1dad2" },
                    { "2", "2bc82d0e-8b77-4a6a-84da-e79b618acbcf" },
                    { "2", "354f78e9-61bc-4f6e-8761-3cfab3749d42" },
                    { "2", "35be5291-5ce0-4483-9e7d-9d60dc912f98" },
                    { "2", "3711943c-2d78-4a3f-b007-a6ee15ba0e7b" },
                    { "2", "448d440b-c1c4-453c-8cda-608fedad3762" },
                    { "2", "47fac782-04bb-45f0-8700-2b9a3b855984" },
                    { "2", "7260b1d5-3c97-4bd1-8bbd-1b0183bb2393" },
                    { "2", "7c4df877-bffb-4cbd-8417-097cff415a03" },
                    { "2", "8567a393-058f-4ecb-a209-307dc6c8c8fa" },
                    { "2", "87ef6fb3-1a20-472e-b6d3-7599afb506e6" },
                    { "2", "8a57c8e1-08f3-42b5-9671-cbc84976fb01" },
                    { "2", "8b1922c7-8118-474b-aa7b-032bec00234c" },
                    { "2", "9904a3cc-92aa-43e4-a743-5bdc46374c6c" },
                    { "2", "a73f5524-6667-4a81-a1a0-1b3e3bbc432f" },
                    { "2", "a989fbed-3273-4342-bf5b-7724721e1504" },
                    { "2", "bafc87aa-2221-4543-ac96-9f1e4aac691d" },
                    { "2", "c5534807-f265-41c6-afa8-fcbefabb164b" },
                    { "2", "d02c893b-5ed4-4e37-bac0-0b62bb50fcdb" },
                    { "2", "d6c9880a-9926-400f-86da-79dc08234f33" },
                    { "2", "dc7b8125-6391-4774-b1f2-ad92281ed289" },
                    { "2", "e29ae0f4-c7d1-4a08-bfbb-b1fcbf2f391d" },
                    { "2", "e2e7e873-a404-4c13-bd5e-8c10a046c168" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "0f39bc69-752a-495f-9e13-07b8d447e98f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "27045ac4-b1d1-4dbb-a13b-529456b1dad2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "2bc82d0e-8b77-4a6a-84da-e79b618acbcf" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "354f78e9-61bc-4f6e-8761-3cfab3749d42" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "35be5291-5ce0-4483-9e7d-9d60dc912f98" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "3711943c-2d78-4a3f-b007-a6ee15ba0e7b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "448d440b-c1c4-453c-8cda-608fedad3762" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "47fac782-04bb-45f0-8700-2b9a3b855984" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "7260b1d5-3c97-4bd1-8bbd-1b0183bb2393" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "7c4df877-bffb-4cbd-8417-097cff415a03" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "8567a393-058f-4ecb-a209-307dc6c8c8fa" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "87ef6fb3-1a20-472e-b6d3-7599afb506e6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "8a57c8e1-08f3-42b5-9671-cbc84976fb01" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "8b1922c7-8118-474b-aa7b-032bec00234c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "9904a3cc-92aa-43e4-a743-5bdc46374c6c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "a73f5524-6667-4a81-a1a0-1b3e3bbc432f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "a989fbed-3273-4342-bf5b-7724721e1504" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "bafc87aa-2221-4543-ac96-9f1e4aac691d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "c5534807-f265-41c6-afa8-fcbefabb164b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "d02c893b-5ed4-4e37-bac0-0b62bb50fcdb" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "d6c9880a-9926-400f-86da-79dc08234f33" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "dc7b8125-6391-4774-b1f2-ad92281ed289" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "e29ae0f4-c7d1-4a08-bfbb-b1fcbf2f391d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "e2e7e873-a404-4c13-bd5e-8c10a046c168" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");
        }
    }
}
