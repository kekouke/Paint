using System.Collections.Generic;
using System.Windows.Controls;
using System;
using System.Windows;

namespace VectorEditorApplication
{

    public class ToolPicker
    {

        private readonly List<(Tool, Type)> _tools;

        private (Tool, Type) _currentTool;

        public ToolPicker()
        {
            _tools = new List<(Tool, Type)>();
        }

        public void AddTool(Tool tool)
        {
            _tools.Add((tool, tool.GetType()));
        }

        public Tool GetSelectedTool()
        {
            return _currentTool.Item1;
        }
        
        public void DisplayInterface(Panel toolPanel, Panel panel)
        {
            toolPanel.Children.Clear();

            _currentTool = _tools[0];

            foreach (var tool in _tools)
            {
                var toolForm = tool.Item1.ToolForm;
                
                if (toolForm != null)
                {
                    (toolForm as Button).AddHandler(Button.ClickEvent, new RoutedEventHandler((s, e) =>
                    {
                        _currentTool = (tool.Item1, tool.Item2);
                        DisplayConfig(panel);
                    }));

                    toolPanel.Children.Add(toolForm);
                }
            }

            DisplayConfig(panel);
        }

        private void DisplayConfig(Panel panel)
        {
            panel.Children.Clear();

            var toolConfigs = _currentTool.Item2.GetProperties();

            foreach (var arg in toolConfigs)
            {
                if (arg.PropertyType.IsSubclassOf(typeof(Config)))
                {
                    panel.Children.Add((arg.GetValue(GetSelectedTool()) as Config)?.Configurator);
                }
            }
        }
    }
}
