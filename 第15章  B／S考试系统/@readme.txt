System.Runtime.InteropServices.COMException的解决方法-

完美解决“换另一台电脑上用VS2008继续开发web项目时出现“System.Runtime.InteropServices.COMException”，然后是加载不了项目。” 
-完美解决“换另一台电脑上用VS2008继续开发web项目时出现 

“System.Runtime.InteropServices.COMException”，然后是加载不了项目。” 
只需要打开项目配置文件*.csproj,将<UseIIS>True</UseIIS> 改为 False，然后可以正常加载项目，接着重新配置为正常的IIS. 


详细出处参考：http://www.jb51.net/article/17629.htm