using GamePackStartProjectGodot.Scripts.Model;
using GamePackStartProjectGodot.Scripts.Observer;
using Godot;
using System;
using System.Collections.Generic;

public abstract class MainMenuButtonComponent
{
    public abstract void Operation<T>(int id) where T : Node;
    public abstract MainMenuButtonComponent SetObserverBuilder<T>(List<T> observerList) where T : Node;
    public abstract MainMenuButtonComponent SetObserverBuilder<T>(T observer) where T : Node;
}
public class MainMenuButtonConcreteDecorator : MainMenuButtonComponent
{
    protected List<Node> observerList = new List<Node>();
    protected Node observerTitle = new Node();
    protected MainMenuSubjectConcreteSubject mainMenuSubjectConcreteSubject = new MainMenuSubjectConcreteSubject();
    protected MainMenuConcreteObserver mainMenuConcreteObserver = null;
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