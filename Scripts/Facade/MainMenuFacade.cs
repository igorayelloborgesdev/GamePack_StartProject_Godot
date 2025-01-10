using GamePackStartProjectGodot.Scripts.Decorator;
using GamePackStartProjectGodot.Scripts.DTO;
using GamePackStartProjectGodot.Scripts.Factory;
using GamePackStartProjectGodot.Scripts.Model;
using GamePackStartProjectGodot.Scripts.Util;
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
        InputConfigSubSystem inputConfigSubSystem;

        public void Init(Control control, MainButtonModel mainButtonModel)
        {
            new MainClient().CreateObjects<Label>(control, mainButtonModel.upperMenuControl_TitleNinePatchRect_TitleLabelNodeName, 
                out mainButtonModel.titleLabel);            
            new MainClient().CreateObjects<Control>(control, mainButtonModel.mainMenuControlsNodeName, mainButtonModel.mainMenuControlsList);
            mainButtonModel.mainMenuControlsList.RemoveAt(0);
            new MainClient().CreateObjects<Button>(control, mainButtonModel.upperMenuControlNodeName, mainButtonModel.mainMenuButtonsList);            
            AssignEventToButton(mainButtonModel.mainMenuButtonsList, new MainMenuButtonConcreteDecorator()
                .SetObserverBuilder<Control>(mainButtonModel.mainMenuControlsList).SetObserverBuilder<Label>(mainButtonModel.titleLabel));
            new MainClient().CreateObjects<Button>(control, mainButtonModel.mainMenuScreenControl_MainMenuScreenControl5_QuitGameButtonName,
                out mainButtonModel.quitGameButton);
            AssignEventToButton(mainButtonModel.quitGameButton, new MainMenuQuitButtonConcreteDecorator()
                .SetObserverBuilder<Control>(control));
            new MainClient().CreateObjects<Button>(control, mainButtonModel.mainMenuScreenControl_MainMenuScreenControl2_LanguageGameButtonName,
                out mainButtonModel.languageGameButton);
            new MainClient().CreateObjects<Button>(control, mainButtonModel.mainMenuScreenControl_MainMenuScreenControl2_InputGameButtonName,
                out mainButtonModel.inputGameButton);
            new MainClient().CreateObjects<Control>(control, mainButtonModel.mainMenuScreenConfigControlName,
                out mainButtonModel.mainMenuScreenConfigControl);
            new MainClient().CreateObjects<Label>(control, mainButtonModel.mainMenuScreenConfigControl_TitleNinePatchRect_TitleLabelName,
                out mainButtonModel.mainMenuScreenConfigControlTitleNinePatchRectTitleLabel);

            new MainClient().CreateObjects<Control>(control, mainButtonModel.mainMenuScreenConfigControlName, mainButtonModel.mainMenuScreenConfigControlList);
            mainButtonModel.mainMenuScreenConfigControlList.RemoveAt(0);

            AssignEventToButton(mainButtonModel.inputGameButton,
                new ConfigButtonConcreteDecorator()
                .SetObserverBuilder<Control>(mainButtonModel.mainMenuScreenConfigControl)
                .SetObserverBuilder<Label>(mainButtonModel.mainMenuScreenConfigControlTitleNinePatchRectTitleLabel)
                .SetObserverBuilder<Control>(mainButtonModel.mainMenuScreenConfigControlList)
                , 0);
            AssignEventToButton(mainButtonModel.languageGameButton,
                new ConfigButtonConcreteDecorator()
                .SetObserverBuilder<Control>(mainButtonModel.mainMenuScreenConfigControl)
                .SetObserverBuilder<Label>(mainButtonModel.mainMenuScreenConfigControlTitleNinePatchRectTitleLabel)
                .SetObserverBuilder<Control>(mainButtonModel.mainMenuScreenConfigControlList)
                , 1);
            new MainClient().CreateObjects<Button>(control, mainButtonModel.mainMenuScreenConfigControl_BackButtonName,
                out mainButtonModel.mainMenuScreenConfigControl_BackButton);            
            AssignEventToButton(mainButtonModel.mainMenuScreenConfigControl_BackButton,
                new ConfigButtonConcreteDecorator()
                .SetObserverBuilder<Control>(mainButtonModel.mainMenuScreenConfigControl));

            mainButtonModel.mainMenuScreenConfigControl.Hide();

            new MainClient().CreateObjects<Label>(control,
                mainButtonModel.mainMenuScreenConfigControl_InputScreenControl,
                mainButtonModel.mainMenuScreenConfigControl_InputScreenControl_ArrayLabel,
                mainButtonModel.mainMenuButtonsConfigLabelList,
                true);

            new MainClient().CreateObjects<Button>(control,
                mainButtonModel.mainMenuScreenConfigControl_InputScreenControl,                
                mainButtonModel.mainMenuButtonsConfigButtonList);

            new MainClient().CreateObjects<Label>(control,
                mainButtonModel.mainMenuScreenConfigControl_InputScreenControl,
                mainButtonModel.mainMenuScreenConfigControl_InputScreenControl_ArrayButton,
                mainButtonModel.mainMenuButtonsConfigButtonLabelList,
                false);

            AssignEventToButton(mainButtonModel.mainMenuButtonsConfigButtonList, new ConfigInputButtonConcreteDecorator()
                .SetObserverBuilder<Label>(mainButtonModel.mainMenuButtonsConfigLabelList, mainButtonModel.mainMenuButtonsConfigButtonLabelList), 
                 mainButtonModel.configDTO);

            new InputConfigClient().CreateObjects(mainButtonModel);
            inputConfigSubSystem = new InputConfigSubSystem().ConfigInputInitBuilder(mainButtonModel);

            new MainClient().CreateObjects<Button>(control, mainButtonModel.mainMenuScreenConfigControl_SaveButtonLabel, 
                out mainButtonModel.mainMenuScreenConfigControl_SaveButton);            
            new MainClient().CreateObjects<Button>(control, mainButtonModel.mainMenuScreenConfigControl_RestoreButtonLabel,
                out mainButtonModel.mainMenuScreenConfigControl_RestoreButton);            

            new MainClient().CreateObjects<Control>(control, mainButtonModel.mainMenuScreenModalControlLabel,
                out mainButtonModel.mainMenuScreenModalControl);
            new MainClient().CreateObjects<Label>(control, mainButtonModel.mainMenuScreenModalControl_ModalScreenControl_Label,
                out mainButtonModel.mainMenuScreenModalControlModalScreenControlLabel);
            new MainClient().CreateObjects<Button>(control, mainButtonModel.mainMenuScreenModalControl_BackButton,
                out mainButtonModel.mainMenuScreenModalControlBackButton);
            new MainClient().CreateObjects<Label>(control, mainButtonModel.mainMenuScreenModalControl_TitleNinePatchRect_TitleLabel,
                out mainButtonModel.mainMenuScreenModalControlTitleNinePatchRectTitleLabel);

            AssignEventToButton(mainButtonModel.mainMenuScreenConfigControl_SaveButton,
                new ConfigButtonSaveConfigConcreteDecorator()
                .SetMainButtonModelBuilder(mainButtonModel));
            AssignEventToButton(mainButtonModel.mainMenuScreenConfigControl_RestoreButton,
                new ConfigButtonRestoreConfigConcreteDecorator()
                .SetMainButtonModelBuilder(mainButtonModel));

            AssignEventToButton(mainButtonModel.mainMenuScreenModalControlBackButton,
                new ConfigButtonModalConfigConcreteDecorator()
                .SetMainButtonModelBuilder(mainButtonModel));
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
        private void AssignEventToButton(Button mainMenuButtons, MainMenuButtonComponent mainMenuButtonComponent)
        {
            mainMenuButtons.Pressed += () => { mainMenuButtonComponent.Operation<Button>(); };            
        }
        private void AssignEventToButton(Button mainMenuButtons, MainMenuButtonComponent mainMenuButtonComponent, int id)
        {
            mainMenuButtons.Pressed += () => { mainMenuButtonComponent.Operation<Button>(id); };
        }
        private void AssignEventToButton(List<Button> mainMenuButtonsList, ConfigButtonComponent configButtonComponent, ConfigDTO configDTO)
        {
            int count = 0;            
            foreach (var mainMenuButton in mainMenuButtonsList)
            {
                int countNew = count;
                mainMenuButton.Pressed += () => { configButtonComponent.Operation<Button>(countNew, configDTO); };
                count++;
            }
            configButtonComponent.Operation<Button>(-1, configDTO);
        }
        public void Update(double delta, MainButtonModel mainButtonModel)
        {                        
            inputConfigSubSystem.ConfigInput(mainButtonModel);
        }
    }
    public class InputConfigSubSystem
    {
        public void ConfigInput(MainButtonModel mainButtonModel)
        {            
            KeyObj keyObj = null;
            if (mainButtonModel.configDTO.isAssign)
            {
                keyObj = KeyboardInput.GetKeyPressed();
                if (keyObj is not null)
                {                    
                    mainButtonModel.configDTO.isAssign = false;
                    mainButtonModel.inputKeyConfgInputConcreteColleague1.Send(keyObj, mainButtonModel.configDTO.idKey);
                }                
            }            
        }
        public InputConfigSubSystem ConfigInputInitBuilder(MainButtonModel mainButtonModel)
        {
            if (ConfigSingleton.saveConfigDTO is null)
            {
                ConfigSingleton.saveConfigDTO = new SaveConfigDTO();
                ConfigSingleton.saveConfigDTO.keysControlArray.AddRange(ConfigDefaultInputs.keysControlArray);
            }
            for (int i = 0; i < ConfigSingleton.saveConfigDTO.keysControlArray.Count; i++)
            {
                mainButtonModel.inputKeyConfgInputConcreteColleague1.Send(ConfigSingleton.saveConfigDTO.keysControlArray[i], i);
            }
            return this;
        }
    }
}
