using AuthServer.Core.DTOs;
using AuthServer.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Service
{
    public class DTOMapper:Profile
    {
        public DTOMapper()
        {
            CreateMap<AppUser, AppUserDTO>().ReverseMap();
        }
    }
}
