namespace Owasp.SafeNuGet
{
    public static  class ExtensionMethods
    {
        #region Object Extension Methods

        public static bool IsNull(this object  obj)
        {
            return  (obj==null);
        }
        public static bool NotNull (this object obj)
        {
            return (obj != null);
        }
        
        #endregion
    }
}
