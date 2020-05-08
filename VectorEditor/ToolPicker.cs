using System.Collections.Generic;
using System.Windows.Controls;
using System;
using System.Windows;

namespace VectorEditorApplication
{

    public class ToolPicker
    {

        readonly public List<(Tool, Type)> tools;

        public ToolPicker()
        {
            tools = new List<(Tool, Type)>();
        }

        public void AddTool(Tool tool)
        {
            tools.Add((tool, tool.GetType()));
        }

        public void ShowInterface(Panel panel, Type toolType, int index)
        {
            panel.Children.Clear();

            var toolConfigs = toolType.GetProperties();

            foreach (var arg in toolConfigs)
            {
                panel.Children.Add((arg.GetValue(tools[index].Item1) as Config).Configurator);
            }
        }
    }
}
