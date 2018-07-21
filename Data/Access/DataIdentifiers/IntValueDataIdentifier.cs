using iStore.Data.Access.DataIdentifiersMeta;

namespace iStore.Data.Access.DataIdentifiers
{
    public class IntValueDataIdentifier : SingleValueDataIdentifier<int>, IIntValueDataIdentifier
    {
        public IntValueDataIdentifier(int id)
        {
            Id = id;
        }
    }
}
