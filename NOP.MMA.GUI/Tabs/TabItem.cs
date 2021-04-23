using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

        /// <summary>
        /// The <see cref="StackPanel"/> that contains the header <see langword="object"/> for <see langword="this"/> tab
        /// </summary>
        protected StackPanel headerParent;
        /// <summary>
        /// The <see cref="Grid"/> that contains the content <see langword="object"/> for <see langword="this"/> tab
        /// </summary>
        protected Grid contentParent;
        /// <summary>
        /// The header <see cref="Button"/> for <see langword="this"/> tab
        /// </summary>
        protected Button header;
        /// <summary>
        /// The close <see cref="Button"/> for <see langword="this"/> tab
        /// </summary>
        protected Button close;
        /// <summary>
        /// The content <see cref="Grid"/> for <see langword="this"/> tab
        /// </summary>
        protected Grid content;

        /// <summary>
        /// The event that should trigger when the tab header is clicked
        /// </summary>
        public RoutedEventHandler OnClick { get; set; }
        /// <summary>
        /// The even that should trigger when the header close button is clicked
        /// </summary>
        public RoutedEventHandler OnCloseClick { get; set; }
        /// <summary>
        /// The color applied to the header background when the <see cref="ITabItem"/> is focused
        /// </summary>
        public SolidColorBrush HighlightColor { get; set; } = Brushes.White;
        /// <summary>
        /// The color applied to the header background when the <see cref="ITabItem"/> is not focused
        /// </summary>
        public SolidColorBrush DefaultColor { get; set; } = Brushes.Gray;
        public int ID { get; }
        public string Header { get; set; }
        public bool IsVisible { get; protected set; }

        /// <summary>
        /// The internal amount of tabs present in the system that inherits from <see langword="this"/> <see cref="TabItem"/>. (<i><strong>Note:</strong> Use this to assign unique ID's to newly created tabs</i>)
        /// </summary>
        private static int tabCounter = 0;

        public abstract void Construct ( StackPanel _headerArea, Grid _contentArea );

        public virtual void Show ( bool _show = true )
        {
            IsVisible = _show;

            if ( IsVisible )
            {
                header.Background = HighlightColor;
            }
            else
            {
                header.Background = DefaultColor;
            }

            content.Visibility = ( ( _show ) ? ( Visibility.Visible ) : ( Visibility.Collapsed ) );
        }

        public virtual void Close ()
        {
            headerParent.Children.Remove (header);
            headerParent.Children.Remove (close);
            contentParent.Children.Remove (content);
        }

        /// <summary>
        /// Build a <see cref="RowDefinition"/> with a height of <paramref name="_height"/>
        /// </summary>
        /// <param name="_height">The height of the row</param>
        /// <param name="_noMinimum">Whether or not to use the <paramref name="_height"/> as minimum height as well</param>
        /// <returns></returns>
        protected RowDefinition BuildRow ( int _height, int? _minimumHeight = null )
        {
            RowDefinition def = new RowDefinition ()
            {
                Height = new GridLength (_height, GridUnitType.Star),
            };

            if ( _minimumHeight.HasValue )
            {
                def.MinHeight = _minimumHeight.Value;
            }

            return def;
        }

        /// <summary>
        /// Build a <see cref="ColumnDefinition"/> with a width of <paramref name="_width"/>
        /// </summary>
        /// <param name="_width">The width of the column</param>
        /// <param name="_noMinimum">Whether or not to use the <paramref name="_width"/> as minimum width as well</param>
        /// <returns></returns>
        protected ColumnDefinition BuildColumn ( int _width, int? _minimumWidth = null )
        {
            ColumnDefinition def = new ColumnDefinition ()
            {
                Width = new GridLength (_width, GridUnitType.Star),
            };

            if ( _minimumWidth.HasValue )
            {
                def.MinWidth = _minimumWidth.Value;
            }

            return def;
        }

        /// <summary>
        /// Trim the length of <see cref="Header"/> if it's more than 15 characters, and adds 3 dots at the end of the trimmed return value
        /// </summary>
        /// <returns>A new <see cref="string"/> that contains exactly 15 characters, where the last 3 characters are dots '.'</returns>
        protected string BuildHeaderText ()
        {
            string tempHeader = Header;

            if ( tempHeader != null && tempHeader.Length > 15 )
            {
                tempHeader = tempHeader.Remove (15);
                tempHeader += "...";
            }

            return tempHeader;
        }

        /// <summary>
        /// Build the header element that is displayed in the tab minimized section
        /// </summary>
        protected void BuildHeaderElement ()
        {
            header = new Button
            {
                FontWeight = FontWeights.Bold,
                Width = 100,
                MinWidth = 100,
                Content = BuildHeaderText (),
            };

            header.Click += OnClick;

            close = new Button
            {
                FontWeight = FontWeights.Bold,
                Background = Brushes.DarkRed,
                Foreground = Brushes.White,
                Content = "X",
            };

            close.Click += OnCloseClick;

            if ( IsVisible )
            {
                header.Background = Brushes.White;
            }
            else
            {
                header.Background = Brushes.Gray;
            }

            headerParent.Children.Add (header);
            headerParent.Children.Add (close);
        }
    }
}
