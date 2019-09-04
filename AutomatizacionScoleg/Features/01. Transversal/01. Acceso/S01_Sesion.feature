Característica: S01_Sesion
Casos de Prueba para sistema LegalPartner
Macro Proceso Transversal
Proceso Acceso
SubProceso Sesión

@mytag
Esquema del escenario: CP01_Iniciar Sesión
	Dado El sistema despliega formulario de inicio de sesión
	Cuando El usuario ingresa <RutUsuario> y <Password>
	Y El usuario pulsa el botón Log In
	Entonces El sistema despliega página principal del sitio Legal Partner

@source:AccesoData.xlsx
Ejemplos:
| RutUsuario   | Password |

Escenario: CP02_Cerrar Sesión
	Dado El usuario pulsa el botón Cerrar Sesión
	Cuando El usuario confirma el cierre de sesión
	Entonces El sistema despliega formulario de inicio de sesión
