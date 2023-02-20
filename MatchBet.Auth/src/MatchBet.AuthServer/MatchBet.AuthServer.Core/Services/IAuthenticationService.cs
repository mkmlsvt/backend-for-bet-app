using AuthServer.Core.DTOs;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Services
{
    public interface IAuthenticationService
    {
        Task<Response<TokenDTO>>CreateTokenAsync(LoginDTO loginDTO); 
        Task<Response<TokenDTO>>CreateTokenByRefreshToken(string refreshToken); 
        Task<Response<NoDataDto>>RevokeRefreshToken(string refreshToken);
        Response<ClientTokenDTO> CreateTokenByClient(ClientLoginDTO clientLoginDTO);
    }
}
