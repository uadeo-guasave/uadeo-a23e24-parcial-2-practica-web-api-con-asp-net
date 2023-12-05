CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "Alumnos" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Alumnos" PRIMARY KEY AUTOINCREMENT,
    "Matricula" TEXT NOT NULL,
    "Nombres" TEXT NOT NULL,
    "Apellidos" TEXT NOT NULL,
    "CarreraId" INTEGER NOT NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231026143710_InitialCreate', '7.0.12');

COMMIT;

BEGIN TRANSACTION;

CREATE TABLE "Carreras" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Carreras" PRIMARY KEY AUTOINCREMENT,
    "Nombre" TEXT NOT NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231031145223_AddTableCarreras', '7.0.12');

COMMIT;

