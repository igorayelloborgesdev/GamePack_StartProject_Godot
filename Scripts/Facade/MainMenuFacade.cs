using GamePackStartProjectGodot.Scripts.Model;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePackStartProjectGodot.Scripts.Facade
{
    public class MainMenuFacade
    {
        public void Init(Control control, MainButtonModel mainButtonModel)
        {            
            new MainClient().CreateObjects<Button>(control, mainButtonModel.upperMenuControlNodeName, mainButtonModel.mainMenuButtonsList);
            AssignEventToButton(mainButtonModel.mainMenuButtonsList, new MainMenuButtonConcreteDecorator());
        }
        private void AssignEventToButton(List<Button> mainMenuButtonsList, MainMenuButtonComponent mainMenuButtonComponent)
        {
            int count = 0;
            foreach (var mainMenuButton in mainMenuButtonsList)
            {                
                int countNew = count;                
                mainMenuButton.Pressed += () => { mainMenuButtonComponent.Operation(countNew); };
                count++;
            }            
        }
    }
}
