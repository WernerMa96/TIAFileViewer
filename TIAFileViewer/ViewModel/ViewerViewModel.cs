using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TIAFileViewer.Model;

namespace TIAFileViewer.ViewModel
{
    public class ViewerViewModel : ViewModelBase
    {
        #region Private variables
        private ElementInfoModel selectedType;

        #endregion

        #region Properties
        private List<Node> nodes { get; set; }
        public ObservableCollection<ElementInfoModel> ActiveTypeElements { get; set; }
        public ObservableCollection<ElementInfoModel> Types { get; set; }

        #endregion

       
        public ElementInfoModel SelectedType
        {
            get { return selectedType; }
            set
            {
                selectedType = value;
                if (selectedType != null)
                {
                    ShowGroup(selectedType);
                }
            }
        }

        #region Constructors
        /// <summary>
        /// Base constructor
        /// </summary>
        public ViewerViewModel()
        {
            // Initialize
            nodes = new List<Node>();
            Types = new ObservableCollection<ElementInfoModel>();
            ActiveTypeElements = new ObservableCollection<ElementInfoModel>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the structure based on a collection of nodes
        /// </summary>
        /// <param name="newNodes">new node collection</param>
        public void UpdateStructure(IEnumerable<Node> newNodes)
        {
            // Save nodes in a new list
            nodes = new List<Node>(newNodes);

            //Clear typecollection
            Types.Clear();

            foreach (Node node in nodes)
            {
                // Get type in typecollection if it's already existing
                var existingType = Types.Where(x => x.Identifier == node.Type);

                if (!existingType.Any())
                {
                    // Adding new type
                    Types.Add(new ElementInfoModel()
                    {
                        Identifier = node.Type,
                        NoProperties = 1
                    });
                }
                else
                {
                    // Increment the number of properties which are be of this type
                    existingType.First().NoProperties++;
                }
            }
        }

        /// <summary>
        /// Updates view of the group elements
        /// </summary>
        /// <param name="selectedType">type filter</param>
        public void ShowGroup(ElementInfoModel selectedType)
        {
            // Filter nodes on the selected type
            var filtered = nodes.Where(x => x.Type == selectedType.Identifier);

            // Clear current collection
            ActiveTypeElements.Clear();

            foreach (Node node in filtered)
            {
                // Get Name of the property
                var identifierProp = node.Properties[0].Property.Where(x => x.Key == "Name").FirstOrDefault();
                // Get ID of the property if name doesn't exist
                if (identifierProp == null)
                {
                    identifierProp = node.Properties[0].Property.Where(x => x.Key == "Id").First();
                }
                // Get number of properties
                var noProperties = node.Properties[0].Property.Length;

                // Create new info element and add to collection
                ActiveTypeElements.Add(new ElementInfoModel()
                {
                    Identifier = identifierProp.Value,
                    NoProperties = noProperties
                });
            }
        }

        #endregion
    }
}
