Característica: M02 Adm. Usuarios_S03 Usuario
	Macro Proceso Administrador
	Proceso Administrador de usuarios
	SubProceso Usuario

Escenario: CP01_Listar Usuario
Dado El usuario ingresa a la opcion de menú Listar Usuarios
Entonces El sistema despliega una grilla con los registros de usuarios existentes en el sistema

Esquema del escenario: CP02_Ingresar Usuario
	Dado El usuario ingresa a la opción de menú Ingresar Usuarios
	Y El sistema despliega el formulario para ingresar rut de usuario <RutUsuario>
	Cuando El usuario ingresa los datos necesarios para ingresar un nuevo usuario: Nombre <Nombre>, Apellido Paterno <ApellidoPaterno>, Apellido Materno <ApellidoMaterno>, Username <Username>, Password <Password>, Confirmar Password <ConfirmPassword>, Telefono <Telefono>, Email <Email>,selecciona Sucursal <Sucursal> y selecciona Perfil <Perfil>
	Y El usuario pulsa el botón Registrar
	Y El usuario confirma el ingreso del registro
	Entonces El sistema despliega en la grilla el registro ingresado con el rut <RutUsuario>

@source:M02_Adm.Usuarios.xlsx:INGRESAR.USUARIO
Ejemplos:
| RutUsuario | Nombre | ApellidoPaterno | ApellidoMaterno | Username | Password | ConfirmPassword | Telefono | Email | Sucursal | Perfil | 

Esquema del escenario: CP03_Editar Usuario
	Dado El usuario ingresa a la opción de menú Listar Usuarios
	Y El usuario pulsa el botón Detalle para el registro el rut <RutUsuario>
	Cuando El usuario reemplaza los datos del usuario con la siguiente información: Nombre <Nombre>, Apellido Paterno <ApellidoPaterno>, Apellido Materno <ApellidoMaterno>, Username <Username>, Password <Password>, Confirmar Password <ConfirmPassword>, Telefono <Telefono>, Email <Email>,selecciona Sucursal <Sucursal> y selecciona Perfil <Perfil>
	Y El usuario pulsa el botón Editar
	Y El usuario confirma a edición del registro
	Entonces El sistema despliega en la grilla el registro modificado con el rut <RutUsuario>

@source:M02_Adm.Usuarios.xlsx:EDITAR.USUARIO
Ejemplos: 
| RutUsuario | Nombre | ApellidoPaterno | ApellidoMaterno | Username | Password | ConfirmPassword | Telefono | Email | Sucursal | Perfil | 
