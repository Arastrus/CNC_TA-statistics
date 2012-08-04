using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Rainbird.Tools.ComInterop
{
    /// <summary>
    /// Allgemeiner Wrapper, um spätgebunden mit COM-Objekten (bzw. ActiveX-Komponenten) zu arbeiten.
    /// </summary>
    public class ComObject : IDisposable
    {
        // COM-Objekt
        private object _realComObject = null;

        /// <summary>
        /// Übernimmt einen vorhanden Verweis auf ein COM-Objekt.
        /// </summary>
        /// <param name="injectedObject">Vorhandenes COM-Objekt</param>
        public ComObject(object injectedObject)
        {
            // Wenn kein Objekt angegeben wurde ...
            if (injectedObject == null)
                // Ausnahme werfen
                throw new ArgumentNullException("injectedObject");

            // Wenn das angegebene Objekt kein COM-Objekt ist ...
            if (!injectedObject.GetType().IsCOMObject)
                // Ausnahme werfen
                throw new ArgumentException("Das angegebene Objekt ist kein COM-Objekt!", "injectedObject");

            // Verweis übernehmen
            _realComObject = injectedObject;
        }

        /// <summary>
        /// Erzeugt ein neues COM-Objekt anhand einer COM ProgId.
        /// </summary>
        /// <param name="progId"></param>
        public ComObject(string progId)
        {
            // Wenn keine ProgId angegeben wurde ...
            if (string.IsNullOrEmpty(progId))
                // Ausnahme werfen
                throw new ArgumentException();

            // Typinformationen über die ProgId ermitteln
            Type comType = Type.GetTypeFromProgID(progId);

            // Wenn keine Typeninformationene gefunden wurden ...
            if (comType == null)
                // Ausnahme werfen
                throw new TypeLoadException(string.Format("Fehler beim Laden der Typinformationen zu ProgId '{0}'.", progId));

            // Instanz erzeugen
            _realComObject = Activator.CreateInstance(comType);
        }

        /// <summary>
        /// Ruft eine Funktion auf, die als Rückgabewert ein COM-Objekt (also keinen primitiven Datentyp) zurückgibt.
        /// </summary>
        /// <param name="functionName">Funktionsname</param>
        /// <param name="parameters">Parameter</param>
        /// <returns>Rückgabeobjekt</returns>
        public ComObject InvokeObjectReturningFunction(string functionName, params object[] parameters)
        {
            // Methode aufrufen
            object result = _realComObject.GetType().InvokeMember(functionName, BindingFlags.InvokeMethod | BindingFlags.OptionalParamBinding, null, _realComObject, parameters);

            // Wenn ein Objekt zurückgegeben wurde ...
            if (result != null)
                // Rückgabeobjekt in Wrapper einpacken und zurückgeben
                return new ComObject(result);

            // Nichts zurückgeben
            return null;
        }

        /// <summary>
        /// Ruft eine Funktion auf.
        /// </summary>
        /// <param name="functionName">Funktionsname</param>
        /// <param name="parameters">Parameter</param>
        /// <returns>Rückgabewert</returns>
        public object InvokeFunction(string functionName, params object[] parameters)
        {
            // Methode aufrufen und Rückgabewert zurückgeben
            return _realComObject.GetType().InvokeMember(functionName, BindingFlags.InvokeMethod | BindingFlags.OptionalParamBinding, null, _realComObject, parameters);
        }

        /// <summary>
        /// Ruft eine Prozedur auf.
        /// </summary>
        /// <param name="procedureName">Prozedurname</param>
        /// <param name="parameters">Parameter</param>
        public void InvokeProcedure(string procedureName, params object[] parameters)
        {
            // Methode aufrufen
            _realComObject.GetType().InvokeMember(procedureName, BindingFlags.InvokeMethod | BindingFlags.OptionalParamBinding, null, _realComObject, parameters);
        }

        /// <summary>
        /// Ruft den Wert einer Eigenschaft ab.
        /// </summary>
        /// <param name="propertyName">Eigenschaftsname</param>
        /// <returns>Rückgabewert</returns>
        public object GetProperty(string propertyName)
        {
            // Methode aufrufen und Rückgabewert zurückgeben
            return _realComObject.GetType().InvokeMember(propertyName, BindingFlags.GetProperty | BindingFlags.OptionalParamBinding, null, _realComObject, new object[0]);
        }

        /// <summary>
        /// Legt den Wert einer Eigenschaft fest.
        /// </summary>
        /// <param name="propertyName">Eigenschaftsname</param>
        /// <param name="parameters">Parameter</param>
        public void SetProperty(string propertyName, object value)
        {
            // Methode aufrufen
            _realComObject.GetType().InvokeMember(propertyName, BindingFlags.OptionalParamBinding | BindingFlags.SetProperty, null, _realComObject, new object[1] { value });
        }

        /// <summary>
        /// Ruft den Wert einer Eigenschaft ab (für Eigenschaften, die Objekte zurückgeben).
        /// </summary>
        /// <param name="propertyName">Eigenschaftsname</param>
        /// <returns>Rückgabeobjekt</returns>
        public ComObject GetObjectReturningProperty(string propertyName)
        {
            // Methode aufrufen und Rückgabewert zurückgeben
            object result = _realComObject.GetType().InvokeMember(propertyName, BindingFlags.GetProperty | BindingFlags.OptionalParamBinding, null, _realComObject, new object[0]);

            // Wenn ein Objekt zurückgegeben wurde ...
            if (result != null)
                // Rückgabeobjekt in Wrapper einpacken und zurückgeben
                return new ComObject(result);

            // Nichts zurückgeben
            return null;
        }

        public ComObject GetObjectReturningProperty(string propertyName, object[] properties)
        {
            // Methode aufrufen und Rückgabewert zurückgeben
            object result = _realComObject.GetType().InvokeMember(propertyName, BindingFlags.GetProperty | BindingFlags.OptionalParamBinding, null, _realComObject, properties);

            // Wenn ein Objekt zurückgegeben wurde ...
            if (result != null)
                // Rückgabeobjekt in Wrapper einpacken und zurückgeben
                return new ComObject(result);

            // Nichts zurückgeben
            return null;
        }

        #region IDisposable Member

        /// <summary>
        /// Verwendete Ressourcen freigeben-
        /// </summary>
        public void Dispose()
        {
            // Wenn das COM-Objekt nocht existiert ...
            if (_realComObject != null)
            {
                // COM-Objekt freigeben und entsorgen
                Marshal.ReleaseComObject(_realComObject);
                _realComObject = null;
            }
        }

        #endregion
    }
}
