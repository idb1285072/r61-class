USE [master]
GO
/****** Object:  Database [dbTask]    Script Date: 12/1/2024 10:47:48 AM ******/
CREATE DATABASE [dbTask]

GO
ALTER DATABASE [dbTask] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbTask] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbTask] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbTask] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbTask] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbTask] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbTask] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbTask] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbTask] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbTask] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbTask] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbTask] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbTask] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbTask] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbTask] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbTask] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbTask] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbTask] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbTask] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbTask] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbTask] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbTask] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbTask] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbTask] SET  MULTI_USER 
GO
ALTER DATABASE [dbTask] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbTask] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbTask] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbTask] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbTask] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbTask] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [dbTask] SET QUERY_STORE = ON
GO
ALTER DATABASE [dbTask] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [dbTask]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 12/1/2024 10:47:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [nvarchar](50) NULL,
	[Designation] [nvarchar](50) NULL,
	[JoiningDate] [datetime2](7) NULL,
	[Salary] [money] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 12/1/2024 10:47:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskAssign]    Script Date: 12/1/2024 10:47:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskAssign](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmpId] [int] NULL,
	[TaskId] [int] NULL,
	[AssignDate] [datetime2](7) NULL,
 CONSTRAINT [PK_TaskAssign] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskStatus]    Script Date: 12/1/2024 10:47:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TaskStatus] [varchar](50) NULL,
	[AssignID] [int] NOT NULL,
 CONSTRAINT [PK_TaskStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 
GO
INSERT [dbo].[Employee] ([Id], [EmployeeName], [Designation], [JoiningDate], [Salary]) VALUES (2, N'Payel', N'sr.Programmer', CAST(N'2024-10-22T00:00:00.0000000' AS DateTime2), 25000.0000)
GO
INSERT [dbo].[Employee] ([Id], [EmployeeName], [Designation], [JoiningDate], [Salary]) VALUES (4, N'Kamal', N'Acct', CAST(N'2024-10-06T00:00:00.0000000' AS DateTime2), 50000.0000)
GO
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Task] ON 
GO
INSERT [dbo].[Task] ([Id], [Name], [Description]) VALUES (1, N'CRUD', N'CRUD Operation on TASK Table')
GO
INSERT [dbo].[Task] ([Id], [Name], [Description]) VALUES (2, N'Database Create', N'Database Create')
GO
SET IDENTITY_INSERT [dbo].[Task] OFF
GO
SET IDENTITY_INSERT [dbo].[TaskAssign] ON 
GO
INSERT [dbo].[TaskAssign] ([Id], [EmpId], [TaskId], [AssignDate]) VALUES (1, 2, 1, CAST(N'2024-11-30T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[TaskAssign] ([Id], [EmpId], [TaskId], [AssignDate]) VALUES (2, 4, 1, CAST(N'2024-11-30T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[TaskAssign] ([Id], [EmpId], [TaskId], [AssignDate]) VALUES (5, 2, 1, CAST(N'2024-11-30T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[TaskAssign] ([Id], [EmpId], [TaskId], [AssignDate]) VALUES (6, 2, 1, CAST(N'2024-11-30T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[TaskAssign] ([Id], [EmpId], [TaskId], [AssignDate]) VALUES (7, 2, 1, CAST(N'2024-11-30T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[TaskAssign] ([Id], [EmpId], [TaskId], [AssignDate]) VALUES (8, 2, 1, CAST(N'2024-11-30T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[TaskAssign] ([Id], [EmpId], [TaskId], [AssignDate]) VALUES (9, 2, 1, CAST(N'2024-11-30T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[TaskAssign] ([Id], [EmpId], [TaskId], [AssignDate]) VALUES (10, 4, 1, CAST(N'2024-12-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[TaskAssign] ([Id], [EmpId], [TaskId], [AssignDate]) VALUES (11, 2, 1, CAST(N'2024-11-11T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[TaskAssign] ([Id], [EmpId], [TaskId], [AssignDate]) VALUES (12, 2, 1, CAST(N'2024-11-11T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[TaskAssign] ([Id], [EmpId], [TaskId], [AssignDate]) VALUES (13, 2, 1, CAST(N'2024-11-11T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[TaskAssign] ([Id], [EmpId], [TaskId], [AssignDate]) VALUES (14, 2, 1, CAST(N'2024-11-11T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[TaskAssign] ([Id], [EmpId], [TaskId], [AssignDate]) VALUES (15, 4, 1, CAST(N'2024-12-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[TaskAssign] ([Id], [EmpId], [TaskId], [AssignDate]) VALUES (16, 4, 1, CAST(N'2024-12-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[TaskAssign] ([Id], [EmpId], [TaskId], [AssignDate]) VALUES (17, 4, 1, CAST(N'2024-12-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[TaskAssign] ([Id], [EmpId], [TaskId], [AssignDate]) VALUES (20, 4, 1, CAST(N'2024-12-01T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[TaskAssign] OFF
GO
SET IDENTITY_INSERT [dbo].[TaskStatus] ON 
GO
INSERT [dbo].[TaskStatus] ([Id], [TaskStatus], [AssignID]) VALUES (2, N'pending', 20)
GO
SET IDENTITY_INSERT [dbo].[TaskStatus] OFF
GO
ALTER TABLE [dbo].[TaskAssign]  WITH CHECK ADD  CONSTRAINT [FK_TaskAssign_Employee] FOREIGN KEY([EmpId])
REFERENCES [dbo].[Employee] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TaskAssign] CHECK CONSTRAINT [FK_TaskAssign_Employee]
GO
ALTER TABLE [dbo].[TaskAssign]  WITH CHECK ADD  CONSTRAINT [FK_TaskAssign_Task] FOREIGN KEY([TaskId])
REFERENCES [dbo].[Task] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TaskAssign] CHECK CONSTRAINT [FK_TaskAssign_Task]
GO
ALTER TABLE [dbo].[TaskStatus]  WITH CHECK ADD  CONSTRAINT [FK_TaskStatus_TaskStatus] FOREIGN KEY([AssignID])
REFERENCES [dbo].[TaskAssign] ([Id])
GO
ALTER TABLE [dbo].[TaskStatus] CHECK CONSTRAINT [FK_TaskStatus_TaskStatus]
GO
/****** Object:  StoredProcedure [dbo].[EmployeeAssignment]    Script Date: 12/1/2024 10:47:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Proc [dbo].[EmployeeAssignment]
As
Begin
select EmployeeName,Name,AssignDate,TaskAssign.Id  from Employee

inner join TaskAssign on Employee.Id= TaskAssign.EmpId
inner join Task on Task.Id=TaskAssign.TaskId
End
GO
/****** Object:  StoredProcedure [dbo].[InsertTaskAss]    Script Date: 12/1/2024 10:47:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[InsertTaskAss]
@eid int,@tid int,@d date,@id int out
As
Begin
Insert Into TaskAssign (EmpId,TaskId,AssignDate) values(@eid,@tid,@d)
select @id= @@IDENTITY
print @id
end
GO
USE [master]
GO
ALTER DATABASE [dbTask] SET  READ_WRITE 
GO
