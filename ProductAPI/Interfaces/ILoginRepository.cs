using ProductAPI.Models;

namespace ProductAPI.Interfaces
{
    public interface ILoginRepository
    {
        Task<bool> CheckUserLoginAsync(LoginUserModel loginUser);
    }
}
