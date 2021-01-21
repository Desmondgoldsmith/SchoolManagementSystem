USE DessySoft
--create table for issuebook

create Table issueBook
(
  id int identity(1,1) primary key not null,
  StudName Varchar(80) not null,
  StudClass Varchar(80) not null,
  BookName Varchar(80) not null,
  DateIssued Varchar(80) not null,
  DateReturned Varchar(89) not null,
  Picture image not null,
)

-- changing DateReturned column to null
alter table issueBook alter column  DateReturned varchar(80) null
--creating an insert proc for issueBook
create PROC PRissueBook
@sn varchar(80),
@sc varchar(80),
@bn varchar(80),
@di varchar(80),
@i varchar(80)
as 
begin
insert into issueBook (StudName,StudClass,BookName,DateIssued,Picture)
VALUES(@sn,@sc,@bn,@di,@i);
end
--update issue book proc (library)
create PROC PRissueBookUpdate
@id int,
@sn varchar(80),
@sc varchar(80),
@bn varchar(80),
@di varchar(80),
@i varchar(80)
as 
begin
update  issueBook set StudName=@sn,StudClass=@sc,BookName=@bn,DateIssued=@di,Picture=@i
where id = @id
end
--store procedure for return book
create PROC PRreturnBookUpdate
@id int,
@sn varchar(80),
@sc varchar(80),
@bn varchar(80),
@di varchar(80),
@dr varchar(80),
@i varchar(80)
as 
begin
update  issueBook set StudName=@sn,StudClass=@sc,BookName=@bn,DateIssued=@di,DateReturned=@dr,Picture=@i
where id = @id
end