using NOP.MMA.Core.Journals;
using NOP.MMA.Core.Patients;
using NOP.MMA.GUI.Tabs;
using NOP.MMA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NOP.MMA.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The panel that holds all current initializes <see cref="TabItem"/> <see langword="objects"/>
        /// </summary>
        internal static NavTabPanel panel;

        public MainWindow ()
        {
            InitializeComponent ();

            panel = new NavTabPanel (navHeaders, navContent);
        }

        /// <summary>
        /// Create a new <see cref="PatientIndexTab"/> and minimize any open tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click ( object sender, RoutedEventArgs e )
        {
            panel.MinimizeTab (panel.FindTab (item => item.IsVisible == true));

            //IPatient patient = PatientFactory.Create ();  //  Use To create a new test dummy
            //PatientRepo.Link.InsertData (patient);    //  Insert new test dummy into data storage if needed

            //IPregnancyJournal pJournal = JournalFactory.CreateWithPatient (JournalType.PregnancyJournal, patient) as IPregnancyJournal;  //  Use To create a new test dummy
            //PregnancyJournalRepo.Link.InsertData (pJournal);    //  Insert new test dummy into data storage if needed

            //ITravelerJournal tJournal = JournalFactory.CreateWithPatient (JournalType.TravelerJournal, patient) as ITravelerJournal;  //  Use To create a new test dummy
            //TravelerJournalRepo.Link.InsertData (tJournal);    //  Insert new test dummy into data storage if needed

            //JournalStamp stamp = new JournalStamp ()
            //{
            //    BloodPressure = "Test",
            //    FetusActivity = true,
            //    GestationAge = "Test",
            //    Date = DateTime.Now,
            //    Edema = true,
            //    ExaminationLocation = "Test",
            //    FetusGender = "Test",
            //    FosterRepresentation = "Test",
            //    Initials = "Test",
            //    UrinSample = "Test",
            //    UterusSizeInCM = 0.00,
            //    Weight = 0.00
            //};

            //JournalComment comment = new JournalComment ()
            //{
            //    Date = DateTime.Now,
            //    Comment = "Test Comment"
            //};

            //ITravelerJournal journal = TravelerJournalRepo.Link.GetDataByIdentifier (1);
            //journal.AddJournalStamp (stamp);
            //journal.AddJournalComment (comment);

            //TravelerJournalRepo.Link.UpdateData (journal);

            //IPatient patient = PatientRepo.Link.GetDataByIdentifier (1);    //  Getting test dummy from data storage
            //panel.CreatePatientDataTab (patient.Name, patient); //  Creates a new tab for the dummy
            panel.CreatePatientOverviewTab ("Patient Oversigt");
        }
    }
}
