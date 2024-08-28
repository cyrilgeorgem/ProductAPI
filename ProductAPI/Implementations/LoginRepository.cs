using ProductAPI.Interfaces;
using ProductAPI.Models;

namespace ProductAPI.Implementations
{
    public class LoginRepository: ILoginRepository
    {
        public async Task<bool> CheckUserLoginAsync(LoginUserModel loginUser)
        {
			try
			{	
				//Validate user from DB later
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
        }
    }
}
