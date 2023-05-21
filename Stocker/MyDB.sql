create database ApplicationSetting
create database Stoker
go
USE ApplicationSetting

CREATE table DbConfig(
	ConnectionString varchar(255)
);
go

USE Stoker;

CREATE TABLE Items (
  ItemId INT PRIMARY KEY IDENTITY,
  ItemName VARCHAR(255),
  Quatity int
);
go

CREATE TABLE UpdatedDate (
  id INT PRIMARY KEY IDENTITY,
  UpdateDate DATE,
  Input INT,
  Output INT,
  ItemId INT,
  FOREIGN KEY (ItemId) REFERENCES Items(ItemId)
);
go

Create type UpdatedDateModel as table
(
id INT,
UpdateDate DATE,
Input INT,
Output INT,
ItemId INT
);
go

create type ItemsModel as table
(
ItemId INT,
ItemName VARCHAR(255),
Quatity int
);
go

CREATE PROCEDURE [dbo].[Insert_intoItems]
@items as [dbo].[ItemsModel] readonly
AS
BEGIN
insert into [dbo].[Items]
(
	[ItemId],
	[ItemName],
	[Quatity]
)
select * from @items
END;
go

CREATE PROCEDURE [dbo].[Insert_intoUdatedDate]
@udatedDate as [dbo].[UpdatedDateModel] readonly
AS
BEGIN
insert into [dbo].[UpdatedDate]
(
	[id],
	[UpdateDate],
	[Input],
	[Output],
	[ItemId]
)
select * from @udatedDate
END;
go
------------------------------------------------------
CREATE PROCEDURE [dbo].[UpdateStock]
@updateDate datetime,
@input int,
@outPut int,
@itemId int
as
begin
insert into [dbo].[UpdatedDate]
(
	[UpdateDate],
	[Input],
	[Output],
	[ItemId]
)
Values
(
	@updateDate,
	@input,
	@outPut,
	@itemId
)

DECLARE @Quatity int = (select [Quatity] from dbo.Items where [ItemId] = @itemId);

if (@Quatity < @outPut)
	begin
		select 2 as [return];
		return 0;
	end
else
	begin
		UPDATE [dbo].[Items]
		SET [Quatity] += @input
		WHERE [ItemId] = @itemId;

		UPDATE [dbo].[Items]
		SET [Quatity] -= @outPut
		WHERE [ItemId] = @itemId;

		select 0 as [return];
	end
end
go