
create table RegUsers
(
  id int not null primary key identity(1,1),
  Username varchar(80) not null,
  UserRole varchar(80) not null,
  Passwordx varchar(80) not null,
  dateA varchar(80) not null,
  Gua varchar(80) not null,
  GGuaPass varchar(80) not null,
  Picture image not null,

)
--stored proc for RegUsers to insert
CREATE PROC insertRegUsers1
  @u varchar(40),
  @ur varchar(40),
  @p varchar(40) ,
  @d varchar(40),
  @g varchar(40),
  @gp varchar(40),
  @pi image

  as begin
  insert into RegUsers(Username,UserRole,Passwordx,dateA,Gua,GGuaPass,Picture) 
  values(@u,@ur,@p,@d,@g,@gp,@pi)
  end
  
  --creating table for NewStudentRegX [saving new users]
  create table NewStudentRegX
  (
  id int identity(1,1) not null primary key,
  firstname varchar(60) not null,
  lastname varchar(60) not null,
  StdClass varchar(60) not null,
  gender varchar(60) not null,
  age varchar(60) not null,
  RegisterDate varchar(60) not null,
  Parent varchar(60) not null,
  ParentNum varchar(60) not null,
  ParentEmail varchar(60) not null,
  Nationality varchar(60) not null,
  HomeTown varchar(60) not null,
  Residence varchar(60) not null,
  sickness varchar(60) not null,
  emergencyName varchar(60) not null,
  emergencyPhone varchar(60) not null,
  Std_Photograph image ,
  
  )
  --ADDING DATE OF BIRTH COLUMN TO THE [dbo].[NewStudentRegX] TABLE
  Alter table NewStudentRegX add  Dob varchar(80) null

  --creating new table NewGrade1
  create table NewGrade1
  (
    id int not null primary key identity(1,1) ,
FirstName varchar(80) not null,
 LastName varchar(80) not null,
Classx varchar(80) not null,
Age varchar(80) not null,
  Teacher varchar(80) not null,
 )
 --procedure for insert into grade1
 create proc SaveGrade1
 @fn varchar(80),
 @ln varchar(80),
 @cl varchar(80),
 @a varchar(80),
 @t varchar(80)
 as
 begin
 insert into NewGrade1(FirstName,LastName,Classx,Age,Teacher)
 values(@fn,@ln,@cl,@a,@t)
 end

 --procedure for update into grade1
 create proc UpdateGrade1
 @id int ,
 @fn varchar(80),
 @ln varchar(80),
 @cl varchar(80),
 @a varchar(80),
 @t varchar(80)
 as
 begin
 update NewGrade1 set FirstName=@fn,LastName=@ln,Classx=@cl,Age=@a,Teacher=@t
 where @id = id
 end

 --GRADE 1 FEES
 create table Grade1Fees
 (
  id int not null primary key identity(1,1),
  StudName varchar(80) not null,
  StudentClass varchar(80) not null,
  AmtPaid varchar(80) not null,
  AmountPaidWords varchar(80) not null,
  DatePaid varchar(80) not null,
  Balance varchar(80) not null,
  HeadMaster varchar(80) not null,
  picture image ,
  
   )

   create proc SaveFees1
   @sn varchar(80),
    @sc varchar(80),
	 @ap varchar(80),
	  @apw varchar(80),
	   @dp varchar(80),
	    @b varchar(80),
		 @hm varchar(80),
		 @p image
		 as
		 begin
		 insert into Grade1Fees([StudName],[StudentClass],[AmtPaid],[AmountPaidWords],[DatePaid],[Balance],[HeadMaster],[picture])
		 values(@sn,@sc,@ap,@apw,@dp,@b,@hm,@p)
		 end


		 --creating a table for 
		 create table Student_Attendaance
		 (
		   id int identity(1,1) not null primary key,
		   stdClass varchar(80) not null,
		  FName  varchar(80) not null,
		   Lname varchar(80) not null,
		   Datex varchar(80) not null,
		    attendanceStatus varchar(80) not null,
		   Reason varchar(80) not null,
		   Signaturex varchar(80) not null, 

		 )
		   --changing the data type of Signaturex to image [grade1 student attendance]
		 alter table Student_Attendaance alter column Signaturex  image not null
		 

		  -- CREATING TABLE FOR GRADE1 TEACHER ATTENDANCE
		  create table Teacher_Attendance
		  (
		   id int identity(1,1) not null primary key,
		   stdClass varchar(80) not null,
		  FName  varchar(80) not null,
		   Lname varchar(80) not null,
		   Datex varchar(80) not null,
		    attendanceStatus varchar(80) not null,
		   Reason varchar(80) not null,
		   Signaturex varchar(80) not null,

		 )
		 --removing Lname from the Teacher_Attendance table
		 alter table Teacher_Attendance drop column Lname
		 --changing the data type of Signaturex to image [Teacher_Attendance table]
		 alter table Teacher_Attendance alter column Signaturex  image not null

		--removing the picture column from grade 2
		alter table Grade2 drop column Photo

		--grade 2 student attendance table
		create table Grade2StudentAttendance
		(
		  id int identity(1,1) not null primary key,
		   stdClass varchar(80) not null,
		  FName  varchar(80) not null,
		   Lname varchar(80) not null,
		   Datex varchar(80) not null,
		    attendanceStatus varchar(80) not null,
		   Reason varchar(80) not null,
		   Signaturex varchar(80) not null, 
		)
		--changing Grade2StudentAttendance's Signaturex column to image
		alter table Grade2StudentAttendance alter column Signaturex image not null

		
		 -- CREATING TABLE FOR GRADE2 TEACHER ATTENDANCE
		  create table Grade2Teacher_Attendance
		  (
		  
		   id int identity(1,1) not null primary key,
		   TClass varchar(80) not null,
		  Tname  varchar(80) not null,
		   TDate varchar(80) not null,
		   AttStat varchar(80) not null,
		    AbsentR varchar(80) not null,
		   Reason varchar(80) not null,
		   Sig image,

		 )
		 --deleting Reason from Grade2Teacher_Attendance table
		 alter table Grade2Teacher_Attendance drop column Reason

