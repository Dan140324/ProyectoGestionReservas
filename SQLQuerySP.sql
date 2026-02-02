USE LaboratoriosReservas
GO
/*
CREATE PROCEDURE sp_ListarLaboratoriosActivos
AS
BEGIN

    SELECT 
        l.idLaboratorio,
        l.nombre,
        l.capacidad
    FROM Laboratorios l
    WHERE l.idEstado = 1 -- Activo
    ORDER BY l.nombre;
END;


GO
CREATE PROCEDURE sp_ListarTodosLaboratorios
AS
BEGIN

    SELECT 
        l.idLaboratorio,
        l.nombre,
        l.capacidad,
        e.idEstado,
        e.nombreEstado AS estado
    FROM Laboratorios l
    INNER JOIN EstadoLaboratorios e
        ON l.idEstado = e.idEstado
    ORDER BY l.nombre;
END;
*/
/*
GO

CREATE PROCEDURE sp_GuardarLaboratorio
    @idLaboratorio INT = NULL,
    @nombre        VARCHAR(50),
    @capacidad     INT,
    @idEstado      INT = 1
AS
BEGIN

    IF (@capacidad <= 0)
    BEGIN
        RAISERROR ('La capacidad debe ser mayor que cero.', 16, 1);
        RETURN;
    END

    IF @idLaboratorio IS NULL
    BEGIN
        INSERT INTO Laboratorios (nombre, capacidad, idEstado)
        VALUES (@nombre, @capacidad, @idEstado);

        SELECT SCOPE_IDENTITY() AS idLaboratorio;
    END
    ELSE
    BEGIN
        UPDATE Laboratorios
        SET nombre = @nombre,
            capacidad = @capacidad,
            idEstado = @idEstado
        WHERE idLaboratorio = @idLaboratorio;

        SELECT @idLaboratorio AS idLaboratorio;
    END
END;
*/
/*
GO
CREATE PROCEDURE sp_EliminarLaboratorio
    @idLaboratorio INT
AS
BEGIN
    -- Validación
    IF NOT EXISTS (
        SELECT 1
        FROM Laboratorios
        WHERE idLaboratorio = @idLaboratorio
    )
    BEGIN
        RAISERROR('El laboratorio no existe.', 16, 1);
        RETURN;
    END

    -- Verificar si el laboratorio tiene reservas asociadas
    IF EXISTS (
    SELECT 1
    FROM Reservas
    WHERE idLaboratorio = @idLaboratorio
)
BEGIN
    RAISERROR('No se puede eliminar el laboratorio porque tiene reservas asociadas.', 16, 1);
    RETURN;
END

    -- Eliminación lógica (inactivar)
    UPDATE Laboratorios
    SET idEstado = 2 -- Inactivo
    WHERE idLaboratorio = @idLaboratorio;
END;
*/
GO


    
