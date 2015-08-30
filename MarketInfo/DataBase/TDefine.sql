use stockmarket
go

--checkpoint
--dump transaction run with no_log
--go

use stockmarket

-- 证券交易
execute sp_addtype dtcustid,         'int'             , 'not null'      -- 客户代码
execute sp_addtype dtfundid,         'int'             , 'not null'      -- 资金帐号
execute sp_addtype dtsecuid,         'char(10)'        , 'not null'      -- 证券帐号
execute sp_addtype dtbankid,         'varchar(32)'     , 'not null'      -- 银行帐号
execute sp_addtype dtstkid,          'int'             , 'not null'      -- 证券内码
execute sp_addtype dtstkcode,        'char(8)'         , 'not null'      -- 证券代码
execute sp_addtype dtstkname,        'char(8)'         , 'not null'      -- 证券代码
execute sp_addtype dtfee,            'numeric(12,2)'   , 'not null'      -- 交易费用
execute sp_addtype dtname,           'char(16)'        , 'not null'      -- 姓名简称
execute sp_addtype dtidno,           'char(32)'        , 'not null'      -- 证件编号
execute sp_addtype dtamt,            'numeric(15,2)'   , 'not null'      -- 金额
execute sp_addtype dtqty,            'int'             , 'not null'      -- 数量
execute sp_addtype dtkind,           'char(1)'         , 'not null'      -- 货币
execute sp_addtype dtprice,          'numeric(9,3)'    , 'not null'      -- 股票价格
execute sp_addtype dtdate,           'int'             , 'not null'      -- 日期
execute sp_addtype dttime,           'int'             , 'not null'      -- 时间
execute sp_addtype dtorgid,          'char(4)'         , 'not null'      -- 机构编号
execute sp_addtype dtbranch,         'char(4)'         , 'not null'      -- 机构分支
execute sp_addtype dtrate,           'numeric(12,8)'    , 'not null'      -- 费率
execute sp_addtype dtpercent,        'numeric(4,3)'    , 'not null'      -- 百分比
execute sp_addtype dtstation,        'char(12)'        , 'not null'      -- 站点地址
execute sp_addtype dtseat,           'char(6)'         , 'not null'      -- 席位代码
execute sp_addtype dtorder,          'char(10)'        , 'not null'      -- 合同序号
execute sp_addtype dtsno,            'int'             , 'not null'      -- 序号

execute sp_addtype dtkinds,          'varchar(128)'    , 'not null'      -- 允许或禁止的分类
execute sp_addtype dtchar32,         'varchar(32)'     , 'not null'      -- 允许或禁止的证券类别,操作方式,备注,帐号全名
execute sp_addtype dtchar8,          'varchar(8)'      , 'not null'      -- 允许或禁止的市场,货币
execute sp_addtype dtchar64,         'varchar(64)'     , 'not null'      -- 长信息,地址
execute sp_addtype dtchar16,         'varchar(16)'     , 'not null'      -- 短信息
execute sp_addtype dtchar255,        'varchar(255)'    , 'not null'      -- 长值,路径
execute sp_addtype dtchar1024,       'varchar(1024)'   , 'not null'      -- 长值,
execute sp_addtype dtchar2048,       'varchar(2048)'   , 'not null'      -- 长值,
execute sp_addtype dtchar4000,       'varchar(4000)'   , 'not null'      -- 长值,
execute sp_addtype dtchar4096,       'varchar(4096)'   , 'not null'      -- 长值,

execute sp_addtype dtchar2,          'char(2)'         , 'not null'      -- 短值
execute sp_addtype dtchar4,          'char(4)'         , 'not null'      -- 短值
execute sp_addtype dtint,            'int'             , 'not null'      -- 整型

execute sp_addtype dtctrlvalue,      'numeric(15,4)'   , 'not null'      -- 控制值
execute sp_addtype dtnum208,         'numeric(20,8)'   , 'not null'

go

--开放式基金
execute sp_addtype dtofprice,       'numeric(7,4)'         , 'not null'  -- 基金价格
execute sp_addtype dtoftrdid,       'char(2)'              , 'not null'  -- 交易类型
execute sp_addtype dttaacc,         'char(12)'             , 'not null'  -- 基金帐号
execute sp_addtype dttransacc,      'char(17)'             , 'not null'  -- 交易帐号
--execute sp_addtype dtofcorpid,      'char(3)'              , 'not null'  -- 基金公司编码
execute sp_addtype dtyield,         'numeric(8,5)'         , 'not null'  -- 基金收益率
go

--债券交易 
execute sp_addtype dtbondacc,       'char(18)'             , 'not null'      -- 债券帐号  
execute sp_addtype dtchar12,        'char(12)'             , 'not null'      -- 短值
execute sp_addtype dtchar6,         'char(6)'              , 'not null'      -- 短值
execute sp_addtype dtchar5,         'char(5)'              , 'not null'      -- 短值
go
--自动报盘
execute sp_addtype dtchar22,         'varchar(22)'              , 'not null'      -- 深圳合同序号
execute sp_addtype dtchar9,          'varchar(9)'               , 'not null'      -- 深圳成交数量

go
--动态佣金
execute sp_addtype dtfeeid,         'varchar(8)'           , 'not null'  -- 佣金类型
execute sp_addtype dtfeekind,       'varchar(12)'          , 'not null'  -- 佣金品种
go

