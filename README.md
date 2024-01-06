Run Instructions. <br />

1)Download project <br />
2)Open CardCome/Api/WebApi directory -> open file appsettings.json and change connection string for your DB<br />
3)Open comand line in CardCome/Dal and run update-databese EF Core command -> Users table was added to your DB<br/>
4)Install Node.js and angular-cli for run client side <br />
5)Open CardCome folder and run "npm install" using comand line or PowerShell -> node modules installed <br />
6)Open CardCome.sln with Visual Studio and run server side<br />
7)If project run of difference port (5227,7022) then copy the localhost:(yourport) and config proxy.conf.json<br />
8)Go to CardCome/proxy.conf.json and replace your url with old url <br />
(This very important because angularjs run on port 4200 and api run on different port -> "CorsPlatform") <br />
9)Open comand line/ powershell in Client directory and run "npm start" -> project and proxy was started <br />
10)Open browser and paste  http://localhost:4200 -> project run <br />

If something is not clear please call me.
