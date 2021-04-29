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

                pregnancyJournalModel = new PregnancyJournalViewModel ()
                {
                    Abortions = journal.Abortions,
                    Anamnese = journal.Anamnese,
                    ID = journal.ID,
                    Investegations = journal.Investegations,
                    ResAndRiskAssessement = journal.ResAndRiskAssessement,
                    JournalDestination = journal.JournalDestination,
                    PatientData = journal.PatientData,
                    Pregnancies = journal.Pregnancies
                };

                //journalDisplayGrid.Children.Add (new Label () { Content = $"Journal Loaded with ID: {pregnancyJournalModel.ID}" });
                BuildPregnancyJournalDisplay ();
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

                travelerJournalModel = new TravelerJournalViewModel ()
                {
                    AdditonalContext = journal.AdditonalContext,
                    AmnioticFluidTest = journal.AmnioticFluidTest,
                    AntibodyByRhesusNegative = journal.AntibodyByRhesusNegative,
                    AntiDImmunoglobulinGiven = journal.AntiDImmunoglobulinGiven,
                    IrregularAntibody = journal.IrregularAntibody,
                    BirthplaceInfo = journal.BirthplaceInfo,
                    BloodTypeDetermined = journal.BloodTypeDetermined,
                    ChildsRhesusFactor = journal.ChildsRhesusFactor,
                    DoubleTest = journal.DoubleTest,
                    HepB = journal.HepB,
                    ID = journal.ID,
                    JournalComments = journal.JournalComments,
                    JournalDestination = journal.JournalDestination,
                    JournalStamps = journal.JournalStamps,
                    MenstrualInfo = journal.MenstrualInfo,
                    MothersRhesusFactor = journal.MothersRhesusFactor,
                    NaegelsRule = journal.NaegelsRule,
                    NuchalFoldScan = journal.NuchalFoldScan,
                    OddsForDS = journal.OddsForDS,
                    OralGlukoseToleranceTest = journal.OralGlukoseToleranceTest,
                    PatientData = journal.PatientData,
                    PlacentaTest = journal.PlacentaTest,
                    TripleTest = journal.TripleTest,
                    UltraSoundScans = journal.UltraSoundScans,
                    UltrasoundTermin = journal.UltrasoundTermin,
                    UrineCulture = journal.UrineCulture,
                    WeightInfo = journal.WeightInfo
                };

                BuildTravelerJournalDisplay ();
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
                }
                else
                {
                    ITravelerJournal journal = TravelerJournalRepo.Link.GetDataByIdentifier (travelerJournalModel.ID);
                    TravelerJournalRepo.Link.DeleteData (journal);
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
            #region Columns = 4
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
            #region Rows = 4
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
        /// <returns></returns>
        private UIElement BuildListItemCell ( string _content, CellLocation _cellLoc, int _row, int _column, bool _bold = false )
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
                FontWeight = ( ( _bold ) ? ( FontWeights.Bold ) : ( FontWeights.Normal ) )
            };

            cellContainer.Children.Add (cellContent);

            return cellBorder;
        }

        /// <summary>
        /// Build a cell containing a header <see cref="Label"/> and a content <see cref="TextBox"/>
        /// </summary>
        /// <param name="_headerText">The text to apply to the header <see cref="Label"/></param>
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

            Label cellHeader = new Label ()
            {
                Content = _headerText,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                FontWeight = FontWeights.Bold
            };

            TextBox cellContent = new TextBox ()
            {
                Text = _content,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness (10, 0, 0, 0),
                IsReadOnly = _readOnly
            };

            cellContainer.Children.Add (cellHeader);
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
