CREATE DATABASE bank CHARACTER SET utf8 COLLATE utf8_general_ci;
use bank;
CREATE TABLE fixBalances(
	Fid int(100) auto_increment PRIMARY KEY,
	Fcid int(100) not null,
	Fyear int(50) NULL DEFAULT '0',
	FfixBalanceRate double(200,5) NULL DEFAULT '0.00000',
	FfixBalance double(200,3) NULL DEFAULT '0.00000',
	FbusinessTime datetime NULL DEFAULT CURRENT_TIMESTAMP
	);
alter table fixBalances AUTO_INCREMENT=50001;

INSERT INTO fixBalances (Fyear,Fcid,FfixBalanceRate,FfixBalance) VALUES (5 ,20001,0.35,1000.000);
INSERT INTO fixBalances (Fyear,Fcid,FfixBalanceRate,FfixBalance) VALUES (2 ,20001,0.335,1000.000);
INSERT INTO fixBalances (Fyear,Fcid,FfixBalanceRate,FfixBalance) VALUES (3 ,20004,0.30,1000.000);
INSERT INTO fixBalances (Fyear,Fcid,FfixBalanceRate,FfixBalance) VALUES (2 ,20003,0.335,1000.000);


CREATE TABLE cards(
	Cid int(100) auto_increment PRIMARY KEY,
	Cuid int(100) not null,
	Cpassword VARCHAR(200) not null,
	CflowBalance DOUBLE(200,5) NULL DEFAULT '0.00000',
	CflowBalanceRate DOUBLE(200,5) NULL DEFAULT '0.00000'
	);
alter table cards AUTO_INCREMENT=20001;

INSERT INTO cards (Cuid,Cpassword,CflowBalance,CflowBalanceRate) VALUES (10001 ,'20001' ,1000,0.25);
INSERT INTO cards (Cuid,Cpassword,CflowBalance,CflowBalanceRate) VALUES (10002,'20002' ,1000,0.26);
INSERT INTO cards (Cuid,Cpassword) VALUES (10003 ,'20003');
INSERT INTO cards (Cuid,Cpassword) VALUES (10004 ,'20004');


CREATE TABLE Depositors(
	Uid int(100)  PRIMARY KEY not null,
	Ucid int(100) NULL DEFAULT NULL,
	Uname VARCHAR(200) not null,
	Upassword VARCHAR(200)not null,
	Uidentify VARCHAR(5) NOT NULL DEFAULT '储户',
	Ustatus VARCHAR(200) NOT NULL DEFAULT '正常'
	);

INSERT INTO Depositors (Uid,Ucid,Upassword,Uname) VALUES (10001,20001 ,'10001','李一');
INSERT INTO Depositors (Uid,Ucid,Upassword,Uname) VALUES (10002,20002 ,'10002','李二');
INSERT INTO Depositors (Uid,Ucid,Upassword,Uname) VALUES (10003,20003 ,'10003','李三');
INSERT INTO Depositors (Uid,Ucid,Upassword,Uname) VALUES (10004,20004 ,'10004','李四');

CREATE TABLE bands(
	Bcid int(100) PRIMARY KEY not null,
	Buid int(100) not null
	);
INSERT INTO bands (Bcid,Buid) VALUES (20001,10001);
INSERT INTO bands (Bcid,Buid) VALUES (20002,10002);
INSERT INTO bands (Bcid,Buid) VALUES (20003,10003);
INSERT INTO bands (Bcid,Buid) VALUES (20004,10004);

CREATE TABLE managers(
	Mid int(100) auto_increment PRIMARY KEY,
	Mname VARCHAR(200) not null,
	Mpassword VARCHAR(200) not null,
	Midentify VARCHAR(5) NOT NULL DEFAULT '管理员'
	);
-- 主键设置初始值
alter table managers AUTO_INCREMENT=30001;

INSERT INTO managers (Mname,Mpassword) VALUES ('张一' ,'30001');
INSERT INTO managers (Mname,Mpassword,Midentify) VALUES ('张二' ,'30002' ,'行长');
INSERT INTO managers (Mname,Mpassword) VALUES ('张三' ,'30003');
INSERT INTO managers (Mname,Mpassword,Midentify) VALUES ('张四' ,'30004' ,'行长');
INSERT INTO managers (Mname,Mpassword) VALUES ('张五' ,'30005');


CREATE TABLE records(
	Rid int(100) auto_increment PRIMARY KEY,
	Ruid int(100) not null,
	Rcid int(100) not null,
	RflowDeposit DOUBLE(200,3) NULL DEFAULT '0.00000',
	RfixDepostit DOUBLE(200,3) NULL DEFAULT '0.00000',
	Rwithdrawals DOUBLE(200,3) NULL DEFAULT '0.00000',
	RnowDateTime DateTime NULL DEFAULT CURRENT_TIMESTAMP
	);
-- 主键设置初始值
alter table records AUTO_INCREMENT=40001;
INSERT INTO records (Ruid,Rcid,RflowDeposit) VALUES (10001,20001,1000.000);
INSERT INTO records (Ruid,Rcid,RfixDepostit) VALUES (10001,20001,1000.000);
INSERT INTO records (Ruid,Rcid,RfixDepostit) VALUES (10001,20001,1000.000);

INSERT INTO records (Ruid,Rcid,RflowDeposit) VALUES (10002,20002,1000.000);

INSERT INTO records (Ruid,Rcid,RfixDepostit) VALUES (10003,20003,1000.000);

INSERT INTO records (Ruid,Rcid,RfixDepostit) VALUES (10004,20004,1000.000);

-- 设置外键将Depositors的Uid作为cards的一个外键Cuid
alter table cards add constraint FK_Reference_1 foreign key (Cuid)
      references Depositors (Uid) on delete restrict on update restrict;
-- 设置外键将cards的Cid作为records的一个外键Rcid
alter table records add constraint FK_Reference_2 foreign key (Rcid)
      references cards (Cid) on delete restrict on update restrict;

alter table fixBalances add constraint FK_Reference_3 foreign key (Fcid)
      references cards (Cid) on delete restrict on update restrict;

alter table bands add constraint FK_Reference_4 foreign key (Bcid)
      references cards (Cid) on delete restrict on update restrict;

-- 创建视图，用来检索重要信息，不必多表查找
CREATE view information(
	Icid,
	Iuid,
	Ioldtime,
	IflowBalance,
	IflowBalanceRate,
	IfixBalance,
	IfixBalanceRate,
	Iname,
	Istatus)
as select distinct
cards.Cid,
cards.Cuid,
records.RnowDateTime,
cards.CflowBalance,
cards.CflowBalanceRate,
fixBalances.FfixBalance,
fixBalances.FfixBalanceRate,
Depositors.Uname,
Depositors.Ustatus
from Depositors,records,cards left join fixBalances on cards.Cid  = fixbalances.Fcid
where cards.Cid = records.Rcid 
and cards.Cuid = Depositors.Uid;

CREATE view DepositorAndCard(
	Dname,
	Duid,
	Dcid
)
as select distinct
Depositors.Uname,
Depositors.Uid,
Cards.Cid
from Depositors,cards
where cards.Cuid = Depositors.Uid;

