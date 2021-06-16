create table evaluacion (
	id int primary key identity,
	fecha_evaluacion date not null,
	resultado_examen_psicologico varchar(1) not null,
	resultado_examen_algoritmos varchar(1) not null,
	resultado_examen_sql varchar(1) not null,
	resultado_final varchar(1) not null
)

create table candidato (
	id int primary key identity,
	id_evaluacion int not null references evaluacion(id),
	nombre varchar(30) not null,
	apellido varchar(30) not null,
	edad int not null,
	fecha_nacimiento Datetime not null,
	cedula varchar(13) unique not null
)
