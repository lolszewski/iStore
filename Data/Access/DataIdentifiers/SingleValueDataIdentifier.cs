using iStore.Data.Access.DataIdentifiersMeta;

namespace iStore.Data.Access.DataIdentifiers
{
    public class SingleValueDataIdentifier<T> : ISingleValueDataIdentifier<T>
    {
        protected T Id;

        public T GetId() => Id;

        public void SetId(T id) => Id = id;
    }
}
