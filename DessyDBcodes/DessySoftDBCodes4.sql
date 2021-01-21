use DessySoft

 
--table for Grade 1 reports
Create Table C1Reports
(
   id int not null primary key identity(1,1),
   StdName varchar(80) not null,
   Sclass varchar(80) not null,
   Term varchar(80) not null,
   Promoted varchar(80) not null,
   openDate varchar(80) not null,
   yeaxr varchar(80) not null,
   Attendance varchar(80) not null,
   NumOnRoll varchar(80) not null,
   FeesDue varchar(80) not null,
   Tcomm varchar(80) not null,
   --Eng varchar(80) not null,
   --alter table C1Reports drop column Eng   
   ClassScore varchar(80) not null, 
   ExScore varchar(80) not null, 
   TotalScore varchar(80) not null,
   Grade  varchar(80) not null,
   Position varchar(80) not null,
   Remark varchar(80) not null,
   
   --Math varchar(80) not null,
   --alter table C1Reports drop column Math
   MClassScore varchar(80) not null, 
   MExScore varchar(80) not null, 
   MTotalScore varchar(80) not null,
   MGrade  varchar(80) not null,
   MPosition varchar(80) not null,
   MRemark varchar(80) not null,

   --Science varchar(80) not null,
   --alter table C1Reports drop column Science
   SClassScore varchar(80) not null, 
   SExScore varchar(80) not null, 
   STotalScore varchar(80) not null,
   SGrade  varchar(80) not null,
   SPosition varchar(80) not null,
   SRemark varchar(80) not null,

   --SoS varchar(80) not null,
   --alter table C1Reports drop column Sos
   SSClassScore varchar(80) not null, 
   SSExScore varchar(80) not null, 
   SSTotalScore varchar(80) not null,
   SSGrade  varchar(80) not null,
   SSPosition varchar(80) not null,
   SSRemark varchar(80) not null,

   --Fr varchar(80) not null,
   --alter table C1Reports drop column Fr
   FrClassScore varchar(80) not null, 
   FrExScore varchar(80) not null, 
   FrTotalScore varchar(80) not null,
   FrGrade  varchar(80) not null,
   FrPosition varchar(80) not null,
   FrRemark varchar(80) not null,

   --Twi varchar(80) not null,
   --alter table C1Reports drop column Twi
   TwClassScore varchar(80) not null, 
   TwExScore varchar(80) not null, 
   TwTotalScore varchar(80) not null,
   TwGrade  varchar(80) not null,
   TwPosition varchar(80) not null,
   TwRemark varchar(80) not null,
)

--creating stored procedures to save data in C1Reports
create Proc SaveC1Reports
@sn varchar(80),@sc varchar(80),@T varchar(80),@P varchar(80),
@od varchar(80),@Y varchar(80),@Att varchar(80),@NOR varchar(80),
@FD varchar(80),@TC varchar(80),@Cs varchar(80),@ES varchar(80),
@TS varchar(80),@G varchar(80),@Po varchar(80),
@rm varchar(80), @Mcs varchar(80),@Mes varchar(80),@Mt varchar(80),
@MG varchar(80),@Mp varchar(80),@Mrm varchar(80),@Scs varchar(80),@Ses varchar(80),@St varchar(80),
@SG varchar(80),@Sp varchar(80),@srm varchar(80),@sscs varchar(80),@sses varchar(80),@sst varchar(80),
@ssG varchar(80),@sSp varchar(80),@Ssrm varchar(80),@Fcs varchar(80),@Fes varchar(80),@Ft varchar(80),
@FG varchar(80),@Fp varchar(80),@Frm varchar(80),@Tcs varchar(80),@Tes varchar(80),@Tt varchar(80),
@TG varchar(80),@Tp varchar(80),@Trm varchar(80)
as
begin
insert into C1Reports(StdName,Sclass,Term,Promoted,openDate,yeaxr,Attendance,
NumOnRoll,FeesDue,Tcomm,ClassScore,ExScore,TotalScore,Grade,Position,Remark,MClassScore,
MExScore,MTotalScore,MGrade,MPosition,MRemark,SClassScore,SExScore,STotalScore,
SGrade,SPosition,SRemark,SSClassScore,SSExScore,SSTotalScore,SSGrade,SSPosition,
SSRemark,FrClassScore,FrExScore,FrTotalScore,FrGrade,FrPosition,FrRemark,TwClassScore,
TwExScore,TwTotalScore,TwGrade,TwPosition,TwRemark) 
values(@sn ,@sc ,@T,@P,
@od ,@Y,@Att,@NOR ,
@FD,@TC,@Cs ,@ES,
@TS,@G,@Po ,
@rm, @Mcs,@Mes,@Mt,
@MG,@Mp,@Mrm,@Scs,@Ses,@St,
@SG,@Sp,@srm,@sscs,@sses,@sst,
@ssG,@sSp,@Ssrm,@Fcs,@Fes,@Ft,
@FG,@Fp,@Frm,@Tcs,@Tes,@Tt,
@TG ,@Tp,@Trm)
end

truncate table Grade2
alter table [dbo].[Grade2] alter column [Photo] image null