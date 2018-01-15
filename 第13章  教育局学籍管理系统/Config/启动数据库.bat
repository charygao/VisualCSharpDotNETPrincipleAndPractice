C:\WINNT\system32\net start SQLAgent$MSDEDH
C:\WINNT\system32\net start MSSQL$MSDEDH

scm -Action 7 -SvcStartType 2 -service SQLAgent$MSDEDH
scm -Action 7 -SvcStartType 2 -service MSSQL$MSDEDH
osql -S dh\MSDEDH -U sa -P dhsa. -i 'C:\Program Files\zzti\SetupSchoolManage\Restore.txt'

