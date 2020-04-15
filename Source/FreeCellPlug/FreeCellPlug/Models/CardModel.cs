using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;

namespace FreeCellPlug.Models
{
    /*0=A♣　1=A♦　2=A♥　3=A♠
4=2♣　5=2♦　6=2♥　7=2♠
…
48=K♣　49=K♦　50=K♥　51=K♠*/

    /// <summary>
    /// 0=A♣　1=A♦　2=A♥　3=A♠
    /// 4=2♣　5=2♦　6=2♥　7=2♠
    /// …
    /// 48=K♣　49=K♦　50=K♥　51=K♠
    /// </summary>
    public enum CardNumber
    {
        CA, DA, HA, SA,
        C2, D2, H2, S2,
        C3, D3, H3, S3,
        C4, D4, H4, S4,
        C5, D5, H5, S5,
        C6, D6, H6, S6,
        C7, D7, H7, S7,
        C8, D8, H8, S8,
        C9, D9, H9, S9,
        C10, D10, H10, S10,
        CJ, DJ, HJ, SJ,
        CQ, DQ, HQ, SQ,
        CK, DK, HK, SK,
    }
    public class CardModel : NotificationObject
    {

        private CardNumber _Number;

        public CardNumber Number
        {
            get
            { return _Number; }
            set
            { 
                if (_Number == value)
                    return;
                _Number = value;
                RaisePropertyChanged();
            }
        }
    }
}
