using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Win32;
using System.Windows.Input;

namespace TIAFileViewer.ViewModel
{
    public class MenuViewModel : ViewModelBase
    {
        #region Commands
        public ICommand OpenFileCmd { get; set; }
        public ICommand OpenSettingsCmd { get; set; }
        public ICommand CompareCmd { get; set; }
        public ICommand ExportCSVCmd { get; set; }

        #endregion

        #region Constructors
        /// <summary>
        /// Base constructor
        /// </summary>
        public MenuViewModel()
        {
            // Commands
            OpenFileCmd = new RelayCommand(() => OpenFile());
        }

        #endregion

        #region Methods
        /// <summary>
        /// Userselection of a tia-file and publish it through the messenger
        /// </summary>
        private void OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "TIA file (*.tia)|*.tia";
            if (openFileDialog.ShowDialog() == true)
            {
                var path = openFileDialog.FileName;
                Messenger.Default.Send<string>(path);
            }
        }

        #endregion
    }
}
