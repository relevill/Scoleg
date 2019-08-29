Característica: M02 Adm. Usuarios_S01 Grupo
	Macro Proceso Administrador
	Proceso Administrador de usuarios
	SubProceso Grupo

@mytag
Esquema del escenario: CP01_Ingresar Grupo
	Dado El usuario ingresa a la opción de menú Ingresar Grupo Usuarios
	Y El sistema despliega el formulario para ingresar grupo
	Cuando El usuario ingresa <Descripcion> en el campo Descripción
	Y El usuario pulsa el botón Registrar
	Y El usuario confirma el ingreso del registro
	Entonces El sistema crea el grupo de usuarios

@source:M02_Adm.Usuarios.xlsx:M02-0201.0101.INGRESAR.GRUPO
Ejemplos:
| Descripcion |


@mytag
Esquema del escenario: CP02_Editar Grupo
	Dado El sistema despliega la lista de Grupos de Usuarios
	Cuando El usuario edita <DescripcionModificar> en el campo Descripción
	Y El usuario pulsa el botón Editar
	Y El usuario confirma la modificación del registro
	Entonces El sistema modifica el grupo de usuarios

@source:M02_Adm.Usuarios.xlsx:M02-0201.0202.EDITAR.GRUPO
Ejemplos:
| Descripcion | DescripcionModificar |

