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
        public IPatient Context { get; set; }

        private string BuildHeaderText ()
        {
            string tempHeader = Header;

            if ( tempHeader != null && tempHeader.Length > 15 )
            {
                tempHeader = tempHeader.Remove (15);
                tempHeader += "...";
            }

            return tempHeader;
        }

        private void BuildContainer ()
        {
            content = new Grid ();
            content.RowDefinitions.Add (BuildRow (25));
            content.RowDefinitions.Add (BuildRow (140));
            content.RowDefinitions.Add (BuildRow (40));
            content.RowDefinitions.Add (BuildRow (615));
            content.RowDefinitions.Add (BuildRow (85));
        }

        private void BuildContentHeaderArea ()
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
                Content = $"{Context.SSN}, {Context.Name}",
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
            patientData.RowDefinitions.Add (BuildRow (1, true));
            patientData.RowDefinitions.Add (BuildRow (1, true));
            patientData.RowDefinitions.Add (BuildRow (1, true));

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


            journalDisplayGrid = new Grid ();

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

        }

        private void BuildTravelerJournalDisplay ()
        {

        }

        private void BuildHeaderElement ()
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

        /// <summary>
        /// Build a <see cref="RowDefinition"/> with a height of <paramref name="_height"/>
        /// </summary>
        /// <param name="_height">The height of the row</param>
        /// <param name="_noMinimum">Whether or not to use the <paramref name="_height"/> as minimum height as well</param>
        /// <returns></returns>
        private RowDefinition BuildRow ( int _height, bool _noMinimum = false )
        {
            RowDefinition def = new RowDefinition ()
            {
                Height = new GridLength (_height, GridUnitType.Star),
            };

            if ( !_noMinimum )
            {
                def.MinHeight = _height;
            }

            return def;
        }

        public override void Construct ( StackPanel _headerArea, Grid _contentArea )
        {
            headerParent = _headerArea;
            contentParent = _contentArea;

            if ( content == null )
            {
                BuildContainer ();

                BuildHeaderElement ();

                BuildContentHeaderArea ();

                BuildPatientDataArea ();

                BuildNavBarArea ();

                BuildContentArea ();

                BuildButtonPanel ();

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
