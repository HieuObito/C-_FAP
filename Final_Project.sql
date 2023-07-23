create database PRN231_Project
GO
use PRN231_Project
--drop table Customer
--drop database PRN231_Project
create table [Role](
	RoleID int IDENTITY PRIMARY KEY, 
	RoleName NVARCHAR(max),
);

create table Account (
	AccountID int IDENTITY PRIMARY KEY, 
	[RoleID] int,
	[user] VARCHAR(50)NOT NULL,
	[password] VARCHAR(50)NOT NULL,
	foreign key (RoleID) references [Role](RoleID)
);

create table Slot(
	SlotId int IDENTITY PRIMARY KEY, 
	SlotName nvarchar(max),
	Time_from time,
    Time_to time,
);

-- ngay trong tuan
create table [WeekDays](
	DateId int IDENTITY PRIMARY KEY, 
	[DateName] nvarchar(max),
)

create table Slot_Date(
	SlotDateId int IDENTITY PRIMARY KEY, 
	SlotId int,
	DateId int,
	foreign key (SlotId) references Slot(SlotId),
	foreign key (DateId) references WeekDays(DateId),
)

create table Mentor(
	MentorId int IDENTITY PRIMARY KEY,
	MentorName NVARCHAR(max),
	MentorDesc NVARCHAR(max),
	Note Nvarchar(max),
	[Status] int,
);
create table Student(
    StudentId int IDENTITY PRIMARY KEY,
    StudentCode nvarchar(10),
	StudentName NVARCHAR(max),
	StudentDesc NVARCHAR(max),
	StudentImg NVARCHAR(max),
	AccountID int, 
	[Status] int,
	foreign key (AccountID) references Account(AccountID),
);
create table Specialized( -- nganh
	SpecializedId int IDENTITY PRIMARY KEY,
	SpecializedCode nvarchar(10),
    SpecializedName nvarchar(10),
    [Status] int,
);
create table [Subject](
    SubjectId int IDENTITY PRIMARY KEY,
	SubjectCode nvarchar(10),
    SubjectName nvarchar(10),
    [Status] int,
);

create table Class(
	ClassId int IDENTITY PRIMARY KEY,
    ClassName nvarchar(10),
    MentorId int,
    SubjectId int,
    DateFrom smalldatetime,
    DateTo smalldatetime,
    Number int,
    [Status] int,
    foreign key (MentorId) references Mentor(MentorId),
    foreign key (SubjectId) references [Subject](SubjectId),
);

create table ClassSlotDate(
	ClassSlotDateId int IDENTITY PRIMARY KEY,
	ClassId int,
	SlotDateId int,
	foreign key (ClassId) references Class(ClassId),
	foreign key (SlotDateId) references [Slot_Date](SlotDateId),
)

create table StudentClass(
    StudentClass int IDENTITY PRIMARY KEY,
	StudentId int,
	ClassId int,
	foreign key (StudentId) references Student(StudentId),
    foreign key (ClassId) references Class(ClassId),
);

insert into Role (RoleName) values ('Student');
insert into Role (RoleName) values ('Admin');

insert into Account(RoleID,[user],[password]) values (1, 'hieu','123');
insert into Account(RoleID,[user],[password]) values (2, 'fpt','123');

insert into Mentor(MentorName,MentorDesc,Note,[Status]) values ('Nguyen Van A',null,null,1);
insert into Mentor(MentorName,MentorDesc,Note,[Status]) values ('Nguyen Tien B',null,null,1);

insert into Student(StudentCode,StudentName,StudentDesc,StudentImg,AccountID,[Status]) values ('HE151404','Hoang van A',null,null,1,1);
insert into Student(StudentCode,StudentName,StudentDesc,StudentImg,AccountID,[Status]) values ('HE151406','Hoang van A',null,null,2,1);
insert into Student(StudentCode,StudentName,StudentDesc,StudentImg,AccountID,[Status]) values ('HE151405','Hoang van B',null,null,2,1);
insert into Student(StudentCode,StudentName,StudentDesc,StudentImg,AccountID,[Status]) values ('HE151408','Nguyen Van C',null,null,2,1);
insert into Student(StudentCode,StudentName,StudentDesc,StudentImg,AccountID,[Status]) values ('HE151409','Hoa van D',null,null,2,1);
insert into Student(StudentCode,StudentName,StudentDesc,StudentImg,AccountID,[Status]) values ('HE151400','La van E',null,null,2,1);
insert into Student(StudentCode,StudentName,StudentDesc,StudentImg,AccountID,[Status]) values ('HE151412','Oke la G',null,null,2,1);

insert into Subject(SubjectCode,SubjectName,[Status]) values ('PRN221','',1);
insert into Subject(SubjectCode,SubjectName,[Status]) values ('PRU221','',1);
insert into Subject(SubjectCode,SubjectName,[Status]) values ('LAB221','',1);
insert into Subject(SubjectCode,SubjectName,[Status]) values ('PRJ201','',1);
insert into Subject(SubjectCode,SubjectName,[Status]) values ('PRF291','',1);
insert into Subject(SubjectCode,SubjectName,[Status]) values ('PRO201','',1);

