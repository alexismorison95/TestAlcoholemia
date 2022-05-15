--create database alcoholemia;

------------------------------------------------------------------------------------------ TABLAS

CREATE TABLE TipoUsuario (
	id SERIAL PRIMARY KEY,
	tipo VARCHAR NOT NULL UNIQUE--administrador,administrativo,examinador
);


CREATE TABLE Usuario (
	nombreUsuario VARCHAR PRIMARY KEY,
	activo BOOLEAN NOT NULL,
	nombreReal VARCHAR NOT NULL,
	contrasenia VARCHAR NOT NULL,
	tipoUsuarioId INT REFERENCES TipoUsuario(Id)	
);



CREATE TABLE Conductor (
	DNI VARCHAR PRIMARY KEY,
	nombre VARCHAR NOT NULL,
	apellido VARCHAR NOT NULL
);

CREATE TABLE Dominio (
	patente VARCHAR PRIMARY KEY,
	descripcion VARCHAR NOT NULL
);

CREATE TABLE Examinador (
	id SERIAL PRIMARY KEY,
	activo BOOLEAN,
	usuarioNombre VARCHAR UNIQUE REFERENCES Usuario(nombreUsuario) 
);

CREATE TABLE Equipo (
	id SERIAL PRIMARY KEY,  --autoincremental
	nombre VARCHAR UNIQUE NOT NULL, --el impreso en el equipo
	activo BOOLEAN, --activo o no pra el uso
	nroActual INT --numero de muestra actual
);

CREATE TABLE PeriodoUtilizable (
	id SERIAL PRIMARY KEY,
	activo BOOLEAN, --el vigente o no
	fechaInicio DATE NOT NULL,
	fechaVencimiento DATE NOT NULL,
	nroIngreso INT NOT NULL, --1er numero a usar 
	equipoId INT REFERENCES Equipo(Id)
);

CREATE TABLE Prestamo (
	id SERIAL PRIMARY KEY,
	activo BOOLEAN, --prestado o no
	fechaPrestamo DATE NOT NULL,
	horaPrestamo TIME NOT NULL,
	nroInicial INT NOT NULL, --1er numero a usar ?
	fechaDevolucion DATE,
	horaDevolucion TIME,
	nroDevolucion INT, --ultimo numero usado ?
	examinadorId INT REFERENCES Examinador(Id),
	equipoId INT REFERENCES Equipo(Id)
);

CREATE TABLE Prueba (
	id SERIAL PRIMARY KEY,
	fecha DATE NOT NULL,
	hora TIME NOT NULL,
	nroMuestra INT NOT NULL, --???
	resultado FLOAT NOT NULL check(resultado >= 0.0),
	nroActa INT,
	nroRetencion INT,
	verificado BOOLEAN,
	rechazado BOOLEAN,
	descripcionRechazo VARCHAR,
	verificadorNombre VARCHAR REFERENCES Usuario(nombreUsuario),
	conductorDNI VARCHAR REFERENCES Conductor(DNI),
	dominioId VARCHAR REFERENCES Dominio(Patente),
	prestamoId INT REFERENCES Prestamo(Id)
);


---------------------------------------------------------------- TABLA PARA ADMINISTRAR SESIONES ACTIVAS SW
/*
CREATE TABLE Sesion (
	"sid" VARCHAR NOT NULL COLLATE "default",
	"sess" json NOT NULL,
	"expire" TIMEstamp(6) NOT NULL
)
WITH (OIDS=FALSE);
ALTER TABLE Sesion ADD CONSTRAINT "session_pkey" PRIMARY KEY ("sid") NOT DEFERRABLE INITIALLY IMMEDIATE;
*/