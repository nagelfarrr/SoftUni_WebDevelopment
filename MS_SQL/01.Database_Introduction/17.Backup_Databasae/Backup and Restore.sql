USE [master]

BACKUP DATABASE [SoftUni]
	TO DISK = N'D:\SoftUni\MS_SQL\01.Database_Introduction\17.Backup_Databasae\softuni-backup.bak' 

GO

DROP DATABASE [SoftUni]

RESTORE DATABASE [SoftUni] 
    FROM DISK = N'D:\SoftUni\MS_SQL\01.Database_Introduction\17.Backup_Databasae\softuni-backup.bak'