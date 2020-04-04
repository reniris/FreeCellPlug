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

namespace FreeCellPlug.ViewModels
{
    public class CardViewModel : ViewModel
    {
        public CardViewModel()
        {
            Width = 100;
        }

        // Some useful code snippets for ViewModel are defined as l*(llcom, llcomn, lvcomm, lsprop, etc...).
        public void Initialize()
        {
            
        }

        private string _ResourceKey = "SA";

        public string ResourceKey
        {
            get
            { return _ResourceKey; }
            set
            {
                if (_ResourceKey == value)
                    return;
                _ResourceKey = value;
                RaisePropertyChanged();
            }
        }


        private double _Width;

        public double Width
        {
            get => _Width;
            set
            {
                RaisePropertyChangedIfSet(ref _Width, value);
                Height = value * 1.4;
            }
        }

        private double _Height;

        public double Height
        {
            get => _Height;
            private set => RaisePropertyChangedIfSet(ref _Height, value);
        }

    }
}
