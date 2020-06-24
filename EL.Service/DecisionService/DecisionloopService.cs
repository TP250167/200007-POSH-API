using AutoMapper;
using EL.Domain.Entities.DecisionloopEntity;
using EL.Repository.DecisionRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EL.Service.DecisionService
{
    public class DecisionloopService : IDecisionloopService
    {
       
        private ILoggerManager _logger;
        private IMapper _mapper;
        private IDecisionloopRepository _decisionloopRepository;


        public DecisionloopService(IDecisionloopRepository decisionloopRepository, ILoggerManager logger, IMapper mapper)
        {
            _decisionloopRepository = decisionloopRepository;
            _logger = logger;
            _mapper = mapper;
        }




      
        public async Task<ServiceResponse<IEnumerable<Decisionloop>>> GetAllDecisionloopAsync()
        {
          
            ServiceResponse<IEnumerable<Decisionloop>> serviceResponse = new ServiceResponse<IEnumerable<Decisionloop>>();
            try
            {
                
                serviceResponse.Data = await _decisionloopRepository.GetAll();
                

            }
            catch (Exception ex)
            {

                serviceResponse.IsSuccess = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError($"Something went wrong inside CreateSchedule action: {ex.Message}");

            }
            return serviceResponse;





        }


        public async Task<ServiceResponse<IEnumerable<Decisionloop>>> GetAllDecisionloopAsynca()
        {

            ServiceResponse<IEnumerable<Decisionloop>> serviceResponse = new ServiceResponse<IEnumerable<Decisionloop>>();
            try
            {

                serviceResponse.Data = await _decisionloopRepository.GetAll();

                var _result = serviceResponse.Data;
                if (_result != null && _result.Count() > 0)
                {
                    var treeList = new List<Decisionloop>();
                    var treechildList = new List<Decisionloop>();
                    foreach (var item in _result)
                    {
                        //if (item. == -1)
                    }
                }



            }
            catch (Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError($"Something went wrong inside CreateSchedule action: {ex.Message}");

            }
            return serviceResponse;

        }







        public async Task<ServiceResponse<Decisionloop>> Createdecisionloop(Decisionloop decisionloop)
        {
            ServiceResponse<Decisionloop> serviceResponse = new ServiceResponse<Decisionloop>();
            try
            {
                //  Complaint complaint1 = new Complaint();
                //we can use AutoMapper here
                //   Complaint sc = _mapper.Map<Complaint>(complaint1);
                serviceResponse.Data = await _decisionloopRepository.AddData(decisionloop);
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


        public async Task<ServiceResponse<Decisionloop>> GetDecisionloopIdAsync(Guid scheduleId)
        {
            ServiceResponse<Decisionloop> serviceResponse = new ServiceResponse<Decisionloop>();
            try
            {
                serviceResponse.Data = await _decisionloopRepository.GetSingle(scheduleId);
               

            }
            catch (Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError($"Something went wrong inside CreateSchedule action: {ex.Message}");


            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<Decisionloop>> GetDecisionloopAnsIdAsync(Guid decisionloopId, string Result, int SubstoryId, int QuestionId)
        {
            ServiceResponse<Decisionloop> serviceResponse = new ServiceResponse<Decisionloop>();
            try
            {
                serviceResponse.Data = await _decisionloopRepository.GetSingle(decisionloopId);

              //var  _result = serviceResponse.Data;
              //  if (_result != null && _result.co() > 0)
              //  {

              //  }

                    if (serviceResponse.Data.Result==Result)
                {
                    serviceResponse.Message = "valid answer"+serviceResponse.Data.Id;
                }
                else if (serviceResponse.Data.Substoryid == Convert.ToInt32(SubstoryId))
                {
                    if (serviceResponse.Data.Result == Result)
                    {
                        serviceResponse.Message = "valid answer  "+"Substoryid:"+ serviceResponse.Data.Substoryid;
                    }

                    //foreach (var sub in SubstoryId)
                    //if (serviceResponse.Data.Result == Result)
                    //{
                    //    serviceResponse.Message = "valid answer"+ serviceResponse.Data.Substoryid;
                    //}
                    //else 
                    //{ }

                }
                    else if(serviceResponse.Data.QuestionId == Convert.ToInt32(QuestionId))
                    {
                    if (serviceResponse.Data.Result == Result)
                    {
                        serviceResponse.Message = "Solution of question  " + "QuestionId:" + serviceResponse.Data.QuestionId;
                    }

                    else { serviceResponse.Message = "Solution of question  " + "QuestionId:" + serviceResponse.Data.QuestionId; }
                }

                else 
                {
                    serviceResponse.Message = "invalid answer"; 

                
                }


            }
            catch (Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError($"Something went wrong inside CreateSchedule action: {ex.Message}");


            }
            return serviceResponse;

        }

        //public async Task<ServiceResponse<Decisionloop>> DeleteDecisionloopIdAsync(int DecisionloopId)
        //{
        //    ServiceResponse<Decisionloop> serviceResponse = new ServiceResponse<Decisionloop>();
        //    try
        //    {
        //        serviceResponse.Data = await _decisionloopRepository.Delete(DecisionloopId);

        //    }
        //    catch (Exception ex)
        //    {
        //        serviceResponse.IsSuccess = false;
        //        serviceResponse.Message = ex.Message;
        //        _logger.LogError($"Something went wrong inside CreateSchedule action: {ex.Message}");


        //    }
        //    return serviceResponse;

        //}


        public async Task<ServiceResponse<Decisionloop>> Updatedecisionloop(Decisionloop decisionloop)
        {
            ServiceResponse<Decisionloop> serviceResponse = new ServiceResponse<Decisionloop>();
            try
            {

               // Decisionloop dl = new Decisionloop();
            //    decisionloop.CreateDate = DateTime.Now;
                ////  Complaint complaint1 = new Complaint();
                ////we can use AutoMapper here
                ////   Complaint sc = _mapper.Map<Complaint>(complaint1);
                // dl.Id =   decisionloop.Id;
                //  decisionloop.MainStoryname = dl.MainStoryname;
                serviceResponse.Data = await _decisionloopRepository.UpdateData(decisionloop);
                serviceResponse.Message = "decisionloop Updated";
            }
            catch (Exception ex)
            {

                serviceResponse.IsSuccess = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError($"Something went wrong inside Createdecisionloop action: {ex.Message}");

            }

            return serviceResponse;

        }

      
    }
}
