namespace Services
{
    public interface IValidPasswordService
    {
        int scoreStrenghPassword(string password);
    }
}