using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public class MainClient
{    
    public void CreateObjects<T>(Control control, string nodeName, List<T> objectsList) where T : Node
    {        
        var nodes = new List<Node>
        {
            control.GetNode<Node>(nodeName)
        };        
        FindObjects<T>(nodes, objectsList);
    }
    private void FindObjects<T>(List<Node> nodes, List<T> buttons) where T : Node
    {
        if (nodes.Count > 0)
        {
            foreach (var node in nodes)
            {                
                var btn = node as T;
                if (btn is not null)
                {
                    buttons.Add(btn); 
                }                    
                FindObjects<T>(node.GetChildren().ToList(), buttons);
            }
        }
        return;
    }
}