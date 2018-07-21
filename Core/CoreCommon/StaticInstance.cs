namespace iStore.Core.CoreCommon
{
    public class StaticInstance<T> where T : new()
    {
        public static readonly T Instance;

        static StaticInstance()
        {
            Instance = new T();
        }
    }
}
