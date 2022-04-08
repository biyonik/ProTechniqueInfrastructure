namespace ProTechniqueInfrastructure.Core.Utilities.Results;
public class SuccessResult : Result
{
    public SuccessResult(bool success) : base(true)
    {
    }

    public SuccessResult(string message) : base(true, message)
    {

    }
}