--creating table for employee attendance
create table employees
(
id int not null identity(1,1) primary key,
name varchar(80) not null,
EmpRole varchar(80) not null,
TeacherClass varchar(80) not null,
SubjectTaught varchar(80) not null,
DOB varchar(80) not null,
empAge varchar(80) not null,
HomeTown varchar(80) not null,
Residence varchar(80) not null,
PastExp varchar(80) not null,
DateEmployed varchar(80) not null,
email varchar(80) not null,
Num varchar(80) not null,
Picture image,
)
		 
-- creating table to store subjects
 create table subjects
 (
   id int identity(1,1) primary key not null,
   subjectx varchar(80) not null,
   classes varchar(80) not null,
   dateAdded varchar(80) not null,
   AddedBy varchar(80) not null,
   Discription varchar(80) not null,
 
 )
 --proc to insert into the subject table
 create proc SubjectsProc
 @name varchar(80),
 @class varchar(80),
  @Date varchar(80),
   @Add varchar(80),
    @Desc varchar(80)
	as begin
	insert into subjects(subjectx,classes,dateAdded,AddedBy,Discription)
	values(@name,@class,@Date,@Add,@Desc) 
	end

	--proc update thesubject table
	create proc SubjectsProcUpdate
	 @id int,
	 @name varchar(80),
     @class varchar(80),
     @Date varchar(80),
     @Add varchar(80),
     @Desc varchar(80)
	as begin
	update subjects set subjectx = @name,classes = @class,dateAdded = @Date,AddedBy = @Add,Discription = @Desc 
	where id = @id
	end
	-- proc to delete from the subject table
	create proc DeleteProc
	@id int
	as begin
	delete from  subjects where id = @id
	end
	--creating table for Register Student in the library
	create table LiReg
	(
	  id int identity(1,1) primary key not null,
	  name varchar(80) not null,
	  class varchar(80) not null,
	  dateA varchar(80) not null,
	  Gender varchar(80) not null,
	  teacher varchar(80) not null,

	 
	)
	--proc for inserting Student in the library
	create proc stSaveLi
	@sn varchar(80),
	@c varchar(80),
	@d varchar(80),
	@g varchar(80),
	@t varchar(80)
	as begin
	insert into LiReg(name,class,dateA,Gender,teacher)
	values(@sn,@c,@d,@g,@t)
	end

	--proc for updating students in the library
	create proc stUpdateLi
	@id int,
	@sn varchar(80),
	@c varchar(80),
	@d varchar(80),
	@g varchar(80),
	@t varchar(80)
	as begin
	update LiReg set  name = @sn,class=@c ,dateA=@d,Gender=@g,teacher=@t
	where id = @id
	end

	-- create table to register book in the library
	create table LiRegBook
	(
	 id int identity(1,1) primary key not null,
	 bookName varchar(80) not null,
	  Author varchar(80) not null,
	  bookType varchar(80) not null,
	 NumPages varchar(80) not null,
	 DateA varchar(80) not null,

	
	)
--adding timeIssued to IssueBook table
	alter table [dbo].[issueBook] add  TimeIssued Varchar(80) not null
	  
	  --creating table for Grade 3
 CREATE table Grade3
(
 id int identity(1,1) primary key not null,
 FirstName varchar(80) not null,
 LastName  varchar(80) not null,
 Classx varchar(80) not null,
 Age varchar(80) not null,
 Teacher varchar(80) not null,
 
 )  
 --procedure for insert into Grade3
create proc InsertGrade3
@fn varchar(80),
@ln varchar(80),
@c varchar(80),
@a varchar(80),
@t varchar(80)

as
begin
INSERT into Grade3(FirstName,LastName,Classx,Age,Teacher)
Values(@fn,@ln,@c,@a,@t)
end
-- end

--procedures for Update Grade3
create proc UpdateGrade3     
@id int,
@fn varchar(80),
@ln varchar(80),
@c varchar(80),
@a varchar(80),
@t varchar(80)
as
begin
Update Grade3 set FirstName=@fn,LastName=@ln,Classx=@c,Age=@a,Teacher=@t
where id = @id
end
--end

create table RealGrade1Attendance
(
 id int identity(1,1) not null primary key,
 promote varchar(80),
 FirstName varchar(80) not null,
 LastName  varchar(80) not null,
 Classx varchar(80) not null,
 Teacher varchar(80) not null,
 Reason varchar(80) not null,
 Datex varchar(80) not null,
)
