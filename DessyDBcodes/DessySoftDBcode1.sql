
use DessySoft

create table LiRegBook
(
  id int identity(1,1) not null primary key,
  BookName varchar(60) not null,
  Author varchar(60) not null,
  BookType varchar(60) not null,
  NumPages varchar(60) not null,
  DateA varchar(60) not null
)
--stored procedure for LiRegBook
create proc RegBook
@bn varchar(80),
@a varchar(80),
@bt varchar(80),
@np varchar(80),
@da varchar(80)
as
begin
insert into LiRegBook (BookName,Author,BookType,NumPages,DateA) 
values(@bn,@a,@bt,@np,@da)
end

--stored procedure to update LiRegBook
create proc UpdateRegBook
 @id int,
@bn varchar(80),
@a varchar(80),
@bt varchar(80),
@np varchar(80),
@da varchar(80)
as
begin
Update LiRegBook set BookName=@bn,Author=@a,BookType=@bt,NumPages=@np,DateA=@da
where id = @id 
end
--NewGrade1 table
CREATE TABLE TRIAL
(id int not null primary key identity(1,1),
 FirstName varchar(80) not null,
 LastName varchar(80) not null,
 Classx varchar(80) not null,
  Age varchar(80) not null,
Teacher varchar(80) not null,
Photo image not null,
)