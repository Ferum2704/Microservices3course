using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpendingApp.Migrations
{
    public partial class CreateSpendingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
				IF OBJECT_ID('dbo.Pings', 'u' ) is not null
				begin 
					drop table dbo.Pings
				end
				
				IF OBJECT_ID('dbo.Spendings', 'u' ) is null
				begin 
					create table dbo.Spendings
					(
						Id int identity(1,1),
						Currency tinyint not null,
						[Value] int not null,
						[Item] nvarchar(max),

						constraint PK_Spendings primary key clustered (Id asc)
					)
				end");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.Sql(@"
				IF OBJECT_ID('dbo.Pings', 'u' ) is null
				begin 
					CREATE TABLE [dbo].[Pings]
					(
						[Id] [int] IDENTITY(1,1) NOT NULL,
						[Counter] [int] NOT NULL,
					 	CONSTRAINT [PK_Pings] PRIMARY KEY CLUSTERED ([Id] ASC)
					)
				end

				IF OBJECT_ID('dbo.Spendings', 'u' ) is not null
				begin 
					drop table dbo.Spendings
				end");
        }
    }
}
