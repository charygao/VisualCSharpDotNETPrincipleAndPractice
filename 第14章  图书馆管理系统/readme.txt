                                                安装及使用须知

1、数据库安装

    本安装说明是以Microsoft SQL Server 2000中文企业版为例来阐述的，对于Microsoft SQL Server其他版本，
应用程序数据库的安装方法是类似的。 将本文件夹中的DataBase目录下的两个文件LibraryManagment.MDF和
LibraryManagment_log.LDF复制到系统盘的 \Program Files\Microsoft SQL Server\MSSQL\Data目录下。
打开SQL Server Enterprise Manager，展开Microsoft SQL Servers树状菜单，右击“数据库”子项，
在弹出菜单的“所有任务”中选择“附加数据库”命令，按提示给出 \Program Files\Microsoft SQL Server\MSSQL\Data 
目录下的LibraryManagment.MDF路径。
    
3、本程序开发时连接的数据库服务器是本地（local），而且能够以Windows集成安全方式访问。

4、如果用户安装的是Microsoft Visual Studio .NET 2003，那么可以直接打开Library文件夹下的项目，查看代码并进行调试。

5、由于此实例的数据库连接都是手动连接，所以读者要根据自己服务器具体地址设置SqlConnection的ConnectionString属性，
而且按照图书介绍重新为控件绑定数据集。

6、本程序登录前请查看数据库中的user数据表中的数据，登录时的用户验证取自本数据表。
