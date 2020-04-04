using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.EventListeners;
using Livet.Messaging.Windows;

using FreeCellPlug.Models;
using System.Collections.ObjectModel;

namespace FreeCellPlug.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {

            var cm = Enum.GetValues(typeof(CardNumber)).Cast<CardNumber>().Select(e => new CardModel() { Number = e });
            CardModels = new ObservableCollection<CardModel>(cm);

            _Cards = ViewModelHelper.CreateReadOnlyDispatcherCollection(
            CardModels,
            (m) => new CardViewModel() { ResourceKey =  m.Number.ToString()},
            DispatcherHelper.UIDispatcher);
            
            //CompositeDisposable.Add(CardModels);
        }

        // Some useful code snippets for ViewModel are defined as l*(llcom, llcomn, lvcomm, lsprop, etc...).
        public void Initialize()
        {

        }

        private ObservableCollection<CardModel> CardModels;

        //public ObservableCollection<CardViewModel> Cards { get; set; } 
        Livet.ReadOnlyDispatcherCollection<CardViewModel> _Cards;
        public Livet.ReadOnlyDispatcherCollection<CardViewModel> Cards
        {
            get
            {
                if (_Cards == null)
                {

                }
                return _Cards;
            }
        }
    }
}
