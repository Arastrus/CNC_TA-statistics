using System;
using System.Collections.Generic;
using System.Text;

namespace ErfassungKH.Config
{
  
    public abstract class CnfSettings<T> where T : class // Specify that T must be a class.
    {
        protected static T  _Instance = null;
        protected static object thisLock = new object();


        // Version 
        protected string _Version;
        protected string _Versionwarn = "";
        protected string _FileFullNameIni = ""; 
 
    }
}
