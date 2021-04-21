using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.GUI.Tabs
{
    /// <summary>
    /// Represents a tab <see langword="object"/> with an associated context <see langword="object"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITabItem<T> : ITabItem
    {
        /// <summary>
        /// The <see langword="object"/> associated with the tab
        /// </summary>
        T Context { get; set; }
    }
}
