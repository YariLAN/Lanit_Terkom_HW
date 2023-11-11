CREATE TABLE categories
(
	id_category INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	name nchar(50) NOT NULL
);

INSERT INTO categories
	VALUES
		('schoolboy'),
		('student'),
		('professor'),
		('graduate_student'),
		('pensioner'),
		('teacher'),
		('benefit_recipient');