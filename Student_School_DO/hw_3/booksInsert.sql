CREATE TABLE books
(
	id_book uniqueidentifier PRIMARY KEY,
	nameBook nchar(100) NOT NULL,
	author nchar(100) NOT NULL,
	fk_id_genre int REFERENCES genre_type(id_genre),
	collateralValue INT NOT NULL,
	rentalCost INT NOT NULL,
	countBook INT NOT NULL
);

INSERT INTO books 
	VALUES 
		('D8A661A8-2F91-46B1-A32E-5192F1D104E4','Generation_«P»','Victor_Pelevin',2,600,60,0),
		('DE8DFCAD-7B05-4B04-A88E-7EB03F4CB708','Crime_and_Punishment','Fedor_Dostoevsky',1,600,50,8),
		('8C8D269D-F54D-4339-8A82-38DF8C748DA8','The_first_scientific_history_of_the_war_of_1812','Evgeniy_Ponasenkov',9,1000,100,0),
		('C988E38F-4809-4A3F-BB44-1FA4E4FC61AB','We','Evgeniy_Zamyatin',5,500,100,8),
		('76705115-2FA2-4645-AD5E-62DD2D350E8E','Roadside_Picnic','Strugatsky_brothers',2,500,60,6),
		('06D5D032-6563-4C14-ADCC-C1918BAA2A8F','The_Master_and_Margarita','Mikhail_Bulgakov',1,500,40,14),
		('5504B5AC-5060-42F6-A219-5D505A425ECA','Don_Quixote','Miguel_Cervantes',7,500,50,4),
		('A3F56CDD-6699-4F6F-B18E-C89310BCE58C','Alice''s_adventures_in_Wonderland','Lewis_Carrol',21,400,40,4),
		('5DA9E7EC-00C6-4D5E-93AA-B2F022257629','Dead_souls','Nikolai_Gogol',1,400,30,0);
