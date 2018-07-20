using iStore.Core.Meta;
using iStore.Tests.Model.FakeModelMeta;

namespace iStore.Tests.Model.FakeModel
{
    public class FakeModel : IFakeModel, IWithValuesService
    {
        string field;
        
        public void WithValues(params object[] values)
        { 
        }
    }
}
