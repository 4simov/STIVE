using Core.DTO.Famille;
using Core.DTO.Utilisateur;
using Core.Services.Token;
using Core.UseCase;
using Core.UseCase.Utilisateur;
using Infrastructure.Services.NewFolder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using STIVE.Infrastructure;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.UtilisateurNS
{
    public class Login : BaseUseCase<NegosudContext>, ILogin
    {
        // Permet d'avoir accès aux données de configuration de l'API
        private readonly IConfiguration _configuration;
        private readonly ITokenGenerator _tokenGenerator;

        public Login(IConfiguration configuration, ITokenGenerator tokenGenerator, NegosudContext context) : base(context)
        {
            _configuration = configuration;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<UtilisateurLoginResponse> ExecuteAsync(UtilisateurLoginRequest input)
        {
            var user = _dbContext.Utilisateur
                .Where(u => u.Email == input.Email)
                .AsEnumerable() // Passe du côté client
                .FirstOrDefault(u => MyEncryption.Verify(input.Password, u.Mdp));//CheckPassword(u.Mdp, input.Password));

            //var user = await _dbContext.Utilisateur.FirstOrDefaultAsync( u => u.Email == input.Email && CheckPassword(u.Mdp, input.Password));
            if (user == null) 
            {
                return null;
            }

            var token = _tokenGenerator.GenerateToken(user.Id.ToString(), user.Role.ToString());
            return new UtilisateurLoginResponse { Token = token };
        }
    }
}
