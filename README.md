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

### 🐳 Despliegue con Docker

1. Ejecuta el siguiente comando en CMD o PowerShell desde la carpeta que contiene `Dockerfile` y `docker-compose.yml`:

```
docker-compose up --build
```

2. Confirma que los contenedores se estén ejecutando correctamente desde Docker Desktop.

<img width="1913" height="566" alt="image" src="https://github.com/user-attachments/assets/b40a3371-412e-4aab-b1b7-6e5c6113ec4d" />

3. Conéctate a la base de datos local usando SQL Server Management Studio o Visual Studio SQL:

```
User: sa
Password: Your_password123
```

<img width="494" height="325" alt="image" src="https://github.com/user-attachments/assets/b63a7a52-8610-4bb5-8d3b-656ccaa70647" />

4. Ejecuta el script 01. Base structure.sql para crear la estructura inicial de la base de datos.

5. Abre Swagger en tu navegador para verificar que la aplicación se está ejecutando:

<img width="1912" height="785" alt="image" src="https://github.com/user-attachments/assets/9a0306dd-c6b4-4dbd-8537-fc819d6d9653" />

---

## 🙋 Autor

### Yeimer Andres Jaramillo Fernandez
📧 Mail: Andresjara0897@hotmail.com <br/>
💼 GitHub: https://github.com/Jaferye97 <br/>
🔗 LinkedIn: https://www.linkedin.com/in/yeimerjarafer/ <br/>




