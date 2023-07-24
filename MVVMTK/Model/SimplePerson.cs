using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Documents;

namespace MVVMTK.Model
{
    class SimplePerson : ObservableObject
    {
        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        private string _sureName;
        public string SureName
        {
            get { return _sureName; }
            set { SetProperty(ref _sureName, value); }
        }

        private ObservableCollection<string> _childs;
        public ObservableCollection<string> Childs
        {
            get { return _childs; }
            set { SetProperty(ref _childs, value); }
        }

        public SimplePerson()
        {
            _childs = new ObservableCollection<string>();   
            _lastName = string.Empty;
            _sureName = string.Empty;   
        }

    }
}
