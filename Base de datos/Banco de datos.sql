create database ProyectoVF;
use ProyectoVF;

-- CREANDO TABLAS
create table TYPE_EMPLOYEE( 
id int PRIMARY KEY,
tipo varchar(50)
);

CREATE TABLE EMPLOYEE(
id int primary key,
name varchar(50),
address varchar(50),
email varchar(50),
password varchar(50),
id_type_employee int
);

create table WORK_SECTOR(
id int primary key,
sector varchar(50)
);

CREATE TABLE CITIZEN(
dui int primary key,
name varchar(50),
age int,
phone int,
email varchar(50),
id_work_sector int,
id_appointment int
);

CREATE TABLE APPOINTMENT(
id int primary key,
dui_citizen int,
id_side_effect VARCHAR(50),
type_dose int
);

create table EMPLOYEEXAPPO(
id_employee int not null,
id_appointment int not null,
constraint PK_emploxappo primary key (id_employee,id_appointment)
);

create table CABIN(
id_cabin int primary key not null,
phone int,
email varchar(50),
id_employee int
);

create table EMPLOYEEXCABIN(
id_employee int,
id_cabin int,
fecha date,
hora time,
constraint PK_empoxcabin primary key (id_employee,id_cabin)
);

CREATE TABLE VACCINATION(
id int primary key not null,
dui_citizen int,
fecha date,
id_appointment int
);

CREATE TABLE SIDE_EFFECT(
id int primary key,
disease varchar(50)
);

CREATE TABLE EFFECTXVACUNNAION(
id_side int,
id_vaci int,
constraint PK_sidexvaci primary key (id_side,id_vaci)
);


-- AGREGANDO CLAVES FORANEAS
alter table EMPLOYEE
add constraint FK_Emxtype
foreign key (id_type_employee) references TYPE_EMPLOYEE (id);

alter table CITIZEN
ADD constraint fk_Cityxsector
foreign key (id_work_sector) references WORK_SECTOR (id);

alter table APPOINTMENT
add constraint FK_apoxcity
foreign key (dui_citizen) references CITIZEN (dui);

alter table EMPLOYEEXAPPO
ADD CONSTRAINT FKemploxid
foreign key (id_employee) references EMPLOYEE (id);

alter table EMPLOYEEXAPPO
ADD CONSTRAINT FK_appoxid
foreign key (id_appointment) references APPOINTMENT (id);

alter table EMPLOYEEXCABIN
add constraint FK_empox
foreign key (id_employee) references EMPLOYEE (id);
 
alter table EMPLOYEEXCABIN
ADD constraint FK_empoxcabin
foreign key (id_cabin) references CABIN (id_cabin);

alter table VACCINATION
ADD CONSTRAINT FK_Vacixdui
foreign key (dui_citizen) references APPOINTMENT (dui_citizen);

alter table VACCINATION
add constraint FK_Vacixapo
foreign key (id_appointment) references APPOINTMENT (id);

alter table EFFECTXVACUNNAION
ADD CONSTRAINT FK_efecxvacu
foreign key (id_vaci) references VACCINATION (id);

alter table EFFECTXVACUNNAION
ADD constraint FK_sidexvacci
foreign key (id_side) references SIDE_EFFECT (id);

-- AGREGANDO DATOS
INSERT INTO TYPE_EMPLOYEE VALUES(1,'Administrador');
INSERT INTO TYPE_EMPLOYEE VALUES(2,'Gestor');
INSERT INTO TYPE_EMPLOYEE VALUES(3,'Doctor');
INSERT INTO TYPE_EMPLOYEE VALUES(4,'Enfermero/a');

INSERT INTO EMPLOYEE VALUES(1,'Alfredo Ramos','Colonia Santa Catalina','alfredor@gmail.com','ucasv123',1);
INSERT INTO EMPLOYEE VALUES(2,'Rosa Melgar','Colonia Teresa','rosamelg@hotmail.com','kifw4',2);
INSERT INTO EMPLOYEE VALUES(3,'Ricardo Moran','Colonia Miramonte','rmoran@gmail.com','apbxa',3);
INSERT INTO EMPLOYEE VALUES(4,'Alejandro Rodríguez','San Jacinto','aleRo@hotmail.com','thznx',4);
INSERT INTO EMPLOYEE VALUES(5,'Roberto López','Nuevo Cuscatlán','rosamelg@hotmail.com','da37w',4);
INSERT INTO EMPLOYEE VALUES(6,'Miguel Romero','Lomas de San Francisco','rosamelg@hotmail.com','xvdaq',2);
INSERT INTO EMPLOYEE VALUES(7,'Daniel García','Mejicanos','rosamelg@hotmail.com','8ydj5',3);
INSERT INTO EMPLOYEE VALUES(8,'Jesús Sosa','Colonia Teresa','rosamelg@hotmail.com','wqcb8',4);
INSERT INTO EMPLOYEE VALUES(9,'Monica Muñoz','Nuevo Cuscatlán','rosamelg@hotmail.com','cx5wb',4);
INSERT INTO EMPLOYEE VALUES(10,'Eva Martínez','Colonia Teresa','rosamelg@hotmail.com','t7cx7',2);
INSERT INTO EMPLOYEE VALUES(11,'Claudia Torres','San Jacinto','rosamelg@hotmail.com','qhzbw',3);
INSERT INTO EMPLOYEE VALUES(12,'Ines Melgar','Mejicanos','rosamelg@hotmail.com','q95jd',4);
INSERT INTO EMPLOYEE VALUES(13,'Eva  Melgar','Lomas de San Francisco','rosamelg@hotmail.com','e9qzp',4);

INSERT INTO CABIN VALUES(1,22053478 ,'Cabina1@uca.sv',2);
INSERT INTO CABIN VALUES(2,22678234 ,'Cabina2@uca.sv',6);
INSERT INTO CABIN VALUES(3,26793341 ,'Cabina3@uca.sv',10);

INSERT INTO WORK_SECTOR VALUES (1,'PNC');
INSERT INTO WORK_SECTOR VALUES (2,'Fuerza Armada');
INSERT INTO WORK_SECTOR VALUES (3,'Cuerpos de Socorro');
INSERT INTO WORK_SECTOR VALUES (4,'Fronteras');
INSERT INTO WORK_SECTOR VALUES (5,'Centros Penales');
INSERT INTO WORK_SECTOR VALUES (6,'Ninguno.');

INSERT INTO SIDE_EFFECT VALUES(1,'Dolor en el area vacunada');
INSERT INTO SIDE_EFFECT VALUES(2,'Enrojecimiento');
INSERT INTO SIDE_EFFECT VALUES(3,'Fatiga');
INSERT INTO SIDE_EFFECT VALUES(4,'Dolor de cabeza');
INSERT INTO SIDE_EFFECT VALUES(5,'Fiebre');
INSERT INTO SIDE_EFFECT VALUES(6,'Mialgia');
INSERT INTO SIDE_EFFECT VALUES(7,'Artralgia');
INSERT INTO SIDE_EFFECT VALUES(8,'Anafilaxia');

SELECT * FROM TYPE_EMPLOYEE;
SELECT * FROM EMPLOYEE;
SELECT * FROM CABIN;
SELECT * FROM WORK_SECTOR;
SELECT * FROM SIDE_EFFECT;
SELECT * FROM CITIZEN;