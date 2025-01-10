CREATE TABLE Students (
    StudentID INT PRIMARY KEY IDENTITY(1,1), 
    FirstName NVARCHAR(50) NOT NULL,        
    LastName NVARCHAR(50) NOT NULL,        
    Email NVARCHAR(100) UNIQUE NOT NULL,    
    DateOfBirth DATE,                        
);

INSERT INTO Students (FirstName, LastName, Email, DateOfBirth)
VALUES
('John', 'Doe', 'john.doe@example.com', '2000-01-15'),
('Jane', 'Smith', 'jane.smith@example.com', '1998-05-22'),
('Alex', 'Taylor', 'alex.taylor@example.com', '1999-08-10');

select * from Students

Create table Courses(
	CourseId int Primary key identity(100,1),
	StudentID INT not null,
	CourseName NVARCHAR(50) not null,
	CourseDate Date not null,
	Constraint Fk_Courses_studentid_ref_Student_studentid Foreign key(StudentID) References Students(StudentID) on delete cascade
);

INSERT INTO Courses (StudentID, CourseName, CourseDate)
VALUES
(1, 'Math', '2025-01-01'),
(1, 'History', '2025-01-15'),
(2, 'Science', '2025-01-10'),
(3, 'Art', '2025-01-20');

INSERT INTO Courses (StudentID, CourseName, CourseDate)
VALUES
(5, 'Psychology', '2025-01-01');

truncate table Courses

select * from Courses

select s.FirstName,s.LastName,c.CourseName
from Students s
join Courses c on c.StudentID=s.StudentID

