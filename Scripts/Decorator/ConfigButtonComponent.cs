using GamePackStartProjectGodot.Scripts.DTO;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GamePackStartProjectGodot.Scripts.Decorator
{
    public abstract class ConfigButtonComponent
    {
        public abstract void Operation<T>(int id, ConfigDTO configDTO) where T : Node;        
        public abstract ConfigButtonComponent SetObserverBuilder<T>(List<T> inputListLabel, List<T> inputButtonListLabel) where T : Node;        
    }

    public class ConfigInputButtonConcreteDecorator : ConfigButtonComponent
    {
        protected List<Node> inputListLabel = new List<Node>();
        protected List<Node> inputButtonListLabel = new List<Node>();        
        protected string colorNormal = "000000";
        protected string colorSelected = "e7a706";        
        public override void Operation<T>(int id, ConfigDTO configDTO)
        {
            configDTO.idKey = id;            
            SetLabelColor(inputListLabel, colorNormal);
            SetLabelColor(inputButtonListLabel, colorNormal);
            if (configDTO.idKey != -1)
            {
                configDTO.isAssign = true;
                SetLabelColor(inputListLabel[configDTO.idKey], colorSelected);
                SetLabelColor(inputButtonListLabel[configDTO.idKey], colorSelected);
            }                                                
        }
        public override ConfigButtonComponent SetObserverBuilder<T>(List<T> inputListLabel, List<T> inputButtonListLabel)
        {
            this.inputListLabel.AddRange(inputListLabel);
            this.inputButtonListLabel.AddRange(inputButtonListLabel);
            return this;
        }        
        private void SetLabelColor(List<Node> labelList, string colorName)
        {
            foreach (var label in labelList)
            {
                if (label != null)
                {
                    (label as Godot.Label).AddThemeColorOverride("font_color", new Color(colorName));                                        
                }                
            }
        }
        private void SetLabelColor(Node label, string colorName)
        {            
            if (label != null)
            {
                (label as Godot.Label).AddThemeColorOverride("font_color", new Color(colorName));
            }            
        }
    }

    public class ConfigInputButtonKeyConcreteDecorator : ConfigButtonComponent
    {
        protected List<Node> inputListLabel = new List<Node>();        
        protected string colorNormal = "000000";
        protected string colorSelected = "e7a706";
        public override void Operation<T>(int id, ConfigDTO configDTO)
        {
            configDTO.idKeyInput = id;
            SetLabelColor(inputListLabel, colorNormal);            
            if (configDTO.idKeyInput != -1)
            {
                configDTO.isAssign = true;
                SetLabelColor(inputListLabel[configDTO.idKeyInput], colorSelected);
                if(ConfigSingleton.saveConfigDTO is not null)
                    ConfigSingleton.saveConfigDTO.keyboardJoystick = id;
            }
        }
        public override ConfigButtonComponent SetObserverBuilder<T>(List<T> inputListLabel, List<T> inputButtonListLabel)
        {
            this.inputListLabel.AddRange(inputListLabel);            
            return this;
        }
        private void SetLabelColor(List<Node> labelList, string colorName)
        {
            foreach (var label in labelList)
            {
                if (label != null)
                {
                    (label as Godot.Label).AddThemeColorOverride("font_color", new Color(colorName));
                }
            }
        }
        private void SetLabelColor(Node label, string colorName)
        {
            if (label != null)
            {
                (label as Godot.Label).AddThemeColorOverride("font_color", new Color(colorName));
            }
        }
    }

}
