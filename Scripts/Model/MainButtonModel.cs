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
        #endregion
        #region UI
        public List<Button> mainMenuButtonsList { get; set; } = new List<Button>();
        #endregion
    }
}
