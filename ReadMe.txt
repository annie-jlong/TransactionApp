Add Nuget Package
1. CsvHelper	
2. Microsoft.Entityframeworkcore.sqlserver

Install sql server docker:

download and run docker image for sql server as below:
 
sudo docker pull mcr.microsoft.com/mssql/server:2017-latest
sudo docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=abcd@123" -p 1433:1433 --name sql1 -h sql1 -d mcr.microsoft.com/mssql/server:2017-latest
sudo docker exec -it sql1 "bash"
/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "abcd@123"

database script: 
Create database TransactionDB
Use TransactionDB
Create Table [Transaction] (TransactionIdentificator VARCHAR(50) not null Primary Key, Amount decimal, CurrencyCode VARCHAR(10), TransactionDate datetime, Status Int)