execute sp_addtype dtbkno,       'char(2)'         , 'not null'      -- 银行编码
execute sp_addtype dtbkbrhno,    'char(4)'         , 'not null'      -- 分行编码
execute sp_addtype dtbksubbrhno, 'char(6)'         , 'not null'      -- 支行编码
execute sp_addtype dtbknetno,    'char(8)'         , 'not null'      -- 网点代码
go

execute sp_addtype dtoperid,         'int'                , 'not null'      -- 柜员代码
--execute sp_addtype dtkeeprate,           'numeric(15,4)'    , 'not null'      -- 维持担保比例

execute sp_addtype dtint64,            'bigint'             , 'not null'      -- 整型  
execute sp_addtype dtstkqty,           'bigint'          , 'not null'      -- 股份发生数
execute sp_addtype dtchar100,            'varchar(100)'             , 'not null'      -- 
execute sp_addtype dtchar20,            'varchar(20)'             , 'not null'      -- 
execute sp_addtype dtchar50,            'varchar(50)'             , 'not null'      -- 

execute sp_addtype dtchar30,         'varchar(30)'     , 'not null'   
execute sp_addtype dtchar3,          'char(3)'         , 'not null'      -- 短值
go

--



use run
go

create default chardft as '0'
go
create default strdft  as ''
go
create default numdft  as 0
go
create default bitdft  as -1
go
create default datedft as convert(int,convert(char(8),getdate(),112))
go
create default timedft as datepart(hour, getdate())*1000000 + datepart(minute ,getdate())*10000 + 
               datepart(second, getdate())*100 + datepart(millisecond,getdate())/10
go

exec sp_bindefault numdft,   'dtcustid'   
exec sp_bindefault numdft,   'dtfundid'   
exec sp_bindefault numdft,   'dtsecuid'   
exec sp_bindefault strdft,   'dtbankid'   
exec sp_bindefault numdft,   'dtstkid'    
exec sp_bindefault strdft,   'dtstkcode'  
exec sp_bindefault strdft,   'dtstkname'   
exec sp_bindefault numdft,   'dtfee'       
exec sp_bindefault strdft,   'dtname'     
exec sp_bindefault numdft,   'dtidno'     
exec sp_bindefault numdft,   'dtamt'      
exec sp_bindefault numdft,   'dtqty'        
exec sp_bindefault chardft,  'dtkind'     
exec sp_bindefault numdft,   'dtprice'    
exec sp_bindefault datedft,  'dtdate'     
exec sp_bindefault timedft,  'dttime'    
exec sp_bindefault strdft,   'dtorgid'    
exec sp_bindefault numdft,   'dtrate'    
exec sp_bindefault numdft,   'dtpercent'  
exec sp_bindefault strdft,   'dtstation' 
exec sp_bindefault strdft,   'dtseat'     
exec sp_bindefault strdft,   'dtorder'    
exec sp_bindefault numdft,   'dtsno'   

exec sp_bindefault strdft,   'dtkinds'    
exec sp_bindefault strdft,   'dtchar32'   
exec sp_bindefault strdft,   'dtchar8'     
exec sp_bindefault strdft,   'dtchar64'     
exec sp_bindefault strdft,   'dtchar16'   
exec sp_bindefault strdft,   'dtchar255'   
exec sp_bindefault strdft,   'dtchar1024'   
exec sp_bindefault strdft,   'dtchar4000' 
exec sp_bindefault strdft,   'dtchar4096'

exec sp_bindefault strdft,   'dtchar2'
exec sp_bindefault strdft,   'dtbranch'
exec sp_bindefault strdft,   'dtchar4'
exec sp_bindefault strdft,   'dtchar6'
exec sp_bindefault strdft,   'dtchar5'
exec sp_bindefault strdft,   'dtchar12'
exec sp_bindefault numdft,   'dtint'  

exec sp_bindefault numdft,   'dtofprice' 
exec sp_bindefault strdft,   'dtoftrdid'
exec sp_bindefault strdft,   'dttaacc'  
exec sp_bindefault strdft,   'dttransacc'
exec sp_bindefault numdft,   'dtyield' 

exec sp_bindefault strdft,   'dtbondacc'

exec sp_bindefault strdft,   'dtchar22'
exec sp_bindefault strdft,   'dtchar9'

exec sp_bindefault strdft,   'dtfeeid'
exec sp_bindefault strdft,   'dtfeekind'
exec sp_bindefault numdft,   'dtctrlvalue' 
go

exec sp_bindefault strdft,   'dtbkno' 
exec sp_bindefault strdft,   'dtbkbrhno' 
exec sp_bindefault strdft,   'dtbksubbrhno' 
exec sp_bindefault strdft,   'dtbknetno' 

--exec sp_bindefault numdft,   'dtkeeprate'  
exec sp_bindefault numdft,   'dtint64'  	
exec sp_bindefault numdft,   'dtstkqty'
exec sp_bindefault numdft,   'dtchar100' 
exec sp_bindefault numdft,   'dtchar20' 
exec sp_bindefault numdft,   'dtchar50'
exec sp_bindefault numdft,   'dtnum208'

exec sp_bindefault strdft,   'dtchar30'
exec sp_bindefault strdft,   'dtchar3'
go
