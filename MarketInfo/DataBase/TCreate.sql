-- ==============================================================
--  Database name:  stockmarket
--  DBMS name:      Microsoft SQL Server 2014
--  Model:          Stock
--  Created on:     2015-6-17
--  Author by:		Chinglee
--  Model:          secuurity Manager
-- ==============================================================
use stockmarket
go
--==============================================================
-- Table : 系统配置信息表
--==============================================================
if exists (select * from sysobjects where name='sysconfig' )
drop table sysconfig
go

create table sysconfig
(
  sysid					dtsno               , -- 配置编码
  class					dtkind				, -- 配置项类别 'u' 网址url 
  keyname               dtkinds             , -- 配置项名称
  keyvalue              dtchar255           , -- 配置项值
  sysstatus				dtkind				, -- 可用状态 '0' 可用状态，'1' 不可用
                                              
  constraint sysconfig_pk primary key (sysid,class,keyname)
)

go

--==============================================================
-- Table : 证券品种信息表
--==============================================================
if exists (select * from sysobjects where name='stock' )
drop table stock
go

create table stock
(
  serverid              dtsno               , -- 机器编码
  market                dtkind              , -- 交易市场
  stkid                 dtstkid             , -- 证券内码
  stkcode               dtstkcode           , -- 证券代码
  linkstk               dtstkcode           , -- 关联代码
  frzstk                dtstkcode           , -- 冻结代码
  stkname               dtstkname           , -- 证券名称
  stktype               dtkind              , -- 证券类别
  moneytype             dtkind              , -- 货币代码
  spellid               dtchar8             , -- 拼音编码
  stkstatus             dtkind              , -- 状态
                                              -- 'N' 通常状态
                                              -- 'Y' 首日上市
                                              -- 'Z' 增发股份上市
                                              -- 'F' 上网定价发行
                                              -- 'I' 上网竞价发行
                                              -- 'P' 国债挂牌分销
  stklevel              dtkind              , -- 证券级别 'N'表示'S'ST股'P'PT股'H' 上交所挂牌股票
  stkright              dtkind              , -- 证券权益 "N"表示正常状态,"E"表示除权,"D"表示除息,"A"表示除权除息.
  
  constraint stock_pk primary key (stkcode,market,serverid)

)

go
--==============================================================
-- Table:  客户表
--==============================================================
if exists (select * from sysobjects where name='customer' )
drop table customer
go

create table customer (
  userid                dtcustid            , -- 用户代码
  username              dtname              , -- 用户姓名
  userkind              dtkind              , -- 客户类别(0,上帝; 1 管理; 2 普通)
  usergroup             dtkind              , -- 客户分组(备用)
  pwd					dtchar32            , -- 登录密码
  pwderrtimes           dtint               , -- 客户密码校验错误次数
  status                dtkind              , -- 状态, 0正常1冻结2挂失3密码锁定4复核锁定5系统锁定*销户
  lockflag              dtkind              , -- **密码出错锁定 '0' 不锁定 '1'锁定
  extprop               dtchar32            , -- **备用的客户扩展属性
  identitysign          dtchar64            , -- **数字签名
  custotherkind1        dtkind              , -- 备用字段1  
  custotherkind2        dtkind              , -- 备用字段2  
  custotherkinds        dtkinds             , -- 备用字段3
  constraint customer_pk primary key (userid)
)

go


--==============================================================
-- Table:  用户自选股票列表(该表已废弃)
--==============================================================

--if exists (select * from sysobjects where name='cust_stockinfo' )
--drop table cust_stockinfo
--go

--create table cust_stockinfo (
--  userid                dtcustid            , -- 用户代码
--  stocklist             dtchar2048          , -- 用户自选列表（600000,601166…逗号分隔）

--  constraint cust_stockinfo_pk primary key (userid)
--)



--==============================================================
-- Table:  用户自选股票列表
--==============================================================
if exists (select * from sysobjects where name='custselectstock' )
drop table cust_stockinfo
go

create table custselectstock (
  userid                dtcustid            , -- 用户代码
  stkcode               dtstkcode           , -- 用户自选股票代码
  stkname               dtstkname           , -- 用户自选股票名称

  constraint cust_stockinfo_pk primary key (userid,stkcode)
)