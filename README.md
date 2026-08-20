# ☕ CafeteriaHexagonal

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-11.0-239120?style=for-the-badge&logo=csharp&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2019-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Swagger](https://img.shields.io/badge/Swagger-OpenAPI-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)
![GitHub](https://img.shields.io/badge/GitHub-Repositorio-181717?style=for-the-badge&logo=github&logoColor=white)

---

## 📖 **Descripción**

**CafeteriaHexagonal** es una API RESTful para la gestión de cafés, desarrollada con **Arquitectura Hexagonal (Ports & Adapters)** y **Domain-Driven Design (DDD)**.

El proyecto fue creado como parte de un curso de arquitectura de software y sigue los principios de **Clean Architecture** y **buenas prácticas de desarrollo**.

---

## 🏗️ **Arquitectura Hexagonal**
┌─────────────────────────────────────────────────────────────┐
│ CLIENTE (HTTP) │
└─────────────────────────────────────────────────────────────┘
│
▼
┌─────────────────────────────────────────────────────────────┐
│ ADAPTADOR DE ENTRADA │
│ (ApiCafeteria) │
│ ┌─────────────────────────┐ │
│ │ Program.cs (Minimal API)│ │
│ └─────────────────────────┘ │
└─────────────────────────────────────────────────────────────┘
│
▼
┌─────────────────────────────────────────────────────────────┐
│ PUERTOS DE ENTRADA │
│ (Interfaces de Aplicación) │
│ IServicioCafe / IServicioPrepararCafe │
└─────────────────────────────────────────────────────────────┘
│
▼
┌─────────────────────────────────────────────────────────────┐
│ CASOS DE USO │
│ (AplicacionCafeteria) │
│ ┌─────────────────────────────────┐ │
│ │ ServicioCafe / ServicioPreparar │ │
│ └─────────────────────────────────┘ │
└─────────────────────────────────────────────────────────────┘
│
▼
┌─────────────────────────────────────────────────────────────┐
│ DOMINIO (NÚCLEO) │
│ (DominioCafe) │
│ ┌─────────────────────────────────────────────────┐ │
│ │ Entidad: Cafe │ │
│ │ Puertos: IRepositorioCafe / IObtenerCafe │ │
│ │ IPrepararCafe │ │
│ └─────────────────────────────────────────────────┘ │
└─────────────────────────────────────────────────────────────┘
│
▼
┌─────────────────────────────────────────────────────────────┐
│ PUERTOS DE SALIDA │
│ (Interfaces de Repositorio) │
└─────────────────────────────────────────────────────────────┘
│
▼
┌─────────────────────────────────────────────────────────────┐
│ ADAPTADOR DE SALIDA │
│ (RepositorioCafe) │
│ ┌─────────────────────────────────────────────────┐ │
│ │ CafeRepositorio (SQL Server) │ │
│ │ ContextoCafeteria (Entity Framework) │ │
│ └─────────────────────────────────────────────────┘ │
└─────────────────────────────────────────────────────────────┘
│
▼
┌─────────────────────────────────────────────────────────────┐
│ BASE DE DATOS │
│ (SQL Server) │
│ ┌───────────────────┐ │
│ │ Tabla: Cafes │ │
│ └───────────────────┘ │
└─────────────────────────────────────────────────────────────┘


---

## 🚀 **Tecnologías Utilizadas**

| Tecnología | Versión | Descripción |
|------------|---------|-------------|
| .NET | **8.0** | Framework principal |
| C# | **11.0** | Lenguaje de programación |
| SQL Server | **2019** | Base de datos |
| Entity Framework | **8.0** | ORM |
| Swagger | **OpenAPI** | Documentación |
| Git | **Latest** | Control de versiones |

---

## 📦 **Estructura del Proyecto**

📁 CafeteriaHexagonal/

├── 📁 ApiCafeteria/ # Adaptador de Entrada (API REST)
│ ├── 📄 Program.cs # Endpoints y configuración
│ └── 📄 appsettings.json # Configuración (base de datos)
│
├── 📁 AplicacionCafeteria/ # Casos de Uso (Servicios)
│ ├── 📁 DTOs/ # Objetos de transferencia
│ │ └── 📄 CafeDTO.cs
│ ├── 📁 Interfaces/ # Puertos de entrada
│ │ ├── 📄 IServicioCafe.cs
│ │ └── 📄 IServicioPrepararCafe.cs
│ ├── 📁 Mappers/ # Conversión entre capas
│ │ └── 📄 MapeadorCafe.cs
│ └── 📁 Servicios/ # Casos de uso
│ ├── 📄 ServicioCafe.cs
│ └── 📄 ServicioPrepararCafe.cs
│
├── 📁 DominioCafe/ # Núcleo del negocio
│ ├── 📁 Entidades/ # Entidades de dominio
│ │ └── 📄 Cafe.cs
│ └── 📁 Interfaces/ # Puertos de salida
│ ├── 📄 IRepositorioCafe.cs
│ ├── 📄 IObtenerCafe.cs
│ └── 📄 IPrepararCafe.cs
│
└── 📁 RepositorioCafe/ # Adaptador de Salida
├── 📁 Contexto/ # DbContext
│ └── 📄 ContextoCafeteria.cs
├── 📁 Modelos/ # Modelos de base de datos
│ └── 📄 CafeModelo.cs
└── 📄 CafeRepositorio.cs # Implementación de puertos

---

## 🔧 **Endpoints de la API**

| Método | Endpoint | Descripción | Código de Éxito |
|--------|----------|-------------|-----------------|
| `GET` | `/cafes` | Obtener todos los cafés | `200 OK` |
| `GET` | `/cafes/{id}` | Obtener café por ID | `200 OK` |
| `POST` | `/cafes` | Crear un nuevo café | `201 Created` |
| `PUT` | `/cafes` | Actualizar un café | `200 OK` |
| `PUT` | `/cafes/preparar/{id}` | Preparar un café | `204 No Content` |

---

## 🎯 **Ejemplo de Uso**

### **1. Crear un Café**

**Petición:**
```http
POST /cafes
Content-Type: application/json

{
  "nombre": "Café Americano",
  "precio": 2.50,
  "tamaño": "Grande"
}
```
**Respuesta:**
```http
{
  "id": 1,
  "nombre": "Café Americano",
  "precio": 2.50,
  "estaPreparado": false,
  "tamaño": "Grande",
  "fechaCreacion": "2026-08-20T10:30:00"
}
```
**Preparar un Café:**
```http
Petición: PUT /cafes/preparar/1
```
**Respuesta:**
```http
204 No Content
```
**Obtener todos los Cafés:**
```http
Petición: GET /cafes
```
**Respuesta:**
```http
[
  {
    "id": 1,
    "nombre": "Café Americano",
    "precio": 2.50,
    "estaPreparado": true,
    "tamaño": "Grande",
    "fechaCreacion": "2026-08-20T10:30:00"
  },
  {
    "id": 2,
    "nombre": "Café Latte",
    "precio": 3.00,
    "estaPreparado": false,
    "tamaño": "Mediano",
    "fechaCreacion": "2026-08-20T10:35:00"
  }
]
```
**🗄️ Base de Datos**
Tabla: Cafes
```http
CREATE TABLE Cafes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Precio DECIMAL(18,2) NOT NULL,
    EstaPreparado BIT NOT NULL DEFAULT 0,
    Tamaño NVARCHAR(20) NOT NULL DEFAULT 'Mediano',
    FechaCreacion DATETIME2 NOT NULL DEFAULT GETDATE()
);
```
**🚀 Cómo Ejecutar el Proyecto**
Prerrequisitos
.NET 8.0 SDK

SQL Server 2019+ o LocalDB

Visual Studio 2022 o VS Code

Instalación
```http
# 1. Clonar el repositorio
git clone https://github.com/jolurn/CafeteriaHexagonal.git

# 2. Navegar al proyecto
cd CafeteriaHexagonal

# 3. Restaurar dependencias
dotnet restore

# 4. Ejecutar la API
cd ApiCafeteria
dotnet run
```
**Acceder a Swagger**
Abre tu navegador y ve a:
```http
https://localhost:7042/swagger/index.html
```
👥 Autor
Jorge Luis Ramos Nolasco

GitHub: @jolurn

⭐ ¡Dale una estrella!
Si te gustó este proyecto, no olvides darle ⭐ en GitHub. ¡Gracias!

https://img.shields.io/badge/GitHub-S%C3%ADgueme-181717?style=for-the-badge&logo=github&logoColor=white
