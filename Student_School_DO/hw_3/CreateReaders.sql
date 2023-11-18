USE [LibraryDB]
GO

/****** Object:  Table [dbo].[readers]    Script Date: 04.11.2023 13:34:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[readers](
	[id_reader] [uniqueidentifier] NOT NULL,
	[lastName] [nchar](50) NOT NULL,
	[firstName] [nchar](50) NOT NULL,
	[patronymic] [nchar](80) NOT NULL,
	[fk_id_category] [int] NOT NULL,
	[adress] [text] NOT NULL,
	[email] [nchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_reader] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[readers]  WITH CHECK ADD FOREIGN KEY([fk_id_category])
REFERENCES [dbo].[categories] ([id_category])
GO

INSERT INTO readers (id_reader,  lastName,  firstName,  patronymic,  fk_id_category,  adress,  email)
	VALUES 
		('92DAC638-2A79-4870-8745-2B6DF879214E',  'Ruleeva', 'Ksenia','Dmytrievna',5, 'line_13_of_Vasilyevsky_island,h_32,ap_4', 'ksenia23@mail.ru'),
		('2BA1B6B9-B3A2-4DF8-A066-8C8C436936FF',  'Rybina', 'Maria','Sergeevna', 1, 'Valeria_Gavrilin_st,h_7,ap_258',  'xxxmaria@.gmail.com'),                             
		('897FF5B1-78FA-4B31-B200-99329E78CB8C',  'Yashchenko', 'Alexandra','Ivanovna', 2, 'Novocherkassky_pr-kt,h_24,ap_16',  'yashhenko.yulechka1977@gmail.com'),                  
		('10D63457-4338-408E-892B-A1B6675051A8',  'Matveev', 'Yaroslav','Gennadievych', 2, 'Bogatyrsky_pr-kt,h_27,ap_3', 'yaroslav.mat1001@mail.ru'),                         
		('9509849F-C97B-4F92-9688-E9EC01730E2D',  'Isakov', 'Viktor','Ivanovich', 4, 'Bolshaya_Morskaya_st,h_67,ap_1', 'ivi@guap.ru');


