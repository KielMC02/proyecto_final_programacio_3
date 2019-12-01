/*Creacion de la Base de datos*/
create database HUMAN_RESOURCES
use HUMAN_RESOURCES
GO
/**************Creacion de Entindades *****************/
/*-------------Creacion tabla cargos 1-----------*/

create table DEPARTAMENTOS
(
	id_departamento int identity(1,1) primary key,
	nombre_departamento varchar(30) not null,
)

/*------------Insertar Registros-------------------*/
insert into DEPARTAMENTOS values('HELP DESK TI')
insert into DEPARTAMENTOS values('Atencion al Cliente')
insert into DEPARTAMENTOS values('Estadisticas y Metricas')
insert into DEPARTAMENTOS values('Telemercadeo y Ventas')
insert into DEPARTAMENTOS values('Recursos Humanos')
/*------------------------------------------------*/

/*-------------Creacion tabla cargos 2-----------*/
create table CARGOS
(
	id_cargo int identity(1,1) primary key,
	nombre_cargo varchar(30) not null
)
/*------------Insertar Registros-------------------*/
/*--HELP DESK TI-*/
insert into CARGOS values('Analistas de nivel 1')
insert into CARGOS values('Analistas de nivel 2')
insert into CARGOS values('Controladores de incidentes')
/*-Estadisticas y Metricas-*/
insert into CARGOS values('Analista de Ausentismo')
insert into CARGOS values('Analista de Metricas')
/*--Atencion al Cliente--*/
insert into CARGOS values('Cajero')
/*Telemercadeo y Ventas*/
insert into CARGOS values('Representante de Ventas')
/*Recursos Humanos*/
insert into CARGOS values('Analista de Recursos Humanos')
insert into CARGOS values('Reclutador')
insert into CARGOS values('Encargado de Pruebas de Ingreso')
/*Generales*/
insert into CARGOS values('Supervisor')
insert into CARGOS values('Entrenador')
/*--Atencion al Cliente--*/
insert into CARGOS values('Representante Atencion Cliente')

SELECT * FROM CARGOS
/*------------------------------------------------*/

/*-------------Creacion tabla SALIDAS_EMPLEADOS 4-----------*/
create table SALIDA_EMPLEADOS
(
	id_salida_empleado int identity(1,1) primary key,
	id_emplado int not null,
	tipo_salida varchar(10) not null
)
Alter table SALIDA_EMPLEADOS
add feha_salida date not null
/*------------Insertar Registros-------------------*/
/*------------------------------------------------*/

/*-------------Creacion tabla EMPLEADOS-----------*/
create table EMPLEADOS
( 
	id_empleado int identity(1,1) primary key,
	nombre varchar(25) not null,
	apellido varchar(25) not null,
	telefono varchar(12) not null,
	id_departamento int not null,
	id_cargo int not null,
	fecha_ingreso date not null,
	salario decimal not null,
	estatus varchar(10) not null default('Activo'),
	id_salida_empleado int null
)
/*Estatus*/
Alter table EMPLEADOS
add constraint CK_EMPLEADOS_ESTATUS
check(estatus in('ACTIVO','INACTIVO'))
/*Agregando llaves Foreneas (foreign key)*/
alter table EMPLEADOS
add constraint  FK_DEPARTAMENTO_EMPLEADOS foreign key (id_departamento) references DEPARTAMENTOS(id_departamento)
/*----------------------------*/
alter table EMPLEADOS
add constraint FK_CARGO_EMPLEADOS foreign key (id_cargo) references CARGOS(id_cargo)
/*----------------------------*/
alter table EMPLEADOS
add constraint FK_SALIDA_EMPLEADOS foreign key (id_salida_empleado) references SALIDA_EMPLEADOS(id_salida_empleado)
/*------------Insertar Registros-------------------*/
/*--HELP DESK TI-*/
insert into EMPLEADOS values ('Ewin','Mendez','849-276-5378',1,2,'02/01/2018',27000.0,('Activo'),null)
/*-Estadisticas y Metricas-*/
insert into EMPLEADOS values('Raymond','Pena','829-126-8528',3,5,'09/15/2018',22000.0,('Activo'),null)
/*Telemercadeo y Ventas*/
insert into EMPLEADOS values('Janil','Pimentel','849-457-8528',4,8,'08/15/2015',18000.0,('Activo'),null)
/*Recursos Humanos*/
insert into EMPLEADOS values('Carlos','Rodriguez','809-789-4125',5,9,'03/20/2016',22000.0,('Activo'),null)
/*Generales*/
insert into EMPLEADOS values('Daniel','Martinez','809-125-7852',1,12,'10/30/2010',40000.0,('Activo'),null)
/*--Atencion al Cliente--*/
insert into EMPLEADOS values('Nataly','Beliard','809-456-8578',2,15,'01/20/2016',19000.0,('Activo'),null)
select * from EMPLEADOS
/*------------------------------------------------*/


/*-------------Creacion tabla PERMISOS 5-----------*/
create table PERMISOS
(
	id_permiso int identity(1,1) primary key,
	id_empleado int not null,
	fecha_inicio_permiso date not null,
	fecha_fin_permiso date not null,
	comentario_permiso varchar(250) not null,

)
alter table PERMISOS
add constraint FK_PERMISOS_EMPLEADOS foreign key (id_empleado) references EMPLEADOS(id_empleado)
/*------------Insertar Registros-------------------*/
/*------------------------------------------------*/
/*-------------Creacion de tabla VACACIONES 6-----------*/
Create table VACACIONES
(
	id_vacaciones int identity(1,1) primary key ,
	id_empleado int not null,
	fecha_inicio_vacaciones date not null,
	fecha_fin_vaciones date not null,
	comentario_vacaiones varchar(250) not null
)
alter table VACACIONES
add constraint FK_VACACIONES_EMPLEADOS foreign key (id_empleado) references EMPLEADOS(id_empleado)
/*------------Insertar Registros-------------------*/
/*------------------------------------------------*/

/*-------------Creacion de tabla LICENCIAS 7-----------*/
create table LICENCIAS
(
	id_licencia int identity(1,1) primary key, 
	id_empleado int not null,
	fecha_inicio_licencia date default(getdate()),
	fecha_fin_licencia date not null,
	motivo_licencia varchar(30) not null,
	comentario_varchar varchar(250) not null
)
alter table LICENCIAS
add constraint FK_LICENCIAS_EMPLEADOS foreign key (id_empleado) references EMPLEADOS(id_empleado)
/*------------Insertar Registros-------------------*/
/*------------------------------------------------*/

/*-------------Creacion de tabla NOMINAS 8-----------*/
create table NOMINAS
(
	id_codigo int identity(1,1)primary key not null,
	fecha_nomina date default(getdate()) not null,
	monto_total decimal not null
)