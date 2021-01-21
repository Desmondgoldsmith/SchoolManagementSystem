Use DessySoft

CREATE table Grade2
(
 id int identity(1,1) primary key not null,
 FirstName varchar(80) not null,
 LastName  varchar(80) not null,
 Classx varchar(80) not null,
 Age varchar(80) not null,
 Teacher varchar(80) not null,
 Photo image not null
 )  
 --procedure for insert into Grade2
create proc InsertGrade2
@fn varchar(80),
@ln varchar(80),
@c varchar(80),
@a varchar(80),
@t varchar(80),
@i image
as
begin
INSERT into Grade2(FirstName,LastName,Classx,Age,Teacher,Photo)
Values(@fn,@ln,@c,@a,@t,@i)
end
-- end

--procedure for Update into Grade2
create proc UpdateGrade2
@id int,
@fn varchar(80),
@ln varchar(80),
@c varchar(80),
@a varchar(80),
@t varchar(80),
@i image
as
begin
Update Grade2 set FirstName=@fn,LastName=@ln,Classx=@c,Age=@a,Teacher=@t,Photo=@i
where id = @id
end
--end

