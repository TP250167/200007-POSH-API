using EL.Domain.Entities.DecisionloopEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EL.Service.DecisionService
{
  public  interface IDecisionloopService
    {
         Task<ServiceResponse<IEnumerable<Decisionloop>>> GetAllDecisionloopAsync();
        Task<ServiceResponse<IEnumerable<Decisionloop>>> GetAllDecisionloopAsynca();
        Task<ServiceResponse<Decisionloop>> Createdecisionloop(Decisionloop decisionloop);

        Task<ServiceResponse<Decisionloop>> GetDecisionloopIdAsync(Guid id);
        Task<ServiceResponse<Decisionloop>> GetDecisionloopAnsIdAsync(Guid id, string Result, int SubstoryId, int QuestionId);

        
        Task<ServiceResponse<Decisionloop>> Updatedecisionloop(Decisionloop decisionloop);
        //Task<ServiceResponse<Decisionloop>> DeleteDecisionloopIdAsync(Guid id);


    }
}
