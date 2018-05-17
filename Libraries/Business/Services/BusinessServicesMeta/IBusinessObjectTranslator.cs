using iStore.Libraries.Business.Model.BusinessModelMeta;
using iStore.Libraries.Business.Services.BusinessServicesMeta;

namespace iStore.Libraries.Business.Services.BusinessApiMeta
{
    public interface IBusinessObjectTranslator<InputType, OutputType> : IBusinessService 
        where InputType: BusinessObject 
        where OutputType : BusinessObject
    {
        OutputType Translate(InputType input);
    }
}
