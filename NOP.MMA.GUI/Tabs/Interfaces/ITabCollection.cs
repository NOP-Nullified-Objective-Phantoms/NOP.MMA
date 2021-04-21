using NOP.Common.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.GUI.Tabs
{
    /// <summary>
    /// Defines a collection of <see cref="ITabItem"/> <see langword="objects"/>
    /// </summary>
    public interface ITabCollection
    {
        /// <summary>
        /// Searches the collection of <see cref="ITabItem"/> <see langword="objects"/> for a specific <see cref="ITabItem"/> and returns it
        /// </summary>
        /// <param name="_predicate">The behaviour to appy when searching</param>
        /// <returns>The first occurence that matches the <paramref name="_predicate"/> criteria</returns>
        ITabItem FindTab ( Predicate<ITabItem> _predicate );
        /// <summary>
        /// Open a new tab
        /// </summary>
        /// <param name="_tab">The tab to open</param>
        /// <returns><see langword="True"/> if the tab could be opened; Otherwise, if not, <see langword="false"/></returns>
        bool OpenTab ( ITabItem _tab );
        /// <summary>
        /// Collapse and hide the tab
        /// </summary>
        /// <param name="_tab">The tab to hide</param>
        /// <returns></returns>
        bool MinimizeTab ( ITabItem _tab );
        /// <summary>
        /// Close an open tab
        /// </summary>
        /// <param name="_tab">The tab to close</param>
        /// <returns><see langword="True"/> if the tab could be closed; Otherwise, if not, <see langword="false"/></returns>
        bool CloseTab ( ITabItem _tab );
    }
}
