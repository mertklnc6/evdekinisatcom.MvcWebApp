﻿using AutoMapper;
using evdekinisatcom.MvcWebApp.DataAccess.Identity.Models;
using evdekinisatcom.MvcWebApp.DataAccess.UnitOfWorks;
using evdekinisatcom.MvcWebApp.Entity.Entities;
using evdekinisatcom.MvcWebApp.Entity.Services;
using evdekinisatcom.MvcWebApp.Entity.UnitOfWorks;
using evdekinisatcom.MvcWebApp.Entity.ViewModels;
using evdekinisatcom.MvcWebApp_App.Entity.Entities;
using evdekinisatcom.MvcWebApp_App.Service.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evdekinisatcom.MvcWebApp.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly ICartService _cartService;
        private readonly IWishlistService _wishlistService;
        private readonly IUnitOfWork _uow;
        public AccountService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, IMapper mapper, ICartService cartService, IUnitOfWork uow, IWishlistService wishlistService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _cartService = cartService;
            _uow = uow;
            _wishlistService = wishlistService;
        }

        public async Task<string> CreateRoleAsync(RoleViewModel model)
        {
            string message = string.Empty;
            var role = new AppRole()
            {
                Name = model.Name,
                Description = model.Description
            };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                message = "OK";
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    message = error.Description;
                }
                //ModelState.AddModelError("", "Rol kayıt işlemi gerçekleşmedi.");
            }
            return message;
        }

        public async Task<string> CreateUserAsync(RegisterViewModel model)
        {
            string message = string.Empty;
            var user = new AppUser()
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                UserName = model.Username,
                Address = model.Address,

            };


            var identityResult = await _userManager.CreateAsync(user, model.ConfirmPassword);

            if (identityResult.Succeeded)
            {
                await _cartService.CreateCartForUserAsync(user.Id);
                var cart = await _cartService.GetCartByUserId(user.Id);
                user.CartId = cart.Id;
                await _wishlistService.CreateWishlistForUserAsync(user.Id);
                var wishlist = await _wishlistService.GetWishlistByUserId(user.Id);
                user.WishlistId = wishlist.Id;
                await _userManager.UpdateAsync(user);

                message = "OK";
            }
            else
            {
                foreach (var error in identityResult.Errors)
                {
                    message = error.Description;
                }
            }
            return message;
        }

        public async Task<string> EditRoleListAsync(EditRoleViewModel model)
        {
            string msg = "OK";
            foreach (var userId in model.UserIdsToAdd ?? new string[] { })
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    var result = await _userManager.AddToRoleAsync(user, model.RoleName);
                    if (!result.Succeeded)
                    {
                        msg = $"{user.UserName} role eklenemedi";

                    }
                }
            }
            foreach (var userId in model.UserIdsToDelete ?? new string[] { })
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    var result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                    if (!result.Succeeded)
                    {
                        msg = $"{user.UserName} rolden çıkarılamadı";
                    }
                }

            }
            return msg;
        }

        public async Task<UserViewModel> Find(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return _mapper.Map<UserViewModel>(user);
        }
        public async Task Update(UserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id.ToString());
            user.Balance = model.Balance;
            user.PhoneNumber = model.PhoneNumber;
            user.Address = model.Address;
            await _userManager.UpdateAsync(user);
        }

        public async Task UpdatePP(ProfileImageViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId.ToString());
            user.ProfilePicUrl = model.ProfileImageUrl;            
            await _userManager.UpdateAsync(user);
        }


        public async Task<RoleViewModel> FindRoleByIdAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            return _mapper.Map<RoleViewModel>(role);
        }

        public async Task<UserViewModel> FindByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return _mapper.Map<UserViewModel>(user);
        }
        public async Task<UserViewModel> FindUserAsync(int id)
        {
            var user = await _uow.GetRepository<AppUser>().GetByIdAsync(u => u.Id == id);
            return _mapper.Map<UserViewModel>(user);
        }

        public async Task<IdentityResult> ChangePasswordAsync(string userId, string oldPassword, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new InvalidOperationException("Kullanıcı bulunamadı.");
            }

            return await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }



        public async Task<string> FindByNameAsync(LoginViewModel model)
        {
            string message = string.Empty;
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                message = "user not found";
                return message;
            }
            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
            if (signInResult.Succeeded)
            {

                message = "OK";
            }
            return message;
        }
        public async Task<List<RoleViewModel>> GetAllRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return _mapper.Map<List<RoleViewModel>>(roles);
        }

        public async Task<List<UserViewModel>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();

            return _mapper.Map<List<UserViewModel>>(users);
        }
        public async Task<UsersInOrOutViewModel> GetAllUsersWithRole(string id)
        {
            var role = await this.FindByIdAsync(id);

            var usersInRole = new List<AppUser>();
            var usersOutRole = new List<AppUser>();

            var users = await _userManager.Users.ToListAsync();

            foreach (var user in users)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    usersInRole.Add(user);  //Bu rolde bulunan kullanıcıların listesi
                }
                else
                {
                    usersOutRole.Add(user); //Bu rolde olmayan kullanıcıların listesi
                }
            }
            UsersInOrOutViewModel model = new UsersInOrOutViewModel()
            {
                Role = _mapper.Map<RoleViewModel>(role),
                UsersInRole = _mapper.Map<List<UserViewModel>>(usersInRole),
                UsersOutRole = _mapper.Map<List<UserViewModel>>(usersOutRole)
            };
            return model;
        }
        public async Task<string> Withdraw(int userId, decimal amount, string iban, string recipientName)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var message = string.Empty;
            if (user.Balance < amount)
            {

                message = "NO";
                
            }
            else
            {
                message = "OK";
                // Bakiyeyi güncelle
                user.Balance -= amount;
                await _userManager.UpdateAsync(user);

                // Çekme işlemini kaydet
                var withdrawal = new Withdraw
                {
                    UserId = user.Id.ToString(),
                    Amount = amount,
                    IBAN = iban,
                    RecipientName = recipientName
                };
                await _uow.GetRepository<Withdraw>().Add(withdrawal);

                await _uow.CommitAsync();

                
            }

            return message;


        }



        public async Task<List<WithdrawViewModel>> GetWithdrawalsByUserId(int userId)
        {
            var list = await _uow.GetRepository<Withdraw>().GetAll(w => w.UserId == userId.ToString());
            var modelList = _mapper.Map<List<WithdrawViewModel>>(list);
            return modelList;
        }


        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();     
        
        }

        
    }


}
