ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE Classes (
    Id int NOT NULL AUTO_INCREMENT,
    Dept longtext CHARACTER SET utf8mb4 NOT NULL,
    Grade longtext CHARACTER SET utf8mb4 NOT NULL,
    Name longtext CHARACTER SET utf8mb4 NOT NULL,
    HeadTeacher longtext CHARACTER SET utf8mb4 NOT NULL,
    Monitor int NULL,
    CreateTime datetime(6) NOT NULL,
    CreateUser int NOT NULL,
    LastEditTime datetime(6) NOT NULL,
    LastEditUser int NOT NULL,
    CONSTRAINT PK_Classes PRIMARY KEY (Id)
) CHARACTER SET=utf8mb4;

CREATE TABLE Courses (
    Id int NOT NULL AUTO_INCREMENT,
    Name longtext CHARACTER SET utf8mb4 NOT NULL,
    Teacher longtext CHARACTER SET utf8mb4 NOT NULL,
    CreateTime datetime(6) NOT NULL,
    CreateUser int NOT NULL,
    LastEditTime datetime(6) NOT NULL,
    LastEditUser int NOT NULL,
    CONSTRAINT PK_Courses PRIMARY KEY (Id)
) CHARACTER SET=utf8mb4;

CREATE TABLE Menus (
    Id int NOT NULL AUTO_INCREMENT,
    Name longtext CHARACTER SET utf8mb4 NOT NULL,
    Description longtext CHARACTER SET utf8mb4 NOT NULL,
    Url longtext CHARACTER SET utf8mb4 NULL,
    Icon longtext CHARACTER SET utf8mb4 NULL,
    ParentId int NULL,
    SortId int NULL,
    CONSTRAINT PK_Menus PRIMARY KEY (Id)
) CHARACTER SET=utf8mb4;

CREATE TABLE RoleMenus (
    Id int NOT NULL AUTO_INCREMENT,
    MenuId int NOT NULL,
    RoleId int NOT NULL,
    CONSTRAINT PK_RoleMenus PRIMARY KEY (Id)
) CHARACTER SET=utf8mb4;

CREATE TABLE Roles (
    Id int NOT NULL AUTO_INCREMENT,
    Name longtext CHARACTER SET utf8mb4 NOT NULL,
    Description longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT PK_Roles PRIMARY KEY (Id)
) CHARACTER SET=utf8mb4;

CREATE TABLE Scores (
    Id int NOT NULL AUTO_INCREMENT,
    StudentId int NOT NULL,
    CourseId int NOT NULL,
    Score double NOT NULL,
    CreateTime datetime(6) NOT NULL,
    CreateUser int NOT NULL,
    LastEditTime datetime(6) NOT NULL,
    LastEditUser int NOT NULL,
    CONSTRAINT PK_Scores PRIMARY KEY (Id)
) CHARACTER SET=utf8mb4;

CREATE TABLE Students (
    Id int NOT NULL AUTO_INCREMENT,
    No longtext CHARACTER SET utf8mb4 NOT NULL,
    Name longtext CHARACTER SET utf8mb4 NOT NULL,
    Age int NOT NULL,
    Sex tinyint(1) NOT NULL,
    ClassesId int NULL,
    CreateTime datetime(6) NULL,
    CreateUser int NULL,
    LastEditTime datetime(6) NULL,
    LastEditUser int NULL,
    CONSTRAINT PK_Students PRIMARY KEY (Id)
) CHARACTER SET=utf8mb4;

CREATE TABLE UserRoles (
    Id int NOT NULL AUTO_INCREMENT,
    UserId int NOT NULL,
    RoleId int NOT NULL,
    CONSTRAINT PK_UserRoles PRIMARY KEY (Id)
) CHARACTER SET=utf8mb4;

CREATE TABLE Users (
    Id int NOT NULL AUTO_INCREMENT,
    UserName longtext CHARACTER SET utf8mb4 NOT NULL,
    Password longtext CHARACTER SET utf8mb4 NOT NULL,
    NickName longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT PK_Users PRIMARY KEY (Id)
) CHARACTER SET=utf8mb4;

SET NAMES 'utf8mb4';

INSERT INTO Users (Id, UserName, Password, NickName) VALUES
(1, 'Admin', 'abc123', 'Admin'),
(2, 'Alan', '123456', 'Alan');

INSERT INTO UserRoles (Id, UserId, RoleId) VALUES
(1, 1, 1),
(2, 2, 1);

INSERT INTO Roles (Id, Name, Description) VALUES
(1, '系统管理员', '系统管理员'),
(2, '学生', '学生'),
(3, '班长', '班长');

INSERT INTO RoleMenus (Id, RoleId, MenuId) VALUES
(9, 1, 9),
(10, 1, 10),
(11, 1, 11),
(12, 1, 12),
(13, 1, 13),
(14, 1, 14),
(15, 1, 15),
(16, 1, 16),
(17, 1, 17),
(18, 1, 18),
(19, 2, 9),
(20, 2, 10),
(21, 2, 11),
(22, 2, 12),
(23, 2, 13),
(24, 2, 14),
(25, 2, 15);

INSERT INTO Menus (Id, Name, Description, Url, ParentId, SortId, Icon) VALUES
(9, '学生管理', '学生管理', NULL, NULL, 1, NULL),
(10, '学生管理', '学生管理', 'Student', 9, 1, '/images/icon_student.png'),
(11, '班级管理', '班级管理', 'Classes', 9, 2, '/images/icon_classes.png'),
(12, '课程管理', '课程管理', 'Course', 9, 3, '/images/icon_course.png'),
(13, '成绩管理', '成绩管理', 'Score', 9, 4, '/images/icon_score.png'),
(14, '系统管理', '系统管理', NULL, NULL, 2, NULL),
(15, '个人信息', '个人信息', 'Personal', 14, 1, '/images/icon_personal.png'),
(16, '用户管理', '用户管理', 'User', 14, 2, '/images/icon_user.png'),
(17, '角色管理', '角色管理', 'Role', 14, 3, '/images/icon_role.png'),
(18, '菜单管理', '菜单管理', 'Menu', 14, 4, '/images/icon_menu.png');

COMMIT;
