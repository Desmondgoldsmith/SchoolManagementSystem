-- creating Grade2 fees table
Create table Grade2FeesRec1
(
  id int identity(1,1) primary key not null,
  sname varchar(80) not null,
  sclass varchar(80) not null,
  amtpaid varchar(80) not null,
  amtpaidW varchar(80) not null,
  datep varchar(80) not null,
 balance varchar(80) not null,
 head varchar(80) not null,
 picture image
)
alter table Grade2FeesRec1 add  statusx Varchar(80) null, Beign varchar(80) null,PaymentMethod varchar(80) null  
--procedure to Save Grade2FeesRec
create Proc SaveG2Fees
@sn varchar(80),
@sc varchar(80),
@ap varchar(80),
@apw varchar(80),
@dp varchar(80),
@b varchar(80), 
@h varchar(80),
@i image
as
begin
 insert into Grade2FeesRec1(sname,sclass,amtpaid,amtPaidW,datep,balance,head,picture)
values(@sn,@sc,@ap,@apw,@dp,@b,@h,@i)
end