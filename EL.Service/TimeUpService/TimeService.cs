using AutoMapper;
using EL.Domain.Entities;
using EL.Domain.Entities.Time;
using EL.Repository.TimeupRepository;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EL.Service.TimeUpService
{
  public  class TimeService: ITimeService
    {
        private readonly ITimeRepository _timeRepository;
        private readonly ILoggerManager _logger;
        //private readonly IConfiguration _configuration;
        private IMapper _mapper;
        private readonly IOptions<AppSetting> _appSetting;

        public TimeService(ITimeRepository timeRepository, ILoggerManager logger, IOptions<AppSetting> appSetting, IMapper mapper)
        {
            _timeRepository = timeRepository;
            _logger = logger;
            _appSetting = appSetting;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Timeup>> Register(Timeup timeup, string password)
        {
            ServiceResponse<Timeup> serviceResponse = new ServiceResponse<Timeup>();
            try
            {

                if (await UserExists(timeup.Questionname))
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "Username already exist";
                    return serviceResponse;
                }
                //   CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

                // user.PasswordHash = passwordHash;
                //   user.PasswordSalt = passwordSalt;
                timeup.CreatedOn = Convert.ToDateTime( DateTime.Now);

                timeup.TimeStart = Convert.ToDateTime( DateTime.Now.ToShortTimeString());
                timeup.TimeEnd =DateTime.Now.AddHours(1); 

                serviceResponse.Data = await _timeRepository.AddData(timeup);
                serviceResponse.Message = "Registered successfully";
            }
            catch (Exception ex)
            {

                serviceResponse.IsSuccess = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError($"Something went wrong inside Register action: {ex.Message}");
            }

            return serviceResponse;

        }

        public async Task<bool> UserExists(string userName)
        {
            //ServiceResponse<bool> serviceResponse = new ServiceResponse<bool>();

            if (await _timeRepository.GetSingle(u => u.Questionname.ToLower().Equals(userName.ToLower())) != null)
            {
                return true;
            }



            return false;
        }
    }
}
