using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System.Linq;
using TIAFileViewer.Helper;
using TIAFileViewer.Model;

namespace TIAFileViewer.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Properties
        public MenuViewModel MenuVM { get; set; }
        public ViewerViewModel ViewerVM { get; set; }

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            // Messenger
            Messenger.Default.Register<string>(this, (x) => GenerateTIAStructure(x));

            // Initialize
            MenuVM = new MenuViewModel();
            ViewerVM = new ViewerViewModel();
        }

        #endregion

        #region Methods
        private void GenerateTIAStructure(string path)
        {
            // Deserialize
            var nodes = XMLHelper.Deserialize<TiaSelectionTool>(path);

            // Filter nodes with type and set new structure on viewer
            var filterdNodes = nodes.Business[0].Graph[0].Nodes[0].Node.Where(x => x.Type != null);
            ViewerVM.UpdateStructure(filterdNodes);
        }

        #endregion
    }
}