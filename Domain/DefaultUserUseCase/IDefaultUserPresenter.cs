using System.Collections.Generic;
using Domain.Entities;

namespace Domain.DefaultUserUseCase
{
    public interface IDefaultUserPresenter
    {
        void OnPresent(WeatherData weather, List<News> news);
    }
}