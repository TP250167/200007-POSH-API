using Autofac;
using EL.Repository;
using EL.Repository.ComplainRepository;
using EL.Repository.DecisionRepository;
using EL.Repository.EmpTeamRepository;
using EL.Repository.IccEmpRepository;
using EL.Repository.poshGameRepository;
using EL.Repository.TimeupRepository;
using EL.Service;
using EL.Service.AuthService;
using EL.Service.ComplainService;
using EL.Service.DecisionService;
using EL.Service.EmpTeamService;
using EL.Service.IccEmpService;
using EL.Service.poshGameService;
using EL.Service.TimeUpService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EL.API
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // The generic ILogger<TCategoryName> service was added to the ServiceCollection by ASP.NET Core.
            // It was then registered with Autofac using the Populate method. All of this starts
            // with the services.AddAutofac() that happens in Program and registers Autofac
            // as the service provider.
            //builder.Register(c => new ValuesService(c.Resolve<ILogger<ValuesService>>()))
            //    .As<IValuesService>()
            //    .InstancePerLifetimeScope();




            #region Register Service & Repository


            builder.RegisterType<ScheduleRepository>().As<IScheduleRepository>();
            builder.RegisterType<ScheduleService>().As<IScheduleService>();


            builder.RegisterType<AuthRepository>().As<IAuthRepository>();
            builder.RegisterType<AuthService>().As<IAuthService>();

            builder.RegisterType<DecisionloopRepository>().As<IDecisionloopRepository>();
            builder.RegisterType<DecisionloopService>().As<IDecisionloopService>();

            builder.RegisterType<TimeRepository>().As<ITimeRepository>();
            builder.RegisterType<TimeService>().As<ITimeService>();

            builder.RegisterType<CompRepository>().As<ICompRepository>();
            builder.RegisterType<CompService>().As<ICompService>();

            builder.RegisterType<EmpRepository>().As<IEmpRepository>();
            builder.RegisterType<EmpService>().As<IEmpService>();

            builder.RegisterType<GameRepository>().As<IGameRepository>();
            builder.RegisterType<GameService>().As<IGameService>();

            builder.RegisterType<TeamRepository>().As<ITeamRepository>();
            builder.RegisterType<TeamService>().As<ITeamService>();

            #endregion
        }
    }
}
