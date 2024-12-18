using Godot;
using System;


public abstract class MainMenuButtonComponent
{
    public abstract void Operation(int id);    
}
public class MainMenuButtonConcreteDecorator : MainMenuButtonComponent
{
    public override void Operation(int id)
    {
        GD.Print(id);
    }
}