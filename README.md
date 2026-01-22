# 🏡 Inmobiliaria API - Backend

API RESTful robusta y escalable desarrollada con **.NET 9** para la gestión de propiedades inmobiliarias. Este servicio alimenta el frontend de la inmobiliaria, gestionando propiedades, imágenes, usuarios y autenticación.

![.NET](https://img.shields.io/badge/.NET-9.0-purple)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-Supabase-blue)
![Docker](https://img.shields.io/badge/Docker-Koyeb-2496ED)
![Status](https://img.shields.io/badge/Status-Production-green)

## 🛠️ Tecnologías

* **Core:** ASP.NET Core Web API (.NET 9).
* **Base de Datos:** PostgreSQL (alojada en Supabase).
* **ORM:** Entity Framework Core (Code First).
* **Almacenamiento:** Cloudinary / Supabase Storage (Imágenes).
* **Seguridad:** JWT (JSON Web Tokens) para autenticación.
* **Despliegue:** Docker + Koyeb.

## 🚀 Instalación y Ejecución Local

1.  **Clonar el repositorio:**
    ```bash
    git clone [https://github.com/Brian13b/inmobiliaria-backend.git](https://github.com/Brian13b/inmobiliaria-backend.git)
    cd inmobiliaria-backend
    ```

2.  **Configurar Variables de Entorno:**
    Renombrar `appsettings.json.example` a `appsettings.json` y configurar la cadena de conexión de Supabase y claves JWT.
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Host=aws-0-us-west-2.pooler.supabase.com;Port=6543;Database=postgres;..."
    }
    ```

3.  **Aplicar Migraciones (Base de Datos):**
    ```bash
    dotnet ef database update --project Inmobiliaria.Infrastructure --startup-project Inmobiliaria.API
    ```

4.  **Ejecutar:**
    ```bash
    dotnet run --project Inmobiliaria.API
    ```

## 🗺️ Roadmap & Updates

Estado actual del desarrollo y planes futuros.

### ✅ Versión 1.0 (Lanzamiento Actual)
- [x] Arquitectura limpia (Domain, Infrastructure, API).
- [x] CRUD completo de Propiedades.
- [x] Integración con Base de Datos PostgreSQL (Supabase).
- [x] Filtrado avanzado (Precio, Tipo, Operación, Ambientes).
- [x] Despliegue continuo en Koyeb mediante Docker.

### 🚧 En Progreso (v1.1)
- [ ] Implementación de `MailingService` para formularios de contacto.
- [ ] Endpoints privados para panel de administración (Dashboard).
- [ ] Optimización de imágenes server-side.

### 🔮 Futuro (v2.0)
- [ ] Sistema de "Favoritos" para usuarios registrados.
- [ ] Integración con mapas interactivos (GeoLocation API).
- [ ] Tests Unitarios (xUnit) y de Integración.

## 📄 Licencia
Este proyecto está bajo la Licencia MIT.