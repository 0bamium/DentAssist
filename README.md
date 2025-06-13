# 🦷 DentAssist - Sistema de Gestión para Clínica Dental "Sonrisa Plena"

Proyecto de evaluación para la asignatura **Programación .NET**, correspondiente a la **Evaluación 2** (20%).

---

## 📌 Descripción del proyecto

**DentAssist** es una aplicación web desarrollada en ASP.NET Core MVC que permite a la clínica dental "Sonrisa Plena" gestionar eficientemente pacientes, turnos, odontólogos, tratamientos y planes de tratamiento clínico.

Este sistema busca reemplazar la gestión manual con una plataforma digital que centraliza la información, reduce errores y mejora la experiencia administrativa y clínica.

---

## 🧠 Tecnologías utilizadas

- ASP.NET Core MVC (.NET 8.0)
- Entity Framework Core
- SQL Server Management Studio 20
- Razor Pages + Bootstrap
- Visual Studio Comunity 2022
- C#
- Librerías jQuery para validación en formularios

---

## 🚀 Instrucciones de instalación y ejecución

### Requisitos

- Visual Studio 2022 o superior
- .NET SDK 8.0
- SQL Server LocalDB

### Pasos

1. Clona o descarga el repositorio.
2. Abre la solución `DentAssist.sln` en Visual Studio.
3. Verifica que la cadena de conexión en `appsettings.json` esté correctamente configurada:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=DentAssistDb;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```
## Nota
> Debes reemplazar los datos del servidor al que tu tengas

4. Abre la consola del administrador de paquetes NuGet y ejecuta:

   ```
   dotnet ef database update
   ```

   Esto creará la base de datos con todas las tablas.

5. Presiona **F5** para ejecutar la aplicación.

---

## 🧩 Funcionalidades implementadas

### 📁 Módulos

- **Pacientes:** ABM completo con historial y validaciones.
- **Odontólogos:** Registro de profesionales con especialidad y correo.
- **Turnos:** Agendamiento con estado (pendiente, confirmado, realizado, cancelado).
- **Tratamientos:** Catálogo editable de tratamientos ofrecidos.
- **Plan de Tratamiento:** Registro personalizado por paciente, con pasos asociados.
- **Validaciones:** Implementadas con DataAnnotations (`[Required]`, `[EmailAddress]`, `[Range]`, etc.)

---

## 🛠️ Validaciones

Los formularios cuentan con validaciones en el cliente y servidor:

- Campos obligatorios con mensajes personalizados.
- Validación de formato de email.
- Duración de turnos limitada a entre 5 y 180 minutos.
- Campos `int`, `DateTime`, `enum` declarados como `nullable` (`int?`, etc.) para activar correctamente `[Required]`.

---

## 👥 Roles funcionales

- **Recepcionista:** Gestiona pacientes y turnos.
- **Administrador:** ABM de odontólogos y tratamientos.
- **Odontólogo:** Visualiza su agenda y accede a planes de tratamiento.

---

## 📁 Estructura del proyecto

```plaintext
Controllers/
├── PacientesController.cs
├── TurnosController.cs
├── PlanTratamientosController.cs
...

Models/
├── Data/
│   ├── Entities/
│   │   ├── Paciente.cs
│   │   ├── Turno.cs
│   │   ├── Tratamiento.cs
│   │   ├── PlanTratamiento.cs
│   │   └── PasoTratamiento.cs
│   └── AppDbContext.cs

Views/
├── Pacientes/
├── Turnos/
├── PlanTratamientos/
├── Shared/
```

---

## 🎓 Autores

- Nombre 1
- Nombre 2
- Nombre 3

Carrera: Ingeniería en Ejecución Informática  
Asignatura: Programación .NET  
Institución: Santo Tomás  
Docente: Maximiliano Moraga

---

## 📎 Notas adicionales

- La funcionalidad de `PasoTratamiento` está integrada dentro de `PlanTratamiento`, por lo que no se gestiona por separado.
- No se implementó autenticación de usuarios ni roles por login.
- Se incluye validación de datos, pero no lógica de recordatorios ni dashboard.

---

## 📷 Manual de usuario

📝 El manual será entregado como documento adicional con capturas del sistema funcionando.
