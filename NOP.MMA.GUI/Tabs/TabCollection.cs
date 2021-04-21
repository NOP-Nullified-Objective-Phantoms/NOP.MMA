using NOP.MMA.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.GUI.Tabs
{
    /// <summary>
    /// Defines a <see langword="base"/> for tab collections
    /// </summary>
    internal abstract class TabCollection : ITabCollection
    {
        /// <summary>
        /// Initialize a new instane of type <see cref="TabCollection"/>
        /// </summary>
        public TabCollection ()
        {
            Tabs = new List<ITabItem> ();
        }

        /// <summary>
        /// The collection of <see cref="ITabItem"/> <see langword="objects"/>
        /// </summary>
        protected virtual List<ITabItem> Tabs { get; }

        /// <summary>
        /// Close a specific tab
        /// </summary>
        /// <param name="_tab">The tab to close</param>
        /// <returns><see langword="True"/> if the tab could be closed; Otherwise, if not, <see langword="false"/></returns>
        public abstract bool CloseTab ( ITabItem _tab );

        /// <summary>
        /// Finds and returns the first occurence that matcbes the <paramref name="_predicate"/> result
        /// </summary>
        /// <param name="_predicate">The search terms</param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns>The first occurence that matches the <paramref name="_predicate"/> result; Otherwise, if no <see cref="ITabItem"/> was found, return <see langword="null"/></returns>
        public ITabItem FindTab ( Predicate<ITabItem> _predicate )
        {
            try
            {
                return Tabs.Find (_predicate);
            }
            catch ( ArgumentException _e )
            {
                Debug.LogWarning ($"Attempted search for Null!{Environment.NewLine}{_e}");
            }

            return null;
        }

        public abstract bool MinimizeTab ( ITabItem _tab );

        public abstract bool OpenTab ( ITabItem _tab );
    }
}
