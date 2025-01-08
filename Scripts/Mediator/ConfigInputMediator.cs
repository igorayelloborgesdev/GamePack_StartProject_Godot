using GamePackStartProjectGodot.Scripts.Decorator;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePackStartProjectGodot.Scripts.Mediator
{    
    public abstract class ConfgInputMediator
    {
        public abstract void Send(KeyObj keyObj,
            ConfgInputColleague colleague);
    }    
    public class ConfgInputConcreteMediator : ConfgInputMediator
    {
        ConfgInputConcreteColleague1 colleague1;
        ConfgInputConcreteColleague2 colleague2;
        public ConfgInputConcreteColleague1 Colleague1
        {
            set { colleague1 = value; }
        }
        public ConfgInputConcreteColleague2 Colleague2
        {
            set { colleague2 = value; }
        }
        public override void Send(KeyObj keyObj, ConfgInputColleague colleague)
        {
            if (colleague == colleague1)
            {
                colleague2.Notify(keyObj);
            }
            else
            {
                colleague1.Notify(keyObj);
            }
        }
    }
    public abstract class ConfgInputColleague
    {
        protected ConfgInputMediator mediator;        
        public ConfgInputColleague(ConfgInputMediator mediator)
        {
            this.mediator = mediator;
        }
    }
    public class ConfgInputConcreteColleague1 : ConfgInputColleague
    {        
        public ConfgInputConcreteColleague1(ConfgInputMediator mediator)
            : base(mediator)
        {
        }
        public void Send(KeyObj keyObj)
        {
            mediator.Send(keyObj, this);
        }
        public void Notify(KeyObj keyObj)
        {
            GD.Print("Colleague1 gets message: "
                + keyObj.keyName);
        }
    }    
    public class ConfgInputConcreteColleague2 : ConfgInputColleague
    {
        protected List<Label> mainMenuButtonsConfigLabelList;
        protected List<Button> mainMenuButtonsConfigButtonList;
        protected List<Label> mainMenuButtonsConfigButtonLabelList;
        public ConfgInputConcreteColleague2(ConfgInputMediator mediator)
            : base(mediator)
        {
        }

        public ConfgInputConcreteColleague2 BuilderMainMenuButtonsConfigLabelList(List<Label> mainMenuButtonsConfigLabelList)
        { 
            this.mainMenuButtonsConfigLabelList = mainMenuButtonsConfigLabelList;
            return this;
        }
        public ConfgInputConcreteColleague2 BuilderMainMenuButtonsConfigButtonList(List<Button> mainMenuButtonsConfigButtonList)
        {
            this.mainMenuButtonsConfigButtonList = mainMenuButtonsConfigButtonList;
            return this;
        }
        public ConfgInputConcreteColleague2 BuilderMainMenuButtonsConfigButtonLabelList(List<Label> mainMenuButtonsConfigButtonLabelList)
        {
            this.mainMenuButtonsConfigButtonLabelList = mainMenuButtonsConfigButtonLabelList;
            return this;
        }
        public void Send(KeyObj keyObj)
        {
            mediator.Send(keyObj, this);
        }
        public void Notify(KeyObj keyObj)
        {
            GD.Print("Colleague2 gets message: "
                + keyObj.keyName);
        }
    }
}
