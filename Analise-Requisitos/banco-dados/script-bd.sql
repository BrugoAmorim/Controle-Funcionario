create database bdfuncionario;
use bdfuncionario;

create table tb_estado(
id_estado int primary key auto_increment,
nm_estado varchar(100) not null
);

create table tb_cargo(
id_cargo int primary key auto_increment,
ds_cargo varchar(100) not null,
vl_salario decimal(15,2) not null,
hr_entrada time not null,
hr_saida time not null
);

create table tb_funcionario(
id_funcionario int primary key auto_increment,
nm_funcionario varchar(100) not null,
ds_rg varchar(12) not null,
ds_cpf varchar(12) not null,
ds_telefone varchar(8),
ds_celular varchar(12),
dt_contratado date not null,
id_cargo int not null,
id_estado int not null, 

foreign key (id_cargo) references tb_cargo (id_cargo),
foreign key (id_estado) references tb_estado (id_estado)
);

/* inserções na tb_estado */
insert into tb_estado(nm_estado)
values("São Paulo");

insert into tb_estado(nm_estado)
values("Rio Janeiro");

insert into tb_estado(nm_estado)
values("Minas Gerais");

insert into tb_estado(nm_estado)
values("Paraná");

insert into tb_estado(nm_estado)
values("Rondônia");

insert into tb_estado(nm_estado)
values("Santa Catarina");

insert into tb_estado(nm_estado)
values("Goiás");


/* inserções na tb_cargo */
insert into tb_cargo(ds_cargo, vl_salario, hr_entrada, hr_saida)
values ("Contador", 2000, '07:30', '21:00');

insert into tb_cargo(ds_cargo, vl_salario, hr_entrada, hr_saida)
values ("Desenvolvedor", 5000, '07:00', '22:00');

insert into tb_cargo(ds_cargo, vl_salario, hr_entrada, hr_saida)
values ("Auxiliar Administrativo", 1300, '07:00', '17:00');

insert into tb_cargo(ds_cargo, vl_salario, hr_entrada, hr_saida)
values ("Logistíca", 3200, '07:00', '19:30');

/* inserções na tb_funcionario */
insert into tb_funcionario(nm_funcionario, ds_rg, ds_cpf, ds_telefone, ds_celular, dt_contratado, id_cargo, id_estado)
values('gustavo oliveira', '551888664/25', '258369147/25', '54442210','11 936140022', '2010-09-15', 1,3);

insert into tb_funcionario(nm_funcionario, ds_rg, ds_cpf,ds_celular, dt_contratado, id_cargo, id_estado)
values('Henrique de Souza', '551724164/18', '258360031/01', '11 93559632', '2016-11-20', 2,2);

select * from tb_estado;
select * from tb_cargo;
select * from tb_funcionario;
