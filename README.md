# 📦 Proyecto: Gestión de Tickets

## 🧾 Descripción

Este proyecto implementa una solución API REST completa para la gestión de tickets (creación, consulta, actualización y eliminación), utilizando buenas prácticas de arquitectura y tecnologías modernas en el backend.

- **Backend**: .NET Core 8 con arquitectura **hexagonal**, acceso a datos mediante **Entity Framework** y base de datos **SQL Server**.
- Comunicación entre capas desacoplada y organizada bajo principios **SOLID** y **Clean Architecture**.

---

## 🚀 Características

- 📄 Registro, actualización y obtención individual de tickets.
- 🔍 Filtrado y paginación de tickets a través de sus diferentes campos.

---

## ⚙️ Tecnologías Usadas

| Backend                |
|------------------------|
| .NET 8                 |
| C#                     |
| Entity Framework       |
| SQL Server             |
| Arquitectura Hexagonal |
| Swagger                |

---

## 🛠️ Estructura del Proyecto

```
/BD
└── 01. Base structure

/Backend
└── Tests // Contiene la misma estructura que la solución, para facilitar la ubicación de las pruebas frente a las clases.
└── Application
│   ├── Ports
│   └── UseCases
└── Domain
│   └── Model
└── Infrastructure
    └── Adapters
        ├── In
        │   └── WebApi
        └── Out
            └── RepositoryEntityFrameworkSqlServer
```

---

## 💡 Cómo Ejecutarlo

### 🗄️ Scripts de Base de Datos

Antes de ejecutar el proyecto, asegúrate de crear la tabla ejecutando los siguientes scripts ubicados en la carpeta `/Db`:

1. `01. Base structure.sql` – Estructura base que contiene la tabla necesaria para cumplir con los requerimientos de la prueba técnica.

### ⚙️ Backend (.NET)

> ⚠️ **Importante:** Asegúrate de configurar la cadena de conexión en appsettings.json.

```bash
cd Backend/WebApi
dotnet restore
dotnet run
```

---


### **🧩 Endpoints principales**
Basado en tu captura:

```markdown
| Método  | Endpoint               | Descripción                     |
|---------|------------------------|---------------------------------|
| POST    | /api/Ticket            | Crear un nuevo ticket           |
| PUT     | /api/Ticket            | Actualizar un ticket existente  |
| GET     | /api/Ticket/{id}       | Obtener ticket por ID           |
| DELETE  | /api/Ticket/{id}       | Eliminar ticket por ID          |
| POST    | /api/Ticket/GetAll     | Listar todos los tickets        |
```

---

### 🧪 Pruebas unitarias

```
dotnet test
```

---

## 🙋 Autor

### Yeimer Andres Jaramillo Fernandez
📧 Mail: Andresjara0897@hotmail.com <br/>
💼 GitHub: https://github.com/Jaferye97 <br/>
🔗 LinkedIn: https://www.linkedin.com/in/yeimerjarafer/ <br/>



