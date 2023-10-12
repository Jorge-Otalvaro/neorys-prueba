-- Crear la tabla Persona
CREATE TABLE Personas (
    Id uniqueidentifier PRIMARY KEY DEFAULT NEWID(),    
    Nombre VARCHAR(255),
    Genero VARCHAR(10),
    Edad INT,
    Identificacion VARCHAR(20),
    Direccion VARCHAR(255),
    Telefono VARCHAR(15),
	CreatedOn DATETIME DEFAULT GETDATE(),
    LastModifiedOn DATETIME
);

-- Crear la tabla Cliente que hereda de Persona
CREATE TABLE Clientes (
    Id uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
    Contrasena VARCHAR(50),
    Estado VARCHAR(20),
	CreatedOn DATETIME DEFAULT GETDATE(),
    LastModifiedOn DATETIME,
    FOREIGN KEY (Id) REFERENCES Personas (Id)
);

-- Crear la tabla Cuenta
CREATE TABLE Cuentas (
    Id uniqueidentifier PRIMARY KEY DEFAULT NEWID(),    
    NumeroCuenta INT,
    TipoCuenta VARCHAR(20),
    SaldoInicial DECIMAL(10, 2),
    Estado BIT DEFAULT 1,
	ClienteId uniqueidentifier,
    FOREIGN KEY (ClienteId) REFERENCES Clientes (Id),
	CreatedOn DATETIME DEFAULT GETDATE(),
    LastModifiedOn DATETIME
);

-- Crear la tabla Movimientos
CREATE TABLE Movimientos (
    Id uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
    Fecha DATETIME,
    TipoMovimiento VARCHAR(20),
    Valor DECIMAL(10, 2),
    Saldo DECIMAL(10, 2),
    CuentaId uniqueidentifier,
    FOREIGN KEY (CuentaId) REFERENCES Cuentas (Id),
    CreatedOn DATETIME DEFAULT GETDATE(),
    LastModifiedOn DATETIME
);

-- Insertar los datos en la tabla "Personas"
INSERT INTO Personas (Nombre, Genero, Edad, Identificacion, Direccion, Telefono)
VALUES
    ('Jose Lema', 'Masculino', 35, 'ID12345', 'Otavalo sn y principal', '098254785'),
    ('Marianela Montalvo', 'Femenino', 28, 'ID67890', 'Amazonas y NNUU', '097548965'),
    ('Juan Osorio', 'Masculino', 42, 'ID54321', '13 junio y Equinoccial', '098874587');

-- Insertar los datos en la tabla "Clientes" y asociarlos con las personas
INSERT INTO Clientes (Id, Contrasena, Estado)
VALUES
    ('18DF01A0-B031-4498-A0CB-5372202C7D43', '1234', 1), -- Asociado a Jose Lema (Id 1)
    ('5352E0F3-B298-47C2-B9A6-AF2488487FBE', '5678', 1), -- Asociado a Marianela Montalvo (Id 2)
    ('B27EDEBA-96F0-4F09-A2D9-DB89A26291E2', '1245', 1); -- Asociado a Juan Osorio (Id 3)

-- Insertar los datos en la tabla "Cuenta"
INSERT INTO Cuentas (ClienteId, NumeroCuenta, TipoCuenta, SaldoInicial, Estado)
VALUES
    ('18DF01A0-B031-4498-A0CB-5372202C7D43', 478758, 'Ahorro', 2000, 1), -- 1 representa "True" para Estado
    ('5352E0F3-B298-47C2-B9A6-AF2488487FBE', 225487, 'Corriente', 100, 1),
    ('B27EDEBA-96F0-4F09-A2D9-DB89A26291E2', 495878, 'Ahorros', 0, 1),
    ('5352E0F3-B298-47C2-B9A6-AF2488487FBE', 496825, 'Ahorros', 540, 1);

-- Insertar datos de movimientos en la tabla Movimientos
INSERT INTO Movimientos (MovimientoId, Fecha, TipoMovimiento, Valor, Saldo, CuentaId)
VALUES 
	(1, '2023-10-11 08:00:00', 'Retiro', 575.00, 1425.00, 'DB51F4FF-97E1-4751-6EBA-08DBCAE68893'),
	(2, '2023-10-11 09:30:00', 'Depósito', 600.00, 700.00, '6359D0AC-052F-4A5E-8B22-C5B2DA3026BA'),
	(3, '2023-10-11 11:15:00', 'Depósito', 150.00, 150.00, '4BB59215-72A5-4E90-CFC5-08DBCB312321'),
	(4, '2023-10-11 14:45:00', 'Retiro', 540.00, 0.00, 'EDBDD932-90C0-49C9-3243-08DBCAE71C46');
