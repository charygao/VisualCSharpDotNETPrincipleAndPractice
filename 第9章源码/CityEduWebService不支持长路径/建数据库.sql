if db_id('CityEduManage') is null
	create database CityEduManage
go
use CityEduManage

/*==============================================================*/
/* Database name: 
CityEduManage
SchoolManage
                     */
/* DBMS name:      Microsoft SQL Server 2000                    */
/* Created on:     2005-8-10 10:17:52                           */
/*==============================================================*/

alter table Class
   drop constraint FK_CLASS_REFERENCE_SCHOOL
go


alter table Class
   drop constraint FK_CLASS_REFERENCE_CLASS_TY
go


alter table Class_Type
   drop constraint FK_CLASS_TY_REFERENCE_SCHOOL_T
go


alter table Office
   drop constraint FK_OFFICE_REFERENCE_QUXIAN
go


alter table School
   drop constraint FK_SCHOOL_REFERENCE_SCHOOL_T
go


alter table Student
   drop constraint FK_STUDENT_REFERENCE_CLASS
go


alter table Student
   drop constraint FK_STUDENT_REFERENCE_QUXIAN
go


alter table Student
   drop constraint FK_STUDENT_REFERENCE_OFFICE
go


alter table Student
   drop constraint FK_STUDENT_REFERENCE_COMMITTE
go


if exists (select 1
            from  sysobjects
           where  id = object_id('View_StudentSchool')
            and   type = 'V')
   drop view View_StudentSchool
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
           where  id = object_id('Class')
            and   type = 'U')
   drop table Class
go


if exists (select 1
            from  sysobjects
           where  id = object_id('Class_Type')
            and   type = 'U')
   drop table Class_Type
go


if exists (select 1
            from  sysobjects
           where  id = object_id('Committee')
            and   type = 'U')
   drop table Committee
go


if exists (select 1
            from  sysobjects
           where  id = object_id('MessageToSchool')
            and   type = 'U')
   drop table MessageToSchool
go


if exists (select 1
            from  sysobjects
           where  id = object_id('Office')
            and   type = 'U')
   drop table Office
go


if exists (select 1
            from  sysobjects
           where  id = object_id('QuXian')
            and   type = 'U')
   drop table QuXian
go


if exists (select 1
            from  sysobjects
           where  id = object_id('School')
            and   type = 'U')
   drop table School
go


if exists (select 1
            from  sysobjects
           where  id = object_id('School_Type')
            and   type = 'U')
   drop table School_Type
go


if exists (select 1
            from  sysobjects
           where  id = object_id('SetClassName')
            and   type = 'U')
   drop table SetClassName
go


if exists (select 1
            from  sysobjects
           where  id = object_id('Student')
            and   type = 'U')
   drop table Student
go


if exists (select 1
            from  sysobjects
           where  id = object_id('Student_OLD')
            and   type = 'U')
   drop table Student_OLD
go


if exists (select 1
            from  sysobjects
           where  id = object_id('Users')
            and   type = 'U')
   drop table Users
go


/*==============================================================*/
/* Table: Class                                                 */
/*==============================================================*/
create table Class (
   Class_ID             int                  not null,
   School_ID            varchar(50)          not null,
   Class_Type_ID        int                  null,
   Class_Name           varchar(20)          not null,
   TeacherInCharge      varchar(50)          null,
   constraint PK_CLASS primary key  (Class_ID, School_ID)
)
go


/*==============================================================*/
/* Table: Class_Type                                            */
/*==============================================================*/
create table Class_Type (
   Class_Type_ID        int                  not null,
   Class_Type_Name      varchar(20)          not null,
   School_Type_ID_Class_Belong int                  null,
   constraint PK_CLASS_TYPE primary key  (Class_Type_ID)
)
go


/*==============================================================*/
/* Table: Committee                                             */
/*==============================================================*/
create table Committee (
   Committee_ID         int                  not null,
   Committee_Name       varchar(50)          not null,
   constraint PK_COMMITTEE primary key  (Committee_ID)
)
go


/*==============================================================*/
/* Table: MessageToSchool                                       */
/*==============================================================*/
create table MessageToSchool (
   Message_ID           int                  identity,
   MessageText          varchar(500)         null,
   MessageValid         bit                  null,
   constraint PK_MESSAGETOSCHOOL primary key  (Message_ID)
)
go


/*==============================================================*/
/* Table: Office                                                */
/*==============================================================*/
create table Office (
   Office_ID            int                  not null,
   Office_Name          varchar(50)          not null,
   QuXian_ID_OfficeIn   int                  null,
   constraint PK_OFFICE primary key  (Office_ID)
)
go


/*==============================================================*/
/* Table: QuXian                                                */
/*==============================================================*/
create table QuXian (
   QuXian_ID            int                  not null,
   QuXian_Name          varchar(50)          not null,
   constraint PK_QUXIAN primary key  (QuXian_ID)
)
go


