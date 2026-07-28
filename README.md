Membros do Projeto:
Henrico Saeki Rolim Issomura
Nícolas Lima Schinagel do Nascimento
Rafael Rodrigues Segui
Victor Hugo Seguette Costa

Banco de dados:
create database dbfeira;
use dbfeira;

create table tbCliente(
Id int primary key auto_increment,
Nome varchar(100) not null,
Email varchar(100) not null unique,
Senha varchar(100) not null,
ConfirmacaoSenha varchar(100) not null
);
