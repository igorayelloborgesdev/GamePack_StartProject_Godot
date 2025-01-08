using GamePackStartProjectGodot.Scripts.Model;
using GamePackStartProjectGodot.Scripts.Observer;
using Godot;
using System;
using System.Collections.Generic;

public abstract class MainMenuButtonComponent
{
    public abstract void Operation<T>(int id) where T : Node;
    public abstract void Operation<T>() where T : Node;
    public abstract MainMenuButtonComponent SetObserverBuilder<T>(List<T> observerList) where T : Node;
    public abstract MainMenuButtonComponent SetObserverBuilder<T>(T observer) where T : Node;    
}
public class MainMenuButtonConcreteDecorator : MainMenuButtonComponent
{
    protected List<Node> observerList = new List<Node>();
    protected Node observerTitle = new Node();
    protected MainMenuSubjectConcreteSubject mainMenuSubjectConcreteSubject = new MainMenuSubjectConcreteSubject();    
    public override void Operation<T>(int id)
    {
        foreach (var node in observerList) 
        {
            var obj = node as Control;   
            if (obj != null)
                obj.Hide();            
        }
        var objShow = observerList[id] as Control;
        objShow.Show();
        mainMenuSubjectConcreteSubject.SubjectState = id.ToString();
        mainMenuSubjectConcreteSubject.Notify();
    }
    public override void Operation<T>(){ }
    public override MainMenuButtonComponent SetObserverBuilder<T>(List<T> observerList)
    {
        this.observerList.AddRange(observerList);
        return this;
    }
    public override MainMenuButtonComponent SetObserverBuilder<T>(T observer)
    {
        this.observerTitle = observer;        
        mainMenuSubjectConcreteSubject.Attach(new MainMenuConcreteObserver(this.observerTitle, mainMenuSubjectConcreteSubject));
        return this;
    }
}

public class MainMenuQuitButtonConcreteDecorator : MainMenuButtonComponent
{    
    protected Node observerTitle = new Node();
    protected Control mainMenuSubject;
    public override void Operation<T>(int id){}
    public override void Operation<T>() {
        this.observerTitle.GetTree().Quit();
    }
    public override MainMenuButtonComponent SetObserverBuilder<T>(List<T> observerList)
    {        
        return this;
    }
    public override MainMenuButtonComponent SetObserverBuilder<T>(T observer)
    {
        this.observerTitle = observer;
        return this;
    }
}

public class ConfigButtonConcreteDecorator : MainMenuButtonComponent
{
    protected List<Node> observerList = new List<Node>();
    protected Node observer;
    protected Node observerTitle;
    protected MainMenuSubjectConcreteSubject mainMenuSubjectConcreteSubject = new MainMenuSubjectConcreteSubject();
    public override void Operation<T>(int id)
    {
        foreach (var node in observerList)
        {
            var objControl = node as Control;
            if (objControl != null)
                objControl.Hide();
        }
        var objShow = observerList[id] as Control;
        objShow.Show();
        var obj = observer as Control;
        if (obj != null)
            obj.Show();
        mainMenuSubjectConcreteSubject.SubjectState = id.ToString();
        mainMenuSubjectConcreteSubject.Notify();
    }
    public override void Operation<T>() 
    {
        var obj = observer as Control;
        if (obj != null)
            obj.Hide();
    }
    public override MainMenuButtonComponent SetObserverBuilder<T>(List<T> observerList)
    {
        this.observerList.AddRange(observerList);
        return this;
    }
    public override MainMenuButtonComponent SetObserverBuilder<T>(T observer)
    {        
        var objLabel = observer as Label;
        if (objLabel != null)
        {
            this.observerTitle = observer;
            mainMenuSubjectConcreteSubject.Attach(new MainMenuConcreteObserver(this.observerTitle, mainMenuSubjectConcreteSubject));
            return this;
        }
        var objControl = observer as Control;
        if (objControl != null)
            this.observer = observer;
        return this;
    }
}
