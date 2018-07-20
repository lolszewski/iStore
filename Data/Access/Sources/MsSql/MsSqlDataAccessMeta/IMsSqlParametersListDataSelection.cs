using iStore.Core.Meta;
using iStore.Data.Access.DataAccessMeta;

namespace iStore.Data.Access.Sources.MsSql.MsSqlDataAccessMeta
{
    public interface IMsSqlParametersListDataSelection : IDataSelection, IWithValueService<object[]>
    {
    }
}
