using System;
using System.ComponentModel;

namespace ERPSYS.Controls.Date
{
    public partial class UCDatesRangeAdv : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FromDateMaskedEditValidator.ValidationGroup = _validationGroup;
            ToDateMaskedEditValidator.ValidationGroup = _validationGroup;
        }
        private int _rangeType;
        private string _validationGroup;
        private DateTime _fromDate, _toDate;

        [Browsable(true)]
        [Bindable(true, BindingDirection.TwoWay)]

        public DateTime FromDate
        {
            get
            {
                int.TryParse(DateRangeList.SelectedValue, out _rangeType);
                switch(_rangeType)
                {
                    //Today
                    case 0:
                    _fromDate = DateTime.Now.Date;
                    break;

                    //Yesterday
                    case 1:
                    _fromDate = DateTime.Now.AddDays(-1).Date;
                    break;

                    //Last7Days
                    case 2:
                    _fromDate = DateTime.Now.AddDays(-7).Date;
                    break;

                    //Last14Days
                    case 3:
                    _fromDate = DateTime.Now.AddDays(-14).Date;
                    break;

                    //Last30Days
                    case 4:
                    _fromDate = DateTime.Now.AddDays(-30).Date;
                    break;

                    //Last60Days
                    case 5:
                    _fromDate = DateTime.Now.AddDays(-60).Date;
                    break;

                   //Period
                    case 6:
                    DateTime.TryParse(FromDateTextBox.Text, out _fromDate);
                    break;

                    default:
                    _fromDate = DateTime.Now.Date;
                    break;
                }
                return _fromDate;
            }
            set
            {
                _fromDate = value;
                FromDateTextBox.Text = _fromDate.ToShortDateString();
            }
        }

        [Browsable(true)]
        [Bindable(true, BindingDirection.TwoWay)]

        public DateTime ToDate
        {
            get
            {
                int.TryParse(DateRangeList.SelectedValue, out _rangeType);

                switch(_rangeType)
                {

                    case 0:

                    case 1:

                    case 2:

                    case 3:

                    case 4:

                    case 5:
                    _toDate = DateTime.Now.Date;
                    break;

                    case 6:
                    DateTime.TryParse(ToDateTextBox.Text, out _toDate);
                    break;

                    default:
                    _toDate = DateTime.Now.Date;
                    break;
                }

                return _toDate;
            }

            set
            {
                _toDate = value;
                ToDateTextBox.Text = _toDate.ToShortDateString();
            }
        }
        public string ValidationGroup
        {
            get
            {
                _validationGroup = FromDateMaskedEditValidator.ValidationGroup;
                return _validationGroup;
            }
            set
            {
                _validationGroup = value;
                ToDateMaskedEditValidator.ValidationGroup = _validationGroup;
                FromDateMaskedEditValidator.ValidationGroup = _validationGroup;
            }
        }


        [DefaultValue(false)]

        public bool IsValidEmpty
        {
            get
            {
                return FromDateMaskedEditValidator.IsValidEmpty;
            }
            set
            {
                FromDateMaskedEditValidator.IsValidEmpty = value;
                ToDateMaskedEditValidator.IsValidEmpty = value;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Page.RegisterRequiresControlState(this);
        }

        protected override object SaveControlState()
        {
            return _fromDate;
        }

        protected override void LoadControlState(object savedState)
        {
            _fromDate = Convert.ToDateTime(savedState);
        }
    }
}