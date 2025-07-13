CREATE DATABASE SECRETARIA;
GO
USE SECRETARIA;
GO

CREATE TABLE Aluno (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(100) NOT NULL,
    DataNascimento DATE NOT NULL,
    CPF CHAR(11) NOT NULL UNIQUE,
    Email NVARCHAR(254) NOT NULL UNIQUE,
    Senha NVARCHAR(255) NOT NULL, --para armazenar a senha criptografada
    DataInclusao DATETIME , --armazenar dados de inclusão e edição para controle
    DataEdicao DATETIME 
);

CREATE TABLE Turma (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(100) NOT NULL,
    Descricao NVARCHAR(255) NULL,    
    DataInclusao DATETIME, --armazenar dados de inclusão e edição para controle
    DataEdicao DATETIME 
);

CREATE TABLE Matricula (
    Id INT PRIMARY KEY IDENTITY(1,1),
    AlunoId INT FOREIGN KEY REFERENCES Aluno(Id),
    TurmaId INT FOREIGN KEY REFERENCES Turma(Id),    
    DataInclusao DATETIME, --armazenar dados de inclusão e edição para controle
    DataEdicao DATETIME 
);

-- Criação de turmas
INSERT INTO Turma (Nome, Descricao, DataInclusao, DataEdicao) VALUES
('Turma A', 'Turma de Introdução ao .NET', GETDATE(), null),
('Turma B', 'Turma de Desenvolvimento Web', GETDATE(), null);
GO

-- Adicionando de alunos (com senha criptografada de "aluno123")
INSERT INTO Aluno (Nome, DataNascimento, CPF, Email, Senha, DataInclusao, DataEdicao) VALUES
('João Silva', '2000-01-01', '12345678900', 'joaosilva@email.com', '$2a$11$L6Bq1utOIpT7UjL0taKo6O4g0ZBt8rKUMIGPt/f34gJPAzvV4aaRe', GETDATE(), null),
('Maria Oliveira', '2001-02-02', '98765432100', 'mariaoliveira@email.com', '$2a$11$L6Bq1utOIpT7UjL0taKo6O4g0ZBt8rKUMIGPt/f34gJPAzvV4aaRe', GETDATE(), null);
GO

-- Adicionando o aluno na tabela de matriculas 
INSERT INTO Matricula (AlunoId, TurmaId, DataInclusao, DataEdicao) VALUES
(1, 1, GETDATE(), null),
(2, 2, GETDATE(), null);
GO