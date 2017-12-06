namespace SAS.Core
{
    public interface IApiMessage<T>
    {
        T Decode(object value);
    }
}
