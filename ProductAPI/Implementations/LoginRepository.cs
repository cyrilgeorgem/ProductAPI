using Product.DAL.Entities;
using ProductAPI.Interfaces;
using ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductAPI.Implementations
{
    public class LoginRepository: ILoginRepository
    {
        private AzureFDBContext _azureFDBContext;
        public LoginRepository(AzureFDBContext azureFDBContext)
        {
            _azureFDBContext = azureFDBContext;
        }

        public async Task<bool> CheckUserLoginAsync(LoginUserModel loginUser)
        {
			try
			{
                LoginUserModel? userObj = await (from user in _azureFDBContext.TblDplogins
                                                 where user.UserName.Trim() == loginUser.UserName.Trim()
                                                 && user.Password.Trim() == loginUser.Password.Trim()
                                                 select new LoginUserModel
                                                 {
                                                     UserName = user.UserName,
                                                     Password = user.Password,
                                                 }).FirstOrDefaultAsync();
                if (userObj != null)
                {
                    return true;
                }
                else 
                { 
                    return false;
                }
			}
			catch (Exception ex)
			{
				return false;
			}
        }
    }
}
