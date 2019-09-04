Característica: M02 Adm. Usuarios_S02 Perfil
	Macro Proceso Administrador
	Proceso Administrador de usuarios
	SubProceso Perfil

Escenario: CP01_Listar Grupo
Dado El usuario ingresa a la opción de menú Listar Perfil
Entonces El sistema despliega una grilla con los registros de los perfiles existentes en el sistema

Esquema del escenario: CP02_Ingresar Perfil
	Dado El usuario ingresa a la opción de menú Ingresar Perfil
	Y El sistema despliega el formulario para ingresar perfil
	Cuando El usuario ingresa la descripción <Descripcion> y selecciona el grupo <Grupo>
	Y El usuario pulsa el botón Registrar
	Y El usuario confirma el ingreso del registro
	Entonces El sistema despliega en la grilla el registro ingresado con la descripción <Descripcion>

@source:M02_Adm.Usuarios.xlsx:INGRESAR.PERFIL
Ejemplos:
| Descripcion | Grupo |

Esquema del escenario: CP03_Editar Perfil
	Dado El usuario ingresa a la opción de menú Listar Perfil
	Y El usuario pulsa el botón Editar para el registro con descripción <DescripcionSearch>
	Y El sistema despliega el formulario para editar perfil y con la siguiente información: descripción <DescripcionSearch>, grupo <Grupo>
	Cuando El usuario modifica la descripción por <DescripcionEdit> y selecciona el grupo <GrupoEdit>
	Y El usuario pulsa el botón Editar
	Y El usuario confirma a edición del registro
	Entonces El sistema despliega en la grilla el registro modificado con la descripción <DescripcionEdit>

@source:M02_Adm.Usuarios.xlsx:EDITAR.PERFIL
Ejemplos:
| DescripcionSearch | GrupoSearch | DescripcionEdit | GrupoEdit |

Esquema del escenario: CP04_Eliminar Perfil
	Dado El usuario ingresa a la opción de menú Listar perfil
	Y El usuario pulsa el botón Eliminar para el registro con descripción <DescripcionSearch>
	Y El sistema despliega formulario con los campos Descripción y Grupo en modo sólo lectura, y con la siguiente información: <DescripcionSearch>, <Grupo>
	Cuando El usuario pulsa el botón Eliminar
	Y El usuario confirma la eliminación del registro
	Entonces El sistema no despliega en la grilla el registro con la descripción <DescripcionSearch>

@source:M02_Adm.Usuarios.xlsx:ELIMINAR.PERFIL
Ejemplos:
| DescripcionSearch | Grupo |

Esquema del escenario: CP05_Ver Detalle Perfil
	Dado El usuario ingresa a la opción de menú Listar Perfil
	Cuando El usuario pulsa el botón Detalle para el registro con descripción <DescripcionSearch>
	Entonces El sistema despliega un modal con los campos Descripción y Grupo en modo sólo lectura, y con la siguiente información: <DescripcionSearch>, <Grupo>

@source:M02_Adm.Usuarios.xlsx:VER.DETALLE.PERFIL
Ejemplos:
| DescripcionSearch | Grupo |