/*==============================================================*/
/* Table: School                                                */
/*==============================================================*/
create table School (
   School_ID            varchar(50)          not null,
   School_Name          varchar(50)          not null,
   School_Type_ID       int                  not null,
   Schoolmaster         varchar(50)          null,
   School_Tel           varchar(50)          null,
   School_Zip           varchar(50)          null,
   School_Address       varchar(100)         null,
   UploadTime           datetime             null,
   Upload_password      varchar(50)          null,
   constraint PK_SCHOOL primary key  (School_ID)
)
go


/*==============================================================*/
/* Table: School_Type                                           */
/*==============================================================*/
create table School_Type (
   School_Type_ID       int                  not null,
   School_Type_Name     varchar(20)          null,
   School_Type_Year     int                  null,
   constraint PK_SCHOOL_TYPE primary key  (School_Type_ID)
)
go


/*==============================================================*/
/* Table: SetClassName                                          */
/*==============================================================*/
create table SetClassName (
   ClassName_ID         varchar(20)          not null,
   ClassNameSeted       varchar(20)          null,
   constraint PK_SETCLASSNAME primary key  (ClassName_ID)
)
go


/*==============================================================*/
/* Table: Student                                               */
/*==============================================================*/
create table Student (
   School_ID            varchar(50)          not null,
   Student_ID           varchar(20)          not null,
   Class_ID             int                  not null,
   Name                 varchar(50)          not null,
   Birthday             datetime             null,
   Sex                  char(2)              null,
   Father               varchar(50)          null,
   Mother               varchar(50)          null,
   Keeper               varchar(50)          null,
   StudentTel           varchar(20)          null,
   QuXian_ID            int                  null,
   Office_ID            int                  null,
   Committee            varchar(50)          null,
   Committee_ID         int                  null,
   Student_Address      varchar(100)         null,
   constraint PK_STUDENT primary key  (School_ID, Student_ID)
)
go


/*==============================================================*/
/* Table: Student_OLD                                           */
/*==============================================================*/
create table Student_OLD (
   temp_ID              int                  identity,
   School_ID            varchar(30)          null,
   Student_ID           varchar(20)          null,
   Class_ID             int                  null,
   Name                 varchar(50)          null,
   Birthday             datetime             null,
   Sex                  char(2)              null,
   Father               varchar(50)          null,
   Mother               varchar(50)          null,
   Keeper               varchar(50)          null,
   StudentTel           varchar(20)          null,
   QuXian_ID            int                  null,
   Office_ID            int                  null,
   Committee            varchar(50)          null,
   Committee_ID         int                  null,
   Student_Address      varchar(100)         null,
   constraint PK_STUDENT_OLD primary key  (temp_ID)
)
go


/*==============================================================*/
/* Table: Users                                                 */
/*==============================================================*/
create table Users (
   UserName             varchar(20)          not null,
   PassWord             varchar(20)          null,
   ReadOnly             bit                  null,
   constraint PK_USERS primary key  (UserName)
)
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
on Student.Class_ID=Class.Class_ID
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
/* View: View_StudentSchool                                     */
/*==============================================================*/
create view View_StudentSchool as 
SELECT Student.*,School.School_Name
FROM Student inner join School
on Student.School_ID=School.School_ID
go


alter table Class
   add constraint FK_CLASS_REFERENCE_SCHOOL foreign key (School_ID)
      references School (School_ID)
go


alter table Class
   add constraint FK_CLASS_REFERENCE_CLASS_TY foreign key (Class_Type_ID)
      references Class_Type (Class_Type_ID)
go


alter table Class_Type
   add constraint FK_CLASS_TY_REFERENCE_SCHOOL_T foreign key (School_Type_ID_Class_Belong)
      references School_Type (School_Type_ID)
go


alter table Office
   add constraint FK_OFFICE_REFERENCE_QUXIAN foreign key (QuXian_ID_OfficeIn)
      references QuXian (QuXian_ID)
go


alter table School
   add constraint FK_SCHOOL_REFERENCE_SCHOOL_T foreign key (School_Type_ID)
      references School_Type (School_Type_ID)
go


alter table Student
   add constraint FK_STUDENT_REFERENCE_CLASS foreign key (Class_ID, School_ID)
      references Class (Class_ID, School_ID)
go


alter table Student
   add constraint FK_STUDENT_REFERENCE_QUXIAN foreign key (QuXian_ID)
      references QuXian (QuXian_ID)
go


alter table Student
   add constraint FK_STUDENT_REFERENCE_OFFICE foreign key (Office_ID)
      references Office (Office_ID)
go


alter table Student
   add constraint FK_STUDENT_REFERENCE_COMMITTE foreign key (Committee_ID)
      references Committee (Committee_ID)
go


