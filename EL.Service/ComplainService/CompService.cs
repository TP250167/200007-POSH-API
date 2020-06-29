using AutoMapper;
using EL.Domain.Entities;
using EL.Domain.Entities.comp;
using EL.Repository.ComplainRepository;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EL.Service.ComplainService
{
  public  class CompService:ICompService
    {
        private readonly ICompRepository _compRepository;
        private readonly ILoggerManager _logger;
        //private readonly IConfiguration _configuration;
        private IMapper _mapper;
        private readonly IOptions<AppSetting> _appSetting;

        public CompService(ICompRepository compRepository, ILoggerManager logger, IOptions<AppSetting> appSetting, IMapper mapper)
        {
            _compRepository = compRepository;
            _logger = logger;
            _appSetting = appSetting;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Complain>> AddComplain(Complain complain)
        {
            ServiceResponse<Complain> serviceResponse = new ServiceResponse<Complain>();
            try
            {
                //  Complaint complaint1 = new Complaint();
                //we can use AutoMapper here
                //   Complaint sc = _mapper.Map<Complaint>(complaint1);
                serviceResponse.Data = await _compRepository.AddData(complain);
                serviceResponse.Message = "Schedule Created";
            }
            catch (Exception ex)
            {

                serviceResponse.IsSuccess = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError($"Something went wrong inside CreateSchedule action: {ex.Message}");

            }

            return serviceResponse;

        }
    }
}
