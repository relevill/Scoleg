Característica: M02 Adm. Usuarios_S02 Perfil
	Macro Proceso Administrador
	Proceso Administrador de usuarios
	SubProceso Perfil

@mytag
Esquema del escenario: CP01_Ingresar Perfil
	Dado El usuario ingresa a la opción de menú Perfiles
	Y El sistema despliega el formulario para ingresar perfil
	Cuando El usuario ingresa <DescripcionPerfil> en el campo Descripción
	Y El usuario selecciona un <GrupoPerfil> en el campo Grupo de Perfil
	Y El usuario pulsa el botón Registrar nuevo perfil
	Y El usuario confirma el ingreso del registro de nuevo perfil
	Entonces El sistema crea el nuevo Perfil

	@source:M02_Adm.Usuarios.xlsx:M02-0202.0101.INGRESAR.PERFIL
	Ejemplos:
		| DescripcionPerfil | GrupoPerfil |

@mytag
Esquema del escenario: CP02_Editar Perfil
	Dado El usuario ingresa a la opcion de menú Listar Perfiles
	Y El usuario presiona el botón editar según <DescripcionPerfil> de la lista
	Y El sistema despliega el formulario para editar un perfil
	Cuando El usuario edita <DescripcionEditar> en el campo Descripcion Perfil
	Y El usuario cambia un <GrupoEditar> del campo Grupo de Perfil
	Y El usuario pulsa el boton Editar nuevo perfil
	Entonces El usuario confirma la modificacion del perfil

	@source:M02_Adm.Usuarios.xlsx:M02-0202.0202_EDITAR.PERFIL
	Ejemplos:
		| DescripcionPerfil | GrupoPerfil | DescripcionEditar | GrupoEditar |


@mytag
Esquema del escenario: CP03_Ver Detalle Perfil
	Dado El usuario ingresa a la opcion del menu Listar Perfiles
	Cuando El usuario presiona el boton Ver Detalle según <DescripcionPerfil> y <GrupoPerfil> de la lista
	Y El usuario verifica los elementos mostrados <DescripcionPerfil> y <GrupoPerfil>
	Entonces El sistema cierra la ventana modal detalle registro
	
@source:M02_Adm.Usuarios.xlsx:M02-0202.0505_VERDETALLE.PERFIL
	Ejemplos: 
		| DescripcionPerfil | GrupoPerfil |


@mytag
Esquema del escenario: CP04_Eliminar Perfil
Dado El usuario ingresa a la opcion del menú Listar Perfiles
Cuando El usuario presiona el botón Eliminar según <DescripcionPerfil> y <GrupoPerfil> de la lista
Y El usuario presiona boton Eliminar
Y El usuario confirma la eliminación del registro
Entonces El sistema muestra la confirmación y el usuario cierra la ventana

@source:M02_Adm.Usuarios.xlsx:M02-0202.0303_ELIMINAR.PERFIL
	Ejemplos: 
		| DescripcionPerfil | GrupoPerfil |

@mytag
Escenario: CP05_Listar Perfil
Dado El usuario selecciona la opción del menú Listar Perfiles
Entonces El sistema despliegue una grilla con los registros de perfiles existentes en el sistema

