using MngBussinessLogicLayer.DTO.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngBussinessLogicLayer.Repository.Interface
{
    public interface IAuth
    {
        Task<string> Register(RegisterDto registerDto);
        Task<string> AdminRegister(RegisterDto registerDto);

        Task<string> Login (LoginDtos loginDto);
    }
}
