﻿CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY,
    UserName NVARCHAR(100),
    Email NVARCHAR(100),
    Role NVARCHAR(50),
    Phone NVARCHAR(20),
    Address NVARCHAR(255)
);
