using iStore.Data.Access.DataAccessMeta;

namespace iStore.Data.Access.DataIdentifiersMeta
{
    public interface ISingleValueDataIdentifier<T> : IDataIdentifier 
    {
        void SetId(T id);

        T GetId();

        ISingleValueDataIdentifier<T> WithValue(T id);
    }
}
