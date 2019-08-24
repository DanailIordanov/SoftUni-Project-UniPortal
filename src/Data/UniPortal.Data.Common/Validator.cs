namespace UniPortal.Data.Common
{
    using System;

    public static class Validator
    {
        public static void ThrowIfNull(object argument, string name)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(name);
            }
        }
    }
}
