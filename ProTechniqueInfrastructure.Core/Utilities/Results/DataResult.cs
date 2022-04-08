namespace ProTechniqueInfrastructure.Core.Utilities.Results;
public class DataResult<T> : Result, IDataResult<T>
{
    public DataResult(T data, bool success) : base(success)
    {
    }

    public DataResult(T data, bool success, string message) : base(success, message)
    {
        Data = data;
    }

    public T Data { get; }
}