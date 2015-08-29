--新股票代码更新20150623
insert into run..stock (market, stkcode, stkname,stktype) values (1, '000001', '上证综指',9)
--delete run..stock where stkcode = '399001';
insert into run..stock (market, stkcode, stkname) values (2, '399001', '深证成指');
--delete run..stock where stkcode = '399006';
insert into run..stock (market, stkcode, stkname) values (2, '399006', '创业板指');
update run..stock set stkname = '中国核电' where stkcode = '601985';
--delete run..stock where stkcode = '601211';
insert into run..stock (market, stkcode, stkname) values (1, '601211', '国泰君安')

--系统配置加入
insert into run..sysconfig (sysid, class, keyname, keyvalue, sysstatus) values (1001, 'u', 'Marketlist_Sina','http://hq.sinajs.cn/list=','0');
insert into run..sysconfig (sysid, class, keyname, keyvalue, sysstatus) values (1002, 'u', 'Marketlist_Tencent','http://qt.gtimg.cn/q=','0');
insert into run..sysconfig (sysid, class, keyname, keyvalue, sysstatus) values (1003, 'u', 'Marketdailyk_Sina','http://image.sinajs.cn/newchart/daily/n/','0');
insert into run..sysconfig (sysid, class, keyname, keyvalue, sysstatus) values (1004, 'u', 'Markettimeline_Sina','http://image.sinajs.cn/newchart/min/n/','0');
insert into run..sysconfig (sysid, class, keyname, keyvalue, sysstatus) values (1005, 'u', 'Marketweekk_Sina','http://image.sinajs.cn/newchart/weekly/n/','0');
insert into run..sysconfig (sysid, class, keyname, keyvalue, sysstatus) values (1006, 'u', 'Marketmonthk_Sina','http://image.sinajs.cn/newchart/monthly/n/','0');
insert into run..sysconfig (sysid, class, keyname, keyvalue, sysstatus) values (1007, 'u', 'Market_daily_his_yahoo','http://table.finance.yahoo.com/table.csv?s=','0');

--用户表,加入admin
insert into run..customer (userid, username, userkind, pwd, status ) values (1, 'admin', '0','990818','0');

--为admin加入自选表
insert into run..cust_stockinfo (userid, stocklist) values (1, '600839,600000,601166,000001,399001,600036,000521,000333,600030,600015,002736,600028,601857,399006,601336,002326,000581')


insert into market..custselectstock(userid,stkcode,stkname) values(1,'150182','军工B');
insert into market..custselectstock(userid,stkcode,stkname) values(1,'000001','上证指数');