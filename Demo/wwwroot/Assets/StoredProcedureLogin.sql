/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [CustomerId]
      ,[UserName]
      ,[Password]
      ,[LastLoginDate]
      ,[LoginFailedCount]
      ,[AccountLocked]
  FROM [Demo].[dbo].[DemoLoginInfo]

  delete  from DemoLoginInfo where CustomerId > 0

