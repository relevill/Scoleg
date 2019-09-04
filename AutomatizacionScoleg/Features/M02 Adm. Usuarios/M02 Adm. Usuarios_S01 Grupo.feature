Característica: M02 Adm. Usuarios_S01 Grupo
	Macro Proceso Administrador
	Proceso Administrador de usuarios
	SubProceso Grupo

Escenario: CP01_Listar Grupo
Dado El usuario ingresa a la opción de menú Listar Grupos Usuarios
Entonces El sistema despliega una grilla con los registros de grupos existentes en el sistema

Esquema del escenario: CP02_Ingresar Grupo
	Dado El usuario ingresa a la opción de menú Ingresar Grupo Usuarios
	Y El sistema despliega el formulario para ingresar grupo
	Cuando El usuario ingresa la descripción <Descripcion> y selecciona el módulo <Modulo>
	Y El usuario pulsa el botón Registrar
	Y El usuario confirma el ingreso del registro
	Entonces El sistema despliega en la grilla el registro ingresado con la descripción <Descripcion>

@source:M02_Adm.Usuarios.xlsx:INGRESAR.GRUPO
Ejemplos:
| Descripcion | Modulo |

Esquema del escenario: CP03_Editar Grupo
	Dado El usuario ingresa a la opción de menú Listar Grupos Usuarios
	Y El usuario pulsa el botón Detalle para el registro con descripción <DescripcionSearch>
	Y El sistema despliega el formulario para editar grupo y con la siguiente información: descripción <DescripcionSearch>, Módulos <ModuloSearch>
	Cuando El usuario modifica la descripción por <DescripcionEdit> y selecciona el módulo <ModuloEdit>
	Y El usuario pulsa el botón Editar
	Y El usuario confirma a edición del registro
	Entonces El sistema despliega en la grilla el registro modificado con la descripción <DescripcionEdit>

@source:M02_Adm.Usuarios.xlsx:EDITAR.GRUPO
Ejemplos:
| DescripcionSearch | ModuloSearch | DescripcionEdit | ModuloEdit |

Esquema del escenario: CP04_Eliminar Grupo
	Dado El usuario ingresa a la opción de menú Listar Grupos Usuarios
	Y El usuario pulsa el botón Eliminar para el registro con descripción <DescripcionSearch>
	Y El sistema despliega formulario con los campos Descripción y Módulos en modo sólo lectura, y con la siguiente información: <DescripcionSearch>, <Modulos>
	Cuando El usuario pulsa el botón Eliminar
	Y El usuario confirma la eliminación del registro
	Entonces El sistema no despliega en la grilla el registro con la descripción <DescripcionSearch>

@source:M02_Adm.Usuarios.xlsx:ELIMINAR.GRUPO
Ejemplos:
| DescripcionSearch | Modulos |

Esquema del escenario: CP05_Ver Detalle Grupo
	Dado El usuario ingresa a la opción de menú Listar Grupos Usuarios
	Cuando El usuario pulsa el botón Detalle para el registro con descripción <DescripcionSearch>
	Entonces El sistema despliega un modal con los campos Descripción y Módulos en modo sólo lectura, y con la siguiente información: <DescripcionSearch>, <Modulos>

@source:M02_Adm.Usuarios.xlsx:VER.DETALLE.GRUPO
Ejemplos:
| DescripcionSearch | Modulos |
