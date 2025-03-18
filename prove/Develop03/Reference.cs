public class Reference
{
    private string _referenceText;

    public Reference(string referenceText)
    {
        _referenceText = referenceText;
    }

    public override string ToString()
    {
        return _referenceText;
    }
}