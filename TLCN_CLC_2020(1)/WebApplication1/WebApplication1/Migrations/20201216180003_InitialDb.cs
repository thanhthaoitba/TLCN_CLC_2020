using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BlogId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BlogId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    TypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type_Name = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Prizes",
                columns: table => new
                {
                    PrizeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Prize_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prizes", x => x.PrizeId);
                });

            migrationBuilder.CreateTable(
                name: "Productors",
                columns: table => new
                {
                    ProductorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Productor_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name_Manager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_overView = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Linkfb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkTwiter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productors", x => x.ProductorId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    ActorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ActorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_Overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    String = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrizeID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Linkfb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkTwiter = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.ActorId);
                    table.ForeignKey(
                        name: "FK_Actors_Prizes_PrizeID",
                        column: x => x.PrizeID,
                        principalTable: "Prizes",
                        principalColumn: "PrizeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    DirectorsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Directors_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_Overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrizeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Linkfb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkTwiter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.DirectorsId);
                    table.ForeignKey(
                        name: "FK_Directors_Prizes_PrizeId",
                        column: x => x.PrizeId,
                        principalTable: "Prizes",
                        principalColumn: "PrizeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MediaProductor",
                columns: table => new
                {
                    MediaProductorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LinkProductorMedia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaProductor", x => x.MediaProductorId);
                    table.ForeignKey(
                        name: "FK_MediaProductor_Productors_ProductorId",
                        column: x => x.ProductorId,
                        principalTable: "Productors",
                        principalColumn: "ProductorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserBlogs",
                columns: table => new
                {
                    BlogId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBlogs", x => new { x.BlogId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserBlogs_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBlogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaActor",
                columns: table => new
                {
                    MediaActorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LinkActorMedia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaActor", x => x.MediaActorId);
                    table.ForeignKey(
                        name: "FK_MediaActor_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhotoActor",
                columns: table => new
                {
                    PhotoActorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ActorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoActor", x => x.PhotoActorId);
                    table.ForeignKey(
                        name: "FK_PhotoActor_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MediaDirector",
                columns: table => new
                {
                    MediaDirectorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LinkDirectorMedia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirectorsId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaDirector", x => x.MediaDirectorId);
                    table.ForeignKey(
                        name: "FK_MediaDirector_Directors_DirectorsId",
                        column: x => x.DirectorsId,
                        principalTable: "Directors",
                        principalColumn: "DirectorsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    movieId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MovieName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ReleaseYear = table.Column<string>(type: "nvarchar(5)", nullable: true),
                    Length = table.Column<int>(type: "int", nullable: false),
                    Link_Trailer = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    Ave_Rate = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Content_Overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrizeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DirectorsId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.movieId);
                    table.ForeignKey(
                        name: "FK_Movies_Directors_DirectorsId",
                        column: x => x.DirectorsId,
                        principalTable: "Directors",
                        principalColumn: "DirectorsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movies_Prizes_PrizeId",
                        column: x => x.PrizeId,
                        principalTable: "Prizes",
                        principalColumn: "PrizeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movies_Productors_ProductorId",
                        column: x => x.ProductorId,
                        principalTable: "Productors",
                        principalColumn: "ProductorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhotoDirector",
                columns: table => new
                {
                    PhotoProductorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirectorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirectorsId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoDirector", x => x.PhotoProductorId);
                    table.ForeignKey(
                        name: "FK_PhotoDirector_Directors_DirectorsId",
                        column: x => x.DirectorsId,
                        principalTable: "Directors",
                        principalColumn: "DirectorsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovieActors",
                columns: table => new
                {
                    ActorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MovieId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActors", x => new { x.MovieId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_MovieActors_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActors_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "movieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeMovies",
                columns: table => new
                {
                    MovieId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TypeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeMovies", x => new { x.MovieId, x.TypeId });
                    table.ForeignKey(
                        name: "FK_TypeMovies_Genres_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Genres",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypeMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "movieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCommentMovies",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MovieId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCommentMovies", x => new { x.MovieId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserCommentMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "movieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCommentMovies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFavoriteMovies",
                columns: table => new
                {
                    MovieId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavoriteMovies", x => new { x.MovieId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserFavoriteMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "movieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavoriteMovies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actors_PrizeID",
                table: "Actors",
                column: "PrizeID");

            migrationBuilder.CreateIndex(
                name: "IX_Directors_PrizeId",
                table: "Directors",
                column: "PrizeId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaActor_ActorId",
                table: "MediaActor",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaDirector_DirectorsId",
                table: "MediaDirector",
                column: "DirectorsId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaProductor_ProductorId",
                table: "MediaProductor",
                column: "ProductorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieActors_ActorId",
                table: "MovieActors",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorsId",
                table: "Movies",
                column: "DirectorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_PrizeId",
                table: "Movies",
                column: "PrizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ProductorId",
                table: "Movies",
                column: "ProductorId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoActor_ActorId",
                table: "PhotoActor",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoDirector_DirectorsId",
                table: "PhotoDirector",
                column: "DirectorsId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeMovies_TypeId",
                table: "TypeMovies",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBlogs_UserId",
                table: "UserBlogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCommentMovies_UserId",
                table: "UserCommentMovies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteMovies_UserId",
                table: "UserFavoriteMovies",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaActor");

            migrationBuilder.DropTable(
                name: "MediaDirector");

            migrationBuilder.DropTable(
                name: "MediaProductor");

            migrationBuilder.DropTable(
                name: "MovieActors");

            migrationBuilder.DropTable(
                name: "PhotoActor");

            migrationBuilder.DropTable(
                name: "PhotoDirector");

            migrationBuilder.DropTable(
                name: "TypeMovies");

            migrationBuilder.DropTable(
                name: "UserBlogs");

            migrationBuilder.DropTable(
                name: "UserCommentMovies");

            migrationBuilder.DropTable(
                name: "UserFavoriteMovies");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Productors");

            migrationBuilder.DropTable(
                name: "Prizes");
        }
    }
}
