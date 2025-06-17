# ✅ Validaciones en Formularios - DentAssist

Este documento describe las reglas de validación utilizadas en el sistema para asegurar la integridad de los datos ingresados.

---

## 🔍 General

- Validaciones aplicadas en cliente (JavaScript/jQuery) y en servidor (DataAnnotations).
- Campos obligatorios marcados con `*`.
- Formularios muestran mensajes de error personalizados.

---

## 🧾 Validaciones por Entidad

### Paciente
- `Nombre`: `[Required]`, longitud mínima 3 caracteres.
- `Correo`: `[Required]`, `[EmailAddress]`.
- `Telefono`: solo dígitos, 9 caracteres.

### Turno
- `Duración`: `[Range(5,180)]` minutos.
- `Fecha`: no puede estar vacía.
- `Estado`: enumerado (`Pendiente`, `Confirmado`, etc.) con selección obligatoria.

### Odontólogo
- `Especialidad`: `[Required]`.
- `Correo`: validación de formato.

### Tratamiento
- `Nombre`: requerido, único.
- `Descripción`: campo opcional.
- `Costo`: debe ser un número positivo.

### Plan de Tratamiento
- `PacienteId` y `OdontologoId`: campos seleccionables, no deben contener datos erróneos como dirección o correo (ya corregido).

---

## 🧪 Observaciones

- Se usa `int?` y `DateTime?` para forzar validación con `[Required]`.
- Se recomienda revisar formularios con validadores externos como Postman, Swagger o herramientas de navegador.
