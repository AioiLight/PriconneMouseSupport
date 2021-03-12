namespace PriconneMouseSupport
{
    internal static class Util
    {
        internal static string[] GetFunctionsStrings()
        {
            return new string[]
            {
                Properties.Resources.Menu,
                Properties.Resources.Back,
                Properties.Resources.Auto,
                Properties.Resources.Speed
            };
        }

        internal static Functions GetFunctionFromIndex(int index)
        {
            return (Functions)index;
        }
    }
}
