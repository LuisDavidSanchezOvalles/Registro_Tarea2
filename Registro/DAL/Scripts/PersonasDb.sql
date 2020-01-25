Create DataBase PersonasDb
go

use PersonasDb
go

create Table Personas
(
Id int identity primary key,
Nombre varchar(30),
Telefono varchar(13),
Cedula varchar(13),
Direccion varchar(max)
);

select * from Personas;