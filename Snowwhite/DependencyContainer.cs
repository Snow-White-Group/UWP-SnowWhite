﻿using Autofac;
using Domain.Boundaries;
using Domain.DefaultUserUseCase;
using Domain.Services;
using ServicesGateways;
using Snowwhite.Services;
using Snowwhite.UseCases.DefaultUserUseCase;

namespace Snowwhite
{
    public class DependencyContainer
    {
        private static IContainer container;

        public static void LaunchApplication()
        {
            RegistrationRoot();
            using (var scope = container.BeginLifetimeScope())
            {
                container.Resolve<IDefaultUserUseCase>().TriggerDefaultUser();
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
            builder.RegisterType<DefaultUserViewModel>().As<IDefaultUserPresenter>().SingleInstance();


            container = builder.Build();
        }
    }
}