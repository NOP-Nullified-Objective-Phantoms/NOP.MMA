using NOP.MMA.Core.Patients;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace NOP.MMA.GUI.Tabs
{
    /// <summary>
    /// Represents a collection of <see cref="TabItem"/> <see langword="objects"/> that can populate a <see cref="StackPanel"/> display with tabs
    /// </summary>
    internal class NavTabPanel : TabCollection
    {
        /// <summary>
        /// Initialize a new instance of type <see cref="NavTabPanel"/> where the <paramref name="_tabDisplay"/> and <paramref name="_contentArea"/> is defined
        /// </summary>
        /// <param name="_tabDisplay">The panel tabs are instantiated into</param>
        /// <param name="_contentArea">The grid that contains the content for a given tab</param>
        public NavTabPanel ( StackPanel _tabDisplay, Grid _contentArea ) : base ()
        {
            tabDisplay = _tabDisplay;
            contentArea = _contentArea;
        }

        /// <summary>
        /// The panel tabs are instantiated into
        /// </summary>
        private readonly StackPanel tabDisplay;
        /// <summary>
        /// The grid that contains the content for a given tab
        /// </summary>
        private readonly Grid contentArea;

        /// <summary>
        /// <inheritdoc/> and remove it from the <see cref="TabCollection"/>. If there's other tabs in the <see cref="TabCollection"/> this will switch tab to the latest tab added to the <see cref="TabCollection"/>
        /// </summary>
        /// <param name="_tab">The tab to close</param>
        /// <returns><inheritdoc/></returns>
        public override bool CloseTab ( ITabItem _tab )
        {
            ITabItem item = Tabs.Find (item => item.ID == _tab.ID);

            if ( item != null )
            {
                item.Close ();

                if ( Tabs.Remove (item) && FindTab (item => item.IsVisible == true) == null )
                {
                    if ( Tabs.Count > 0 && Tabs[ ( ( Tabs.Count - 1 >= 0 ) ? ( Tabs.Count - 1 ) : ( Tabs.Count ) ) ] != null )
                    {
                        return OpenTab (Tabs[ ( ( Tabs.Count - 1 >= 0 ) ? ( Tabs.Count - 1 ) : ( Tabs.Count ) ) ]);
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="_tab">The tab to minimize</param>
        /// <returns><see langword="True"/> if the tab could be minimized; Otherwise, if not, <see langword="false"/></returns>
        public override bool MinimizeTab ( ITabItem _tab )
        {
            if ( _tab != null )
            {
                _tab.Show (false);
                return true;
            }

            return false;
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="_tab">The tab to open</param>
        /// <returns><inheritdoc/></returns>
        public override bool OpenTab ( ITabItem _tab )
        {
            if ( _tab != null )
            {
                _tab.Show ();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Apply the base configuration for all <see cref="TabItem"/> <see langword="objects"/> in the <see cref="TabCollection"/>
        /// </summary>
        /// <param name="_tab">The tab to configure</param>
        /// <param name="_showContent">Whether or not to show the tab after configuration</param>
        private void ConfigurateTab ( TabItem _tab, bool _showContent )
        {
            #region On Click Behaviour
            _tab.OnClick = ( o, e ) =>
            {
                ITabItem other = FindTab (item => item.IsVisible == true);
                if ( other != null )
                {
                    MinimizeTab (other);
                }

                OpenTab (_tab);
            };
            #endregion

            #region On Close Behaviour
            _tab.OnCloseClick = ( o, e ) =>
             {
                 CloseTab (_tab);
             };
            #endregion

            Tabs.Add (_tab);

            _tab.Construct (tabDisplay, contentArea);

            if ( _showContent )
            {
                MinimizeTab (FindTab (item => item.IsVisible == true && item.ID != _tab.ID));
            }
        }

        /// <summary>
        /// Create a new instance of type <see cref="PatientDataTab"/> and add it to the <see cref="TabCollection"/>
        /// </summary>
        /// <param name="_headerText">The text to display as header</param>
        /// <param name="_showContent">Whether or not to display the tab after creation</param>
        /// <returns>The newly created <see cref="ITabItem"/></returns>
        public ITabItem CreatePatientDataTab ( string _headerText, IPatient _context, bool _showContent = true )
        {
            TabItem tab = new PatientDataTab (_headerText, _showContent)
            {
                Context = _context
            };

            ConfigurateTab (tab, _showContent);

            return tab;
        }

        /// <summary>
        /// Create a new instance of type <see cref="PatientIndexTab"/> and add it to the <see cref="TabCollection"/>
        /// </summary>
        /// <param name="_headerText">The text to display as header</param>
        /// <param name="_showContent">Whether or not to display the tab after creation</param>
        /// <returns>The newly created <see cref="ITabItem"/></returns>
        public ITabItem CreatePatientOverviewTab ( string _headerText, bool _showContent = true )
        {
            TabItem tab = new PatientIndexTab (_headerText, _showContent);

            ConfigurateTab (tab, _showContent);

            return tab;
        }
    }
}
