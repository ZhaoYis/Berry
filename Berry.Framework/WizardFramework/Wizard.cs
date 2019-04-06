﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WizardFramework
{
    /// <summary>
    /// Represents the base class for wizards. 
    /// </summary>
    /// <remarks>
    /// Although this class is not marked as abstract, it still should be the base class for all the
    /// wizards. Marking this class as abstract will prevent developers from customizing the wizard
    /// by using Windows Forms Designer.
    /// </remarks>
    public partial class Wizard : Form, IWizard
    {

        #region Private Fields

        private readonly List<Tuple<WizardPageBase, bool>> _wizardPages = new List<Tuple<WizardPageBase, bool>>();

        private volatile int _currentPageIndex = 0;

        #endregion Private Fields

        #region Protected Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Wizard" /> class. 
        /// </summary>
        protected Wizard()
        {
            InitializeComponent();
            if (this.components == null)
            {
                this.components = new Container();
            }
            this.components.Add(new Disposer(this.OnDispose));
        }

        #endregion Protected Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the text for the Cancel button.
        /// </summary>
        /// <value>
        /// The text for the Cancel button.
        /// </value>
        [Category("Wizard")]
        [Description("Gets or sets the text for the Cancel button.")]
        public string CancelText
        {
            get { return this.btnCancel.Text; }
            set { this.btnCancel.Text = value; }
        }

        /// <summary>
        /// Gets the number of elements contained in the <see
        /// cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        [Browsable(false)]
        public int Count
        {
            get { return this._wizardPages.Count; }
        }

        /// <summary>
        /// Gets or sets the text for the Finish button.
        /// </summary>
        /// <value>
        /// The text for the Finish button.
        /// </value>
        [Category("Wizard")]
        [Description("Gets or sets the text for the Finish button.")]
        public string FinishText
        {
            get { return this.btnFinish.Text; }
            set { this.btnFinish.Text = value; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see
        /// cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
        /// </summary>
        [Browsable(false)]
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a list of <see cref="IWizardModel" /> instances that represent the data model for
        /// each wizard page in the wizard.
        /// </summary>
        /// <value> The list of <see cref="IWizardModel" /> instances. </value>
        [Browsable(false)]
        public IEnumerable<IWizardModel> Models
        {
            get { return this._wizardPages.Select(p => p.Item1.Model); }
        }

        /// <summary>
        /// Gets or sets the text for the Next button.
        /// </summary>
        /// <value>
        /// The text for the Next button.
        /// </value>
        [Category("Wizard")]
        [Description("Gets or sets the text for the Next button.")]
        public string NextText
        {
            get { return this.btnNext.Text; }
            set { this.btnNext.Text = value; }
        }

        /// <summary>
        /// Gets or sets the text for the Previous button.
        /// </summary>
        /// <value>
        /// The text for the Previous button.
        /// </value>
        [Category("Wizard")]
        [Description("Gets or sets the text for the Previous button.")]
        public string PreviousText
        {
            get { return this.btnPrevious.Text; }
            set { this.btnPrevious.Text = value; }
        }

        #endregion Public Properties

        #region Private Properties

        private WizardPageBase CurrentPage
        {
            get
            {
                if (this.pnlContent.Controls.Count == 0)
                {
                    return null;
                }
                return this.pnlContent.Controls[0] as WizardPageBase;
            }
        }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        /// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1" />. 
        /// </summary>
        /// <param name="item">
        /// The object to add to the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </param>
        public void Add(WizardPageBase item)
        {
            if (item != null)
            {
                item.NavigationStateUpdated += WizardPageNavigationStatusUpdateHandler;
                this._wizardPages.Add(new Tuple<WizardPageBase, bool>(item, true));
            }
        }

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1" />. 
        /// </summary>
        public void Clear()
        {
            foreach (var wizardPage in this)
            {
                wizardPage.NavigationStateUpdated -= WizardPageNavigationStatusUpdateHandler;
            }
            this._wizardPages.Clear();
        }

        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1" />
        /// contains a specific value.
        /// </summary>
        /// <param name="item">
        /// The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </param>
        /// <returns>
        /// true if <paramref name="item" /> is found in the <see
        /// cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false.
        /// </returns>
        public bool Contains(WizardPageBase item)
        {
            return this._wizardPages.Exists(p => p.Item1 == item);
        }

        /// <summary>
        /// Copies the wizard pages to the specified array. 
        /// </summary>
        /// <param name="array"> The array. </param>
        /// <param name="arrayIndex"> Index of the array. </param>
        public void CopyTo(WizardPageBase[] array, int arrayIndex)
        {
            this._wizardPages.Select(p => p.Item1).ToList().CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// The factory method for creating a wizard page with specific wizard type. 
        /// </summary>
        /// <typeparam name="T"> The type of the wizard page to be created. </typeparam>
        /// <returns> A <see cref="WizardPageBase" /> instance that is created. </returns>
        /// <exception cref="System.InvalidOperationException">
        /// Cannot create a wizard page with no public constructor which takes the IWizard instance
        /// as its only parameter.
        /// </exception>
        public T CreatePage<T>() where T : WizardPageBase
        {
            var constructorInfo = typeof(T).GetConstructor(new[] { typeof(Wizard) });
            if (constructorInfo == null)
            {
                throw new InvalidOperationException("Cannot create a wizard page with no public constructor which takes the IWizard instance as its only parameter.");
            }
            return (T)Activator.CreateInstance(typeof(T), this);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection. 
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate
        /// through the collection.
        /// </returns>
        public IEnumerator<WizardPageBase> GetEnumerator()
        {
            return this._wizardPages.Select(p => p.Item1).GetEnumerator();
        }

        /// <summary>
        /// Gets the data model from the wizard with specified model type. 
        /// </summary>
        /// <typeparam name="T"> The <see cref="Type" /> of the model. </typeparam>
        /// <returns> The data model for the particular wizard page. </returns>
        public T GetWizardModel<T>() where T : class, IWizardModel
        {
            if (this.Count > 0)
            {
                foreach (var wizardPage in this)
                {
                    if (wizardPage.Model != null && wizardPage.Model.GetType() == typeof(T))
                    {
                        return (T)wizardPage.Model;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see
        /// cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="item">
        /// The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </param>
        /// <returns>
        /// true if <paramref name="item" /> was successfully removed from the <see
        /// cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false. This method also
        /// returns false if <paramref name="item" /> is not found in the original <see
        /// cref="T:System.Collections.Generic.ICollection`1" />.
        /// </returns>
        public bool Remove(WizardPageBase item)
        {
            if (item != null)
            {
                item.NavigationStateUpdated -= WizardPageNavigationStatusUpdateHandler;
                var removable = this._wizardPages.FirstOrDefault(t => t.Item1 == item);
                if (removable != null)
                    return this._wizardPages.Remove(removable);
            }
            return false;
        }
        
        public bool Remove(int index)
        {
            this._wizardPages[index].Item1.NavigationStateUpdated -= WizardPageNavigationStatusUpdateHandler;
            var removable = this._wizardPages.FirstOrDefault(t => t.Item1 == this._wizardPages[index].Item1);
            if (removable != null)
                return this._wizardPages.Remove(removable);
            return false;
        }

        /// <summary>
        /// Sets the display behavior of the wizard page. 
        /// </summary>
        /// <param name="pageIndex"> Index of the page on which the display behavior is specified. </param>
        /// <param name="display"> The display behavior. </param>
        public void SetPageDisplay(int pageIndex, WizardPageDisplay display)
        {
            switch (display)
            {
                case WizardPageDisplay.Hide:
                    this._wizardPages[pageIndex] = new Tuple<WizardPageBase, bool>(this._wizardPages[pageIndex].Item1, false);
                    break;

                case WizardPageDisplay.Show:
                    this._wizardPages[pageIndex] = new Tuple<WizardPageBase, bool>(this._wizardPages[pageIndex].Item1, true);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Sets the display behavior of the wizard page. 
        /// </summary>
        /// <typeparam name="T">
        /// The type of the wizard page on which the display behavior is specified.
        /// </typeparam>
        /// <param name="display"> The display behavior. </param>
        public void SetPageDisplay<T>(WizardPageDisplay display)
            where T : WizardPageBase
        {
            var index = this._wizardPages.FindIndex(pred => pred.Item1.GetType() == typeof(T));
            this.SetPageDisplay(index, display);
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection. 
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate
        /// through the collection.
        /// </returns>
        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this._wizardPages.GetEnumerator();
        }

        #endregion Public Methods

        #region Internal Methods

        /// <summary>
        /// Goes to the next page.
        /// </summary>
        /// <returns></returns>
        internal async Task GoNextPageAsync()
        {
            using (new LengthyOperation(this))
            {
                var wizardPage = this._wizardPages[_currentPageIndex].Item1;
                if (!await wizardPage.ExecuteBeforeGoingNextAsync())
                {
                    return;
                }
                while (_currentPageIndex < this.Count - 1)
                {
                    _currentPageIndex++;
                    if (!this._wizardPages[_currentPageIndex].Item2)
                    {
                        continue;
                    }
                    else
                    {
                        ShowWizardPage(_currentPageIndex);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Goes to the previous page.
        /// </summary>
        /// <returns></returns>
        internal async Task GoPreviousPageAsync()
        {
            using (new LengthyOperation(this))
            {
                var wizardPage = this._wizardPages[_currentPageIndex].Item1;
                if (!await wizardPage.ExecuteBeforeGoingPreviousAsync())
                {
                    return;
                }
                while (_currentPageIndex > 0)
                {
                    _currentPageIndex--;
                    if (!this._wizardPages[_currentPageIndex].Item2)
                    {
                        continue;
                    }
                    else
                    {
                        ShowWizardPage(_currentPageIndex);
                        break;
                    }
                }
            }
        }

        #endregion Internal Methods

        #region Protected Methods

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Closed" /> event. 
        /// </summary>
        /// <param name="e"> The <see cref="T:System.EventArgs" /> that contains the event data. </param>
        protected override void OnClosed(EventArgs e)
        {
            // Clears the pnlContent to trigger the ControlRemoved event. 
            if (this.pnlContent.Controls.Count > 0)
            {
                var ctrl = this.pnlContent.Controls[0];
                ctrl.Tag = (this.DialogResult == DialogResult.Cancel);
                this.pnlContent.Controls.Clear();
            }
            base.OnClosed(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Shown" /> event. 
        /// </summary>
        /// <param name="e"> A <see cref="T:System.EventArgs" /> that contains the event data. </param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.ShowWizardPage();
        }

        #endregion Protected Methods

        #region Private Methods

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result =  MessageBox.Show("确定要退出安装向导吗？", "温馨提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                Close();
            }
        }

        private async void btnFinish_Click(object sender, EventArgs e)
        {
            using (new LengthyOperation(this))
            {
                var wizardPage = this._wizardPages[_currentPageIndex].Item1;
                if (!await wizardPage.ExecuteBeforeGoingFinishAsync())
                {
                    DialogResult = DialogResult.None;
                }
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            await GoNextPageAsync();
        }
        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            await GoPreviousPageAsync();
        }
        private void OnDispose(bool disposing)
        {
            this.Clear();
        }

        private void pnlContent_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control != null && e.Control is WizardPageBase)
            {
                var wizardPage = e.Control as WizardPageBase;
                this.lblTitle.Text = wizardPage.Title;
                this.lblDescription.Text = wizardPage.Description;
                this.lblTitle.Refresh();
                this.lblDescription.Refresh();
                if (wizardPage.Logo != null)
                {
                    picLogo.Visible = true;
                    picLogo.Image = wizardPage.Logo;
                    lblDescription.Width = picLogo.Left - lblDescription.Left;
                }
                else
                {
                    picLogo.Visible = false;
                    picLogo.Image = null;
                    lblDescription.Width = picLogo.Left + picLogo.Width - lblDescription.Left;
                }
                switch (wizardPage.Type)
                {
                    case WizardPageType.Expanded:
                        pnlTitle.Visible = false;
                        break;

                    default:
                        pnlTitle.Visible = true;
                        break;
                }
                this.UpdateButtonState(wizardPage);
            }
        }

        private void pnlContent_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (e.Control != null && e.Control.Tag != null && e.Control.Tag is bool && !(bool)e.Control.Tag && e.Control is WizardPageBase)
            {
                (e.Control as WizardPageBase).PersistValuesToModel();
            }
        }

        private void ShowWizardPage(int index = 0)
        {
            if (index >= 0 && index < this.Count)
            {
                IWizardPage fromPage = null;
                if (pnlContent.Controls.Count > 0)
                {
                    var ctrl = pnlContent.Controls[0];
                    fromPage = ctrl as IWizardPage;
                    ctrl.Tag = false;
                    pnlContent.Controls.Clear();
                }
                var wizardPage = this._wizardPages[index].Item1;
                var wizardPageControl = wizardPage.Presentation;
                wizardPage.ExecuteShowAsync(fromPage);
                if (wizardPageControl != null)
                {
                    wizardPageControl.Dock = DockStyle.Fill;
                    pnlContent.Controls.Add(wizardPageControl);
                    if (wizardPage.FocusingControl != null)
                    {
                        wizardPage.FocusingControl.Select();
                        wizardPage.FocusingControl.Focus();
                    }
                }
                UpdateAcceptButton();
            }
            else
            {
                UpdateButtonState(WizardPage.GetEmptyPage(this));
                this.lblTitle.Text = string.Empty;
                this.lblDescription.Text = string.Empty;
            }
        }

        private void UpdateAcceptButton()
        {
            if (btnFinish.Enabled)
            {
                this.AcceptButton = btnFinish;
            }
            else if (btnNext.Enabled)
            {
                this.AcceptButton = btnNext;
            }
            else if (btnPrevious.Enabled)
            {
                this.AcceptButton = btnPrevious;
            }
            else
            {
                this.AcceptButton = btnCancel;
            }
        }

        private void UpdateButtonState(WizardPageBase wizardPage)
        {
            if (wizardPage != null)
            {
                btnPrevious.Enabled = wizardPage.CanGoPreviousPage && _currentPageIndex > 0;
                btnNext.Enabled = wizardPage.CanGoNextPage && _currentPageIndex < this.Count - 1;
                btnFinish.Enabled = wizardPage.CanGoFinishPage || _currentPageIndex == this.Count - 1;
                btnCancel.Enabled = wizardPage.CanGoCancel;

                UpdateAcceptButton();
            }
        }

        private void WizardPageNavigationStatusUpdateHandler(object sender, EventArgs e)
        {
            var wizardPage = this.CurrentPage;
            this.UpdateButtonState(wizardPage);
        }

        #endregion Private Methods

    }
}