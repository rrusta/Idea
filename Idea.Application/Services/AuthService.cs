using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Interfaces;
using RealEstate.Application.ViewModels;
using RealEstate.Domain.IdentityModels;
using RealEstate.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;

    public AuthService(IAuthRepository authRepository, IMapper mapper, UserManager<ApplicationUser> userManager)
    {
        _authRepository = authRepository;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<UserViewModel> Login(LoginViewModel loginViewModel)
    {
        var user = await _authRepository.Login(username: loginViewModel.Username, password: loginViewModel.Password);

        return _mapper.Map<UserViewModel>(user);
    }

    public async Task<UserViewModel> SocialLogin(SocialUserViewModel socialUserViewModel)
    {
        string[] fullName = socialUserViewModel.Name.Split(' ');
        string firstName = "";
        string lastName = "";

        for (int i = 0; i < fullName.Length - 1; i++)
        {
            firstName += fullName[i] + " ";
        }
        firstName = firstName.TrimEnd();
        lastName = fullName[fullName.Length - 1];
        ApplicationUser applicationUser = new ApplicationUser()
        {
            UserName = socialUserViewModel.Email,
            FirstName = firstName,
            Email = socialUserViewModel.Email,
            LastName = lastName,
            CreatedAt = DateTime.Now,
            EmailConfirmed = true
        };

        if (socialUserViewModel.UserTypeId != null)
            applicationUser.UserTypeId = (int)socialUserViewModel.UserTypeId;

        if (socialUserViewModel.AcceptedTerms != null)
            applicationUser.AcceptedTerms = (bool)socialUserViewModel.AcceptedTerms;

        applicationUser.AcceptNewsEmails = socialUserViewModel.AcceptNewsEmails;

        var result = await _authRepository.SocialLogin(applicationUser);

        var userViewModel = _mapper.Map<UserViewModel>(result);

        return userViewModel;
    }

    public async Task<UserViewModel> Register(RegisterUserViewModel registerViewModel)
    {
        ApplicationUser applicationUser = new ApplicationUser()
        {
            UserName = registerViewModel.Email,
            FirstName = registerViewModel.FirstName,
            LastName = registerViewModel.LastName,
            Email = registerViewModel.Email,
            UserTypeId = registerViewModel.UserTypeId,
            AcceptNewsEmails = registerViewModel.AcceptNewsEmails,
            AcceptedTerms = registerViewModel.AcceptedTerms,
            CreatedAt = DateTime.Now
        };

        var user = await _authRepository.Register(applicationUser, registerViewModel.Password);

        return _mapper.Map<UserViewModel>(user);
    }

    public async Task<bool> CheckUserExistsByEmail(string email)
    {
        return await _authRepository.CheckUserExistsByEmail(email);
    }

    public Task<string> GenerateJWToken(UserViewModel user)
    {
        var applicationUser = _mapper.Map<ApplicationUser>(user);
        return _authRepository.GenerateJWToken(applicationUser);
    }


    public async Task<UserViewModel> ForgotPassword(ForgotPasswordViewModel forgotPasswordViewModel)
    {
        var user = await _authRepository.ForgotPassword(email: forgotPasswordViewModel.Email);

        return _mapper.Map<UserViewModel>(user);
    }


    public async Task<UserViewModel> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
    {

        var user = await _authRepository.ResetPassword(email: resetPasswordViewModel.Email, token: resetPasswordViewModel.Token, password: resetPasswordViewModel.Password);


        return _mapper.Map<UserViewModel>(user);
    }


    public async Task<string> VerifyEmail(string username, string code)
    {
        return await _authRepository.VerifyEmail(username, code);
    }

    public async Task<UserViewModel> ForgotPasswordConfirm(ForgotPasswordViewModel forgotPasswordViewModel)
    {
        var user = await _authRepository.ForgotPasswordConfirm(email: forgotPasswordViewModel.Email);

        return _mapper.Map<UserViewModel>(user);
    }

    public async Task<bool> ResendConfirmationEmail(string email)
    {
        return await _authRepository.ResendConfirmationEmail(email);
    }

    public async Task<IEnumerable<UserTypesViewModel>> GetUserTypes()
    {
        return _mapper.Map<IEnumerable<UserTypesViewModel>>(await _authRepository.GetUserTypes());
    }

    public async Task<UserViewModel> RegisterUserDetails(RegisterUserDetailsViewModel registerUserDetailsViewModel)
    {
        var user = await _userManager.FindByIdAsync(registerUserDetailsViewModel.UserId);

        user.UserTypeId = registerUserDetailsViewModel.UserTypeId;
        user.AcceptNewsEmails = registerUserDetailsViewModel.AcceptNewsEmails;
        user.AcceptedTerms = registerUserDetailsViewModel.AcceptedTerms;

        var result = await _authRepository.RegisterUserDetails(user);
        return _mapper.Map<UserViewModel>(result);
    }
}
