using AuthServer.Core.Config;
using AuthServer.Core.DTOs;
using AuthServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Services
{
    public interface ITokenService
    {
        TokenDTO CreateToken(AppUser appUser);
        ClientTokenDTO CreateTokenByClient(Client client);
    }
}
