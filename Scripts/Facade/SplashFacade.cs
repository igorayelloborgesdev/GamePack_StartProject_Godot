using GamePackStartProjectGodot.Scripts.Util;
using Godot;
using System;

public class SplashFacade
{
    public void Init()
    {
        InitConfigDefaultInputs();
        LoadConfig();        
    }
    private void LoadConfig()
    {
        ConfigSingleton.saveConfigDTO = SaveLoad.LoadConfig<SaveConfigDTO>();
    }    
    public void InitConfigDefaultInputs()
    {
        ConfigDefaultInputs.Init();
    }    
}
