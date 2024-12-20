using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePackStartProjectGodot.Scripts.Observer
{
    public abstract class MainMenuSubject
    {
        private MainMenuObserver observerTitle = null;
        public void Attach(MainMenuObserver observer)
        {
            observerTitle = observer;
        }        
        public void Notify()
        {
            observerTitle.Update();
        }
    }
    public class MainMenuSubjectConcreteSubject : MainMenuSubject
    {
        private string subjectState;        
        public string SubjectState
        {
            get { return subjectState; }
            set { subjectState = value; }
        }
    }
    public abstract class MainMenuObserver
    {
        public abstract void Update();
    }
    public class MainMenuConcreteObserver : MainMenuObserver
    {
        private Node node = null;
        private MainMenuSubjectConcreteSubject mainMenuSubjectConcreteSubject = null;
        public MainMenuConcreteObserver(Node node, MainMenuSubjectConcreteSubject mainMenuSubjectConcreteSubject)
        {
            this.node = node;
            this.mainMenuSubjectConcreteSubject = mainMenuSubjectConcreteSubject;
        }
        public override void Update()
        {
            var obj = node as Label;
            if (obj != null)
                obj.Text = this.mainMenuSubjectConcreteSubject.SubjectState.ToString();                
        }                
    }
}
