if db_id('CityEduManage') is null
	create database CityEduManage
go
use CityEduManage

/*==============================================================*/
/* Database name:  PHYSICAL DATA MODEL 1                        */
/* DBMS name:      Microsoft SQL Server 2000                    */
/* Created on:     2005-9-4 14:49:55                            */
/*==============================================================*/


if exists (select 1
            from  sysobjects
           where  id = object_id('View_Teacher_Statistics')
            and   type = 'V')
   drop view View_Teacher_Statistics
go


if exists (select 1
            from  sysobjects
           where  id = object_id('View_Teacher')
            and   type = 'V')
   drop view View_Teacher
go


if exists (select 1
            from  sysobjects
           where  id = object_id('View_Student_Statistics')
            and   type = 'V')
   drop view View_Student_Statistics
go


if exists (select 1
            from  sysobjects
           where  id = object_id('View_StudentSchool_SchoolType')
            and   type = 'V')
   drop view View_StudentSchool_SchoolType
go


if exists (select 1
            from  sysobjects
           where  id = object_id('View_StudentSchool')
            and   type = 'V')
   drop view View_StudentSchool
go


if exists (select 1
            from  sysobjects
           where  id = object_id('View_StudentClass_Detail_City')
            and   type = 'V')
   drop view View_StudentClass_Detail_City
go


if exists (select 1
            from  sysobjects
           where  id = object_id('View_StudentClass_Detail')
            and   type = 'V')
   drop view View_StudentClass_Detail
go


if exists (select 1
            from  sysobjects
           where  id = object_id('View_StudentClass')
            and   type = 'V')
   drop view View_StudentClass
go


if exists (select 1
            from  sysobjects
           where  id = object_id('View_School')
            and   type = 'V')
   drop view View_School
go


if exists (select 1
            from  sysobjects
           where  id = object_id('View_Office')
            and   type = 'V')
   drop view View_Office
go


if exists (select 1
            from  sysobjects
           where  id = object_id('View_Committee')
            and   type = 'V')
   drop view View_Committee
go


if exists (select 1
            from  sysobjects
           where  id = object_id('View_Class_Statistics_temp')
            and   type = 'V')
   drop view View_Class_Statistics_temp
go


if exists (select 1
            from  sysobjects
           where  id = object_id('View_Class_Statistics')
            and   type = 'V')
   drop view View_Class_Statistics
go


if exists (select 1
            from  sysobjects
           where  id = object_id('View_ClassSchool')
            and   type = 'V')
   drop view View_ClassSchool
go


if exists (select 1
            from  sysobjects
           where  id = object_id('View_Class')
            and   type = 'V')
   drop view View_Class
go


if exists (select 1
            from  sysobjects
           where  id = object_id('View_City_Teacher_Statistics')
            and   type = 'V')
   drop view View_City_Teacher_Statistics
go


if exists (select 1
            from  sysobjects
           where  id = object_id('View_City_Student_Statistics')
            and   type = 'V')
   drop view View_City_Student_Statistics
go


if exists (select 1
            from  sysobjects
           where  id = object_id('View_City_School_Statistics')
            and   type = 'V')
   drop view View_City_School_Statistics
go


if exists (select 1
            from  sysobjects
           where  id = object_id('View_City_Class_Statistics')
            and   type = 'V')
   drop view View_City_Class_Statistics
go





/*==============================================================*/
/* View: View_Class                                             */
/*==============================================================*/
create view View_Class as 
SELECT Class.*,Class_Type.Class_Type_Name
FROM Class_Type inner join Class
on Class_Type.Class_Type_ID=Class.Class_Type_ID
go


/*==============================================================*/
/* View: View_ClassSchool                                       */
/*==============================================================*/
create view View_ClassSchool as 
SELECT School.School_Name,School.School_Type_ID,Class.*
FROM School inner join Class
on School.School_ID=Class.School_ID
go



/*==============================================================*/
/* View: View_Class_Statistics_temp                             */
/*==============================================================*/
create view View_Class_Statistics_temp as 
SELECT School.School_ID,School.School_Type_ID,School.School_Name,View_Class.Class_Type_Name,View_Class.Class_ID,View_Class.Class_Type_ID
FROM School inner join View_Class
on School.School_ID=View_Class.School_ID
go



/*==============================================================*/
/* View: View_Office                                            */
/*==============================================================*/
create view View_Office as 
SELECT Office.*,QuXian.QuXian_Name
FROM Office inner join QuXian
on Office.QuXian_ID_OfficeIn=QuXian.QuXian_ID
go


