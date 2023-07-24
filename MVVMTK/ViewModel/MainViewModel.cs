using Microsoft.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVVMTK.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
		private Model.SimplePerson _person;

		public Model.SimplePerson Person
		{
			get { return _person; }
			set { _person = value; }
		}

		public ICommand ClearName { get; }
		public ICommand DeleteChildName { get; }
		public ICommand ResetData { get; }


        public MainViewModel()
        {
            _person = new Model.SimplePerson();
			ClearName = new RelayCommand(ClearNameOfPerson);
			DeleteChildName = new RelayCommand<IList>(DeleteNameOfChildFromList);
			ResetData = new RelayCommand(GenerateSimpleData);

			GenerateSimpleData();

        }

		private void GenerateSimpleData()
		{
			Person.SureName = "Otto";
			Person.LastName = "Müller";
			Person.Childs = new System.Collections.ObjectModel.ObservableCollection<string> { "Wilhelm", "Marie", "Herbert" };
		}

        private void DeleteNameOfChildFromList(IList? obj)
		{
			var itemCopy = (obj as IList<object>).ToList();

			foreach (string item in itemCopy)
			{
				Person.Childs.Remove(item);
			}
		}

		private void ClearNameOfPerson() 
		{
			Person.LastName = string.Empty;
			Person.SureName = string.Empty;
		}
    }
}
