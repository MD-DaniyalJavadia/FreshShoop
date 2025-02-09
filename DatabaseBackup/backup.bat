@echo off
SET db_name=ShopApp              
SET db_user=Daniyal-Lab                 
SET db_password=daniyal-lab      
SET backup_path=E:\FreshShop\FreshShoop\DatabaseBackup\ShopApp_Backup.bak  
SET server_name=DESKTOP-8BGG873\SQLEXPRESS  

REM -- Backup ka SQL command
sqlcmd -S %server_name% -U %db_user% -P %db_password% -Q "BACKUP DATABASE [%db_name%] TO DISK='%backup_path%'"

REM -- Backup complete hone par message
echo Bhai Backup completed successfully!
pause
