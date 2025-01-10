using GamePackStartProjectGodot.Scripts.DTO;
using GamePackStartProjectGodot.Scripts.Mediator;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePackStartProjectGodot.Scripts.Model
{
    public class MainButtonModel
    {
        #region Node Name
        public string upperMenuControlNodeName { get; set; } = "UpperMenuControl";
        public string mainMenuControlsNodeName { get; set; } = "MainMenuScreenControl";
        public string upperMenuControl_TitleNinePatchRect_TitleLabelNodeName { get; set; } = "UpperMenuControl/TitleNinePatchRect/TitleLabel";
        public string mainMenuScreenControl_MainMenuScreenControl5_QuitGameButtonName { get; set; } = "MainMenuScreenControl/MainMenuScreenControl5/QuitGameButton";
        public string mainMenuScreenControl_MainMenuScreenControl2_LanguageGameButtonName { get; set; } = "MainMenuScreenControl/MainMenuScreenControl2/LanguageGameButton";
        public string mainMenuScreenControl_MainMenuScreenControl2_InputGameButtonName { get; set; } = "MainMenuScreenControl/MainMenuScreenControl2/InputGameButton";
        public string mainMenuScreenConfigControlName { get; set; } = "MainMenuScreenConfigControl";
        public string mainMenuScreenConfigControl_BackButtonName { get; set; } = "MainMenuScreenConfigControl/BackButton";
        public string mainMenuScreenConfigControl_TitleNinePatchRect_TitleLabelName { get; set; } = "MainMenuScreenConfigControl/TitleNinePatchRect/TitleLabel";
        public string mainMenuScreenConfigControl_InputScreenControl { get; set; } = "MainMenuScreenConfigControl/InputScreenControl";
        public string[] mainMenuScreenConfigControl_InputScreenControl_ArrayLabel { get; set; } = {
            "InputUpTitleNinePatchRect",
            "InputDownTitleNinePatchRect",
            "InputLeftTitleNinePatchRect",
            "InputRightTitleNinePatchRect",
            "InputButton1TitleNinePatchRect",
            "InputButton2TitleNinePatchRect",
            "InputPauseTitleNinePatchRect"
        };
        public string[] mainMenuScreenConfigControl_InputScreenControl_ArrayButton { get; set; } = {
            "InputUpButton",
            "InputDownButton",
            "InputLeftButton",
            "InputRightButton",
            "InputButton1Button",
            "InputButton2Button",
            "InputPauseButton"
        };
        public string mainMenuScreenConfigControl_SaveButtonLabel { get; set; } = "MainMenuScreenConfigControl/SaveButton";
        public string mainMenuScreenConfigControl_RestoreButtonLabel { get; set; } = "MainMenuScreenConfigControl/RestoreButton";
        public string mainMenuScreenModalControlLabel { get; set; } = "MainMenuScreenModalControl";
        public string mainMenuScreenModalControl_ModalScreenControl_Label { get; set; } = "MainMenuScreenModalControl/ModalScreenControl/Label";
        public string mainMenuScreenModalControl_BackButton { get; set; } = "MainMenuScreenModalControl/BackButton";
        public string mainMenuScreenModalControl_TitleNinePatchRect_TitleLabel { get; set; } = "MainMenuScreenModalControl/TitleNinePatchRect/TitleLabel";
        #endregion
        #region UI
        public List<Button> mainMenuButtonsList { get; set; } = new List<Button>();
        public List<Control> mainMenuControlsList { get; set; } = new List<Control>();
        public Label titleLabel;
        public Button quitGameButton;
        public Button languageGameButton;
        public Button inputGameButton;
        public Control mainMenuScreenConfigControl;
        public Button mainMenuScreenConfigControl_BackButton;
        public Label mainMenuScreenConfigControlTitleNinePatchRectTitleLabel;
        public List<Control> mainMenuScreenConfigControlList { get; set; } = new List<Control>();
        public List<Label> mainMenuButtonsConfigLabelList { get; set; } = new List<Label>();
        public List<Button> mainMenuButtonsConfigButtonList { get; set; } = new List<Button>();
        public List<Label> mainMenuButtonsConfigButtonLabelList { get; set; } = new List<Label>();
        public Button mainMenuScreenConfigControl_SaveButton;
        public Button mainMenuScreenConfigControl_RestoreButton;

        public Control mainMenuScreenModalControl;
        public Label mainMenuScreenModalControlModalScreenControlLabel;
        public Button mainMenuScreenModalControlBackButton;
        public Label mainMenuScreenModalControlTitleNinePatchRectTitleLabel;
        #endregion
        #region Variables
        public ConfigDTO configDTO { get; set; } = new ConfigDTO();
        public ConfgInputConcreteMediator confgInputConcreteMediator = new ConfgInputConcreteMediator();
        public ConfgInputConcreteColleague1 inputKeyConfgInputConcreteColleague1;
        public ConfgInputConcreteColleague2 inputKeyLabelConfgInputConcreteColleague1;
        #endregion
    }
}
