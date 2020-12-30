using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderMapping
{
    public class Reminder
    {
        /// <summary>
        /// Gets or sets the value indicating whether the reminder is dismissed or not. 
        /// </summary>
        public bool Dismissed { get; set; }

        /// <summary>
        /// Gets or sets the value to display reminder alert before appointment start time.
        /// </summary>
        public TimeSpan TimeInterval { get; set; }

    }
}
