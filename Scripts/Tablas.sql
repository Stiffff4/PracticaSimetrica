create table evaluacion (
	id int primary key identity,
	id_candidato int not null references candidato(id),
	fecha_evaluacion date not null,
	resultado_examen_psicologico int not null,
	resultado_examen_algoritmos int not null,
	resultado_examen_sql int not null,
	resultado_final int not null
)

create table candidato (
	id int primary key identity,
	nombre varchar(30) not null,
	apellido varchar(30) not null,
	edad int not null,
	fecha_nacimiento Datetime not null,
	cedula varchar(13) unique not null
)
