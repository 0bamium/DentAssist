# 📄 Casos de Uso - DentAssist

Este documento describe los principales casos de uso implementados en el sistema según el rol de usuario.

---

## 👩‍💼 Recepcionista

### CU-01: Registrar un nuevo paciente
**Precondición:** Estar en el módulo “Pacientes”  
**Flujo principal:**
1. Clic en “Crear nuevo”.
2. Completar los campos obligatorios.
3. Guardar.

### CU-02: Agendar turno
**Precondición:** Paciente y odontólogo registrados  
**Flujo principal:**
1. Ir al módulo “Turnos”.
2. Seleccionar paciente y odontólogo.
3. Definir fecha, duración y estado.
4. Guardar turno.

---

## 🧑‍⚕️ Odontólogo

### CU-03: Consultar agenda personal
1. Acceder al módulo Turnos.
2. Visualizar turnos asignados según su especialidad.

### CU-04: Crear plan de tratamiento
1. Seleccionar paciente.
2. Asociar tratamientos y pasos.
3. Guardar el plan completo.

---

## 👨‍💼 Administrador

### CU-05: Registrar odontólogo
1. Ir a módulo “Odontólogos”.
2. Agregar nombre, correo y especialidad.
3. Guardar.

### CU-06: Gestionar tratamientos
1. Acceder al módulo “Tratamientos”.
2. Añadir o editar tratamientos ofrecidos.
