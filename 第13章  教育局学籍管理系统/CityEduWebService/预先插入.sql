if db_id('CityEduManage') is null
	create database CityEduManage
go
use CityEduManage


/*学校类型*/
insert into School_Type values(0,'小学',6)
insert into School_Type values(1,'初中',3)
insert into School_Type values(2,'高中',3)
insert into School_Type values(3,'完中',6)
insert into School_Type values(4,'九年一贯制',9)
/*年级*/
insert into Class_Type values(0,'1年级',0)
insert into Class_Type values(1,'2年级',0)
insert into Class_Type values(2,'3年级',0)
insert into Class_Type values(3,'4年级',0)
insert into Class_Type values(4,'5年级',0)
insert into Class_Type values(5,'6年级',0)
/*年级*/
insert into Class_Type values(6,'初1',1)
insert into Class_Type values(7,'初2',1)
insert into Class_Type values(8,'初3',1)
/*年级*/
insert into Class_Type values(9,'高1',2)
insert into Class_Type values(10,'高2',2)
insert into Class_Type values(11,'高3',2)
/*年级*/
insert into Class_Type values(12,'初1',3)
insert into Class_Type values(13,'初2',3)
insert into Class_Type values(14,'初3',3)
insert into Class_Type values(15,'高1',3)
insert into Class_Type values(16,'高2',3)
insert into Class_Type values(17,'高3',3)
/*年级*/
insert into Class_Type values(18,'1年级',4)
insert into Class_Type values(19,'2年级',4)
insert into Class_Type values(20,'3年级',4)
insert into Class_Type values(21,'4年级',4)
insert into Class_Type values(22,'5年级',4)
insert into Class_Type values(23,'6年级',4)
insert into Class_Type values(24,'初1',4)
insert into Class_Type values(25,'初2',4)
insert into Class_Type values(26,'初3',4)
/*年级*/
insert into QuXian values(0,'中原区')
insert into QuXian values(1,'二七区')
insert into QuXian values(2,'管城区')
insert into QuXian values(3,'金水区')
insert into QuXian values(4,'惠济区')
insert into QuXian values(5,'高新区')
insert into QuXian values(6,'经济开发区')
insert into QuXian values(7,'郑州市其它县市区')
insert into QuXian values(8,'非郑州市')
insert into QuXian values(9,'无下属办事处的区')
insert into Office values(0,'无下属家居委会的办事处',9)
/*用户*/
insert into Users values('Admin','Admin',0)
go