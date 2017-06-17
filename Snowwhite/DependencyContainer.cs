using Autofac;
using Domain.Boundaries;
using Domain.DefaultUserUseCase;
using Domain.Services;
using Domain.StartupUseCase;
using Domain.VoiceUseCases.NoiseDetectedUseCase;
using Domain.VoiceUseCases.TriggerEnrollmentUseCase;
using ServicesGateways;
using ServicesGateways.NoiseDetection;
using Snowwhite.Services;
using Snowwhite.UseCases.DefaultUserUseCase;
using Snowwhite.ViewModels.DefaultUserUseCase;

namespace Snowwhite
{
    using System;

    public class DependencyContainer
    {
        private static IContainer container;

        public static void LaunchApplication()
        {
            RegistrationRoot();
            using (var scope = container.BeginLifetimeScope())
            {
                container.Resolve<IStartupUseCase>().StartApplication();
            }
        }

        public static DefaultUserViewModel LoadDefaultUserViewModel()
        {
            using (var scope = container.BeginLifetimeScope())
            {
               return container.Resolve<DefaultUserViewModel>();
            }
        }

        private static void RegistrationRoot()
        {
            var builder = new ContainerBuilder();
            
            //Services
            builder.RegisterType<WeatherService>().As<IWeatherService>().SingleInstance();
            builder.RegisterType<NewsService>().As<INewsService>().SingleInstance();
            builder.RegisterType<MirrorStateService>().As<IMirrorStateServices>().SingleInstance();
            builder.Register<NavigateService>(
                context =>
                {
                    var navigationService = new NavigateService();
                    navigationService.RegistratePage<DefaultUserViewModel>(typeof(DefaultUserPage));
                    return navigationService;
                }).As<IDeliveryBoundary>().SingleInstance();


            //UseCase DefaultUser
            builder.RegisterType<DefaultUserUseCaseInteractor>().As<IDefaultUserUseCase>().SingleInstance();
            builder.RegisterType<DefaultUserViewModel>()
                .As<IDefaultUserPresenter>()
                .As<INoiseActionPresenter>()
                .As<DefaultUserViewModel>()
                .SingleInstance();

            builder.RegisterType<NoiseDetectionService>().As<INoiseDetectionService>().SingleInstance();
            builder.RegisterType<TempNoiseDetectedInteractor>().As<INoiseDetectedUseCase>().SingleInstance();
            builder.RegisterType<StartupInteractor>().As<IStartupUseCase>().SingleInstance();

            container = builder.Build();
        }
    }
}