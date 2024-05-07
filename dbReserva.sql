IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'dbReserva')
BEGIN
    CREATE DATABASE dbReserva;
END
GO

USE dbReserva;
GO

-- Tabla de Tours
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Tours')
BEGIN
    CREATE TABLE Tours (
        id_tour INT PRIMARY KEY,
        nombre VARCHAR(255) NOT NULL,
        descripcion TEXT,
        precio DECIMAL(10, 2) NOT NULL
    );
END
GO

-- Tabla de Clientes
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Clientes')
BEGIN
    CREATE TABLE Clientes (
        id_cliente VARCHAR(12) PRIMARY KEY,
        nombre VARCHAR(255) NOT NULL,
        email VARCHAR(255) NOT NULL,
        telefono VARCHAR(20)
        -- Puedes agregar otros campos como dirección, ciudad, etc.
    );
END
GO

-- Tabla de Reservas
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Reservas')
BEGIN
    CREATE TABLE Reservas (
        id_reserva INT PRIMARY KEY,
        id_tour INT,
        id_cliente VARCHAR(12),
        fecha_reserva DATE,
        cantidad_personas INT,
        FOREIGN KEY (id_tour) REFERENCES Tours(id_tour),
        FOREIGN KEY (id_cliente) REFERENCES Clientes(id_cliente)
    );
END
GO

-- Tabla de Pagos
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Pagos')
BEGIN
    CREATE TABLE Pagos (
        id_pago INT PRIMARY KEY,
        id_reserva INT,
        monto DECIMAL(10, 2) NOT NULL,
        fecha_pago DATE,
        FOREIGN KEY (id_reserva) REFERENCES Reservas(id_reserva)
    );
END
GO
