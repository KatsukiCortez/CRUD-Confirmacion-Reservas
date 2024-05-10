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
        -- Puedes agregar otros campos como direcci�n, ciudad, etc.
    );
END
GO

-- Tabla de Reservas
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Reservas')
BEGIN
    CREATE TABLE Reservas (
        id_reserva INT PRIMARY KEY,
        tour INT,
        cliente VARCHAR(12),
        fecha_reserva DATE,
        cantidad_personas INT,
        FOREIGN KEY (tour) REFERENCES Tours(id_tour),
        FOREIGN KEY (cliente) REFERENCES Clientes(id_cliente)
    );
END
GO

-- Tabla de Pagos
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Pagos')
BEGIN
    CREATE TABLE Pagos (
        id_pago INT PRIMARY KEY,
        reserva INT,
        monto DECIMAL(10, 2) NOT NULL,
        fecha_pago DATE,
        FOREIGN KEY (reserva) REFERENCES Reservas(id_reserva)
    );
END
GO


INSERT INTO Tours (id_tour, nombre, descripcion, precio) VALUES
(1, 'Tour a Machu Picchu', 'Descubre la maravilla de Machu Picchu en este tour de un día completo.', 150.00),
(2, 'Tour Valle Sagrado', 'Visita los impresionantes sitios arqueológicos y pueblos tradicionales del Valle Sagrado.', 120.00),
(3, 'Tour Laguna Humantay', 'Disfruta de una caminata hacia la hermosa laguna de Humantay en las alturas de Cusco.', 80.00),
(4, 'Tour Montaña de Siete Colores', 'Explora la increíble montaña de colores en Vinicunca, una experiencia única.', 100.00);

INSERT INTO Clientes (id_cliente, nombre, email, telefono) VALUES
('CLI001', 'Juan Pérez', 'juan@example.com', '+51 987 654 321'),
('CLI002', 'María Rodríguez', 'maria@example.com', '+51 987 123 456'),
('CLI003', 'Carlos Gómez', 'carlos@example.com', '+51 987 789 012');

INSERT INTO Reservas (id_reserva, tour, cliente, fecha_reserva, cantidad_personas) VALUES
(1, 1, 'CLI001', '2024-05-15', 2),
(2, 3, 'CLI002', '2024-06-10', 1),
(3, 2, 'CLI003', '2024-07-05', 4),
(4, 4, 'CLI001', '2024-08-20', 3);

INSERT INTO Pagos (id_pago, reserva, monto, fecha_pago) VALUES
(1, 1, 300.00, '2024-05-14'),
(2, 2, 80.00, '2024-06-08'),
(3, 3, 480.00, '2024-07-04'),
(4, 4, 300.00, '2024-08-19');
