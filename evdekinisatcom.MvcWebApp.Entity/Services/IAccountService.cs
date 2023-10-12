using evdekinisatcom.MvcWebApp.Entity.Entities;
using evdekinisatcom.MvcWebApp.Entity.ViewModels;
using evdekinisatcom.MvcWebApp_App.Service.ViewModels;
using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evdekinisatcom.MvcWebApp.Entity.Services
{
    public interface IAccountService
    {
		Task<string> CreateUserAsync(RegisterViewModel model);

		Task Update(UserViewModel model);

        Task<string> Withdraw(int userId, decimal amount, string iban, string recipientName);
		Task<List<WithdrawViewModel>> GetWithdrawalsByUserId(int userId);



        Task<IdentityResult> ChangePasswordAsync(string userId, string oldPassword, string newPassword);

        Task<string> FindByNameAsync(LoginViewModel model);

		Task<string> CreateRoleAsync(RoleViewModel model);

		Task<List<RoleViewModel>> GetAllRoles();

		Task<RoleViewModel> FindRoleByIdAsync(string id);
		Task<UserViewModel> FindByIdAsync(string id);

		Task<UserViewModel> FindUserAsync(int id);


        Task<List<UserViewModel>> GetAllUsersAsync();


        Task<UsersInOrOutViewModel> GetAllUsersWithRole(string id);

		Task<string> EditRoleListAsync(EditRoleViewModel model);
		Task<UserViewModel> Find(string username);


		Task LogoutAsync();
	}

   
}
