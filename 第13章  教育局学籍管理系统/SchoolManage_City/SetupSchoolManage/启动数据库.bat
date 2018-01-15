net start SQLAgent$MSDEDH
net start MSSQL$MSDEDH
C:\WINNT\system32\net start SQLAgent$MSDEDH
C:\WINNT\system32\net start MSSQL$MSDEDH
scm -Action 7 -SvcStartType 2 -service SQLAgent$MSDEDH
scm -Action 7 -SvcStartType 2 -service MSSQL$MSDEDH


