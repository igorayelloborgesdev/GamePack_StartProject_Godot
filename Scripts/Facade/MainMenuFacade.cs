using GamePackStartProjectGodot.Scripts.Model;
using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePackStartProjectGodot.Scripts.Facade
{
    public class MainMenuFacade
    {
        public void Init(Control control, MainButtonModel mainButtonModel)
        {
            new MainClient().CreateObjects<Label>(control, mainButtonModel.upperMenuControl_TitleNinePatchRect_TitleLabelNodeName, 
                out mainButtonModel.titleLabel);            
            new MainClient().CreateObjects<Control>(control, mainButtonModel.mainMenuControlsNodeName, mainButtonModel.mainMenuControlsList);
            mainButtonModel.mainMenuControlsList.RemoveAt(0);
            new MainClient().CreateObjects<Button>(control, mainButtonModel.upperMenuControlNodeName, mainButtonModel.mainMenuButtonsList);            
            AssignEventToButton(mainButtonModel.mainMenuButtonsList, new MainMenuButtonConcreteDecorator()
                .SetObserverBuilder<Control>(mainButtonModel.mainMenuControlsList).SetObserverBuilder<Label>(mainButtonModel.titleLabel));            
        }
        private void AssignEventToButton(List<Button> mainMenuButtonsList, MainMenuButtonComponent mainMenuButtonComponent)
        {            
            int count = 0;            
            foreach (var mainMenuButton in mainMenuButtonsList)
            {                
                int countNew = count;                
                mainMenuButton.Pressed += () => { mainMenuButtonComponent.Operation<Button>(countNew); };
                count++;
            }
            mainMenuButtonComponent.Operation<Button>(0);
        }
    }
}
