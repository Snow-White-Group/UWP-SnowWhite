using System;

public class DefaultUserUseCaseInteractor : IDefaultUserUseCase
{
    private readonly IConfigurationPageService _configurationPageService;
    private readonly IWeatherService _weatherService;

    public void TriggerDefaultUser()
    {
        // load user and weather
        // return data for boundary for presenter (http://i.imgur.com/WkBAATy.png)
    }
}
