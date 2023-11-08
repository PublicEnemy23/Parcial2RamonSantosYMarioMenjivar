Create DataBase BDParcial2MarioMenjivarRamonSantos;

use BDParcial2MarioMenjivarRamonSantos;

create table Departamentos(
IdDepartamento int primary key identity (1,1) not null,
NombreDepartamento varchar(50) not null
);

insert into Departamentos(NombreDepartamento) values ('Chalatenango'),('San Salvador'),('San Vicente'),('Santa Ana');

select * from Departamentos;

create table Municipios(
IdMunicipio int primary key identity (1,1) not null,
NombreMunicipio varchar(50) not null,
IdDepartamento int not null,
constraint FK_Municipios_Departamentos_id foreign key (IdDepartamento) references Departamentos (IdDepartamento)
);


insert into Municipios (NombreMunicipio,IdDepartamento) values ('Comalapa',1),('Dulce Nombre de Maria',1),('Chalatenango',1),('La Laguna',1);
insert into Municipios (NombreMunicipio,IdDepartamento) values ('Antiguo Cuscatlan',2),('Santa Tecla',2),('Apopa',2),('Cuscatancingo',2);
insert into Municipios (NombreMunicipio,IdDepartamento) values ('San Sebastian',3),('San Vicente',3),('Apastepeque',3),('San Lorenzo',3);
insert into Municipios (NombreMunicipio,IdDepartamento) values ('Chalchuapa',4),('Texistepeque',4),('Metapan',4),('Cojutepeque',4);



select * from Municipios;



create table Clientes(
IdCliente int primary key identity (1,1) not null,
Nombre varchar(50) not null,
Apellido varchar(50) not null,
IdDepartamento int not null,
IdMunicipio int not null,
constraint FK_Clientes_Departamentos_id foreign key (IdDepartamento) references Departamentos (IdDepartamento),
constraint FK_Clientes_Municipios_id foreign key (IdMunicipio) references Municipios (IdMunicipio)
);

insert into Clientes(Nombre,Apellido,IdDepartamento,IdMunicipio)
values('Mario','Menjivar',1,3),('Ramon','Santos',1,4);

select * from Clientes;