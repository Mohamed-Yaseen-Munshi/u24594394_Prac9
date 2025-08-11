
	use UnitedGlobalUniversity
	Go

	create table student (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name Varchar(255),
	Age INT,
	Fee Decimal(10,2),
	Club Varchar(255)
	);
	Go

	
	INSERT INTO Student (Name, Age, Fee, Club) VALUES
	('Jon Snow', 24, 300.00, 'Blue Sky'),
	('Eren Yeager', 21, 280.00, 'Rotary'),
	('Hermione Granger', 20, 320.00, 'Red Hat'),
	('Daenerys Targaryen', 23, 350.00, 'Spicy'),
	('Armin Arlert', 19, 260.00, 'Blue Sky'),
	('Tyrion Lannister', 19, 400.00, 'Rotary'),
	('Harry Potter', 22, 310.00, 'Red Hat'),
	('Mikasa Ackerman', 21, 330.00, 'Spicy'),
	('Sansa Stark', 20, 270.00, 'Blue Sky'),
	('Levi Ackerman', 21, 420.00, 'Rotary');
	Go

	DROP TABLE IF EXISTS Student;
GO

CREATE TABLE Student (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(255),
    Age INT,
    Fee DECIMAL(10,2),
    Club VARCHAR(255)
);
GO



	