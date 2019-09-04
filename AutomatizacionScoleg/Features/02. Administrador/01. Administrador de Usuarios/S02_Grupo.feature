Característica: S02_Grupo
Casos de Prueba para sistema LegalPartner
Macro Proceso Administrador
Proceso Administrador de usuarios
SubProceso Grupo

@mytag
Esquema del escenario: CP01_Ingresar grupo
	Dado El usuario ingresa a la opción de menú ingresar grupo usuarios
	Y El sistema despliega formulario para ingresar grupo
	Cuando El usuario completa el campo <Descripcion>
	Y El usuario pulsa el botón Registrar
	Y El usuario confirma el ingreso del registro
	Entonces El sistema crea el registro exitosamente

@source:AdministradorUsuariosData.xlsx
Ejemplos:
| Descripcion |
