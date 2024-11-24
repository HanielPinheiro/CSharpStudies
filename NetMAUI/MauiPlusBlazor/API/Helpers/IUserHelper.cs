﻿using Microsoft.AspNetCore.Identity;
using Share.DTO;
using Share.Entities;

namespace API.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserAsync(string email);
        
        Task<User> GetUserAsync(Guid userId);

        Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword);
        
        Task<IdentityResult> UpdateUserAsync(User user);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

        Task<SignInResult> LoginAsync(LoginDTO model);

        Task LogoutAsync();

        Task<string> GenerateEmailConfirmationTokenAsync(User user);

        Task<IdentityResult> ConfirmEmailAsync(User user, string token);

        Task<string> GeneratePasswordResetTokenAsync(User user);

        Task<IdentityResult> ResetPasswordAsync(User user, string token, string password);


    }
}