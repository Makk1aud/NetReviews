namespace Domain.Interfaces;

public interface IUserDomainService
{
    public string HashPassword(string password, out byte[] salt);
    
    public bool VerifyPassword(string password, string hashedPassword, byte[] salt);
}