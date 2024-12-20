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
        #endregion
        #region UI
        public List<Button> mainMenuButtonsList { get; set; } = new List<Button>();
        public List<Control> mainMenuControlsList { get; set; } = new List<Control>();
        public Label titleLabel;
        #endregion
    }
}
