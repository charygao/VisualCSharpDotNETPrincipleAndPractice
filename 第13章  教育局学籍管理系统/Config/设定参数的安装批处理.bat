setup /settings "MyParameters.ini" SAPWD="dhsa."
net start SQLAgent$DH
net start MSSQL$DH
scm -Action 7 -SvcStartType 2 -service SQLAgent$DH
scm -Action 7 -SvcStartType 2 -service MSSQL$DH