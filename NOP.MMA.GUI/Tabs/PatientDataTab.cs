using NOP.MMA.Core.Journals;
using NOP.MMA.Core.Patients;
using NOP.MMA.GUI.ViewModels;
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
    internal class PatientDataTab : TabItem, ITabItem<IPatient>
    {
        /// <summary>
        /// The area where to display the context data
        /// </summary>
        private Grid journalDisplayGrid;

        private PregnancyJournalViewModel pregnancyJournalModel;
        private TravelerJournalViewModel travelerJournalModel;

        /// <summary>
        /// Initialize a new instance of type <see cref="PatientDataTab"/> where the <paramref name="_header"/> is defined
        /// </summary>
        /// <param name="_header">The text to display as header</param>
        /// <param name="_showContent">Whether or not to create the tab open or minimized</param>
        public PatientDataTab ( string _header, bool _showContent = true ) : base (_header, _showContent)
        {

        }

        public IPatient Context { get; set; }

        private void BuildContainer ()
        {
            content = new Grid ();
            content.RowDefinitions.Add (BuildRow (25));
            content.RowDefinitions.Add (BuildRow (140));
            content.RowDefinitions.Add (BuildRow (40));
            content.RowDefinitions.Add (BuildRow (615));
            content.RowDefinitions.Add (BuildRow (85));
        }

        private void BuildPatientDataArea ()
        {
            /*
                <Border Grid.Row="1" BorderBrush="Black" BorderThickness="0,1,0,0" Background="LightGray">
                    <Grid >
                        <!--#region Definitions-->
                        <Grid.RowDefinitions>
                            <RowDefinition></RowDefinition>
                            <RowDefinition></RowDefinition>
                            <RowDefinition></RowDefinition>
                        </Grid.RowDefinitions>
                        <!--#endregion-->

                        <Border Grid.Row="0" BorderBrush="Black" BorderThickness="1,1,1,1" HorizontalAlignment="Left" VerticalAlignment="Center" Margin="25,10,10,10">
                            <TextBlock Width="250">Bob Hansen</TextBlock>
                        </Border>

                        <Border Grid.Row="1"  BorderBrush="Black" BorderThickness="1,1,1,1" HorizontalAlignment="Left" VerticalAlignment="Center" Margin="25,10,10,10">
                            <TextBlock Width="250">Elmegaardvej, 67, 1.tv, 6270 Tønder</TextBlock>
                        </Border>

                        <Border Grid.Row="2"  BorderBrush="Black" BorderThickness="1,1,1,1" HorizontalAlignment="Left" VerticalAlignment="Center" Margin="25,10,10,10">
                            <TextBlock Width="250">Bob Hansen</TextBlock>
                        </Border>
                    </Grid>
                </Border>
             */

            Border gridBorder = new Border ()
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness (0, 1, 0, 0),
                Background = Brushes.LightGray
            };

            Grid patientData = new Grid ();
            patientData.RowDefinitions.Add (BuildRow (1, 1));
            patientData.RowDefinitions.Add (BuildRow (1, 1));
            patientData.RowDefinitions.Add (BuildRow (1, 1));

            gridBorder.Child = patientData;

            #region Name
            Border nameBorder = new Border ()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness (1, 1, 1, 1),
                Margin = new Thickness (25, 10, 10, 10)
            };

            TextBlock nameText = new TextBlock ()
            {
                Text = Context.Name,
                Width = 250,
            };

            nameBorder.Child = nameText;
            #endregion

            #region Address
            Border addressBorder = new Border ()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness (1, 1, 1, 1),
                Margin = new Thickness (25, 10, 10, 10)
            };

            TextBlock addressText = new TextBlock ()
            {
                Text = Context.Address,
                Width = 250,
            };

            addressBorder.Child = addressText;
            #endregion

            #region Phone
            Border phoneBorder = new Border ()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness (1, 1, 1, 1),
                Margin = new Thickness (25, 10, 10, 10)
            };

            TextBlock phoneText = new TextBlock ()
            {
                Text = Context.PrivatePhone,
                Width = 250,
            };

            phoneBorder.Child = phoneText;
            #endregion

            patientData.Children.Add (nameBorder);
            patientData.Children.Add (addressBorder);
            patientData.Children.Add (phoneBorder);

            Grid.SetRow (nameBorder, 0);
            Grid.SetRow (addressBorder, 1);
            Grid.SetRow (phoneBorder, 2);

            content.Children.Add (gridBorder);
            Grid.SetRow (gridBorder, 1);
        }

        private void BuildContentHeaderArea ( string _headertext )
        {
            #region Tab Header
            /*
                <Border Grid.Row="0" VerticalAlignment="Top" HorizontalAlignment="Left" Width="200" BorderBrush="Black" BorderThickness="0,1,1,0" CornerRadius="0,15,0,0" Background="LightGray">
                    <Label Content="123456-7890, Hansen, Bob" FontWeight="Bold" HorizontalAlignment="Center"></Label>
                </Border>
             */

            Border headerBorder = new Border ()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Width = 200,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness (0, 1, 1, 0),
                CornerRadius = new CornerRadius (0, 15, 0, 0),
                Background = Brushes.LightGray
            };

            Label headerText = new Label ()
            {
                Content = _headertext,
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            headerBorder.Child = headerText;
            #endregion

            #region tab Close Button
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
                Background = Brushes.DarkRed,
                Foreground = Brushes.White,
                BorderThickness = new Thickness (0)
            };

            closeButton.Click += ( o, e ) =>
            {
                MainWindow.panel.CloseTab (MainWindow.panel.FindTab (item => item.ID == ID));
            };

            closeBorder.Child = closeButton;
            #endregion

            content.Children.Add (headerBorder);
            content.Children.Add (closeBorder);

            Grid.SetRow (headerBorder, 0);
            Grid.SetRow (closeButton, 0);
        }

        private void BuildNavBarArea ()
        {
            /*
                <Border Grid.Row="2" BorderBrush="Black" BorderThickness="0" HorizontalAlignment="Stretch" VerticalAlignment="Stretch" Background="LightGray">
                    <StackPanel Orientation="Horizontal" HorizontalAlignment="Left" Margin="25,0,0,0">
                        <StackPanel.Resources>
                            <Style TargetType="{x:Type Button}">
                                <Setter Property="Width" Value="100"></Setter>
                                <Setter Property="HorizontalAlignment" Value="Stretch"></Setter>
                                <Setter Property="VerticalAlignment" Value="Stretch"></Setter>
                                <Setter Property="BorderThickness" Value="6"></Setter>
                                <Setter Property="BorderBrush" Value="LightGray"></Setter>
                            </Style>
                        </StackPanel.Resources>

                        <Border CornerRadius="15,15,0,0" BorderBrush="Black" BorderThickness="1" HorizontalAlignment="Right">
                            <Border CornerRadius="15,15,0,0" BorderBrush="LightGray" BorderThickness="6" HorizontalAlignment="Right" >
                                <Button Content="Svangerskabs Journal" FontWeight="Bold" Width="250" Background="LightGray" Foreground="Black" BorderThickness="0"></Button>
                            </Border>
                        </Border>
                        <Border CornerRadius="15,15,0,0" BorderBrush="Black" BorderThickness="1" HorizontalAlignment="Right">
                            <Border CornerRadius="15,15,0,0" BorderBrush="LightGray" BorderThickness="6" HorizontalAlignment="Right" >
                                <Button Content="Vandre Journal" FontWeight="Bold" Width="250" Background="LightGray" Foreground="Black" BorderThickness="0"></Button>
                            </Border>
                        </Border>
                    </StackPanel>
                </Border>
             */

            Border outerBorder = new Border ()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness (0),
                Background = Brushes.LightGray
            };

            #region Panel
            StackPanel panel = new StackPanel ()
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness (25, 0, 0, 0)
            };

            Style panelStyle = new Style (typeof (Button));
            panelStyle.Setters.Add (new Setter (Button.WidthProperty, double.Parse ("100")));
            panelStyle.Setters.Add (new Setter (Button.HorizontalAlignmentProperty, HorizontalAlignment.Stretch));
            panelStyle.Setters.Add (new Setter (Button.VerticalAlignmentProperty, VerticalAlignment.Stretch));
            panelStyle.Setters.Add (new Setter (Button.BorderBrushProperty, Brushes.LightGray));
            panelStyle.Setters.Add (new Setter (Button.BorderThicknessProperty, new Thickness (6)));

            panel.Resources.Add (typeof (Button), panelStyle);

            outerBorder.Child = panel;
            #endregion

            #region Preggo Button
            Border preggoButtonOuterBorder = new Border ()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness (1),
                CornerRadius = new CornerRadius (15, 15, 0, 0)
            };

            Border preggoButtonInnerBorder = new Border ()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                BorderBrush = Brushes.LightGray,
                BorderThickness = new Thickness (6),
                CornerRadius = new CornerRadius (15, 15, 0, 0)
            };

            Button preggoButton = new Button ()
            {
                Content = "Svangerskabsjournal",
                FontWeight = FontWeights.Bold,
                Width = 250,
                Background = Brushes.LightGray,
                Foreground = Brushes.Black,
                BorderThickness = new Thickness (0)
            };

            preggoButton.Click += ( o, e ) =>
            {
                travelerJournalModel = null;
                IPregnancyJournal journal = PregnancyJournalRepo.Link.GetEnumerable ().ToList ().Find (item => item.PatientData.ID == Context.ID);

                if ( journal != null )
                {
                    SetJournalModel (journal);

                    BuildPregnancyJournalDisplay ();
                    return;
                }

                ClearDisplay (journalDisplayGrid);

                journalDisplayGrid.Children.Add (BuildCreateJournalButton ("Tilføj Svangerskabsjournal", JournalType.PregnancyJournal));
            };

            preggoButtonInnerBorder.Child = preggoButton;
            preggoButtonOuterBorder.Child = preggoButtonInnerBorder;
            panel.Children.Add (preggoButtonOuterBorder);
            #endregion

            #region Traveler Button
            Border travelerButtonOuterBorder = new Border ()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness (1),
                CornerRadius = new CornerRadius (15, 15, 0, 0)
            };

            Border travelerButtonInnerBorder = new Border ()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                BorderBrush = Brushes.LightGray,
                BorderThickness = new Thickness (6),
                CornerRadius = new CornerRadius (15, 15, 0, 0)
            };

            Button travelerButton = new Button ()
            {
                Content = "Vandrejournal",
                FontWeight = FontWeights.Bold,
                Width = 250,
                Background = Brushes.LightGray,
                Foreground = Brushes.Black,
                BorderThickness = new Thickness (0)
            };

            travelerButton.Click += ( o, e ) =>
            {
                pregnancyJournalModel = null;
                ITravelerJournal journal = TravelerJournalRepo.Link.GetEnumerable ().ToList ().Find (item => item.PatientData.ID == Context.ID);

                if ( journal != null )
                {
                    SetJournalModel (journal);

                    BuildTravelerJournalDisplay ();
                    return;
                }

                ClearDisplay (journalDisplayGrid);

                journalDisplayGrid.Children.Add (BuildCreateJournalButton ("Tilføj Vandrejournal", JournalType.TravelerJournal));
            };

            travelerButtonInnerBorder.Child = travelerButton;
            travelerButtonOuterBorder.Child = travelerButtonInnerBorder;
            panel.Children.Add (travelerButtonOuterBorder);
            #endregion

            content.Children.Add (outerBorder);
            Grid.SetRow (outerBorder, 2);
        }

        private void BuildContentArea ()
        {
            /*
                <Border Grid.Row="3" BorderBrush="Black" BorderThickness="0" Background="LightGray">
                    <Border Grid.Row="3" BorderBrush="Black" BorderThickness="1,1,1,1" Background="White" Margin="25,0,25,0">
                        <Grid x:Name="navTabContentContainer">

                        </Grid>
                    </Border>
                </Border>
             */

            Border outerBorder = new Border ()
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness (0),
                Background = Brushes.LightGray
            };

            Border innerBorder = new Border ()
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness (1),
                Background = Brushes.White,
                Margin = new Thickness (25, 0, 25, 0)
            };


            journalDisplayGrid = new Grid ()
            {
                Height = 600
            };

            innerBorder.Child = journalDisplayGrid;
            outerBorder.Child = innerBorder;
            content.Children.Add (outerBorder);
            Grid.SetRow (outerBorder, 3);
        }

        private void BuildButtonPanel ()
        {
            /*
                <Border Grid.Row="4" BorderBrush="Black" BorderThickness="0" Background="LightGray">
                    <Grid>
                        <StackPanel Orientation="Horizontal" Background="LightGray" HorizontalAlignment="Left" VerticalAlignment="Center">
                            <Button Content="Delete" FontWeight="Bold" Width="100" Height="25" HorizontalAlignment="Left" VerticalAlignment="Center" Background="LightGray" Foreground="Black" BorderThickness="2" Margin="25,0,0,0"></Button>
                        </StackPanel>

                        <StackPanel Orientation="Horizontal" Background="LightGray" HorizontalAlignment="Right" VerticalAlignment="Center">
                            <Button Content="Save" FontWeight="Bold" Width="100" Height="25" HorizontalAlignment="Left" VerticalAlignment="Center" Background="LightGray" Foreground="Black" BorderThickness="2" Margin="0,0,25,0"></Button>
                            <Button Content="Print" FontWeight="Bold" Width="100" Height="25" HorizontalAlignment="Left" VerticalAlignment="Center" Background="LightGray" Foreground="Black" BorderThickness="2" Margin="0,0,25,0"></Button>
                        </StackPanel>
                    </Grid>
                </Border>
             */

            Border outerBorder = new Border ()
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness (0),
                Background = Brushes.LightGray
            };

            Grid grid = new Grid ();

            #region Left Panel
            StackPanel leftPanel = new StackPanel ()
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                Background = Brushes.LightGray
            };

            Button deleteButton = new Button ()
            {
                Content = "Slet",
                FontWeight = FontWeights.Bold,
                Width = 100,
                Height = 25,
                Background = Brushes.LightGray,
                Foreground = Brushes.Black,
                BorderThickness = new Thickness (2),
                Margin = new Thickness (25, 0, 0, 0)
            };

            deleteButton.Click += ( o, e ) =>
            {
                if ( pregnancyJournalModel != null )
                {
                    IPregnancyJournal journal = PregnancyJournalRepo.Link.GetDataByIdentifier (pregnancyJournalModel.ID);
                    PregnancyJournalRepo.Link.DeleteData (journal);

                    ClearDisplay (journalDisplayGrid);
                    journalDisplayGrid.Children.Add (BuildCreateJournalButton ("Tilføj Svangerskabsjournal", JournalType.PregnancyJournal));
                }
                else if ( travelerJournalModel != null )
                {
                    ITravelerJournal journal = TravelerJournalRepo.Link.GetDataByIdentifier (travelerJournalModel.ID);
                    TravelerJournalRepo.Link.DeleteData (journal);

                    ClearDisplay (journalDisplayGrid);
                    journalDisplayGrid.Children.Add (BuildCreateJournalButton ("Tilføj Vandrejournal", JournalType.TravelerJournal));
                }
            };

            leftPanel.Children.Add (deleteButton);
            grid.Children.Add (leftPanel);
            #endregion

            #region Right Panel
            StackPanel rightPanel = new StackPanel ()
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Center,
                Background = Brushes.LightGray
            };

            Button saveButton = new Button ()
            {
                Content = "Gem",
                FontWeight = FontWeights.Bold,
                Width = 100,
                Height = 25,
                Background = Brushes.LightGray,
                Foreground = Brushes.Black,
                BorderThickness = new Thickness (2),
                Margin = new Thickness (0, 0, 25, 0)
            };

            Button printButton = new Button ()
            {
                Content = "Print",
                FontWeight = FontWeights.Bold,
                Width = 100,
                Height = 25,
                Background = Brushes.LightGray,
                Foreground = Brushes.Black,
                BorderThickness = new Thickness (2),
                Margin = new Thickness (0, 0, 25, 0)
            };

            rightPanel.Children.Add (saveButton);
            rightPanel.Children.Add (printButton);
            grid.Children.Add (rightPanel);
            #endregion

            outerBorder.Child = grid;

            content.Children.Add (outerBorder);
            Grid.SetRow (outerBorder, 4);
        }

        private void BuildPregnancyJournalDisplay ()
        {
            ClearDisplay (journalDisplayGrid);

            ScrollViewer scroll = new ScrollViewer ()
            {
                HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto
            };

            #region Display Grid
            Grid display = new Grid ();
            display.RowDefinitions.Add (BuildRow (1, 40));
            display.RowDefinitions.Add (BuildRow (4, 160));
            display.RowDefinitions.Add (BuildRow (5, 200));
            display.RowDefinitions.Add (BuildRow (4, 160));
            display.RowDefinitions.Add (BuildRow (5, 200));
            display.RowDefinitions.Add (BuildRow (21, 840));
            display.RowDefinitions.Add (BuildRow (3, 120));
            display.RowDefinitions.Add (BuildRow (12, 240));
            #endregion

            scroll.Content = display;

            #region Header
            Label headerText = new Label ()
            {
                Content = "Svangerskabsjournal",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                FontWeight = FontWeights.Bold,
                FontSize = 20,
            };

            Grid.SetRow (headerText, 0);
            display.Children.Add (headerText);
            #endregion

            #region Patient Data Area
            Grid patientDataGrid = new Grid ();
            patientDataGrid.RowDefinitions.Add (BuildRow (1, 40));
            patientDataGrid.RowDefinitions.Add (BuildRow (1, 40));
            patientDataGrid.RowDefinitions.Add (BuildRow (1, 40));
            patientDataGrid.RowDefinitions.Add (BuildRow (1, 40));
            patientDataGrid.ColumnDefinitions.Add (BuildColumn (1));
            patientDataGrid.ColumnDefinitions.Add (BuildColumn (1));
            Border patientDataAreaBorder = new Border ()
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness (1, 1, 1, 1),
                Margin = new Thickness (10, 0, 10, 0)
            };

            patientDataAreaBorder.Child = patientDataGrid;

            Grid.SetRow (patientDataAreaBorder, 1);
            display.Children.Add (patientDataAreaBorder);

            #region Left Column
            patientDataGrid.Children.Add (BuildTextFieldCell ("Personnummer, Navn", $"{pregnancyJournalModel.PatientData.SSN}, {pregnancyJournalModel.PatientData.Name}", CellLocation.TopLeft, 0, 0));
            patientDataGrid.Children.Add (BuildTextFieldCell ("Addresse", pregnancyJournalModel.PatientData.Address, CellLocation.MiddleLeft, 1, 0));
            patientDataGrid.Children.Add (BuildTextFieldCell ("Email", pregnancyJournalModel.PatientData.Email, CellLocation.MiddleLeft, 2, 0));

            Grid phoneArea = new Grid ();
            phoneArea.ColumnDefinitions.Add (BuildColumn (1));
            phoneArea.ColumnDefinitions.Add (BuildColumn (1));

            phoneArea.Children.Add (BuildTextFieldCell ("Tlf. Privat/Mobil", pregnancyJournalModel.PatientData.PrivatePhone, CellLocation.BottomLeft, 0, 0));
            phoneArea.Children.Add (BuildTextFieldCell ("Tlf. Arbejde", pregnancyJournalModel.PatientData.WorkPhone, CellLocation.BottomLeft, 0, 1));

            Grid.SetRow (phoneArea, 3);
            Grid.SetColumn (phoneArea, 0);
            patientDataGrid.Children.Add (phoneArea);
            #endregion

            #region Right Column
            patientDataGrid.Children.Add (BuildTextFieldCell ("Lægens Navn", pregnancyJournalModel.PatientData.DoctorsName, CellLocation.TopMiddle, 0, 1));
            patientDataGrid.Children.Add (BuildTextFieldCell ("Lægens Adresse", pregnancyJournalModel.PatientData.DoctorsAddress, CellLocation.TopMiddle, 1, 1));
            patientDataGrid.Children.Add (BuildTextFieldCell ("Lægens Email", string.Empty, CellLocation.TopMiddle, 2, 1));
            patientDataGrid.Children.Add (BuildTextFieldCell ("Lægens Tlf.", pregnancyJournalModel.PatientData.DoctorsPhone, CellLocation.BottomMiddle, 3, 1));
            #endregion
            #endregion

            #region Social Info
            Grid socialInfoGrid = new Grid ();
            socialInfoGrid.RowDefinitions.Add (BuildRow (1, 40));
            socialInfoGrid.RowDefinitions.Add (BuildRow (1, 40));
            socialInfoGrid.RowDefinitions.Add (BuildRow (1, 40));
            socialInfoGrid.RowDefinitions.Add (BuildRow (1, 40));

            Border socialInfoBorder = new Border ()
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness (1, 1, 1, 1),
                Margin = new Thickness (10, 10, 10, 0)
            };

            socialInfoBorder.Child = socialInfoGrid;

            Grid.SetRow (socialInfoBorder, 2);
            display.Children.Add (socialInfoBorder);


            #region Civil Status
            Grid civilStatusGrid = new Grid ();
            civilStatusGrid.RowDefinitions.Add (BuildRow (1));
            civilStatusGrid.RowDefinitions.Add (BuildRow (1));
            civilStatusGrid.ColumnDefinitions.Add (BuildColumn (1));
            civilStatusGrid.ColumnDefinitions.Add (BuildColumn (2));
            civilStatusGrid.ColumnDefinitions.Add (BuildColumn (3));

            Grid.SetRow (civilStatusGrid, 0);
            Grid.SetColumn (civilStatusGrid, 0);
            Grid.SetRowSpan (civilStatusGrid, 2);
            socialInfoGrid.Children.Add (civilStatusGrid);

            UIElement civilStatusLabel = BuildListItemCell ("Civilstand", CellLocation.TopLeft, 0, 0, true, true, 20);
            Grid.SetRowSpan (civilStatusLabel, 2);
            civilStatusGrid.Children.Add (civilStatusLabel);

            #region Civil Status Values
            Grid civilStatusValueGrid = new Grid ();
            civilStatusValueGrid.ColumnDefinitions.Add (BuildColumn (1));
            civilStatusValueGrid.ColumnDefinitions.Add (BuildColumn (1));
            civilStatusValueGrid.ColumnDefinitions.Add (BuildColumn (1));
            civilStatusValueGrid.ColumnDefinitions.Add (BuildColumn (1));
            civilStatusValueGrid.ColumnDefinitions.Add (BuildColumn (1));

            Grid.SetRow (civilStatusValueGrid, 0);
            Grid.SetColumn (civilStatusValueGrid, 1);

            civilStatusValueGrid.Children.Add (BuildBooleanFieldCell ("Sæt X", "Ugift", ( pregnancyJournalModel.PatientData.CivilStatus == MaritalStatus.UnMarried ), CellLocation.TopMiddle, 0, 0));
            civilStatusValueGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Gift", ( pregnancyJournalModel.PatientData.CivilStatus == MaritalStatus.Married ), CellLocation.TopMiddle, 0, 1));
            civilStatusValueGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Seperaret", ( pregnancyJournalModel.PatientData.CivilStatus == MaritalStatus.Seperated ), CellLocation.TopMiddle, 0, 2));
            civilStatusValueGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Fraskildt", ( pregnancyJournalModel.PatientData.CivilStatus == MaritalStatus.Divorced ), CellLocation.TopMiddle, 0, 3));
            civilStatusValueGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Enke", ( pregnancyJournalModel.PatientData.CivilStatus == MaritalStatus.Widowed ), CellLocation.TopLeft, 0, 4));

            civilStatusGrid.Children.Add (civilStatusValueGrid);
            #endregion

            #region Cohabitable Values
            Grid cohabitableValueGrid = new Grid ();
            cohabitableValueGrid.ColumnDefinitions.Add (BuildColumn (1));
            cohabitableValueGrid.ColumnDefinitions.Add (BuildColumn (1));

            Grid.SetRow (cohabitableValueGrid, 0);
            Grid.SetColumn (cohabitableValueGrid, 2);

            cohabitableValueGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Samboende", pregnancyJournalModel.PatientData.Cohibitable, CellLocation.TopMiddle, 0, 0));
            cohabitableValueGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Enlig", !pregnancyJournalModel.PatientData.Cohibitable, CellLocation.TopMiddle, 0, 1));

            civilStatusGrid.Children.Add (cohabitableValueGrid);
            #endregion

            #region Childs Fathers Info
            civilStatusGrid.Children.Add (BuildTextFieldCell ("Barnefars Navn", pregnancyJournalModel.PatientData.ChildFathersName, CellLocation.TopLeft, 1, 1));
            civilStatusGrid.Children.Add (BuildTextFieldCell ("Personnummer", pregnancyJournalModel.PatientData.ChildFathersSSN, CellLocation.TopMiddle, 1, 2));
            #endregion
            #endregion

            #region Language
            Grid languageGrid = new Grid ();
            languageGrid.RowDefinitions.Add (BuildRow (1));
            languageGrid.ColumnDefinitions.Add (BuildColumn (1));
            languageGrid.ColumnDefinitions.Add (BuildColumn (1));
            languageGrid.ColumnDefinitions.Add (BuildColumn (2));
            languageGrid.ColumnDefinitions.Add (BuildColumn (2));

            Grid.SetRow (languageGrid, 2);
            Grid.SetColumn (languageGrid, 0);
            socialInfoGrid.Children.Add (languageGrid);

            languageGrid.Children.Add (BuildListItemCell ("Sprog", CellLocation.TopLeft, 0, 0, true, true, 20));

            #region Need Translator
            Grid transGrid = new Grid ();
            transGrid.ColumnDefinitions.Add (BuildColumn (1));
            transGrid.ColumnDefinitions.Add (BuildColumn (1));

            Grid.SetRow (transGrid, 0);
            Grid.SetColumn (transGrid, 1);

            transGrid.Children.Add (BuildBooleanFieldCell ("Behov for tolkebistand", "Ja", pregnancyJournalModel.PatientData.NeedTranslator, CellLocation.TopMiddle, 0, 0));
            transGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Nej", !pregnancyJournalModel.PatientData.NeedTranslator, CellLocation.TopLeft, 0, 1));

            languageGrid.Children.Add (transGrid);
            #endregion

            languageGrid.Children.Add (BuildTextFieldCell ("Hvis ja, hvilket sprog", pregnancyJournalModel.PatientData.TranslatorLanguage, CellLocation.TopLeft, 0, 2));
            languageGrid.Children.Add (BuildTextFieldCell ("National oprindelse", pregnancyJournalModel.PatientData.Nationality, CellLocation.TopMiddle, 0, 3));
            #endregion

            socialInfoGrid.Children.Add (BuildTextFieldCell ("Supplerende oplysninger", pregnancyJournalModel.PatientData.OtherInfo, CellLocation.BottomMiddle, 3, 0));
            #endregion

            #region Pregnancies
            Grid pregnanciesGrid = new Grid ();
            #region Rows = 5
            pregnanciesGrid.RowDefinitions.Add (BuildRow (1, 40));
            pregnanciesGrid.RowDefinitions.Add (BuildRow (1, 40));
            pregnanciesGrid.RowDefinitions.Add (BuildRow (1, 40));
            pregnanciesGrid.RowDefinitions.Add (BuildRow (1, 40));
            pregnanciesGrid.RowDefinitions.Add (BuildRow (1, 40));
            #endregion
            #region Columns = 10
            pregnanciesGrid.ColumnDefinitions.Add (BuildColumn (1));
            pregnanciesGrid.ColumnDefinitions.Add (BuildColumn (1));
            pregnanciesGrid.ColumnDefinitions.Add (BuildColumn (1));
            pregnanciesGrid.ColumnDefinitions.Add (BuildColumn (1));
            pregnanciesGrid.ColumnDefinitions.Add (BuildColumn (1));
            pregnanciesGrid.ColumnDefinitions.Add (BuildColumn (1));
            pregnanciesGrid.ColumnDefinitions.Add (BuildColumn (1));
            pregnanciesGrid.ColumnDefinitions.Add (BuildColumn (1));
            pregnanciesGrid.ColumnDefinitions.Add (BuildColumn (1));
            pregnanciesGrid.ColumnDefinitions.Add (BuildColumn (1));
            #endregion

            Border pregnanciesAreaBorder = new Border ()
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness (1, 1, 1, 1),
                Margin = new Thickness (10, 10, 10, 0)
            };
            Grid.SetRow (pregnanciesAreaBorder, 3);

            pregnanciesAreaBorder.Child = pregnanciesGrid;
            display.Children.Add (pregnanciesAreaBorder);

            pregnanciesGrid.Children.Add (BuildListItemCell ("År", CellLocation.TopLeft, 0, 0, true));
            pregnanciesGrid.Children.Add (BuildListItemCell ("Levende", CellLocation.TopLeft, 0, 1, true));
            pregnanciesGrid.Children.Add (BuildListItemCell ("Død", CellLocation.TopLeft, 0, 2, true));
            pregnanciesGrid.Children.Add (BuildListItemCell ("Køn", CellLocation.TopLeft, 0, 3, true));
            pregnanciesGrid.Children.Add (BuildListItemCell ("GA", CellLocation.TopLeft, 0, 4, true));
            pregnanciesGrid.Children.Add (BuildListItemCell ("Vægt", CellLocation.TopLeft, 0, 5, true));
            pregnanciesGrid.Children.Add (BuildListItemCell ("Fødested", CellLocation.TopLeft, 0, 6, true));
            pregnanciesGrid.Children.Add (BuildListItemCell ("Graviditetsforløb", CellLocation.TopLeft, 0, 7, true));
            pregnanciesGrid.Children.Add (BuildListItemCell ("Fødselsoplevelse (God, Neutral, Dårlig)", CellLocation.TopLeft, 0, 8, true));
            pregnanciesGrid.Children.Add (BuildListItemCell ("Barns nuværende tilsand", CellLocation.TopMiddle, 0, 9, true));

            if ( pregnancyJournalModel.Pregnancies.History != null && pregnancyJournalModel.Pregnancies.History.Count > 0 )
            {
                for ( int row = 0; row < pregnancyJournalModel.Pregnancies.History.Count; row++ )
                {
                    pregnanciesGrid.Children.Add (BuildListItemCell (pregnancyJournalModel.Pregnancies.History[ row ].Year.ToString (), CellLocation.TopLeft, row + 1, 0));
                    pregnanciesGrid.Children.Add (BuildListItemCell (( ( pregnancyJournalModel.Pregnancies.History[ row ].BornAlive ) ? ( "Ja" ) : ( "Nej" ) ), CellLocation.TopLeft, row + 1, 1));
                    pregnanciesGrid.Children.Add (BuildListItemCell (( ( pregnancyJournalModel.Pregnancies.History[ row ].StillBorn ) ? ( "Ja" ) : ( "Nej" ) ), CellLocation.TopLeft, row + 1, 2));
                    pregnanciesGrid.Children.Add (BuildListItemCell (( ( pregnancyJournalModel.Pregnancies.History[ row ].Male ) ? ( "Dreng" ) : ( "Pige" ) ), CellLocation.TopLeft, row + 1, 3));
                    pregnanciesGrid.Children.Add (BuildListItemCell (pregnancyJournalModel.Pregnancies.History[ row ].GestationAge, CellLocation.TopLeft, row + 1, 4));
                    pregnanciesGrid.Children.Add (BuildListItemCell (pregnancyJournalModel.Pregnancies.History[ row ].Weight.ToString ("0.00"), CellLocation.TopLeft, row + 1, 5));
                    pregnanciesGrid.Children.Add (BuildListItemCell (pregnancyJournalModel.Pregnancies.History[ row ].PlaceOfBirth, CellLocation.TopLeft, row + 1, 6));
                    pregnanciesGrid.Children.Add (BuildListItemCell (pregnancyJournalModel.Pregnancies.History[ row ].PregnancyProgress, CellLocation.TopLeft, row + 1, 7));
                    string experience = string.Empty;
                    switch ( pregnancyJournalModel.Pregnancies.History[ row ].PregnancyExperience )
                    {
                        case Core.Experience.Good:
                            experience = "God";
                            break;
                        case Core.Experience.Neutral:
                            experience = "Neutral";
                            break;
                        case Core.Experience.Bad:
                            experience = "Dårlig";
                            break;
                        default:
                            break;
                    }

                    pregnanciesGrid.Children.Add (BuildListItemCell (experience, CellLocation.TopLeft, row + 1, 8));
                    pregnanciesGrid.Children.Add (BuildListItemCell (pregnancyJournalModel.Pregnancies.History[ row ].CurrentStatusOfChild, CellLocation.TopMiddle, row + 1, 9));

                }
            }
            #endregion 

            #region Abortions
            Grid abortionsGrid = new Grid ();
            #region Rows = 5
            abortionsGrid.RowDefinitions.Add (BuildRow (1, 40));
            abortionsGrid.RowDefinitions.Add (BuildRow (1, 40));
            abortionsGrid.RowDefinitions.Add (BuildRow (1, 40));
            abortionsGrid.RowDefinitions.Add (BuildRow (1, 40));
            abortionsGrid.RowDefinitions.Add (BuildRow (1, 40));
            #endregion
            #region Columns = 3
            abortionsGrid.ColumnDefinitions.Add (BuildColumn (1));
            abortionsGrid.ColumnDefinitions.Add (BuildColumn (1));
            abortionsGrid.ColumnDefinitions.Add (BuildColumn (1));
            #endregion

            Border abortionsAreaBorder = new Border ()
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness (1, 1, 1, 1),
                Margin = new Thickness (10, 10, 10, 0)
            };
            Grid.SetRow (abortionsAreaBorder, 4);

            abortionsAreaBorder.Child = abortionsGrid;
            display.Children.Add (abortionsAreaBorder);

            abortionsGrid.Children.Add (BuildListItemCell ("År", CellLocation.TopLeft, 0, 0, true));
            abortionsGrid.Children.Add (BuildListItemCell ("Provokeret Uge", CellLocation.TopLeft, 0, 1, true));
            abortionsGrid.Children.Add (BuildListItemCell ("Spontan Uge", CellLocation.TopMiddle, 0, 2, true));

            if ( pregnancyJournalModel.Abortions.History != null && pregnancyJournalModel.Abortions.History.Count > 0 )
            {
                for ( int row = 0; row < pregnancyJournalModel.Abortions.History.Count; row++ )
                {
                    abortionsGrid.Children.Add (BuildListItemCell (pregnancyJournalModel.Abortions.History[ row ].Year.ToString (), CellLocation.TopLeft, row + 1, 0));
                    abortionsGrid.Children.Add (BuildListItemCell (pregnancyJournalModel.Abortions.History[ row ].PlannedAbortionGA, CellLocation.TopLeft, row + 1, 1));
                    abortionsGrid.Children.Add (BuildListItemCell (pregnancyJournalModel.Abortions.History[ row ].UnplannedAbortionGA, CellLocation.TopMiddle, row + 1, 2));
                }
            }
            #endregion

            #region Anamnese
            Grid anamneseGrid = new Grid ();
            #region Rows = 21
            anamneseGrid.RowDefinitions.Add (BuildRow (1, 40));
            anamneseGrid.RowDefinitions.Add (BuildRow (1, 40));
            anamneseGrid.RowDefinitions.Add (BuildRow (1, 40));
            anamneseGrid.RowDefinitions.Add (BuildRow (1, 40));
            anamneseGrid.RowDefinitions.Add (BuildRow (1, 40));
            anamneseGrid.RowDefinitions.Add (BuildRow (1, 40));
            anamneseGrid.RowDefinitions.Add (BuildRow (1, 40));
            anamneseGrid.RowDefinitions.Add (BuildRow (1, 40));
            anamneseGrid.RowDefinitions.Add (BuildRow (1, 40));
            anamneseGrid.RowDefinitions.Add (BuildRow (1, 40));
            anamneseGrid.RowDefinitions.Add (BuildRow (1, 40));
            anamneseGrid.RowDefinitions.Add (BuildRow (1, 40));
            anamneseGrid.RowDefinitions.Add (BuildRow (1, 40));
            anamneseGrid.RowDefinitions.Add (BuildRow (1, 40));
            anamneseGrid.RowDefinitions.Add (BuildRow (1, 40));
            anamneseGrid.RowDefinitions.Add (BuildRow (1, 40));
            anamneseGrid.RowDefinitions.Add (BuildRow (1, 40));
            anamneseGrid.RowDefinitions.Add (BuildRow (1, 40));
            anamneseGrid.RowDefinitions.Add (BuildRow (1, 40));
            anamneseGrid.RowDefinitions.Add (BuildRow (1, 40));
            anamneseGrid.RowDefinitions.Add (BuildRow (1, 40));
            #endregion

            Border ananmneseAreaBorder = new Border ()
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness (1, 1, 1, 1),
                Margin = new Thickness (10, 10, 10, 0)
            };
            Grid.SetRow (ananmneseAreaBorder, 5);

            ananmneseAreaBorder.Child = anamneseGrid;
            display.Children.Add (ananmneseAreaBorder);

            #region Termin
            Grid terminsGrid = new Grid ();
            terminsGrid.ColumnDefinitions.Add (BuildColumn (1));
            terminsGrid.ColumnDefinitions.Add (BuildColumn (2));
            terminsGrid.ColumnDefinitions.Add (BuildColumn (2));
            terminsGrid.ColumnDefinitions.Add (BuildColumn (2));
            terminsGrid.ColumnDefinitions.Add (BuildColumn (4));
            Grid.SetRow (terminsGrid, 0);
            Grid.SetColumn (terminsGrid, 0);
            Grid.SetRowSpan (terminsGrid, 1);
            Grid.SetColumnSpan (terminsGrid, 1);
            anamneseGrid.Children.Add (terminsGrid);

            terminsGrid.Children.Add (BuildListItemCell ("Terminsberegning", CellLocation.TopLeft, 0, 0, true, true, 14));
            terminsGrid.Children.Add (BuildTextFieldCell ("Sidste Mens. 1. dag", pregnancyJournalModel.Anamnese.TermInfo.MenstrualInfo.LastMentruationalDay.ToShortDateString (), CellLocation.TopLeft, 0, 1));
            terminsGrid.Children.Add (BuildTextFieldCell ("Cycklus", pregnancyJournalModel.Anamnese.TermInfo.MenstrualInfo.MenstruationalCycle, CellLocation.TopLeft, 0, 2));
            terminsGrid.Children.Add (BuildTextFieldCell ("Termin", pregnancyJournalModel.Anamnese.TermInfo.ExpectedBirthDate.ToShortDateString (), CellLocation.TopLeft, 0, 3));
            terminsGrid.Children.Add (BuildTextFieldCell ("Evt. Bemærkninger", pregnancyJournalModel.Anamnese.TermInfo.Comment, CellLocation.TopMiddle, 0, 4));
            #endregion

            #region Fertility
            Grid fertilityGrid = new Grid ();
            fertilityGrid.ColumnDefinitions.Add (BuildColumn (1));
            fertilityGrid.ColumnDefinitions.Add (BuildColumn (5));
            fertilityGrid.ColumnDefinitions.Add (BuildColumn (5));
            Grid.SetRow (fertilityGrid, 1);
            Grid.SetColumn (fertilityGrid, 0);
            Grid.SetRowSpan (fertilityGrid, 1);
            Grid.SetColumnSpan (fertilityGrid, 1);
            anamneseGrid.Children.Add (fertilityGrid);

            fertilityGrid.Children.Add (BuildListItemCell ("Fetilitesbehandling", CellLocation.TopLeft, 0, 0, true, true, 14));

            Grid fertilityStateGrid = new Grid ();
            fertilityStateGrid.ColumnDefinitions.Add (BuildColumn (1));
            fertilityStateGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetColumn (fertilityStateGrid, 1);
            fertilityGrid.Children.Add (fertilityStateGrid);

            fertilityStateGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Ja", pregnancyJournalModel.Anamnese.FertilityInfo.RecievedFertilityTreatment, CellLocation.TopMiddle, 0, 0));
            fertilityStateGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Nej", !pregnancyJournalModel.Anamnese.FertilityInfo.RecievedFertilityTreatment, CellLocation.TopLeft, 0, 1));

            fertilityGrid.Children.Add (BuildTextFieldCell ("Evt. Bemærkninger", pregnancyJournalModel.Anamnese.FertilityInfo.Comment, CellLocation.TopMiddle, 0, 2));
            #endregion

            #region Prenatal
            Grid prenatalGrid = new Grid ();
            prenatalGrid.RowDefinitions.Add (BuildRow (1));
            prenatalGrid.RowDefinitions.Add (BuildRow (1));
            prenatalGrid.RowDefinitions.Add (BuildRow (1));
            prenatalGrid.ColumnDefinitions.Add (BuildColumn (1));
            prenatalGrid.ColumnDefinitions.Add (BuildColumn (2));
            prenatalGrid.ColumnDefinitions.Add (BuildColumn (2));

            Grid.SetRow (prenatalGrid, 2);
            Grid.SetColumn (prenatalGrid, 0);
            Grid.SetRowSpan (prenatalGrid, 3);
            anamneseGrid.Children.Add (prenatalGrid);

            UIElement prenatalLabel = BuildListItemCell ("Prænatal Risikovurdering", CellLocation.TopLeft, 0, 0, true, true, 14);
            Grid.SetRowSpan (prenatalLabel, 3);
            prenatalGrid.Children.Add (prenatalLabel);

            UIElement familyHistory = BuildTextFieldCell ("Familiehistorie, herunder arvelige sygdomme", pregnancyJournalModel.Anamnese.RiskAssessment.FamiliyHistory, CellLocation.TopMiddle, 0, 1);
            Grid.SetColumnSpan (familyHistory, 2);
            prenatalGrid.Children.Add (familyHistory);

            #region Test Values
            Grid prenatalTestGrid = new Grid ();
            prenatalTestGrid.ColumnDefinitions.Add (BuildColumn (1));
            prenatalTestGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (prenatalTestGrid, 1);
            Grid.SetColumn (prenatalTestGrid, 1);
            Grid.SetColumnSpan (prenatalTestGrid, 2);
            prenatalGrid.Children.Add (prenatalTestGrid);

            #region Double Test
            Grid doubleTestGrid = new Grid ();
            doubleTestGrid.ColumnDefinitions.Add (BuildColumn (1));
            doubleTestGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (doubleTestGrid, 0);
            Grid.SetColumn (doubleTestGrid, 0);
            prenatalTestGrid.Children.Add (doubleTestGrid);

            doubleTestGrid.Children.Add (BuildBooleanFieldCell ("Doubletest taget (uge 8+0 - 13+6)", "Ja", pregnancyJournalModel.Anamnese.RiskAssessment.DoubleTestTaken, CellLocation.TopMiddle, 0, 0));
            doubleTestGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Nej", !pregnancyJournalModel.Anamnese.RiskAssessment.DoubleTestTaken, CellLocation.TopLeft, 0, 1));
            #endregion

            #region Triple Test
            Grid tripleTestGrid = new Grid ();
            tripleTestGrid.ColumnDefinitions.Add (BuildColumn (1));
            tripleTestGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (tripleTestGrid, 0);
            Grid.SetColumn (tripleTestGrid, 1);
            prenatalTestGrid.Children.Add (tripleTestGrid);

            tripleTestGrid.Children.Add (BuildBooleanFieldCell ("Tripletest taget (uge 14+0 - 20+6)", "Ja", pregnancyJournalModel.Anamnese.RiskAssessment.TripleTestTaken, CellLocation.TopMiddle, 0, 0));
            tripleTestGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Nej", !pregnancyJournalModel.Anamnese.RiskAssessment.TripleTestTaken, CellLocation.TopMiddle, 0, 1));
            #endregion
            #endregion

            #region Scans
            Grid scanGrid = new Grid ();
            scanGrid.ColumnDefinitions.Add (BuildColumn (1));
            scanGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (scanGrid, 2);
            Grid.SetColumn (scanGrid, 1);
            Grid.SetColumnSpan (scanGrid, 2);
            prenatalGrid.Children.Add (scanGrid);

            #region Nuchalfold Scan
            Grid nuchalfoldScanGrid = new Grid ();
            nuchalfoldScanGrid.ColumnDefinitions.Add (BuildColumn (1));
            nuchalfoldScanGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (nuchalfoldScanGrid, 0);
            Grid.SetColumn (nuchalfoldScanGrid, 0);
            scanGrid.Children.Add (nuchalfoldScanGrid);

            nuchalfoldScanGrid.Children.Add (BuildBooleanFieldCell ("Ønskes nakkefoldsscanning (Uge 11+0 - 13+6)", "Ja", pregnancyJournalModel.Anamnese.RiskAssessment.RequestedNuchalFoldScan, CellLocation.TopMiddle, 0, 0));
            nuchalfoldScanGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Nej", !pregnancyJournalModel.Anamnese.RiskAssessment.RequestedNuchalFoldScan, CellLocation.TopLeft, 0, 1));
            #endregion

            #region Malformation Scan
            Grid malformationScanGrid = new Grid ();
            malformationScanGrid.ColumnDefinitions.Add (BuildColumn (1));
            malformationScanGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (malformationScanGrid, 0);
            Grid.SetColumn (malformationScanGrid, 1);
            scanGrid.Children.Add (malformationScanGrid);

            malformationScanGrid.Children.Add (BuildBooleanFieldCell ("Ønskes Misdannelsesscanning (Uge 18+0 - 20+0)", "Ja", pregnancyJournalModel.Anamnese.RiskAssessment.RequestedMalformationScan, CellLocation.TopMiddle, 0, 0));
            malformationScanGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Nej", !pregnancyJournalModel.Anamnese.RiskAssessment.RequestedMalformationScan, CellLocation.TopMiddle, 0, 1));
            #endregion
            #endregion
            #endregion

            #region WorkEnvironment
            Grid environmentGrid = new Grid ();
            environmentGrid.RowDefinitions.Add (BuildRow (1));
            environmentGrid.RowDefinitions.Add (BuildRow (1));
            environmentGrid.RowDefinitions.Add (BuildRow (1));
            environmentGrid.ColumnDefinitions.Add (BuildColumn (1));
            environmentGrid.ColumnDefinitions.Add (BuildColumn (2));
            environmentGrid.ColumnDefinitions.Add (BuildColumn (2));

            Grid.SetRow (environmentGrid, 5);
            Grid.SetColumn (environmentGrid, 0);
            Grid.SetRowSpan (environmentGrid, 3);
            anamneseGrid.Children.Add (environmentGrid);

            UIElement environmentLabel = BuildListItemCell ("Arbejdsmiljøpåvirkning", CellLocation.TopLeft, 0, 0, true, true, 14);
            Grid.SetRowSpan (environmentLabel, 3);
            environmentGrid.Children.Add (environmentLabel);

            #region Row 1
            Grid environmentRow1Grid = new Grid ();
            environmentRow1Grid.ColumnDefinitions.Add (BuildColumn (1));
            environmentRow1Grid.ColumnDefinitions.Add (BuildColumn (1));
            environmentRow1Grid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (environmentRow1Grid, 0);
            Grid.SetColumn (environmentRow1Grid, 1);
            Grid.SetColumnSpan (environmentRow1Grid, 2);
            environmentGrid.Children.Add (environmentRow1Grid);

            environmentRow1Grid.Children.Add (BuildTextFieldCell ("Den gravides arbejde", pregnancyJournalModel.Anamnese.WorkEnvironment.WorkPosition, CellLocation.TopLeft, 0, 0));
            environmentRow1Grid.Children.Add (BuildTextFieldCell ("Timer pr. uge", pregnancyJournalModel.Anamnese.WorkEnvironment.WorkHoursPrWeek.ToString (), CellLocation.TopLeft, 0, 1));
            environmentRow1Grid.Children.Add (BuildTextFieldCell ("Barnefars arbejde", pregnancyJournalModel.Anamnese.WorkEnvironment.FathersWorkPosition, CellLocation.TopMiddle, 0, 2));
            #endregion

            #region Row 2
            Grid environmentRow2Grid = new Grid ();
            environmentRow2Grid.ColumnDefinitions.Add (BuildColumn (1));
            environmentRow2Grid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (environmentRow2Grid, 1);
            Grid.SetColumn (environmentRow2Grid, 1);
            Grid.SetColumnSpan (environmentRow2Grid, 2);
            environmentGrid.Children.Add (environmentRow2Grid);

            #region Work Environment Values
            Grid workEnvironmentValuesGrid = new Grid ();
            workEnvironmentValuesGrid.ColumnDefinitions.Add (BuildColumn (1));
            workEnvironmentValuesGrid.ColumnDefinitions.Add (BuildColumn (1));
            workEnvironmentValuesGrid.ColumnDefinitions.Add (BuildColumn (1));
            workEnvironmentValuesGrid.ColumnDefinitions.Add (BuildColumn (1));
            environmentRow2Grid.Children.Add (workEnvironmentValuesGrid);

            workEnvironmentValuesGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Ergonomisk", ( pregnancyJournalModel.Anamnese.WorkEnvironment.WorkEnvironments[ 0 ] == WorkEnvironment.Ergonomic ), CellLocation.TopMiddle, 0, 0));
            workEnvironmentValuesGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Biologisk", ( pregnancyJournalModel.Anamnese.WorkEnvironment.WorkEnvironments[ 0 ] == WorkEnvironment.Biological ), CellLocation.TopMiddle, 0, 1));
            workEnvironmentValuesGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Kemisk", ( pregnancyJournalModel.Anamnese.WorkEnvironment.WorkEnvironments[ 0 ] == WorkEnvironment.Chemical ), CellLocation.TopMiddle, 0, 2));
            workEnvironmentValuesGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Andet", ( pregnancyJournalModel.Anamnese.WorkEnvironment.WorkEnvironments[ 0 ] == WorkEnvironment.Other ), CellLocation.TopLeft, 0, 3));
            #endregion 

            environmentRow2Grid.Children.Add (BuildTextFieldCell ("Art og periode", pregnancyJournalModel.Anamnese.WorkEnvironment.NatureAndPeriod, CellLocation.TopMiddle, 0, 1));
            #endregion

            #region Row 3
            Grid environmentRow3Grid = new Grid ();
            environmentRow3Grid.ColumnDefinitions.Add (BuildColumn (1));
            environmentRow3Grid.ColumnDefinitions.Add (BuildColumn (1));
            environmentRow3Grid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (environmentRow3Grid, 2);
            Grid.SetColumn (environmentRow3Grid, 1);
            Grid.SetColumnSpan (environmentRow3Grid, 2);
            environmentGrid.Children.Add (environmentRow3Grid);

            #region Clinic
            Grid clinicGrid = new Grid ();
            clinicGrid.ColumnDefinitions.Add (BuildColumn (1));
            clinicGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetColumn (clinicGrid, 0);
            environmentRow3Grid.Children.Add (clinicGrid);

            clinicGrid.Children.Add (BuildBooleanFieldCell ("Henvist til arbejdsmedicinsk klinik", "Ja", pregnancyJournalModel.Anamnese.WorkEnvironment.ReferedToOMClinic, CellLocation.TopMiddle, 0, 0));
            clinicGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Nej", !pregnancyJournalModel.Anamnese.WorkEnvironment.ReferedToOMClinic, CellLocation.TopLeft, 0, 1));
            #endregion

            #region Partial Leave
            Grid partialLeaveGrid = new Grid ();
            partialLeaveGrid.ColumnDefinitions.Add (BuildColumn (1));
            partialLeaveGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetColumn (partialLeaveGrid, 1);
            environmentRow3Grid.Children.Add (partialLeaveGrid);

            partialLeaveGrid.Children.Add (BuildBooleanFieldCell ("Devlis Fraværsmelding", "Ja", pregnancyJournalModel.Anamnese.WorkEnvironment.PartialLeaveNotification, CellLocation.TopMiddle, 0, 0));
            partialLeaveGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Nej", !pregnancyJournalModel.Anamnese.WorkEnvironment.PartialLeaveNotification, CellLocation.TopLeft, 0, 1));
            #endregion

            #region Leave
            Grid leaveGrid = new Grid ();
            leaveGrid.ColumnDefinitions.Add (BuildColumn (1));
            leaveGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetColumn (leaveGrid, 2);
            environmentRow3Grid.Children.Add (leaveGrid);

            leaveGrid.Children.Add (BuildBooleanFieldCell ("Fraværsmelding", "Ja", pregnancyJournalModel.Anamnese.WorkEnvironment.LeaveNotification, CellLocation.TopMiddle, 0, 0));
            leaveGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Nej", !pregnancyJournalModel.Anamnese.WorkEnvironment.LeaveNotification, CellLocation.TopMiddle, 0, 1));
            #endregion
            #endregion
            #endregion

            #region Allergy
            Grid allergyGrid = new Grid ();
            allergyGrid.RowDefinitions.Add (BuildRow (1));
            allergyGrid.RowDefinitions.Add (BuildRow (1));
            allergyGrid.ColumnDefinitions.Add (BuildColumn (1));
            allergyGrid.ColumnDefinitions.Add (BuildColumn (4));

            Grid.SetRow (allergyGrid, 8);
            Grid.SetColumn (allergyGrid, 0);
            Grid.SetRowSpan (allergyGrid, 2);
            anamneseGrid.Children.Add (allergyGrid);

            UIElement allergyLabel = BuildListItemCell ("Allergi", CellLocation.TopLeft, 0, 0, true, true, 14);
            Grid.SetRowSpan (allergyLabel, 2);
            allergyGrid.Children.Add (allergyLabel);

            #region Row 1
            allergyGrid.Children.Add (BuildTextFieldCell ("Den gravide er allergisk over for", pregnancyJournalModel.Anamnese.Allergies.Allergies, CellLocation.TopMiddle, 0, 1));
            #endregion

            #region Row 2
            Grid allergyRow2Grid = new Grid ();
            allergyRow2Grid.ColumnDefinitions.Add (BuildColumn (1));
            allergyRow2Grid.ColumnDefinitions.Add (BuildColumn (1));
            allergyRow2Grid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (allergyRow2Grid, 2);
            Grid.SetColumn (allergyRow2Grid, 1);
            allergyGrid.Children.Add (allergyRow2Grid);

            allergyRow2Grid.Children.Add (BuildBooleanFieldCell ("Barnets disponeret for allergisk sygdom", "Ingen", ( pregnancyJournalModel.Anamnese.Allergies.ChildAllergyRisk == ChildDisposedAllergy.None ), CellLocation.TopMiddle, 0, 0));
            allergyRow2Grid.Children.Add (BuildBooleanFieldCell (string.Empty, "Enkelt (Forældre/søskende)", ( pregnancyJournalModel.Anamnese.Allergies.ChildAllergyRisk == ChildDisposedAllergy.OneParentOrSibling ), CellLocation.TopMiddle, 0, 1));
            allergyRow2Grid.Children.Add (BuildBooleanFieldCell (string.Empty, "Dobbelt", ( pregnancyJournalModel.Anamnese.Allergies.ChildAllergyRisk == ChildDisposedAllergy.Double ), CellLocation.TopMiddle, 0, 2));
            #endregion
            #endregion

            #region Chronics
            Grid chronicGrid = new Grid ();
            chronicGrid.RowDefinitions.Add (BuildRow (1));
            chronicGrid.ColumnDefinitions.Add (BuildColumn (1));
            chronicGrid.ColumnDefinitions.Add (BuildColumn (4));

            Grid.SetRow (chronicGrid, 10);
            Grid.SetColumn (chronicGrid, 0);
            Grid.SetRowSpan (chronicGrid, 1);
            anamneseGrid.Children.Add (chronicGrid);

            UIElement chronicLabel = BuildListItemCell ("Kroniske sygdomme", CellLocation.TopLeft, 0, 0, true, true, 14);
            Grid.SetRowSpan (chronicLabel, 1);
            chronicGrid.Children.Add (chronicLabel);

            Grid chronicValueGrid = new Grid ();
            chronicValueGrid.ColumnDefinitions.Add (BuildColumn (1));
            chronicValueGrid.ColumnDefinitions.Add (BuildColumn (1));
            chronicValueGrid.ColumnDefinitions.Add (BuildColumn (1));
            chronicValueGrid.ColumnDefinitions.Add (BuildColumn (1));
            chronicValueGrid.ColumnDefinitions.Add (BuildColumn (1));
            chronicValueGrid.ColumnDefinitions.Add (BuildColumn (1));
            chronicValueGrid.ColumnDefinitions.Add (BuildColumn (1));
            chronicValueGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (chronicValueGrid, 0);
            Grid.SetColumn (chronicValueGrid, 1);
            chronicGrid.Children.Add (chronicValueGrid);

            chronicValueGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Kredsløb", pregnancyJournalModel.Anamnese.ChronicMedicalData.Circulation, CellLocation.TopLeft, 0, 0));
            chronicValueGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Luftveje", pregnancyJournalModel.Anamnese.ChronicMedicalData.Airways, CellLocation.TopLeft, 0, 1));
            chronicValueGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Thyroidea", pregnancyJournalModel.Anamnese.ChronicMedicalData.Thyroidea, CellLocation.TopLeft, 0, 2));
            chronicValueGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Diabetes", pregnancyJournalModel.Anamnese.ChronicMedicalData.Diabetes, CellLocation.TopLeft, 0, 3));
            chronicValueGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Epilepsi", pregnancyJournalModel.Anamnese.ChronicMedicalData.Epilepsy, CellLocation.TopLeft, 0, 4));
            chronicValueGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Psykisk Sygdom", pregnancyJournalModel.Anamnese.ChronicMedicalData.PsychologicalIllness, CellLocation.TopLeft, 0, 5));
            chronicValueGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Herpes Genitalis", pregnancyJournalModel.Anamnese.ChronicMedicalData.HerpesGenitalis, CellLocation.TopLeft, 0, 6));
            chronicValueGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Recidiverende UVI", pregnancyJournalModel.Anamnese.ChronicMedicalData.RecurrentUTI, CellLocation.TopMiddle, 0, 7));
            #endregion

            #region Medicin
            Grid medicinGrid = new Grid ();
            medicinGrid.RowDefinitions.Add (BuildRow (1));
            medicinGrid.ColumnDefinitions.Add (BuildColumn (1));
            medicinGrid.ColumnDefinitions.Add (BuildColumn (4));

            Grid.SetRow (medicinGrid, 11);
            Grid.SetColumn (medicinGrid, 0);
            Grid.SetRowSpan (medicinGrid, 1);
            anamneseGrid.Children.Add (medicinGrid);

            UIElement medicinLabel = BuildListItemCell ("Medicin", CellLocation.TopLeft, 0, 0, true, true, 14);
            Grid.SetRowSpan (medicinLabel, 1);
            medicinGrid.Children.Add (medicinLabel);

            medicinGrid.Children.Add (BuildTextFieldCell (null, pregnancyJournalModel.Anamnese.Medicin, CellLocation.TopMiddle, 0, 1));
            #endregion

            #region MFR Vaccination
            Grid mfrGrid = new Grid ();
            mfrGrid.RowDefinitions.Add (BuildRow (1));
            mfrGrid.ColumnDefinitions.Add (BuildColumn (1));
            mfrGrid.ColumnDefinitions.Add (BuildColumn (4));

            Grid.SetRow (mfrGrid, 12);
            Grid.SetColumn (mfrGrid, 0);
            Grid.SetRowSpan (mfrGrid, 1);
            anamneseGrid.Children.Add (mfrGrid);

            UIElement mfrLabel = BuildListItemCell ("MFR Vaccinationsstatus", CellLocation.TopLeft, 0, 0, true, true, 14);
            Grid.SetRowSpan (mfrLabel, 1);
            mfrGrid.Children.Add (mfrLabel);

            Grid mfrValueGrid = new Grid ();
            mfrValueGrid.ColumnDefinitions.Add (BuildColumn (1));
            mfrValueGrid.ColumnDefinitions.Add (BuildColumn (1));
            mfrValueGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (mfrValueGrid, 0);
            Grid.SetColumn (mfrValueGrid, 1);
            mfrGrid.Children.Add (mfrValueGrid);

            mfrValueGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Vaccineret", ( pregnancyJournalModel.Anamnese.MMRVaccinated == MMRVaccinationStatus.Vaccinated ), CellLocation.TopMiddle, 0, 0));
            mfrValueGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Ikke Vaccineret", ( pregnancyJournalModel.Anamnese.MMRVaccinated == MMRVaccinationStatus.NotVaccinated ), CellLocation.TopMiddle, 0, 1));
            mfrValueGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Ukendt", ( pregnancyJournalModel.Anamnese.MMRVaccinated == MMRVaccinationStatus.Unknown ), CellLocation.TopMiddle, 0, 2));
            #endregion

            #region Past Admittance
            Grid admittanceGrid = new Grid ();
            admittanceGrid.RowDefinitions.Add (BuildRow (1));
            admittanceGrid.ColumnDefinitions.Add (BuildColumn (1));
            admittanceGrid.ColumnDefinitions.Add (BuildColumn (3));

            Grid.SetRow (admittanceGrid, 13);
            Grid.SetColumn (admittanceGrid, 0);
            Grid.SetRowSpan (admittanceGrid, 1);
            anamneseGrid.Children.Add (admittanceGrid);

            UIElement admittanceLabel = BuildListItemCell ("Tidligere indlæggelser og behandlinger af relevans for graviditeter", CellLocation.TopLeft, 0, 0, true, true, 14);
            Grid.SetRowSpan (admittanceLabel, 1);
            admittanceGrid.Children.Add (admittanceLabel);

            admittanceGrid.Children.Add (BuildTextFieldCell (null, pregnancyJournalModel.Anamnese.PastAdmittance, CellLocation.TopMiddle, 0, 1));
            #endregion

            #region Tobacco
            Grid tobaccoGrid = new Grid ();
            tobaccoGrid.RowDefinitions.Add (BuildRow (1));
            tobaccoGrid.ColumnDefinitions.Add (BuildColumn (1));
            tobaccoGrid.ColumnDefinitions.Add (BuildColumn (1));
            tobaccoGrid.ColumnDefinitions.Add (BuildColumn (1));
            tobaccoGrid.ColumnDefinitions.Add (BuildColumn (1));
            tobaccoGrid.ColumnDefinitions.Add (BuildColumn (1));

            Grid.SetRow (tobaccoGrid, 14);
            Grid.SetColumn (tobaccoGrid, 0);
            Grid.SetRowSpan (tobaccoGrid, 1);
            anamneseGrid.Children.Add (tobaccoGrid);

            UIElement tobaccoLabel = BuildListItemCell ("Tobak", CellLocation.TopLeft, 0, 0, true, true, 14);
            Grid.SetRowSpan (tobaccoLabel, 1);
            tobaccoGrid.Children.Add (tobaccoLabel);

            #region Smoker
            Grid SmokerGrid = new Grid ();
            SmokerGrid.ColumnDefinitions.Add (BuildColumn (1));
            SmokerGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (SmokerGrid, 0);
            Grid.SetColumn (SmokerGrid, 1);
            tobaccoGrid.Children.Add (SmokerGrid);

            SmokerGrid.Children.Add (BuildBooleanFieldCell ("Ryger", "Ja", pregnancyJournalModel.Anamnese.TobaccoInfo.Smoker, CellLocation.TopMiddle, 0, 0));
            SmokerGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Nej", !pregnancyJournalModel.Anamnese.TobaccoInfo.Smoker, CellLocation.TopLeft, 0, 1));
            #endregion

            tobaccoGrid.Children.Add (BuildTextFieldCell ("Antal cigaretter pr. dag", pregnancyJournalModel.Anamnese.TobaccoInfo.AmountPrDay.ToString (), CellLocation.TopLeft, 0, 2));
            tobaccoGrid.Children.Add (BuildTextFieldCell ("Evt. ophørsdato", pregnancyJournalModel.Anamnese.TobaccoInfo.QuitDate.ToShortDateString (), CellLocation.TopLeft, 0, 3));

            #region rehab
            Grid rehabGrid = new Grid ();
            rehabGrid.ColumnDefinitions.Add (BuildColumn (1));
            rehabGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (rehabGrid, 0);
            Grid.SetColumn (rehabGrid, 4);
            tobaccoGrid.Children.Add (rehabGrid);

            rehabGrid.Children.Add (BuildBooleanFieldCell ("Ønsker rygeafvænningstilbud", "Ja", pregnancyJournalModel.Anamnese.TobaccoInfo.RequestedRehab, CellLocation.TopMiddle, 0, 0));
            rehabGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Nej", !pregnancyJournalModel.Anamnese.TobaccoInfo.RequestedRehab, CellLocation.TopLeft, 0, 1));
            #endregion
            #endregion

            #region Alchol
            Grid alcoholGrid = new Grid ();
            alcoholGrid.RowDefinitions.Add (BuildRow (1));
            alcoholGrid.ColumnDefinitions.Add (BuildColumn (1));
            alcoholGrid.ColumnDefinitions.Add (BuildColumn (1));
            alcoholGrid.ColumnDefinitions.Add (BuildColumn (1));
            alcoholGrid.ColumnDefinitions.Add (BuildColumn (2));

            Grid.SetRow (alcoholGrid, 15);
            Grid.SetColumn (alcoholGrid, 0);
            Grid.SetRowSpan (alcoholGrid, 1);
            anamneseGrid.Children.Add (alcoholGrid);

            UIElement alcoholLabel = BuildListItemCell ("Alkohol", CellLocation.TopLeft, 0, 0, true, true, 14);
            Grid.SetRowSpan (alcoholLabel, 1);
            alcoholGrid.Children.Add (alcoholLabel);

            #region Drinker
            Grid drinkerGrid = new Grid ();
            drinkerGrid.ColumnDefinitions.Add (BuildColumn (1));
            drinkerGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (drinkerGrid, 0);
            Grid.SetColumn (drinkerGrid, 1);
            alcoholGrid.Children.Add (drinkerGrid);

            drinkerGrid.Children.Add (BuildBooleanFieldCell ("Forbrug efter erkendt graviditet", "Ja", pregnancyJournalModel.Anamnese.AlcoholInfo.DuringPregnancy, CellLocation.TopMiddle, 0, 0));
            drinkerGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Nej", !pregnancyJournalModel.Anamnese.AlcoholInfo.DuringPregnancy, CellLocation.TopLeft, 0, 1));
            #endregion

            alcoholGrid.Children.Add (BuildTextFieldCell ("Antal genstande pr. dag", pregnancyJournalModel.Anamnese.AlcoholInfo.AmountPrWeek.ToString (), CellLocation.TopLeft, 0, 2));

            #region Multiple Pr. Session
            Grid multipleGrid = new Grid ();
            multipleGrid.ColumnDefinitions.Add (BuildColumn (1));
            multipleGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (multipleGrid, 0);
            Grid.SetColumn (multipleGrid, 4);
            alcoholGrid.Children.Add (multipleGrid);

            multipleGrid.Children.Add (BuildBooleanFieldCell ("Flere ved samme lejlighed (Evt. Bemærkninger under Samlet Vurtdering)", "Ja", pregnancyJournalModel.Anamnese.AlcoholInfo.MultiplePrSession, CellLocation.TopMiddle, 0, 0));
            multipleGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Nej", !pregnancyJournalModel.Anamnese.AlcoholInfo.MultiplePrSession, CellLocation.TopLeft, 0, 1));
            #endregion
            #endregion

            #region Other Drugs
            Grid drugsGrid = new Grid ();
            drugsGrid.RowDefinitions.Add (BuildRow (1));
            drugsGrid.ColumnDefinitions.Add (BuildColumn (1));
            drugsGrid.ColumnDefinitions.Add (BuildColumn (1));
            drugsGrid.ColumnDefinitions.Add (BuildColumn (3));

            Grid.SetRow (drugsGrid, 16);
            Grid.SetColumn (drugsGrid, 0);
            Grid.SetRowSpan (drugsGrid, 1);
            anamneseGrid.Children.Add (drugsGrid);

            UIElement drugsLabel = BuildListItemCell ("Andre Rusmidler", CellLocation.TopLeft, 0, 0, true, true, 14);
            Grid.SetRowSpan (drugsLabel, 1);
            drugsGrid.Children.Add (drugsLabel);

            #region Use of Drugs
            Grid useOfDrugsGrid = new Grid ();
            useOfDrugsGrid.ColumnDefinitions.Add (BuildColumn (1));
            useOfDrugsGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (useOfDrugsGrid, 0);
            Grid.SetColumn (useOfDrugsGrid, 1);
            drugsGrid.Children.Add (useOfDrugsGrid);

            useOfDrugsGrid.Children.Add (BuildBooleanFieldCell ("Forbrug efter erkendt graviditet", "Ja", pregnancyJournalModel.Anamnese.OtherDrugs, CellLocation.TopMiddle, 0, 0));
            useOfDrugsGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Nej", !pregnancyJournalModel.Anamnese.OtherDrugs, CellLocation.TopLeft, 0, 1));
            #endregion

            drugsGrid.Children.Add (BuildTextFieldCell ("Uddybes", pregnancyJournalModel.Anamnese.OtherDrugsComment, CellLocation.TopMiddle, 0, 2));
            #endregion

            #region Diet
            Grid dietGrid = new Grid ();
            dietGrid.RowDefinitions.Add (BuildRow (1));
            dietGrid.ColumnDefinitions.Add (BuildColumn (1));
            dietGrid.ColumnDefinitions.Add (BuildColumn (4));

            Grid.SetRow (dietGrid, 17);
            Grid.SetColumn (dietGrid, 0);
            Grid.SetRowSpan (dietGrid, 1);
            anamneseGrid.Children.Add (dietGrid);

            UIElement dietLabel = BuildListItemCell ("Kost og motion", CellLocation.TopLeft, 0, 0, true, true, 14);
            Grid.SetRowSpan (dietLabel, 1);
            dietGrid.Children.Add (dietLabel);

            dietGrid.Children.Add (BuildTextFieldCell ("Evt. Bemærkninger", pregnancyJournalModel.Anamnese.DietAndActivity, CellLocation.TopMiddle, 0, 1));
            #endregion
            #endregion

            journalDisplayGrid.Children.Add (scroll);
        }

        private void BuildTravelerJournalDisplay ()
        {
            ClearDisplay (journalDisplayGrid);

            ScrollViewer scroll = new ScrollViewer ()
            {
                HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto
            };

            #region Display Grid
            Grid display = new Grid ();
            display.RowDefinitions.Add (BuildRow (1, 40));
            display.RowDefinitions.Add (BuildRow (4, 160));
            display.RowDefinitions.Add (BuildRow (4, 160));
            display.RowDefinitions.Add (BuildRow (12, 480));
            display.RowDefinitions.Add (BuildRow (15, 600));
            display.RowDefinitions.Add (BuildRow (7, 280));
            display.RowDefinitions.Add (BuildRow (3, 120));
            display.RowDefinitions.Add (BuildRow (5, 200));
            #endregion

            scroll.Content = display;

            #region Header
            Label headerText = new Label ()
            {
                Content = "Vandrejournal",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                FontWeight = FontWeights.Bold,
                FontSize = 20,
            };

            Grid.SetRow (headerText, 0);
            display.Children.Add (headerText);
            #endregion

            #region Patient Data Area
            Grid patientDataGrid = new Grid ();
            patientDataGrid.RowDefinitions.Add (BuildRow (1, 40));
            patientDataGrid.RowDefinitions.Add (BuildRow (1, 40));
            patientDataGrid.RowDefinitions.Add (BuildRow (1, 40));
            patientDataGrid.RowDefinitions.Add (BuildRow (1, 40));
            patientDataGrid.ColumnDefinitions.Add (BuildColumn (1));
            patientDataGrid.ColumnDefinitions.Add (BuildColumn (1));
            Border patientDataAreaBorder = new Border ()
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness (1, 1, 1, 1),
                Margin = new Thickness (10, 0, 10, 0)
            };

            patientDataAreaBorder.Child = patientDataGrid;

            Grid.SetRow (patientDataAreaBorder, 1);
            display.Children.Add (patientDataAreaBorder);

            #region Left Column
            patientDataGrid.Children.Add (BuildTextFieldCell ("Personnummer, Navn", $"{travelerJournalModel.PatientData.SSN}, {travelerJournalModel.PatientData.Name}", CellLocation.TopLeft, 0, 0));
            patientDataGrid.Children.Add (BuildTextFieldCell ("Addresse", travelerJournalModel.PatientData.Address, CellLocation.MiddleLeft, 1, 0));
            patientDataGrid.Children.Add (BuildTextFieldCell ("Email", travelerJournalModel.PatientData.Email, CellLocation.MiddleLeft, 2, 0));

            Grid phoneArea = new Grid ();
            phoneArea.ColumnDefinitions.Add (BuildColumn (1));
            phoneArea.ColumnDefinitions.Add (BuildColumn (1));

            phoneArea.Children.Add (BuildTextFieldCell ("Tlf. Privat/Mobil", travelerJournalModel.PatientData.PrivatePhone, CellLocation.BottomLeft, 0, 0));
            phoneArea.Children.Add (BuildTextFieldCell ("Tlf. Arbejde", travelerJournalModel.PatientData.WorkPhone, CellLocation.BottomLeft, 0, 1));

            Grid.SetRow (phoneArea, 3);
            Grid.SetColumn (phoneArea, 0);
            patientDataGrid.Children.Add (phoneArea);
            #endregion

            #region Right Column
            patientDataGrid.Children.Add (BuildTextFieldCell ("Lægens Navn", travelerJournalModel.PatientData.DoctorsName, CellLocation.TopMiddle, 0, 1));
            patientDataGrid.Children.Add (BuildTextFieldCell ("Lægens Adresse", travelerJournalModel.PatientData.DoctorsAddress, CellLocation.TopMiddle, 1, 1));
            patientDataGrid.Children.Add (BuildTextFieldCell ("Lægens Email", string.Empty, CellLocation.TopMiddle, 2, 1));
            patientDataGrid.Children.Add (BuildTextFieldCell ("Lægens Tlf.", travelerJournalModel.PatientData.DoctorsPhone, CellLocation.BottomMiddle, 3, 1));
            #endregion
            #endregion

            #region Core Data
            Grid patientCoreDataGrid = new Grid ();
            patientCoreDataGrid.RowDefinitions.Add (BuildRow (1, 40));
            patientCoreDataGrid.RowDefinitions.Add (BuildRow (1, 40));
            patientCoreDataGrid.RowDefinitions.Add (BuildRow (1, 40));
            patientCoreDataGrid.RowDefinitions.Add (BuildRow (1, 40));
            patientCoreDataGrid.ColumnDefinitions.Add (BuildColumn (1));
            patientCoreDataGrid.ColumnDefinitions.Add (BuildColumn (1));

            Border patientCoreDataAreaBorder = new Border ()
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness (1, 1, 1, 1),
                Margin = new Thickness (10, 5, 10, 0)
            };

            patientCoreDataAreaBorder.Child = patientCoreDataGrid;

            Grid.SetRow (patientCoreDataAreaBorder, 2);
            display.Children.Add (patientCoreDataAreaBorder);

            #region Left Column
            #region Upper Left
            Grid upperLeftGrid = new Grid ();
            upperLeftGrid.ColumnDefinitions.Add (BuildColumn (1));
            upperLeftGrid.ColumnDefinitions.Add (BuildColumn (1));
            upperLeftGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (upperLeftGrid, 0);
            Grid.SetColumn (upperLeftGrid, 0);
            patientCoreDataGrid.Children.Add (upperLeftGrid);

            upperLeftGrid.Children.Add (BuildTextFieldCell ("Sidste Mens 1 Dag", travelerJournalModel.MenstrualInfo.LastMentruationalDay.ToShortDateString (), CellLocation.TopLeft, 0, 0));
            upperLeftGrid.Children.Add (BuildTextFieldCell ("Cyklus", travelerJournalModel.MenstrualInfo.MenstruationalCycle, CellLocation.TopMiddle, 0, 1));

            Grid stateGrid = new Grid ();
            stateGrid.ColumnDefinitions.Add (BuildColumn (1));
            stateGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (stateGrid, 0);
            Grid.SetColumn (stateGrid, 2);
            upperLeftGrid.Children.Add (stateGrid);

            stateGrid.Children.Add (BuildBooleanFieldCell ("Beregning Sikker", "Ja", travelerJournalModel.MenstrualInfo.IsCalculationSafe, CellLocation.Middle, 0, 0));
            stateGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Nej", !travelerJournalModel.MenstrualInfo.IsCalculationSafe, CellLocation.MiddleLeft, 0, 1));
            #endregion

            #region Upper Middle Left
            Grid upperMiddleLeftGrid = new Grid ();
            upperMiddleLeftGrid.ColumnDefinitions.Add (BuildColumn (1));
            upperMiddleLeftGrid.ColumnDefinitions.Add (BuildColumn (1));
            upperMiddleLeftGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (upperMiddleLeftGrid, 1);
            Grid.SetColumn (upperMiddleLeftGrid, 0);
            patientCoreDataGrid.Children.Add (upperMiddleLeftGrid);

            upperMiddleLeftGrid.Children.Add (BuildTextFieldCell ("Før-graviditetsvægt - kg", travelerJournalModel.WeightInfo.WeightBeforePregnancyInKG.ToString ("0.00"), CellLocation.MiddleLeft, 0, 0));
            upperMiddleLeftGrid.Children.Add (BuildTextFieldCell ("Højde - cm", travelerJournalModel.WeightInfo.HeightInCM.ToString ("0.00"), CellLocation.MiddleLeft, 0, 1));
            upperMiddleLeftGrid.Children.Add (BuildTextFieldCell ("BMI", travelerJournalModel.WeightInfo.BMI.ToString ("0.00"), CellLocation.MiddleLeft, 0, 2));
            #endregion

            #region Lower Middle Left
            Grid lowerMiddleLeftGrid = new Grid ();
            lowerMiddleLeftGrid.ColumnDefinitions.Add (BuildColumn (1));
            lowerMiddleLeftGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (lowerMiddleLeftGrid, 2);
            Grid.SetColumn (lowerMiddleLeftGrid, 0);
            patientCoreDataGrid.Children.Add (lowerMiddleLeftGrid);

            #region Rhesus
            Grid rhesusGrid = new Grid ();
            rhesusGrid.ColumnDefinitions.Add (BuildColumn (1));
            rhesusGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (rhesusGrid, 0);
            Grid.SetColumn (rhesusGrid, 0);
            lowerMiddleLeftGrid.Children.Add (rhesusGrid);

            rhesusGrid.Children.Add (BuildBooleanFieldCell ("Moderens Rhesustype", "Positiv", travelerJournalModel.MothersRhesusFactor, CellLocation.Middle, 0, 0));
            rhesusGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Negativ", !travelerJournalModel.MothersRhesusFactor, CellLocation.MiddleLeft, 0, 1));
            #endregion

            #region Antibody
            Grid antibodyGrid = new Grid ();
            antibodyGrid.ColumnDefinitions.Add (BuildColumn (1));
            antibodyGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (antibodyGrid, 0);
            Grid.SetColumn (antibodyGrid, 1);
            lowerMiddleLeftGrid.Children.Add (antibodyGrid);

            antibodyGrid.Children.Add (BuildBooleanFieldCell ("Irregulære Antistoffer i 6. - 10. uge", "Positiv", travelerJournalModel.IrregularAntibody, CellLocation.Middle, 0, 0));
            antibodyGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Negativ", !travelerJournalModel.IrregularAntibody, CellLocation.MiddleLeft, 0, 1));
            #endregion
            #endregion

            #region Lower Left
            Grid lowerLeftGrid = new Grid ();
            lowerLeftGrid.ColumnDefinitions.Add (BuildColumn (1));
            lowerLeftGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (lowerLeftGrid, 3);
            Grid.SetColumn (lowerLeftGrid, 0);
            patientCoreDataGrid.Children.Add (lowerLeftGrid);

            lowerLeftGrid.Children.Add (BuildBooleanFieldCell ("Uge 29 anity-D immuniglobulin er givet", string.Empty, !string.IsNullOrWhiteSpace (travelerJournalModel.AntiDImmunoglobulinGiven.Value), CellLocation.BottomLeft, 0, 0));
            lowerLeftGrid.Children.Add (BuildTextFieldCell ("Dato, initialer", $"{travelerJournalModel.AntiDImmunoglobulinGiven.Date.ToShortDateString ()}, {travelerJournalModel.AntiDImmunoglobulinGiven.Initials}", CellLocation.BottomLeft, 0, 1));
            #endregion
            #endregion 

            #region Right Column
            #region Upper Right
            Grid upperRightGrid = new Grid ();
            upperRightGrid.ColumnDefinitions.Add (BuildColumn (1));
            upperRightGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (upperRightGrid, 0);
            Grid.SetColumn (upperRightGrid, 1);
            patientCoreDataGrid.Children.Add (upperRightGrid);

            upperRightGrid.Children.Add (BuildTextFieldCell ("Naegels Termin", travelerJournalModel.NaegelsRule.ToShortDateString (), CellLocation.TopLeft, 0, 0));
            upperRightGrid.Children.Add (BuildTextFieldCell ("Ultralydfastsat Termin", travelerJournalModel.UltrasoundTermin.ToShortDateString (), CellLocation.TopMiddle, 0, 1));
            #endregion

            #region Upper Middle Right
            Grid upperMiddleRightGrid = new Grid ();
            upperMiddleRightGrid.ColumnDefinitions.Add (BuildColumn (1));
            upperMiddleRightGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (upperMiddleRightGrid, 1);
            Grid.SetColumn (upperMiddleRightGrid, 1);
            patientCoreDataGrid.Children.Add (upperMiddleRightGrid);

            #region Hep B
            Grid hepBGrid = new Grid ();
            hepBGrid.ColumnDefinitions.Add (BuildColumn (1));
            hepBGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (hepBGrid, 0);
            Grid.SetColumn (hepBGrid, 0);
            upperMiddleRightGrid.Children.Add (hepBGrid);


            bool hepBResult = ( travelerJournalModel.HepB.Result == ScreeningInfo.Positive );

            hepBGrid.Children.Add (BuildBooleanFieldCell ("Hep B", "Positiv", hepBResult, CellLocation.Middle, 0, 0));
            hepBGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Negativ", !hepBResult, CellLocation.MiddleLeft, 0, 1));
            #endregion

            #region Bloodtype Taken
            Grid bloodGrid = new Grid ();
            bloodGrid.ColumnDefinitions.Add (BuildColumn (1));
            bloodGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (bloodGrid, 0);
            Grid.SetColumn (bloodGrid, 1);
            upperMiddleRightGrid.Children.Add (bloodGrid);

            bloodGrid.Children.Add (BuildBooleanFieldCell ("Blodtype Taget", "Ja", travelerJournalModel.BloodTypeDetermined, CellLocation.Middle, 0, 0));
            bloodGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Nej", !travelerJournalModel.BloodTypeDetermined, CellLocation.TopMiddle, 0, 1));
            #endregion
            #endregion

            #region Lower Middle Right
            Grid lowerMiddleRightGrid = new Grid ();
            lowerMiddleRightGrid.ColumnDefinitions.Add (BuildColumn (1));
            lowerMiddleRightGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (lowerMiddleRightGrid, 2);
            Grid.SetColumn (lowerMiddleRightGrid, 1);
            patientCoreDataGrid.Children.Add (lowerMiddleRightGrid);

            #region Child Rhesus
            Grid childRhesusGrid = new Grid ();
            childRhesusGrid.ColumnDefinitions.Add (BuildColumn (1));
            childRhesusGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (childRhesusGrid, 0);
            Grid.SetColumn (childRhesusGrid, 0);
            lowerMiddleRightGrid.Children.Add (childRhesusGrid);

            childRhesusGrid.Children.Add (BuildBooleanFieldCell ("Barnets Rhesustype (uge 25)", "Positiv", travelerJournalModel.ChildsRhesusFactor, CellLocation.Middle, 0, 0));
            childRhesusGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Negativ", !travelerJournalModel.ChildsRhesusFactor, CellLocation.MiddleLeft, 0, 1));
            #endregion

            #region Antibody By Rhesus Negative
            Grid byRhesusNegativGrid = new Grid ();
            byRhesusNegativGrid.ColumnDefinitions.Add (BuildColumn (1));
            byRhesusNegativGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (byRhesusNegativGrid, 0);
            Grid.SetColumn (byRhesusNegativGrid, 1);
            lowerMiddleRightGrid.Children.Add (byRhesusNegativGrid);

            byRhesusNegativGrid.Children.Add (BuildBooleanFieldCell ("Antistof hos rh.neg. i 25. uge", "Positiv", travelerJournalModel.BloodTypeDetermined, CellLocation.Middle, 0, 0));
            byRhesusNegativGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Negativ", !travelerJournalModel.BloodTypeDetermined, CellLocation.TopMiddle, 0, 1));
            #endregion
            #endregion

            #region Lower Right
            Grid lowerRightGrid = new Grid ();
            lowerRightGrid.ColumnDefinitions.Add (BuildColumn (1));
            lowerRightGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (lowerRightGrid, 3);
            Grid.SetColumn (lowerRightGrid, 1);
            patientCoreDataGrid.Children.Add (lowerRightGrid);

            lowerRightGrid.Children.Add (BuildBooleanFieldCell ("Urindyrkning: Set x ved fund af gruppe B-streptokokker uanset hvornår i graviditeten", string.Empty, !string.IsNullOrWhiteSpace (travelerJournalModel.UrineCulture.Value), CellLocation.BottomLeft, 0, 0));
            lowerRightGrid.Children.Add (BuildTextFieldCell ("Dato, Initialer", $"{travelerJournalModel.UrineCulture.Date.ToShortDateString ()}, {travelerJournalModel.UrineCulture.Initials}", CellLocation.BottomMiddle, 0, 1));
            #endregion
            #endregion
            #endregion

            #region Journal Stamps
            Grid journalStampsGrid = new Grid ();
            #region Rows = 12
            journalStampsGrid.RowDefinitions.Add (BuildRow (1, 40));
            journalStampsGrid.RowDefinitions.Add (BuildRow (1, 40));
            journalStampsGrid.RowDefinitions.Add (BuildRow (1, 40));
            journalStampsGrid.RowDefinitions.Add (BuildRow (1, 40));
            journalStampsGrid.RowDefinitions.Add (BuildRow (1, 40));
            journalStampsGrid.RowDefinitions.Add (BuildRow (1, 40));
            journalStampsGrid.RowDefinitions.Add (BuildRow (1, 40));
            journalStampsGrid.RowDefinitions.Add (BuildRow (1, 40));
            journalStampsGrid.RowDefinitions.Add (BuildRow (1, 40));
            journalStampsGrid.RowDefinitions.Add (BuildRow (1, 40));
            journalStampsGrid.RowDefinitions.Add (BuildRow (1, 40));
            journalStampsGrid.RowDefinitions.Add (BuildRow (1, 40));
            journalStampsGrid.RowDefinitions.Add (BuildRow (1, 40));
            #endregion
            #region Columns = 12
            journalStampsGrid.ColumnDefinitions.Add (BuildColumn (1));
            journalStampsGrid.ColumnDefinitions.Add (BuildColumn (1));
            journalStampsGrid.ColumnDefinitions.Add (BuildColumn (1));
            journalStampsGrid.ColumnDefinitions.Add (BuildColumn (1));
            journalStampsGrid.ColumnDefinitions.Add (BuildColumn (1));
            journalStampsGrid.ColumnDefinitions.Add (BuildColumn (1));
            journalStampsGrid.ColumnDefinitions.Add (BuildColumn (1));
            journalStampsGrid.ColumnDefinitions.Add (BuildColumn (1));
            journalStampsGrid.ColumnDefinitions.Add (BuildColumn (1));
            journalStampsGrid.ColumnDefinitions.Add (BuildColumn (1));
            journalStampsGrid.ColumnDefinitions.Add (BuildColumn (1));
            journalStampsGrid.ColumnDefinitions.Add (BuildColumn (1));
            #endregion

            Border journalStampsAreaBorder = new Border ()
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness (1, 1, 1, 1),
                Margin = new Thickness (10, 10, 10, 0)
            };
            Grid.SetRow (journalStampsAreaBorder, 3);

            journalStampsAreaBorder.Child = journalStampsGrid;
            display.Children.Add (journalStampsAreaBorder);

            journalStampsGrid.Children.Add (BuildListItemCell ("Dato", CellLocation.TopLeft, 0, 0, true));
            journalStampsGrid.Children.Add (BuildListItemCell ("Gestations alder", CellLocation.TopLeft, 0, 1, true));
            journalStampsGrid.Children.Add (BuildListItemCell ("Vægt", CellLocation.TopLeft, 0, 2, true));
            journalStampsGrid.Children.Add (BuildListItemCell ("Blodtryk", CellLocation.TopLeft, 0, 3, true));
            journalStampsGrid.Children.Add (BuildListItemCell ("Urin A S Leu Nit", CellLocation.TopLeft, 0, 4, true));
            journalStampsGrid.Children.Add (BuildListItemCell ("Ødem", CellLocation.TopLeft, 0, 5, true));
            journalStampsGrid.Children.Add (BuildListItemCell ("Symfysefund.mål", CellLocation.TopLeft, 0, 6, true));
            journalStampsGrid.Children.Add (BuildListItemCell ("Foster Præsentation", CellLocation.TopLeft, 0, 7, true));
            journalStampsGrid.Children.Add (BuildListItemCell ("Faterkøn", CellLocation.TopLeft, 0, 8, true));
            journalStampsGrid.Children.Add (BuildListItemCell ("Foster Aktivitet", CellLocation.TopLeft, 0, 9, true));
            journalStampsGrid.Children.Add (BuildListItemCell ("Undersøgelsessted", CellLocation.TopLeft, 0, 10, true));
            journalStampsGrid.Children.Add (BuildListItemCell ("Initialer", CellLocation.Middle, 0, 11, true));

            if ( travelerJournalModel.JournalStamps != null && travelerJournalModel.JournalStamps.Count > 0 )
            {
                for ( int row = 0; row < travelerJournalModel.JournalStamps.Count; row++ )
                {
                    journalStampsGrid.Children.Add (BuildListItemCell (travelerJournalModel.JournalStamps[ row ].Date.ToShortDateString (), CellLocation.TopLeft, row + 1, 0));
                    journalStampsGrid.Children.Add (BuildListItemCell (travelerJournalModel.JournalStamps[ row ].GestationAge, CellLocation.TopLeft, row + 1, 1));
                    journalStampsGrid.Children.Add (BuildListItemCell (travelerJournalModel.JournalStamps[ row ].Weight.ToString ("0.00"), CellLocation.TopLeft, row + 1, 2));
                    journalStampsGrid.Children.Add (BuildListItemCell (travelerJournalModel.JournalStamps[ row ].BloodPressure, CellLocation.TopLeft, row + 1, 3));
                    journalStampsGrid.Children.Add (BuildListItemCell (travelerJournalModel.JournalStamps[ row ].UrinSample, CellLocation.TopLeft, row + 1, 4));
                    journalStampsGrid.Children.Add (BuildListItemCell (travelerJournalModel.JournalStamps[ row ].Edema.ToString (), CellLocation.TopLeft, row + 1, 5));
                    journalStampsGrid.Children.Add (BuildListItemCell (travelerJournalModel.JournalStamps[ row ].UterusSizeInCM.ToString ("0.00"), CellLocation.TopLeft, row + 1, 6));
                    journalStampsGrid.Children.Add (BuildListItemCell (travelerJournalModel.JournalStamps[ row ].FosterRepresentation, CellLocation.TopLeft, row + 1, 7));
                    journalStampsGrid.Children.Add (BuildListItemCell (travelerJournalModel.JournalStamps[ row ].FetusGender, CellLocation.TopLeft, row + 1, 8));
                    journalStampsGrid.Children.Add (BuildListItemCell (travelerJournalModel.JournalStamps[ row ].FetusActivity.ToString (), CellLocation.TopLeft, row + 1, 9));
                    journalStampsGrid.Children.Add (BuildListItemCell (travelerJournalModel.JournalStamps[ row ].ExaminationLocation, CellLocation.TopLeft, row + 1, 10));
                    journalStampsGrid.Children.Add (BuildListItemCell (travelerJournalModel.JournalStamps[ row ].Initials, CellLocation.Middle, row + 1, 11));
                }
            }
            #endregion

            #region Journal Comments
            Grid journalCommentsGrid = new Grid ();
            #region Rows = 15
            journalCommentsGrid.RowDefinitions.Add (BuildRow (1, 40));
            journalCommentsGrid.RowDefinitions.Add (BuildRow (1, 40));
            journalCommentsGrid.RowDefinitions.Add (BuildRow (1, 40));
            journalCommentsGrid.RowDefinitions.Add (BuildRow (1, 40));
            journalCommentsGrid.RowDefinitions.Add (BuildRow (1, 40));
            journalCommentsGrid.RowDefinitions.Add (BuildRow (1, 40));
            journalCommentsGrid.RowDefinitions.Add (BuildRow (1, 40));
            journalCommentsGrid.RowDefinitions.Add (BuildRow (1, 40));
            journalCommentsGrid.RowDefinitions.Add (BuildRow (1, 40));
            journalCommentsGrid.RowDefinitions.Add (BuildRow (1, 40));
            journalCommentsGrid.RowDefinitions.Add (BuildRow (1, 40));
            journalCommentsGrid.RowDefinitions.Add (BuildRow (1, 40));
            journalCommentsGrid.RowDefinitions.Add (BuildRow (1, 40));
            journalCommentsGrid.RowDefinitions.Add (BuildRow (1, 40));
            journalCommentsGrid.RowDefinitions.Add (BuildRow (1, 40));
            #endregion
            #region Columns = 2
            journalCommentsGrid.ColumnDefinitions.Add (BuildColumn (1));
            journalCommentsGrid.ColumnDefinitions.Add (BuildColumn (11));
            #endregion

            Border journalCommentsAreaBorder = new Border ()
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness (1, 1, 1, 1),
                Margin = new Thickness (10, 5, 10, 0)
            };
            Grid.SetRow (journalCommentsAreaBorder, 4);

            journalCommentsAreaBorder.Child = journalCommentsGrid;
            display.Children.Add (journalCommentsAreaBorder);

            journalCommentsGrid.Children.Add (BuildListItemCell ("Dato", CellLocation.TopLeft, 0, 0, true));
            journalCommentsGrid.Children.Add (BuildListItemCell ("Supplerende Oplysninger, herundder jordmoderfaglig vurdering af ressourcer/risici/belastniger", CellLocation.TopMiddle, 0, 1, true));

            if ( travelerJournalModel.JournalComments != null && travelerJournalModel.JournalComments.Count > 0 )
            {
                for ( int row = 0; row < travelerJournalModel.JournalComments.Count; row++ )
                {
                    journalCommentsGrid.Children.Add (BuildListItemCell (travelerJournalModel.JournalComments[ row ].Date.ToShortDateString (), CellLocation.TopLeft, row + 1, 0));
                    journalCommentsGrid.Children.Add (BuildListItemCell (travelerJournalModel.JournalComments[ row ].Comment, CellLocation.TopMiddle, row + 1, 1));
                }
            }
            #endregion

            #region Screenings
            Grid screeningAreaGrid = new Grid ();
            screeningAreaGrid.RowDefinitions.Add (BuildRow (1, 40));
            screeningAreaGrid.RowDefinitions.Add (BuildRow (1, 40));
            screeningAreaGrid.RowDefinitions.Add (BuildRow (1, 40));
            screeningAreaGrid.RowDefinitions.Add (BuildRow (4, 160));
            Border screeningAreaBorder = new Border ()
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness (1, 1, 1, 1),
                Margin = new Thickness (10, 10, 10, 0)
            };

            screeningAreaBorder.Child = screeningAreaGrid;

            Grid.SetRow (screeningAreaBorder, 5);
            display.Children.Add (screeningAreaBorder);

            #region Test Area
            Grid testAreaGrid = new Grid ();
            testAreaGrid.ColumnDefinitions.Add (BuildColumn (1));
            testAreaGrid.ColumnDefinitions.Add (BuildColumn (1));
            testAreaGrid.ColumnDefinitions.Add (BuildColumn (1));

            screeningAreaGrid.Children.Add (testAreaGrid);

            Grid.SetRow (testAreaGrid, 0);

            testAreaGrid.Children.Add (BuildTextFieldCell ("Doubletest Dato", travelerJournalModel.DoubleTest.ToShortDateString (), CellLocation.TopLeft, 0, 0));
            testAreaGrid.Children.Add (BuildTextFieldCell ("Nakkefoldsscanning Dato", travelerJournalModel.NuchalFoldScan.ToShortTimeString (), CellLocation.TopLeft, 0, 1));
            testAreaGrid.Children.Add (BuildTextFieldCell ("Tripletest Dato", travelerJournalModel.TripleTest.ToShortDateString (), CellLocation.TopMiddle, 0, 2)); ;
            #endregion

            #region DS Area
            Grid dsAreaGrid = new Grid ();
            dsAreaGrid.ColumnDefinitions.Add (BuildColumn (1));
            dsAreaGrid.ColumnDefinitions.Add (BuildColumn (1));
            dsAreaGrid.ColumnDefinitions.Add (BuildColumn (1));

            screeningAreaGrid.Children.Add (dsAreaGrid);

            Grid.SetRow (dsAreaGrid, 1);

            dsAreaGrid.Children.Add (BuildListItemCell ("Odds for DS udmeldt til kvinden (Ved kombinationstest det samlede odds)", CellLocation.TopLeft, 0, 0, true));
            dsAreaGrid.Children.Add (BuildTextFieldCell ("1:", travelerJournalModel.OddsForDS.Value, CellLocation.TopLeft, 0, 1));
            dsAreaGrid.Children.Add (BuildTextFieldCell ("Initialer", travelerJournalModel.OddsForDS.Initials, CellLocation.TopMiddle, 0, 2));
            #endregion

            #region Foster Area
            Grid fosterAreaGrid = new Grid ();
            fosterAreaGrid.ColumnDefinitions.Add (BuildColumn (1));
            fosterAreaGrid.ColumnDefinitions.Add (BuildColumn (1));
            fosterAreaGrid.ColumnDefinitions.Add (BuildColumn (1));

            screeningAreaGrid.Children.Add (fosterAreaGrid);

            Grid.SetRow (fosterAreaGrid, 2);

            #region Foster Test Area
            Grid fosterTestGrid = new Grid ();
            fosterTestGrid.ColumnDefinitions.Add (BuildColumn (1));
            fosterTestGrid.ColumnDefinitions.Add (BuildColumn (1));

            Grid.SetRow (fosterTestGrid, 0);
            Grid.SetColumn (fosterTestGrid, 0);
            fosterTestGrid.Children.Add (BuildBooleanFieldCell ("Prøver", "Moderkageprøve", !string.IsNullOrWhiteSpace (travelerJournalModel.PlacentaTest.Value), CellLocation.Middle, 0, 0));
            fosterTestGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Fostervandsprøve", !string.IsNullOrWhiteSpace (travelerJournalModel.AmnioticFluidTest.Value), CellLocation.MiddleLeft, 0, 1));
            fosterAreaGrid.Children.Add (fosterTestGrid);
            #endregion

            #region Foster Date Area
            Grid fosterDateGrid = new Grid ();
            fosterDateGrid.ColumnDefinitions.Add (BuildColumn (1));
            fosterDateGrid.ColumnDefinitions.Add (BuildColumn (1));

            Grid.SetRow (fosterDateGrid, 0);
            Grid.SetColumn (fosterDateGrid, 1);
            fosterDateGrid.Children.Add (BuildTextFieldCell ("Moderkageprøve Dato", travelerJournalModel.PlacentaTest.Date.ToShortDateString (), CellLocation.TopLeft, 0, 0));
            fosterDateGrid.Children.Add (BuildTextFieldCell ("Fostervandsprøve Dato", travelerJournalModel.AmnioticFluidTest.Date.ToShortDateString (), CellLocation.MiddleLeft, 0, 1));
            fosterAreaGrid.Children.Add (fosterDateGrid);
            #endregion

            #region Foster Initials Area
            Grid fosterInitialsGrid = new Grid ();
            fosterInitialsGrid.ColumnDefinitions.Add (BuildColumn (1));
            fosterInitialsGrid.ColumnDefinitions.Add (BuildColumn (1));

            Grid.SetRow (fosterInitialsGrid, 0);
            Grid.SetColumn (fosterInitialsGrid, 2);
            fosterInitialsGrid.Children.Add (BuildTextFieldCell ("Moderkageprøve Initialer", travelerJournalModel.PlacentaTest.Initials, CellLocation.TopLeft, 0, 0));
            fosterInitialsGrid.Children.Add (BuildTextFieldCell ("Fostervandsprøve Initialer", travelerJournalModel.AmnioticFluidTest.Initials, CellLocation.TopMiddle, 0, 1));
            fosterAreaGrid.Children.Add (fosterInitialsGrid);
            #endregion
            #endregion

            #region Ultrasound scans
            Grid ultraGrid = new Grid ();
            #region Rows = 5
            ultraGrid.RowDefinitions.Add (BuildRow (1, 40));
            ultraGrid.RowDefinitions.Add (BuildRow (1, 40));
            ultraGrid.RowDefinitions.Add (BuildRow (1, 40));
            ultraGrid.RowDefinitions.Add (BuildRow (1, 40));
            ultraGrid.RowDefinitions.Add (BuildRow (1, 40));
            #endregion
            #region Columns = 10
            ultraGrid.ColumnDefinitions.Add (BuildColumn (1));
            ultraGrid.ColumnDefinitions.Add (BuildColumn (1));
            ultraGrid.ColumnDefinitions.Add (BuildColumn (1));
            ultraGrid.ColumnDefinitions.Add (BuildColumn (1));
            ultraGrid.ColumnDefinitions.Add (BuildColumn (1));
            ultraGrid.ColumnDefinitions.Add (BuildColumn (1));
            ultraGrid.ColumnDefinitions.Add (BuildColumn (1));
            ultraGrid.ColumnDefinitions.Add (BuildColumn (1));
            ultraGrid.ColumnDefinitions.Add (BuildColumn (1));
            ultraGrid.ColumnDefinitions.Add (BuildColumn (1));
            #endregion

            Grid.SetRow (ultraGrid, 3);
            screeningAreaGrid.Children.Add (ultraGrid);

            ultraGrid.Children.Add (BuildListItemCell ("Ultralydsscanning", CellLocation.TopLeft, 0, 0, true));
            ultraGrid.Children.Add (BuildListItemCell ("Dato", CellLocation.TopLeft, 0, 1, true));
            ultraGrid.Children.Add (BuildListItemCell ("Ga (U + D)", CellLocation.TopLeft, 0, 2, true));
            ultraGrid.Children.Add (BuildListItemCell ("UL Vægt", CellLocation.TopLeft, 0, 3, true));
            ultraGrid.Children.Add (BuildListItemCell ("Vægtafvigelse %", CellLocation.TopLeft, 0, 4, true));
            ultraGrid.Children.Add (BuildListItemCell ("Fosterpræsentation", CellLocation.TopLeft, 0, 5, true));
            ultraGrid.Children.Add (BuildListItemCell ("Fostervand", CellLocation.TopLeft, 0, 6, true));
            ultraGrid.Children.Add (BuildListItemCell ("Flow", CellLocation.TopLeft, 0, 7, true));
            //ultraGrid.Children.Add (BuildListItemCell ("Konklusion", CellLocation.TopLeft, 0, 8, true));
            ultraGrid.Children.Add (BuildListItemCell ("Undersøgelsessted", CellLocation.TopLeft, 0, 8, true));
            ultraGrid.Children.Add (BuildListItemCell ("Initialer", CellLocation.TopMiddle, 0, 9, true));

            if ( travelerJournalModel.UltraSoundScans != null && travelerJournalModel.UltraSoundScans.Count > 0 )
            {
                for ( int row = 0; row < travelerJournalModel.UltraSoundScans.Count; row++ )
                {
                    ultraGrid.Children.Add (BuildListItemCell ("Scan Result", CellLocation.TopLeft, row + 1, 0, true));
                    ultraGrid.Children.Add (BuildListItemCell (travelerJournalModel.UltraSoundScans[ row ].Date.ToShortDateString (), CellLocation.TopLeft, row + 1, 1));
                    ultraGrid.Children.Add (BuildListItemCell (travelerJournalModel.UltraSoundScans[ row ].GestationAge, CellLocation.TopLeft, row + 1, 2));
                    ultraGrid.Children.Add (BuildListItemCell (travelerJournalModel.UltraSoundScans[ row ].USWeight.ToString ("0.00"), CellLocation.TopLeft, row + 1, 3));
                    ultraGrid.Children.Add (BuildListItemCell (travelerJournalModel.UltraSoundScans[ row ].WeightDifference.ToString ("0.00"), CellLocation.TopLeft, row + 1, 4));
                    ultraGrid.Children.Add (BuildListItemCell (travelerJournalModel.UltraSoundScans[ row ].FosterRepresentation, CellLocation.TopLeft, row + 1, 5));
                    ultraGrid.Children.Add (BuildListItemCell (travelerJournalModel.UltraSoundScans[ row ].AmnioticFluidAmount.ToString ("0.00"), CellLocation.TopLeft, row + 1, 6));
                    ultraGrid.Children.Add (BuildListItemCell (travelerJournalModel.UltraSoundScans[ row ].Flow, CellLocation.TopLeft, row + 1, 7));
                    ultraGrid.Children.Add (BuildListItemCell (travelerJournalModel.UltraSoundScans[ row ].ExaminationLocation, CellLocation.TopLeft, row + 1, 8));
                    ultraGrid.Children.Add (BuildListItemCell (travelerJournalModel.UltraSoundScans[ row ].Initials, CellLocation.Middle, row + 1, 9));
                }
            }
            #endregion
            #endregion

            #region Diabetes Screening - OGTT
            Grid ogttgAreaGrid = new Grid ();
            ogttgAreaGrid.RowDefinitions.Add (BuildRow (1, 40));
            ogttgAreaGrid.RowDefinitions.Add (BuildRow (1, 40));
            ogttgAreaGrid.RowDefinitions.Add (BuildRow (1, 40));
            ogttgAreaGrid.RowDefinitions.Add (BuildRow (1, 40));
            Border ogttAreaBorder = new Border ()
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness (1, 1, 1, 1),
                Margin = new Thickness (10, 10, 10, 0)
            };

            ogttAreaBorder.Child = ogttgAreaGrid;

            Grid.SetRow (ogttAreaBorder, 6);
            display.Children.Add (ogttAreaBorder);

            #region Row 1
            Grid row1Grid = new Grid ();
            row1Grid.ColumnDefinitions.Add (BuildColumn (1));
            row1Grid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (row1Grid, 0);

            ogttgAreaGrid.Children.Add (row1Grid);

            #region  Week 18-20
            Grid week18_20Grid = new Grid ();
            week18_20Grid.ColumnDefinitions.Add (BuildColumn (1));
            week18_20Grid.ColumnDefinitions.Add (BuildColumn (1));
            week18_20Grid.ColumnDefinitions.Add (BuildColumn (1));
            week18_20Grid.Children.Add (BuildListItemCell ("Uge 18-20*", CellLocation.TopLeft, 0, 0, true));
            week18_20Grid.Children.Add (BuildTextFieldCell ("Dato", travelerJournalModel.OralGlukoseToleranceTest.Week18_20.Date.ToShortDateString (), CellLocation.TopLeft, 0, 1));
            week18_20Grid.Children.Add (BuildTextFieldCell ("2 Timers Værdi", travelerJournalModel.OralGlukoseToleranceTest.Week18_20.Value, CellLocation.TopLeft, 0, 2));

            Grid.SetColumn (week18_20Grid, 0);
            row1Grid.Children.Add (week18_20Grid);
            #endregion

            #region  Week 28-30
            Grid week28_30Grid = new Grid ();
            week28_30Grid.ColumnDefinitions.Add (BuildColumn (1));
            week28_30Grid.ColumnDefinitions.Add (BuildColumn (1));
            week28_30Grid.ColumnDefinitions.Add (BuildColumn (1));
            week28_30Grid.Children.Add (BuildListItemCell ("Uge 28-30**", CellLocation.TopLeft, 0, 0, true));
            week28_30Grid.Children.Add (BuildTextFieldCell ("Dato", travelerJournalModel.OralGlukoseToleranceTest.Week28_30.Date.ToShortDateString (), CellLocation.TopLeft, 0, 1));
            week28_30Grid.Children.Add (BuildTextFieldCell ("2 Timers Værdi", travelerJournalModel.OralGlukoseToleranceTest.Week28_30.Value, CellLocation.TopMiddle, 0, 2));

            Grid.SetColumn (week28_30Grid, 1);
            row1Grid.Children.Add (week28_30Grid);
            #endregion
            #endregion

            #region Row 2
            Grid row2Grid = new Grid ();
            row2Grid.ColumnDefinitions.Add (BuildColumn (1));
            row2Grid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (row2Grid, 1);

            ogttgAreaGrid.Children.Add (row2Grid);

            #region  Glycosuria
            Grid glycosuriaGrid = new Grid ();
            glycosuriaGrid.ColumnDefinitions.Add (BuildColumn (1));
            glycosuriaGrid.ColumnDefinitions.Add (BuildColumn (1));
            glycosuriaGrid.ColumnDefinitions.Add (BuildColumn (1));
            glycosuriaGrid.Children.Add (BuildListItemCell ("Ved glucosuri, såfremt der ikke er udført OGTT inden for 4 uger", CellLocation.TopLeft, 0, 0, true));
            glycosuriaGrid.Children.Add (BuildTextFieldCell ("Dato", travelerJournalModel.OralGlukoseToleranceTest.Glycosuria.Date.ToShortDateString (), CellLocation.TopLeft, 0, 1));
            glycosuriaGrid.Children.Add (BuildTextFieldCell ("2 Timers Værdi", travelerJournalModel.OralGlukoseToleranceTest.Glycosuria.Value, CellLocation.TopLeft, 0, 2));

            row2Grid.Children.Add (glycosuriaGrid);
            #endregion
            #endregion

            #region Row 3
            Grid row3Grid = new Grid ();
            row3Grid.RowDefinitions.Add (BuildRow (1));
            row3Grid.RowDefinitions.Add (BuildRow (1));
            Grid.SetRow (row3Grid, 3);

            row3Grid.Children.Add (BuildListItemCell ("Risikofaktorer: 1: Tidligere GDM | 2: Familiær Disposition | 3: BMI før graviditet >= 27 | 4: Tidligere fødsel af barn med fødselsvægt >= 4500 G | 5: Glucosuri", CellLocation.Middle, 0, 0));
            row3Grid.Children.Add (BuildListItemCell ("* Ved tidligere GDM eller mindt 2 risikofaktorer måles OGTT i 18.-20. og 28.-20. uge. | ** Ved 1 risikofaktorer måles OGTT i 28.-20. uge", CellLocation.BottomMiddle, 1, 0));

            ogttgAreaGrid.Children.Add (row3Grid);
            #endregion
            #endregion

            #region Birth Info
            Grid birthInfoAreaGrid = new Grid ();
            birthInfoAreaGrid.RowDefinitions.Add (BuildRow (1, 40));
            birthInfoAreaGrid.RowDefinitions.Add (BuildRow (1, 40));
            birthInfoAreaGrid.RowDefinitions.Add (BuildRow (1, 40));
            birthInfoAreaGrid.RowDefinitions.Add (BuildRow (1, 40));
            birthInfoAreaGrid.ColumnDefinitions.Add (BuildColumn (1));
            birthInfoAreaGrid.ColumnDefinitions.Add (BuildColumn (1));

            Border birthInfoAreaBorder = new Border ()
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness (1, 1, 1, 1),
                Margin = new Thickness (10, 10, 10, 0)
            };

            birthInfoAreaBorder.Child = birthInfoAreaGrid;

            Grid.SetRow (birthInfoAreaBorder, 7);
            display.Children.Add (birthInfoAreaBorder);

            #region Left
            birthInfoAreaGrid.Children.Add (BuildTextFieldCell ("Ønsket Fødested", travelerJournalModel.BirthplaceInfo.BirthplaceWish, CellLocation.TopLeft, 0, 0));

            Grid leftMiddleGrid = new Grid ();
            leftMiddleGrid.ColumnDefinitions.Add (BuildColumn (1));
            leftMiddleGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetRow (leftMiddleGrid, 1);
            Grid.SetColumn (leftMiddleGrid, 0);
            birthInfoAreaGrid.Children.Add (leftMiddleGrid);

            leftMiddleGrid.Children.Add (BuildTextFieldCell ("Primært planlagt fødested", travelerJournalModel.BirthplaceInfo.PrimaryExpectedBirthplace, CellLocation.TopLeft, 0, 0));
            leftMiddleGrid.Children.Add (BuildTextFieldCell ("Ændret Fødested", travelerJournalModel.BirthplaceInfo.ChangedBirthplace, CellLocation.TopLeft, 0, 1));

            birthInfoAreaGrid.Children.Add (BuildTextFieldCell ("Evt. ønsket jm-konsultation (sted/ugedag/jordemoder)", travelerJournalModel.BirthplaceInfo.MidwifeConsultationWish, CellLocation.TopLeft, 2, 0));
            birthInfoAreaGrid.Children.Add (BuildListItemCell ("Udfyldes af af jordemoderen", CellLocation.BottomLeft, 3, 0, true));
            #endregion

            #region Right
            birthInfoAreaGrid.Children.Add (BuildTextFieldCell ("Jordmodercenter", travelerJournalModel.BirthplaceInfo.MidwifeCenterName, CellLocation.TopMiddle, 0, 1));

            birthInfoAreaGrid.Children.Add (BuildTextFieldCell ("Adresse", $"{travelerJournalModel.BirthplaceInfo.MidwifeCenterStreet} {travelerJournalModel.BirthplaceInfo.MidwifeCenterHouseNumber}, {travelerJournalModel.BirthplaceInfo.MidwifeCenterPostalCode} {travelerJournalModel.BirthplaceInfo.MidwifeCenterCity}", CellLocation.TopMiddle, 1, 1));
            birthInfoAreaGrid.Children.Add (BuildTextFieldCell ("Telfon/Mobil", travelerJournalModel.BirthplaceInfo.MidwifeCenterPhone, CellLocation.TopMiddle, 2, 1));

            Grid midwifeValueGrid = new Grid ();
            midwifeValueGrid.ColumnDefinitions.Add (BuildColumn (1));
            midwifeValueGrid.ColumnDefinitions.Add (BuildColumn (1));

            Grid.SetRow (midwifeValueGrid, 3);
            Grid.SetColumn (midwifeValueGrid, 1);
            birthInfoAreaGrid.Children.Add (midwifeValueGrid);

            #region Birth Preperation Wish
            Grid birthPreperationWishGrid = new Grid ();
            birthPreperationWishGrid.ColumnDefinitions.Add (BuildColumn (1));
            birthPreperationWishGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetColumn (birthPreperationWishGrid, 0);
            midwifeValueGrid.Children.Add (birthPreperationWishGrid);

            birthPreperationWishGrid.Children.Add (BuildBooleanFieldCell ("Ønskes fødselsforberedende undervisning", "Ja", travelerJournalModel.BirthplaceInfo.BirthPreperationWish, CellLocation.BottomMiddle, 0, 0));
            birthPreperationWishGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Nej", !travelerJournalModel.BirthplaceInfo.BirthPreperationWish, CellLocation.BottomMiddle, 0, 1));
            #endregion

            #region Con Format
            Grid conFormatWishGrid = new Grid ();
            conFormatWishGrid.ColumnDefinitions.Add (BuildColumn (1));
            conFormatWishGrid.ColumnDefinitions.Add (BuildColumn (1));
            Grid.SetColumn (conFormatWishGrid, 1);
            midwifeValueGrid.Children.Add (conFormatWishGrid);

            conFormatWishGrid.Children.Add (BuildBooleanFieldCell ("Konsultationsform", "Individuel", travelerJournalModel.BirthplaceInfo.ConFormat == ConsultationFormat.Individual, CellLocation.BottomMiddle, 0, 0));
            conFormatWishGrid.Children.Add (BuildBooleanFieldCell (string.Empty, "Gruppe", travelerJournalModel.BirthplaceInfo.ConFormat == ConsultationFormat.Group, CellLocation.BottomMiddle, 0, 1));
            #endregion
            #endregion
            #endregion

            journalDisplayGrid.Children.Add (scroll);
        }

        /// <summary>
        /// Build a cell where the <paramref name="_content"/> stretches the entire cell
        /// </summary>
        /// <param name="_content">The content of the cell</param>
        /// <param name="_cellLoc">Where on the <see cref="Grid"/> the cell is located. (<i><strong>Note:</strong> This is used to define where the <see cref="Border"/> is applied to the <see cref="UIElement"/></i>)</param>
        /// <param name="_row">Which row on the <see cref="Grid"/> the cell should be placed in</param>
        /// <param name="_column">Which column on the <see cref="Grid"/> the cell should be placed in</param>
        /// <param name="_bold">Whether or not the <paramref name="_content"/> should be bold or not</param>
        /// <param name="_center">Whether or not to center the content of the cell</param>
        /// <param name="_fontSize">The size of the text in the cell</param>
        /// <returns></returns>
        private UIElement BuildListItemCell ( string _content, CellLocation _cellLoc, int _row, int _column, bool _bold = false, bool _center = false, double _fontSize = 12 )
        {
            Border cellBorder = new Border ()
            {
                BorderBrush = Brushes.Black,
                BorderThickness = BuildCellBorder (_cellLoc),
            };

            Grid.SetRow (cellBorder, _row);
            Grid.SetColumn (cellBorder, _column);

            Grid cellContainer = new Grid ();

            cellBorder.Child = cellContainer;

            Label cellContent = new Label ()
            {
                Content = _content,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalContentAlignment = ( ( _center ) ? ( HorizontalAlignment.Center ) : ( HorizontalAlignment.Left ) ),
                VerticalContentAlignment = ( ( _center ) ? ( VerticalAlignment.Center ) : ( VerticalAlignment.Top ) ),
                FontSize = _fontSize,
                FontWeight = ( ( _bold ) ? ( FontWeights.Bold ) : ( FontWeights.Normal ) )
            };

            cellContainer.Children.Add (cellContent);

            return cellBorder;
        }

        /// <summary>
        /// Build a cell containing a header <see cref="Label"/> and a content <see cref="TextBox"/>
        /// </summary>
        /// <param name="_headerText">The text to apply to the header <see cref="Label"/>
        /// <br/>
        /// If <see langword="null"/>: The <paramref name="_headerText"/> <see cref="UIElement"/> will not be displayd
        /// <br/>
        /// If <see cref="String.Empty"/>: The header <see cref="UIElement"/> is not displayed but it's space is reserved
        /// </param>
        /// <param name="_content">The content of the <see cref="TextBox"/></param>
        /// <param name="_cellLoc">Where on the <see cref="Grid"/> the cell is located. (<i><strong>Note:</strong> This is used to define where the <see cref="Border"/> is applied to the <see cref="UIElement"/></i>)</param>
        /// <param name="_row">Which row on the <see cref="Grid"/> the cell should be placed in</param>
        /// <param name="_column">Which column on the <see cref="Grid"/> the cell should be placed in</param>
        /// <param name="_readOnly">Whether or not the <see cref="TextBox"/> content is <see langword="readonly"/></param>
        /// <returns></returns>
        private UIElement BuildTextFieldCell ( string _headerText, string _content, CellLocation _cellLoc, int _row, int _column, bool _readOnly = true )
        {
            Border cellBorder = new Border ()
            {
                BorderBrush = Brushes.Black,
                BorderThickness = BuildCellBorder (_cellLoc),
            };

            Grid.SetRow (cellBorder, _row);
            Grid.SetColumn (cellBorder, _column);

            Grid cellContainer = new Grid ();

            cellBorder.Child = cellContainer;

            if ( _headerText != null )
            {
                Label cellHeader = new Label ()
                {
                    Content = _headerText,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    FontWeight = FontWeights.Bold,
                    Visibility = ( ( _headerText != string.Empty ? ( Visibility.Visible ) : ( Visibility.Hidden ) ) )
                };

                cellContainer.Children.Add (cellHeader);
            }


            TextBox cellContent = new TextBox ()
            {
                Text = _content,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = ( ( _headerText != null ) ? ( VerticalAlignment.Bottom ) : ( VerticalAlignment.Stretch ) ),
                Margin = new Thickness (( ( _headerText != null ) ? ( 10 ) : ( 0 ) ), 0, 0, 0),
                MaxLines = ( ( _headerText != null ) ? ( 1 ) : ( int.MaxValue ) ),
                IsReadOnly = _readOnly
            };

            cellContainer.Children.Add (cellContent);

            return cellBorder;
        }

        /// <summary>
        /// Build a cell containing a header <see cref="Label"/> and a boolean <see cref="CheckBox"/>
        /// </summary>
        /// <param name="_headerText">The text to apply to the header <see cref="Label"/></param>
        /// <param name="_content">The text to display for the <see cref="CheckBox"/>. Ex: <i>[ ] ContentText</i></param>
        /// <param name="_state">The state of the <see cref="CheckBox"/></param>
        /// <param name="_cellLoc">Where on the <see cref="Grid"/> the cell is located. (<i><strong>Note:</strong> This is used to define where the <see cref="Border"/> is applied to the <see cref="UIElement"/></i>)</param>
        /// <param name="_row">Which row on the <see cref="Grid"/> the cell should be placed in</param>
        /// <param name="_column">Which column on the <see cref="Grid"/> the cell should be placed in</param>
        /// <param name="_readOnly">Whether or not the <see cref="CheckBox"/> state is <see langword="readonly"/></param>
        /// <returns></returns>
        private UIElement BuildBooleanFieldCell ( string _headerText, string _content, bool _state, CellLocation _cellLoc, int _row, int _column, bool _readOnly = true )
        {
            Border cellBorder = new Border ()
            {
                BorderBrush = Brushes.Black,
                BorderThickness = BuildCellBorder (_cellLoc),
            };

            Grid.SetRow (cellBorder, _row);
            Grid.SetColumn (cellBorder, _column);

            Grid cellContainer = new Grid ();

            cellBorder.Child = cellContainer;

            Label cellHeader = new Label ()
            {
                Content = _headerText,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                FontWeight = FontWeights.Bold
            };

            CheckBox cellContent = new CheckBox ()
            {
                Content = _content,
                IsChecked = _state,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness (10, 0, 0, 0),
                IsEnabled = !_readOnly
            };

            cellContainer.Children.Add (cellHeader);
            cellContainer.Children.Add (cellContent);

            return cellBorder;
        }

        /// <summary>
        /// Defines where to draw <see cref="Border"/> lines
        /// </summary>
        /// <param name="_cellLoc"></param>
        /// <returns>A <see cref="Thickness"/> representing the border locations</returns>
        private Thickness BuildCellBorder ( CellLocation _cellLoc )
        {
            Thickness border;

            switch ( _cellLoc )
            {
                case CellLocation.TopLeft:
                    border = new Thickness (0, 0, 1, 1);
                    break;
                case CellLocation.TopRight:
                    border = new Thickness (1, 0, 0, 1);
                    break;
                case CellLocation.TopMiddle:
                    border = new Thickness (0, 0, 0, 1);
                    break;
                case CellLocation.MiddleLeft:
                    border = new Thickness (0, 0, 1, 1);
                    break;
                case CellLocation.MiddleRight:
                    border = new Thickness (1, 0, 0, 1);
                    break;
                case CellLocation.Middle:
                    border = new Thickness (0, 0, 0, 1);
                    break;
                case CellLocation.BottomLeft:
                    border = new Thickness (0, 0, 1, 0);
                    break;
                case CellLocation.BottomRight:
                    border = new Thickness (0, 1, 0, 0);
                    break;
                case CellLocation.BottomMiddle:
                    border = new Thickness (0, 0, 0, 0);
                    break;
                default:
                    break;
            }

            return border;
        }

        /// <summary>
        /// Clear all <see cref="RowDefinition"/>s, <see cref="ColumnDefinition"/>s and children in <paramref name="_container"/>
        /// </summary>
        /// <param name="_container"></param>
        private void ClearDisplay ( Grid _container )
        {
            _container.RowDefinitions.Clear ();
            _container.ColumnDefinitions.Clear ();
            _container.Children.Clear ();
        }

        /// <summary>
        /// Set the view model to be used based on the <see cref="Type"/> of <paramref name="_journal"/>
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="_journal"></param>
        private void SetJournalModel ( IJournal _journal )
        {
            if ( _journal is IPregnancyJournal _pJournal )
            {
                pregnancyJournalModel = new PregnancyJournalViewModel ()
                {
                    Abortions = _pJournal.Abortions,
                    Anamnese = _pJournal.Anamnese,
                    ID = _pJournal.ID,
                    Investegations = _pJournal.Investegations,
                    ResAndRiskAssessement = _pJournal.ResAndRiskAssessement,
                    JournalDestination = _pJournal.JournalDestination,
                    PatientData = _pJournal.PatientData,
                    Pregnancies = _pJournal.Pregnancies
                };
            }
            else if ( _journal is ITravelerJournal _tJournal )
            {
                travelerJournalModel = new TravelerJournalViewModel ()
                {
                    AdditonalContext = _tJournal.AdditonalContext,
                    AmnioticFluidTest = _tJournal.AmnioticFluidTest,
                    AntibodyByRhesusNegative = _tJournal.AntibodyByRhesusNegative,
                    AntiDImmunoglobulinGiven = _tJournal.AntiDImmunoglobulinGiven,
                    IrregularAntibody = _tJournal.IrregularAntibody,
                    BirthplaceInfo = _tJournal.BirthplaceInfo,
                    BloodTypeDetermined = _tJournal.BloodTypeDetermined,
                    ChildsRhesusFactor = _tJournal.ChildsRhesusFactor,
                    DoubleTest = _tJournal.DoubleTest,
                    HepB = _tJournal.HepB,
                    ID = _tJournal.ID,
                    JournalComments = _tJournal.JournalComments,
                    JournalDestination = _tJournal.JournalDestination,
                    JournalStamps = _tJournal.JournalStamps,
                    MenstrualInfo = _tJournal.MenstrualInfo,
                    MothersRhesusFactor = _tJournal.MothersRhesusFactor,
                    NaegelsRule = _tJournal.NaegelsRule,
                    NuchalFoldScan = _tJournal.NuchalFoldScan,
                    OddsForDS = _tJournal.OddsForDS,
                    OralGlukoseToleranceTest = _tJournal.OralGlukoseToleranceTest,
                    PatientData = _tJournal.PatientData,
                    PlacentaTest = _tJournal.PlacentaTest,
                    TripleTest = _tJournal.TripleTest,
                    UltraSoundScans = _tJournal.UltraSoundScans,
                    UltrasoundTermin = _tJournal.UltrasoundTermin,
                    UrineCulture = _tJournal.UrineCulture,
                    WeightInfo = _tJournal.WeightInfo
                };
            }
        }

        /// <summary>
        /// Build a button that can create an <see cref="IPregnancyJournal"/> or an <see cref="ITravelerJournal"/> based on <paramref name="_type"/>
        /// </summary>
        /// <param name="_content">The text written on the button</param>
        /// <param name="_type"></param>
        /// <returns></returns>
        private Button BuildCreateJournalButton ( string _content, JournalType _type )
        {
            Button button = new Button ()
            {
                Content = _content,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            button.Click += ( o, e ) =>
            {
                IJournal journal = JournalFactory.CreateWithPatient (_type, Context);

                switch ( _type )
                {
                    case JournalType.PregnancyJournal:
                        PregnancyJournalRepo.Link.InsertData (journal);
                        SetJournalModel (journal);
                        BuildPregnancyJournalDisplay ();
                        break;
                    case JournalType.TravelerJournal:
                        TravelerJournalRepo.Link.InsertData (journal);
                        SetJournalModel (journal);
                        BuildTravelerJournalDisplay ();
                        break;
                    default:
                        break;
                }
            };

            return button;
        }

        public override void Construct ( StackPanel _headerArea, Grid _contentArea )
        {
            headerParent = _headerArea;
            contentParent = _contentArea;

            if ( content == null )
            {
                BuildContainer ();

                BuildHeaderElement ();

                BuildContentHeaderArea ($"{Context.SSN}, {Context.Name}");

                BuildPatientDataArea ();

                BuildNavBarArea ();

                BuildContentArea ();

                BuildButtonPanel ();

                _contentArea.Children.Add (content);

                #region Open Pregnancy Journal Tab
                IPregnancyJournal journal = PregnancyJournalRepo.Link.GetEnumerable ().ToList ().Find (item => item.PatientData.ID == Context.ID);

                if ( journal != null )
                {
                    SetJournalModel (journal);

                    BuildPregnancyJournalDisplay ();
                    return;
                }

                journalDisplayGrid.Children.Add (BuildCreateJournalButton ("Tilføj Svangerskabsjournal", JournalType.PregnancyJournal));
                #endregion
            }
        }

        public enum CellLocation
        {
            TopLeft,
            TopRight,
            TopMiddle,
            MiddleLeft,
            MiddleRight,
            Middle,
            BottomLeft,
            BottomRight,
            BottomMiddle
        }
    }
}
