Característica: M01 Transversal_S01 Sesion
	Macro Proceso Transversal
	Proceso Acceso
	SubProceso Sesión

Esquema del escenario: CP01_Iniciar Sesión
	Dado El sistema despliega formulario de inicio de sesión
	Cuando El usuario ingresa el Rut <RutUsuario> y Password <Password>
	Y El usuario pulsa el botón Log In
	Entonces El sistema despliega página principal del sitio Legal Partner

@source:M01_Transversal.xlsx:INICIAR.SESION
Ejemplos:
| RutUsuario   | Password |

Escenario: CP02_Cerrar Sesión
	Dado El usuario pulsa el botón Cerrar Sesión
	Cuando El usuario confirma el cierre de sesión
	Entonces El sistema despliega formulario de inicio de sesión