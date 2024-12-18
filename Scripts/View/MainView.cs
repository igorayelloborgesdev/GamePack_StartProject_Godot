using GamePackStartProjectGodot.Scripts.Controller;
using Godot;
using System;

public partial class MainView : Control
{
    #region Variables
    private MainController mainController = new MainController();
    #endregion
    #region Behavior
    public override void _Ready()
    {
        mainController.Init(this);        
    }    
    #endregion  
}
