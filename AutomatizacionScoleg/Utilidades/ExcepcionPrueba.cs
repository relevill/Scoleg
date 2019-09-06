using System;

namespace AutomatizacionScoleg.Utilidades
{
   public class ExcepcionPrueba : Exception
    {
        #region Constructor de la clase
        //Constructor de la clase sin parámetros
        public ExcepcionPrueba()
        {
        }

        //Constructor de la clase con un parámetro.
        public ExcepcionPrueba(string message)
        : base(message)
        {
        }

        //Constructor de la clase con dos parámetros.
        public ExcepcionPrueba(string message, Exception inner)
        : base(message, inner)
        {
        }
        #endregion
    }
}

