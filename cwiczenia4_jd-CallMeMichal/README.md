# cwiczenia4_jd-CallMeMichal
cwiczenia4_jd-CallMeMichal created by GitHub Classroom

CREATE TABLE Animal (
    IdAnimal int  NOT NULL IDENTITY,
    Name nvarchar(200)  NOT NULL,
    Description nvarchar(200)  NULL,
    Category nvarchar(200)  NOT NULL,
    Area nvarchar(200)  NOT NULL,
    CONSTRAINT Animal_pk PRIMARY KEY  (IdAnimal)
);



INSERT INTO Animal (Name, Description, Category, Area)
VALUES ('Lion', 'Large carnivorous mammal', 'Mammals', 'Africa');


select * from Animal;

UPDATE Animal
SET column1 = value1, column2 = value2, ...
WHERE condition;

INSERT INTO Animal (Name, Description, Category, Area)
VALUES ('Elephant', 'Large herbivorous mammal with a trunk', 'Mammals', 'Africa');

INSERT INTO Animal (Name, Description, Category, Area)
VALUES ('Tiger', 'Large carnivorous feline', 'Mammals', 'Asia');

INSERT INTO Animal (Name, Description, Category, Area)
VALUES ('Penguin', 'Flightless aquatic bird', 'Birds', 'Antarctica');

INSERT INTO Animal (Name, Description, Category, Area)
VALUES ('Giraffe', 'Tall herbivorous mammal with a long neck', 'Mammals', 'Africa');

INSERT INTO Animal (Name, Description, Category, Area)
VALUES ('Crocodile', 'Large aquatic reptile with a long tail and powerful jaws', 'Reptiles', 'Africa');




INSERT INTO Animal (Name, Description, Category, Area)
VALUES ('Lion', 'Large carnivorous mammal', 'Mammals', 'Africa');



"UPDATE Animal SET Name = animal.Name, Description = ,WHERE condition";
