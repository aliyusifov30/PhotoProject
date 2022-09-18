using PhotoProject.Application.DTOs.TokenDTOs;
using PhotoProject.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoProject.Application.Abstractions.Services.TokenServices
{
    public interface ITokenHandler
    {
        Task<TokenDto> CreateAccessToken(AppUser model , int second);
    }
}