/*==============================================================*/
/* View: View_Committee                                         */
/*==============================================================*/
create view View_Committee as 
SELECT Committee.*,View_Office.QuXian_Name,View_Office.Office_Name
FROM Committee inner join View_Office
on Committee.Office_ID=View_Office.Office_ID
go

/*==============================================================*/
/* View: View_School                                            */
/*==============================================================*/
create view View_School as 
SELECT School.*,School_Type.School_Type_Name,School_Type.School_Type_Year
FROM School inner join School_Type
on School.School_Type_ID=School_Type.School_Type_ID
go


/*==============================================================*/
/* View: View_StudentClass                                      */
/*==============================================================*/
create view View_StudentClass as 
SELECT Student.*,Class.Class_Name,Class.Class_Type_ID,Class.TeacherInCharge
FROM Student inner join Class
on Student.Class_ID=Class.Class_ID AND Student.School_ID=Class.School_ID
go


/*==============================================================*/
/* View: View_StudentClass_Detail                               */
/*==============================================================*/
create view View_StudentClass_Detail as 
SELECT View_StudentClass.*,Class_Type.Class_Type_Name
FROM View_StudentClass inner join Class_Type
on View_StudentClass.Class_Type_ID=Class_Type.Class_Type_ID
go


/*==============================================================*/
/* View: View_StudentClass_Detail_City                          */
/*==============================================================*/
create view View_StudentClass_Detail_City as 
SELECT View_StudentClass_Detail.*,School.School_Name
FROM View_StudentClass_Detail inner join School
on View_StudentClass_Detail.School_ID=School.School_ID
go


/*==============================================================*/
/* View: View_StudentSchool                                     */
/*==============================================================*/
create view View_StudentSchool as 
SELECT Student.*,School.School_Name,School.School_Type_ID
FROM Student inner join School
on Student.School_ID=School.School_ID
go


/*==============================================================*/
/* View: View_StudentSchool_SchoolType                          */
/*==============================================================*/
create view View_StudentSchool_SchoolType as 
SELECT View_StudentSchool.*,School_Type.School_Type_Name
FROM View_StudentSchool inner join School_Type
on View_StudentSchool.School_Type_ID=School_Type.School_Type_ID
go


/*==============================================================*/
/* View: View_Student_Statistics                                */
/*==============================================================*/
create view View_Student_Statistics as 
select School_ID AS 学校代码,School_Name AS 学校名称,Class_Type_Name AS 年级,Count(Student_ID) AS 人数
FROM View_StudentClass_Detail_City
Group By School_ID,School_Name,Class_Type_Name
go


/*==============================================================*/
/* View: View_Teacher                                           */
/*==============================================================*/
create view View_Teacher as 
SELECT Teacher.*,School.School_Name
FROM Teacher INNER JOIN School
ON Teacher.School_ID = School.School_ID
go


/*==============================================================*/
/* View: View_Teacher_Statistics                                */
/*==============================================================*/
create view View_Teacher_Statistics as 
select School_ID AS 学校代码,School_Name AS 学校名称,SchoolType AS 学历,Count(*) AS 人数
From View_Teacher
Group By SchoolType,School_ID,School_Name
go


/*==============================================================*/
/* View: View_City_Class_Statistics                             */
/*==============================================================*/
create view View_City_Class_Statistics as 
select School_Type.School_Type_Name AS 学校类型,View_Class_Statistics_temp.Class_Type_Name AS 年级,Count(Class_ID) AS 班数
From View_Class_Statistics_temp inner join School_Type
on View_Class_Statistics_temp.School_Type_ID=School_Type.School_Type_ID
Group By School_Type_Name,Class_Type_Name
go

/*==============================================================*/
/* View: View_City_Student_Statistics                           */
/*==============================================================*/
create view View_City_Student_Statistics as 
select School_Type_Name AS 学校类别,Count(Student_ID) AS 人数
FROM View_StudentSchool_SchoolType
Group By School_Type_Name
go


/*==============================================================*/
/* View: View_Class_Statistics                                  */
/*==============================================================*/
create view View_Class_Statistics as 
select School_ID AS 学校代码,School_Name AS 学校名称,Class_Type_Name AS 年级,Count(Class_ID) AS 班数
From View_Class_Statistics_temp
Group By School_ID,School_Name,Class_Type_Name
go


/*==============================================================*/
/* View: View_City_School_Statistics                            */
/*==============================================================*/
create view View_City_School_Statistics as 
select School_Type_Name AS 学校类型,Count(School_ID) AS 个数
From View_School
Group By School_Type_Name
go

/*==============================================================*/
/* View: View_City_Teacher_Statistics                           */
/*==============================================================*/
create view View_City_Teacher_Statistics as 
select SchoolType AS 学历,Count(*) AS 人数
From View_Teacher
Group By SchoolType
go
