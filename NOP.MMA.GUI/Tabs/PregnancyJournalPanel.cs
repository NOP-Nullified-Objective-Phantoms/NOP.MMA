using NOP.MMA.Core.Journals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace NOP.MMA.GUI.Tabs
{
    /// <summary>
    /// Represents a <see cref="TabCollection"/> panel for <see cref="IPregnancyJournal"/> <see langword="objects"/>
    /// </summary>
    internal class PregnancyJournalPanel : TabCollection
    {
        /// <summary>
        /// Initialize a new instance of type <see cref="PregnancyJournalPanel"/> where the <paramref name="_tabDisplay"/> and <paramref name="_contentArea"/> is defined
        /// </summary>
        /// <param name="_tabDisplay">The panel tabs are instantiated into</param>
        /// <param name="_contentArea">The grid that contains the content for a given tab</param>
        public PregnancyJournalPanel ( StackPanel _tabDisplay, Grid _contentArea ) : base ()
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
        /// <inheritdoc/> and remove it from the <see cref="TabCollection"/>
        /// </summary>
        /// <param name="_tab">The tab to close</param>
        /// <returns><inheritdoc/></returns>
        public override bool CloseTab ( ITabItem _tab )
        {
            ITabItem item = Tabs.Find (item => item.ID == _tab.ID);

            if ( item != null )
            {
                item.Close ();
                return Tabs.Remove (item);
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
        /// Create a new tab and add it to the <see cref="TabCollection"/> without an associated <see cref="IPregnancyJournal"/> context
        /// </summary>
        /// <param name="_headerText">The text to display as header</param>
        /// <param name="_showContent">Whether or not to display the tab after creation</param>
        /// <returns>The newly created <see cref="ITabItem"/></returns>
        public ITabItem CreateTab ( string _headerText, bool _showContent = true )
        {
            PregnancyJournalTab item = new PregnancyJournalTab (_headerText, _showContent);

            #region On Click Behaviour
            item.OnClick = ( o, e ) =>
            {
                ITabItem other = FindTab (item => item.IsVisible == true);
                if ( other != null )
                {
                    MinimizeTab (other);
                }

                OpenTab (item);
            };
            #endregion

            #region On Close Behaviour
            item.OnCloseClick = ( o, e ) =>
            {
                CloseTab (item);

                if ( FindTab (item => item.IsVisible == true) == null )
                {
                    if ( Tabs.Count > 0 && Tabs[ 0 ] != null )
                    {
                        OpenTab (Tabs[ 0 ]);
                    }
                }
            };
            #endregion

            Tabs.Add (item);

            item.Construct (tabDisplay, contentArea);

            return item;
        }

        /// <summary>
        /// Create a new tab and add it to the <see cref="TabCollection"/> with an associated <see cref="IPregnancyJournal"/> context
        /// </summary>
        /// <param name="_headerText">The text to display as header</param>
        /// <param name="_journal">The associated <see cref="IPregnancyJournal"/> context</param>
        /// <param name="_showContent">Whether or not to display the tab after creation</param>
        /// <returns>The newly created <see cref="ITabItem"/></returns>
        public ITabItem CreateTab ( string _headerText, IPregnancyJournal _journal, bool _showContent = true )
        {
            PregnancyJournalTab item = CreateTab (_headerText, _showContent) as PregnancyJournalTab;

            item.Context = _journal;

            return item;
        }
    }
}