INSERT INTO [PRN231_Project].[dbo].[WeekDays]([DateName]) VALUES('Monday');
INSERT INTO [PRN231_Project].[dbo].[WeekDays]([DateName]) VALUES('Tuesday');  
INSERT INTO [PRN231_Project].[dbo].[WeekDays]([DateName]) VALUES('Wednesday');
INSERT INTO [PRN231_Project].[dbo].[WeekDays]([DateName]) VALUES('Thursday');
INSERT INTO [PRN231_Project].[dbo].[WeekDays]([DateName]) VALUES('Friday');
INSERT INTO [PRN231_Project].[dbo].[WeekDays]([DateName]) VALUES('Saturday');
INSERT INTO [PRN231_Project].[dbo].[WeekDays]([DateName]) VALUES('Sunday');       

insert into Slot(SlotName,Time_from,Time_to) values ('Slot 1','07:30','09:40');
insert into Slot(SlotName,Time_from,Time_to) values ('Slot 2','10:00','12:20');
insert into Slot(SlotName,Time_from,Time_to) values ('Slot 3','12:50','15:10');
insert into Slot(SlotName,Time_from,Time_to) values ('Slot 4','15:20','17:40');
insert into Slot(SlotName,Time_from,Time_to) values ('Slot 5','17:50','19:00');

INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(1,1);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(1,2);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(1,3);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(1,4);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(1,5);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(1,6);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(1,7);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(2,1);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(2,2);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(2,3);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(2,4);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(2,5);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(2,6);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(2,7);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(3,1);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(3,2);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(3,3);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(3,4);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(3,5);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(3,6);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(3,7);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(4,1);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(4,2);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(4,3);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(4,4);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(4,5);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(4,6);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(4,7);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(5,1);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(5,2);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(5,3);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(5,4);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(5,5);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(5,6);
INSERT INTO [PRN231_Project].[dbo].[Slot_Date]([SlotId],[DateId]) VALUES(5,7);


INSERT INTO [PRN231_Project].[dbo].[Class]([ClassName],[MentorId],[SubjectId],[DateFrom],[DateTo],[Number],[Status])  
VALUES('SE1606',1,1,'07-20-2023','08-25-2023',30,1);
INSERT INTO [PRN231_Project].[dbo].[Class]([ClassName],[MentorId],[SubjectId],[DateFrom],[DateTo],[Number],[Status])  
VALUES('SE1607',1,2,'07-20-2023','08-25-2023',30,1);
INSERT INTO [PRN231_Project].[dbo].[Class]([ClassName],[MentorId],[SubjectId],[DateFrom],[DateTo],[Number],[Status])  
VALUES('SE1608',1,2,'09-09-2023','10-10-2023',30,1);
INSERT INTO [PRN231_Project].[dbo].[Class]([ClassName],[MentorId],[SubjectId],[DateFrom],[DateTo],[Number],[Status])  
VALUES('SE1608',1,2,'09-09-2023','10-10-2023',30,1);


INSERT INTO [PRN231_Project].[dbo].[StudentClass]([StudentId],[ClassId])VALUES(1,1);
INSERT INTO [PRN231_Project].[dbo].[StudentClass]([StudentId],[ClassId])VALUES(2,1);
INSERT INTO [PRN231_Project].[dbo].[StudentClass]([StudentId],[ClassId])VALUES(3,1);
INSERT INTO [PRN231_Project].[dbo].[StudentClass]([StudentId],[ClassId])VALUES(4,1);
INSERT INTO [PRN231_Project].[dbo].[StudentClass]([StudentId],[ClassId])VALUES(5,1);
INSERT INTO [PRN231_Project].[dbo].[StudentClass]([StudentId],[ClassId])VALUES(1,3);
INSERT INTO [PRN231_Project].[dbo].[StudentClass]([StudentId],[ClassId])VALUES(2,3);
INSERT INTO [PRN231_Project].[dbo].[StudentClass]([StudentId],[ClassId])VALUES(3,3);
INSERT INTO [PRN231_Project].[dbo].[StudentClass]([StudentId],[ClassId])VALUES(4,3);
INSERT INTO [PRN231_Project].[dbo].[StudentClass]([StudentId],[ClassId])VALUES(5,3);



INSERT INTO [PRN231_Project].[dbo].[ClassSlotDate]([ClassId],[SlotDateId]) values (1,1);
INSERT INTO [PRN231_Project].[dbo].[ClassSlotDate]([ClassId],[SlotDateId]) values (1,3);
INSERT INTO [PRN231_Project].[dbo].[ClassSlotDate]([ClassId],[SlotDateId]) values (2,7);
INSERT INTO [PRN231_Project].[dbo].[ClassSlotDate]([ClassId],[SlotDateId]) values (2,8);
INSERT INTO [PRN231_Project].[dbo].[ClassSlotDate]([ClassId],[SlotDateId]) values (3,11);
INSERT INTO [PRN231_Project].[dbo].[ClassSlotDate]([ClassId],[SlotDateId]) values (3,10);

delete ClassSlotDate
select * from [ClassSlotDate]
select * from Slot_Date
select * from Class
select * from Account
select * from ClassSlotDate
select * from Slot_Date
select * from [StudentClass]
