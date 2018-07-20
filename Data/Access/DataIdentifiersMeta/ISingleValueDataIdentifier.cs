using iStore.Core.Meta;
using iStore.Data.Access.DataAccessMeta;

namespace iStore.Data.Access.DataIdentifiersMeta
{
    public interface ISingleValueDataIdentifier<T> : IDataIdentifier, IWithValueService<T, ISingleValueDataIdentifier<T>>
    {
        void SetId(T id);

        T GetId();
    }
}
