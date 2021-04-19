using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace NOP.MMA.GUI.Tabs
{
    /// <summary>
    /// Represents a tab <see langword="object"/>
    /// </summary>
    public interface ITabItem
    {
        int ID { get; }
        /// <summary>
        /// The text to display as the tabs header
        /// </summary>
        string Header { get; set; }

        /// <summary>
        /// Returns <see langword="true"/> if the tab is currently displated; Otherwise, if not, <see langword="false"/>
        /// </summary>
        bool IsVisible { get; }

        /// <summary>
        /// Construct the tab <see langword="object"/> based on a <paramref name="_headerArea"/> and a <paramref name="_contentArea"/>
        /// </summary>
        /// <param name="_headerArea">The area that defines the header for the <see cref="ITabItem"/></param>
        /// <param name="_contentArea">The area that defines the content area for <see cref="ITabItem"/></param>
        void Construct ( StackPanel _headerArea, Grid _contentArea );

        /// <summary>
        /// Show or hide the tab content
        /// </summary>
        /// <param name="_show">Whether or not to show or hide the tabs content</param>
        void Show ( bool _show = true );

        /// <summary>
        /// Close the tab
        /// </summary>
        void Close ();
    }
}
