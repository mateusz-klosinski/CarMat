using CarMat.Models;
using CarMat.Repositories;
using CarMat.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.Services
{
    public class AuthService : IAuthService
    {
        private SignInManager<CMUser> _signInManager;
        private IUnitOfWork _unitOfWork;
        private UserManager<CMUser> _userManager;

        public AuthService(IUnitOfWork unitOfWork, UserManager<CMUser> userManager, SignInManager<CMUser> signInManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _signInManager = signInManager;
        }




        public async Task<bool> SignInUserAsync(string username, string password)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(username, password, true, false);

            return signInResult.Succeeded;        
        }



        public async Task SignOutUserAsync()
        {
            await _signInManager.SignOutAsync();
        }



        public async Task<IdentityResult> CreateUserAsync(RegisterViewModel model)
        {
            Demographics userDemographics = getExistingDemographics(model);

            if (userDemographics == null)
            {
                userDemographics = createNewDemographics(model);
            }

            CMUser newUser = createNewUser(model, userDemographics);

            var creationResult = await _userManager.CreateAsync(newUser, model.Password);

            return creationResult;
        }


        private static CMUser createNewUser(RegisterViewModel model, Demographics userDemographics)
        {
            return new CMUser
            {
                UserName = model.UserName,
                Email = model.Email,
                Demographics = userDemographics
            };
        }

        private Demographics createNewDemographics(RegisterViewModel model)
        {
            var userProvince = _unitOfWork.Demographics.GetProvinceByName(model.Province);

            return new Demographics
            {
                City = model.City,
                Province = userProvince
            };

        }

        private Demographics getExistingDemographics(RegisterViewModel model)
        {
            return _unitOfWork.Demographics.GetDemographicsByCityAndProvinceName(model.City, model.Province);
        }
    }
}
