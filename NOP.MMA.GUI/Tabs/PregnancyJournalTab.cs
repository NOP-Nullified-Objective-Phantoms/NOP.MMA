using NOP.MMA.Core.Journals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NOP.MMA.GUI.Tabs
{
    /// <summary>
    /// Represents an extended <see cref="TabItem"/> that can hold a reference to a <see cref="IPregnancyJournal"/> context <see langword="object"/>
    /// </summary>
    internal class PregnancyJournalTab : TabItem, ITabItem<IPregnancyJournal>
    {
        /// <summary>
        /// The <see cref="StackPanel"/> that contains the header <see langword="object"/> for <see langword="this"/> tab
        /// </summary>
        private StackPanel headerParent;
        /// <summary>
        /// The <see cref="Grid"/> that contains the content <see langword="object"/> for <see langword="this"/> tab
        /// </summary>
        private Grid contentParent;
        /// <summary>
        /// The header <see cref="Button"/> for <see langword="this"/> tab
        /// </summary>
        private Button header;
        /// <summary>
        /// The close <see cref="Button"/> for <see langword="this"/> tab
        /// </summary>
        private Button close;
        /// <summary>
        /// The content <see cref="Grid"/> for <see langword="this"/> tab
        /// </summary>
        private Grid content;

        /// <summary>
        /// Initialize a new instance of type <see cref="PregnancyJournalTab"/> where the <paramref name="_header"/> text is defined
        /// </summary>
        /// <param name="_header">The text to display as header text</param>
        /// <param name="_showContent">Whether or not to display the tab after creation</param>
        public PregnancyJournalTab ( string _header, bool _showContent = true ) : base (_header, _showContent)
        {

        }

        /// <summary>
        /// The event that should trigger when the tab header is clicked
        /// </summary>
        public RoutedEventHandler OnClick { get; set; }
        /// <summary>
        /// The even that should trigger when the header close button is clicked
        /// </summary>
        public RoutedEventHandler OnCloseClick { get; set; }
        /// <summary>
        /// The associated <see cref="IPregnancyJournal"/> context
        /// </summary>
        public IPregnancyJournal Context { get; set; }
        /// <summary>
        /// The color applied to the header background when the <see cref="ITabItem"/> is focused
        /// </summary>
        public SolidColorBrush HighlightColor { get; set; } = Brushes.White;
        /// <summary>
        /// The color applied to the header background when the <see cref="ITabItem"/> is not focused
        /// </summary>
        public SolidColorBrush DefaultColor { get; set; } = Brushes.Gray;

        private string BuildHeader ()
        {
            string tempHeader = Header;

            if ( tempHeader.Length > 10 )
            {
                tempHeader = tempHeader.Remove (10);
                tempHeader += "...";
            }

            return tempHeader;
        }

        public override void Construct ( StackPanel _headerArea, Grid _contentArea )
        {
            headerParent = _headerArea;
            contentParent = _contentArea;

            if ( header == null )
            {
                header = new Button
                {
                    FontWeight = FontWeights.Bold,
                    Width = 100,
                    MinWidth = 100,
                    Content = BuildHeader (),
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

                _headerArea.Children.Add (header);
                _headerArea.Children.Add (close);
            }

            if ( content == null )
            {
                Grid contentGrid = new Grid ();
                content = contentGrid;

                Label label = new Label ()
                {
                    Content = $"Hello, World!",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,

                };

                content.Children.Add (label);

                content.Visibility = ( ( IsVisible ) ? ( Visibility.Visible ) : ( Visibility.Collapsed ) );
                _contentArea.Children.Add (content);
            }
        }

        public override void Show ( bool _show = true )
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

        public override void Close ()
        {
            headerParent.Children.Remove (header);
            headerParent.Children.Remove (close);
            contentParent.Children.Remove (content);
        }
    }
}
