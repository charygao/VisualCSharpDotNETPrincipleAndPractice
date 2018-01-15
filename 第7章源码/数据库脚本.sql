create database stumanage
go
use stumanage
go
create table scores( --建立表
	stu_id nchar(10) PRIMARY KEY,
	stu_name nchar(10) not null,
	english_score int check(english_score<100),
	math_score int,
	computer_score int,
	physics_score int 
)
go
insert into scores values ('1','张1','60','70','80','90')
insert into scores values ('2','张2','61','71','81','91')
insert into scores values ('3','张3','62','72','82','92')
insert into scores values ('4','张4','63','73','83','93')
insert into scores values ('5','张5','64','74','84','94')
insert into scores values ('6','张6','65','75','85','95')
insert into scores values ('7','张7','66','76','86','96')
insert into scores values ('8','张8','67','77','87','97')
insert into scores values ('9','张9','68','78','88','98')
insert into scores values ('10','张10','69','79','89','99')
insert into scores values ('11','张11','70','80','90','100')
insert into scores values ('12','张12','71','81','91','101')
insert into scores values ('13','张13','72','82','92','102')
insert into scores values ('14','张14','73','83','93','103')
insert into scores values ('15','张15','74','84','94','104')
insert into scores values ('16','张16','75','85','95','105')
insert into scores values ('17','张17','76','86','96','106')
insert into scores values ('18','张18','77','87','97','107')
insert into scores values ('19','张19','78','88','98','108')
insert into scores values ('20','张20','79','89','99','109')