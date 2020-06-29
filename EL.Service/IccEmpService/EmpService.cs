using AutoMapper;
using EL.Domain.Entities;
using EL.Domain.Entities.Iccemp;
using EL.Repository.IccEmpRepository;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EL.Service.IccEmpService
{
  public  class EmpService:IEmpService
    {
        private readonly IEmpRepository _empRepository;
        private readonly ILoggerManager _logger;
        //private readonly IConfiguration _configuration;
        private IMapper _mapper;
        private readonly IOptions<AppSetting> _appSetting;

        public EmpService(IEmpRepository empRepository, ILoggerManager logger, IOptions<AppSetting> appSetting, IMapper mapper)
        {
            _empRepository = empRepository;
            _logger = logger;
            _appSetting = appSetting;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Icc>> CreateIccEmp(Icc icc)
        {
            ServiceResponse<Icc> serviceResponse = new ServiceResponse<Icc>();
            try
            {
                //  Complaint complaint1 = new Complaint();
                //we can use AutoMapper here
                //   Complaint sc = _mapper.Map<Complaint>(complaint1);
                serviceResponse.Data = await _empRepository.AddData(icc);
                serviceResponse.Message = "Icc Employee Created";
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
