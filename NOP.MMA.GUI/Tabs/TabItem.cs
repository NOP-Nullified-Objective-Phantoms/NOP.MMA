using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace NOP.MMA.GUI.Tabs
{
    /// <summary>
    /// Represents the <see langword="base"/> for all tab elements
    /// </summary>
    internal abstract class TabItem : ITabItem
    {
        /// <summary>
        /// Initialize a new intance of type <see cref="TabItem"/> where the <paramref name="_header"/> is defined
        /// </summary>
        /// <param name="_header">The text to display as header text</param>
        /// <param name="_showContent">Whether or not to display the tab after creation</param>
        public TabItem ( string _header, bool _showContent = true )
        {
            ID = tabCounter++;
            Header = _header;
            IsVisible = _showContent;
        }

        public int ID { get; }
        public string Header { get; set; }
        public bool IsVisible { get; protected set; }

        /// <summary>
        /// The internal amount of tabs present in the system that inherits from <see langword="this"/> <see cref="TabItem"/>. (<i><strong>Note:</strong> Use this to assign unique ID's to newly created tabs</i>)
        /// </summary>
        private static int tabCounter = 0;

        public abstract void Construct ( StackPanel _headerArea, Grid _contentArea );

        public abstract void Show ( bool _show = true );

        public abstract void Close ();
    }
}
