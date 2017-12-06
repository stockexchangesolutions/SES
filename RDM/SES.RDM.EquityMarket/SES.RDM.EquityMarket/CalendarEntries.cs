using SAS.Core;
using System;

namespace SES.RDM.EquityMarket
{
    /// <summary>
    /// The Calendar Entries CSV file will be downloaded with the following layout. Each entry defines a holiday for this calendar.
    /// </summary>
    public class CalendarEntries : NotifyProperty, IEquatable<CalendarEntries>, IApiMessage<CalendarEntries>
    {
        #region private
        private string calendarID;
        private DateTime calendarDate;
        private string description;
        private bool tradingAllowed;
        private bool earlyClose;
        private bool futuresCloseOutDay;
        #endregion

        #region public
        /// <summary>
        /// Name of the calendar.
        /// </summary>
        public string CalendarID { get { return calendarID; } set { if (calendarID != value) { calendarID = value; OnPropertyChanged(nameof(CalendarID)); } } }

        /// <summary>
        /// Defines the date for which the public holiday is being specified.
        /// </summary>
        public DateTime CalendarDate { get { return calendarDate; } set { if (calendarDate != value) { calendarDate = value; OnPropertyChanged(nameof(CalendarDate)); } } }

        /// <summary>
        /// Human readable description of the public holiday.
        /// </summary>
        public string Description { get { return description; } set { if (description != value) { description = value; OnPropertyChanged(nameof(Description)); } } }

        /// <summary>
        /// Specifies whether this date is a trading holiday (weekends & public holidays) or not.
        /// </summary>
        public bool TradingAllowed { get { return tradingAllowed; } set { if (tradingAllowed != value) { tradingAllowed = value; OnPropertyChanged(nameof(TradingAllowed)); } } }

        /// <summary>
        /// Whether this date is an early close for the market.
        /// </summary>
        public bool EarlyClose { get { return earlyClose; } set { if (earlyClose != value) { earlyClose = value; OnPropertyChanged(nameof(EarlyClose)); } } }

        /// <summary>
        /// Whether the particular date is a Futures Close Out day.
        /// </summary>
        public bool FuturesCloseOutDay { get { return futuresCloseOutDay; } set { if (futuresCloseOutDay != value) { futuresCloseOutDay = value; OnPropertyChanged(nameof(FuturesCloseOutDay)); } } }

        #endregion

        #region methord
        public bool Equals(CalendarEntries other)
        {
            return CalendarID == other.CalendarID && CalendarDate == other.CalendarDate;
        }
        public CalendarEntries Decode(object value)
        {
            string[] reault = CSV.Split(value as string);
            return new CalendarEntries();

        }


        #endregion
    }
}
