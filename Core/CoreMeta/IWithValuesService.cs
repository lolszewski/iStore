namespace iStore.Core.Meta
{
    public interface IWithValuesService<TReturningType> : IService
    {
        TReturningType WithValues(params object[] values);
    }

    public interface IWithValuesService : IService
    {
        void WithValues(params object[] values);
    }
}
