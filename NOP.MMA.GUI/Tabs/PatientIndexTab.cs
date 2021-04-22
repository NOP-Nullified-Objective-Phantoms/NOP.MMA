using NOP.MMA.Core.Patients;
using NOP.MMA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NOP.MMA.GUI.Tabs
{
    /// <summary>
    /// Represents a <see cref="TabItem"/> that can search through available <see cref="IPatient"/> <see langword="objects"/> and open <see cref="PatientDataTab"/>s
    /// </summary>
    internal class PatientIndexTab : TabItem
    {
        /// <summary>
        /// Initialize a new instance of type <see cref="PatientIndexTab"/> where <paramref name="_header"/> is specified
        /// </summary>
        /// <param name="_header">The header text to display</param>
        /// <param name="_showContent">Whether or not to show the <see cref="TabItem"/> after instantiation</param>
        public PatientIndexTab ( string _header, bool _showContent = true ) : base (_header, _showContent)
        {

        }

        /// <summary>
        /// The <see cref="StackPanel"/> that holds all the search results
        /// </summary>
        private StackPanel searchResults;
        /// <summary>
        /// The searchbar used to search for <see cref="IPatient"/> <see langword="objects"/>
        /// </summary>
        private TextBox searchbar;

        private void BuildContainer ()
        {
            /*
                <Grid.RowDefinitions>
                <RowDefinition Height="25*" MinHeight="25"></RowDefinition>
                <RowDefinition Height="140*" MinHeight="140"></RowDefinition>
                <RowDefinition Height="750*" MinHeight="750"></RowDefinition>
                </Grid.RowDefinitions>
             */
            content = new Grid ();
            content.RowDefinitions.Add (BuildRow (25));
            content.RowDefinitions.Add (BuildRow (140));
            content.RowDefinitions.Add (BuildRow (750));
        }

        private void BuildTabHeader ()
        {

            #region Header
            /*
                <Border Grid.Row="0" VerticalAlignment="Top" HorizontalAlignment="Left" Width="200" BorderBrush="Black" BorderThickness="0,1,1,0" CornerRadius="0,15,0,0" Background="LightGray">
                    <Label Content="Patient Oversigt" FontWeight="Bold" Height="29" HorizontalAlignment="Center"></Label>
                </Border>
             */

            Border border = new Border ()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Width = 200,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness (0, 1, 1, 0),
                CornerRadius = new CornerRadius (0, 15, 0, 0),
                Background = Brushes.LightGray
            };

            Label header = new Label ()
            {
                Content = "Patient Oversigt",
                HorizontalAlignment = HorizontalAlignment.Center,
                FontWeight = FontWeights.Bold,
                Height = 29,
            };

            border.Child = header;

            Grid.SetRow (border, 0);
            content.Children.Add (border);
            #endregion

            #region Close
            /*
                <Border CornerRadius="15,0,0,0" BorderBrush="DarkRed" BorderThickness="6" HorizontalAlignment="Right" >
                    <Button Content="X" Width="20" Background="DarkRed" Foreground="White" BorderThickness="0"></Button>
                </Border>
             */

            Border closeBorder = new Border ()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                BorderBrush = Brushes.DarkRed,
                BorderThickness = new Thickness (6),
                CornerRadius = new CornerRadius (15, 0, 0, 0)
            };

            Button closeButton = new Button ()
            {
                Content = "X",
                Width = 20,
                BorderThickness = new Thickness (0),
                Foreground = Brushes.White,
                Background = Brushes.DarkRed
            };

            closeButton.Click += ( o, e ) =>
            {
                MainWindow.panel.CloseTab (MainWindow.panel.FindTab (item => item.ID == ID));
            };

            closeBorder.Child = closeButton;

            Grid.SetRow (closeBorder, 0);
            content.Children.Add (closeBorder);
            #endregion
        }

        private void BuildContentHeader ()
        {
            /*
                <Border Grid.Row="1" BorderBrush="Black" BorderThickness="0,1,0,0" Background="LightGray">
                    <Label Content="Patient Oversigt" FontWeight="Bold" BorderBrush="Black" BorderThickness="0,0,0,2" FontSize="50" HorizontalAlignment="Center" VerticalAlignment="Center"></Label>
                </Border>
             */

            Border border = new Border ()
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness (0, 1, 0, 0),
                Background = Brushes.LightGray
            };

            Label header = new Label ()
            {
                Content = "Patient Oversigt",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontWeight = FontWeights.Bold,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness (0, 0, 0, 2),
                FontSize = 50,
            };

            border.Child = header;
            Grid.SetRow (border, 1);
            content.Children.Add (border);
        }

        private void BuildSearchArea ()
        {

            /*
                <Border Grid.Row="2" BorderBrush="Black" BorderThickness="0" Background="LightGray">
                    <Grid>

                    </Grid>
                </Border>
             */

            Border outerBorder = new Border ()
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness (0),
                Background = Brushes.LightGray
            };

            Grid.SetRow (outerBorder, 2);

            #region Content Grid
            /*
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="*"></ColumnDefinition>
                    <ColumnDefinition Width="*" MinWidth="600"></ColumnDefinition>
                    <ColumnDefinition Width="*"></ColumnDefinition>
                </Grid.ColumnDefinitions>
                <Grid.RowDefinitions>
                    <RowDefinition Height="5*"></RowDefinition>
                    <RowDefinition Height="15*"></RowDefinition>
                    <RowDefinition Height="5*"></RowDefinition>
                </Grid.RowDefinitions>
             */

            Grid grid = new Grid ();
            grid.ColumnDefinitions.Add (BuildColumn (1));
            grid.ColumnDefinitions.Add (BuildColumn (1, 600));
            grid.ColumnDefinitions.Add (BuildColumn (1));
            grid.RowDefinitions.Add (BuildRow (5));
            grid.RowDefinitions.Add (BuildRow (15));
            grid.RowDefinitions.Add (BuildRow (5));

            outerBorder.Child = grid;
            #endregion

            #region Search Label

            /*
                <Label Grid.Row="0" Grid.Column="1" Content="Søg" FontWeight="Bold" FontSize="30" HorizontalAlignment="Left" VerticalAlignment="Center"></Label>
             */

            Label searchHeader = new Label ()
            {
                Content = "Søg",
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                FontWeight = FontWeights.Bold,
                FontSize = 30
            };

            Grid.SetColumn (searchHeader, 1);
            Grid.SetRow (searchHeader, 0);

            grid.Children.Add (searchHeader);
            #endregion

            #region Searchbar
            /*
                <TextBox Grid.Row="0"  Grid.Column="1" Width="500" Height="50" FontSize="30" TextAlignment="Center" HorizontalAlignment="Right" VerticalAlignment="Center"></TextBox>
             */
            searchbar = new TextBox ()
            {
                TextAlignment = TextAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 500,
                Height = 50,
                FontSize = 30
            };

            searchbar.TextChanged += ( o, e ) =>
            {
                /*
                    <Button Content="123456-7890, Lone Siversen"></Button>
                 */

                searchResults.Children.Clear ();

                if ( !string.IsNullOrWhiteSpace (searchbar.Text) )
                {
                    List<IPatient> patients = PatientRepo.Link.GetEnumerable ().Where (item => item.Name.ToLower ().Contains (searchbar.Text.ToLower ()) || item.SSN.Replace ("-", string.Empty).Contains (searchbar.Text.Replace ("-", string.Empty))).ToList ();

                    foreach ( IPatient patient in patients )
                    {
                        Button displayButton = new Button ()
                        {
                            Content = $"{patient.SSN}, {patient.Name}"
                        };

                        displayButton.Click += ( o, e ) =>
                        {
                            MainWindow.panel.CreatePatientDataTab ($"{patient.SSN}, {patient.Name}", patient);
                            MainWindow.panel.CloseTab (this);
                        };

                        searchResults.Children.Add (displayButton);
                    }
                }
            };

            Grid.SetColumn (searchbar, 1);
            Grid.SetRow (searchbar, 0);

            grid.Children.Add (searchbar);
            #endregion

            #region Search Results
            #region Results Border
            /*
                <Border Grid.Row="1" Grid.RowSpan="2" Grid.Column="0" Grid.ColumnSpan="3" x:Name="searchResultsBorder" Height="600" BorderBrush="Black" BorderThickness="1,1,1,1" Margin="25,0,25,25" Background="White">

                </Border>
            */

            Border resultsBorder = new Border ()
            {
                Height = 600,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness (1, 1, 1, 1),
                Margin = new Thickness (25, 0, 25, 25),
                Background = Brushes.White
            };

            Grid.SetColumn (resultsBorder, 0);
            Grid.SetColumnSpan (resultsBorder, 3);
            Grid.SetRow (resultsBorder, 1);
            Grid.SetRowSpan (resultsBorder, 2);
            #endregion

            #region Scroll
            /*
                <ScrollViewer HorizontalScrollBarVisibility="Disabled" VerticalScrollBarVisibility="Auto">
                        
                </ScrollViewer>
             */
            ScrollViewer scroll = new ScrollViewer ()
            {
                HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto
            };

            resultsBorder.Child = scroll;
            #endregion

            #region Panel
            /*
                <StackPanel x:Name="searchResults" Orientation="Vertical">
                    <StackPanel.Resources>
                        <Style TargetType="{x:Type Button}">
                            <Setter Property="Margin" Value="2,2,2,2"></Setter>
                            <Setter Property="HorizontalContentAlignment" Value="Center"></Setter>
                            <Setter Property="VerticalContentAlignment" Value="Center"></Setter>
                            <Setter Property="FontWeight" Value="Bold"></Setter>
                            <Setter Property="FontStyle" Value="Italic"></Setter>
                            <Setter Property="FontSize" Value="20"></Setter>
                        </Style>
                    </StackPanel.Resources>
                </StackPanel>
             */

            searchResults = new StackPanel ()
            {
                Name = "searchResults",
                Orientation = Orientation.Vertical
            };

            Style panelStyle = new Style (typeof (Button));
            panelStyle.Setters.Add (new Setter (Button.MarginProperty, new Thickness (2, 2, 2, 2)));
            panelStyle.Setters.Add (new Setter (Button.HorizontalAlignmentProperty, HorizontalAlignment.Stretch));
            panelStyle.Setters.Add (new Setter (Button.VerticalAlignmentProperty, VerticalAlignment.Center));
            panelStyle.Setters.Add (new Setter (Button.FontWeightProperty, FontWeights.Bold));
            panelStyle.Setters.Add (new Setter (Button.FontStyleProperty, FontStyles.Italic));
            panelStyle.Setters.Add (new Setter (Button.FontSizeProperty, double.Parse ("20")));

            searchResults.Resources.Add (typeof (Button), panelStyle);
            #endregion

            resultsBorder.Child = searchResults;
            grid.Children.Add (resultsBorder);
            #endregion

            content.Children.Add (outerBorder);
        }

        public override void Construct ( StackPanel _headerArea, Grid _contentArea )
        {
            headerParent = _headerArea;
            contentParent = _contentArea;

            if ( content == null )
            {
                BuildContainer ();

                BuildHeaderElement ();

                BuildTabHeader ();

                BuildContentHeader ();

                BuildSearchArea ();
            }

            _contentArea.Children.Add (content);
        }
    }
}
