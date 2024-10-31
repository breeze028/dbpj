ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `Classes` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Dept` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Grade` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
    `HeadTeacher` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Monitor` int NULL,
    `CreateTime` datetime(6) NOT NULL,
    `CreateUser` int NOT NULL,
    `LastEditTime` datetime(6) NOT NULL,
    `LastEditUser` int NOT NULL,
    CONSTRAINT `PK_Classes` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Courses` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Teacher` longtext CHARACTER SET utf8mb4 NOT NULL,
    `CreateTime` datetime(6) NOT NULL,
    `CreateUser` int NOT NULL,
    `LastEditTime` datetime(6) NOT NULL,
    `LastEditUser` int NOT NULL,
    CONSTRAINT `PK_Courses` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Menus` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Description` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Url` longtext CHARACTER SET utf8mb4 NULL,
    `Icon` longtext CHARACTER SET utf8mb4 NULL,
    `ParentId` int NULL,
    `SortId` int NULL,
    CONSTRAINT `PK_Menus` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `RoleMenus` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `MenuId` int NOT NULL,
    `RoleId` int NOT NULL,
    CONSTRAINT `PK_RoleMenus` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Roles` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Description` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_Roles` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Scores` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `StudentId` int NOT NULL,
    `CourseId` int NOT NULL,
    `Score` double NOT NULL,
    `CreateTime` datetime(6) NOT NULL,
    `CreateUser` int NOT NULL,
    `LastEditTime` datetime(6) NOT NULL,
    `LastEditUser` int NOT NULL,
    CONSTRAINT `PK_Scores` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Students` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `No` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Age` int NOT NULL,
    `Sex` tinyint(1) NOT NULL,
    `ClassesId` int NULL,
    `CreateTime` datetime(6) NULL,
    `CreateUser` int NULL,
    `LastEditTime` datetime(6) NULL,
    `LastEditUser` int NULL,
    CONSTRAINT `PK_Students` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `UserRoles` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `UserId` int NOT NULL,
    `RoleId` int NOT NULL,
    CONSTRAINT `PK_UserRoles` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Users` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `UserName` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Password` longtext CHARACTER SET utf8mb4 NOT NULL,
    `NickName` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_Users` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

COMMIT;

