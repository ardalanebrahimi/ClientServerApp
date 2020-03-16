using BusinessLogic;

public class Service : IService
{
    Business _bl;
    public Service()
    {
        _bl = new Business();
    }
    public string ConvertToWord(string input)
    {
        return _bl.ConvertToWord(input);
    }
}
