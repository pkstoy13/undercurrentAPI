using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace undercurrentAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Genre = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscoveryScores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ScoreDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EngagementScore = table.Column<double>(type: "double precision", nullable: true),
                    GrowthScore = table.Column<double>(type: "double precision", nullable: true),
                    UndergroundScore = table.Column<double>(type: "double precision", nullable: true),
                    ArtistId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscoveryScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscoveryScores_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlatformAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Platform = table.Column<string>(type: "text", nullable: false),
                    ExternalId = table.Column<string>(type: "text", nullable: false),
                    ProfileUrl = table.Column<string>(type: "text", nullable: true),
                    ArtistId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlatformAccounts_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistStats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SnapshotDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Followers = table.Column<int>(type: "integer", nullable: true),
                    MonthlyListeners = table.Column<int>(type: "integer", nullable: true),
                    Views = table.Column<int>(type: "integer", nullable: true),
                    Likes = table.Column<int>(type: "integer", nullable: true),
                    Comments = table.Column<int>(type: "integer", nullable: true),
                    PlatformAccountId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtistStats_PlatformAccounts_PlatformAccountId",
                        column: x => x.PlatformAccountId,
                        principalTable: "PlatformAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PlayCount = table.Column<int>(type: "integer", nullable: true),
                    LikeCount = table.Column<int>(type: "integer", nullable: true),
                    CommentCount = table.Column<int>(type: "integer", nullable: true),
                    TrackUrl = table.Column<string>(type: "text", nullable: true),
                    IsTopTrack = table.Column<bool>(type: "boolean", nullable: false),
                    PlatformAccountId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tracks_PlatformAccounts_PlatformAccountId",
                        column: x => x.PlatformAccountId,
                        principalTable: "PlatformAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistStats_PlatformAccountId",
                table: "ArtistStats",
                column: "PlatformAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscoveryScores_ArtistId",
                table: "DiscoveryScores",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformAccounts_ArtistId",
                table: "PlatformAccounts",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_PlatformAccountId",
                table: "Tracks",
                column: "PlatformAccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistStats");

            migrationBuilder.DropTable(
                name: "DiscoveryScores");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "PlatformAccounts");

            migrationBuilder.DropTable(
                name: "Artists");
        }
    }
}
