namespace iStore.Core.Meta
{
    public interface IWithValueService<TValueType, TReturningType> : IService
    {
        TReturningType WithValue(TValueType value);
    }

    public interface IWithValueService<TValueType> : IService
    {
        void WithValue(TValueType value);
    }
}
