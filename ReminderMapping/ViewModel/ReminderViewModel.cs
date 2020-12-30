using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ReminderMapping
{
    public class ReminderViewModel
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ReminderViewModel" /> class.
        /// </summary>
        public ReminderViewModel()
        {
            this.Events = new ObservableCollection<Event>();
            this.CreateSchedulerAppointments();
            DisplayDate = DateTime.Now.Date.AddHours(9);
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets event collection.
        /// </summary>
        public ObservableCollection<Event> Events { get; set; } = new ObservableCollection<Event>();

        /// <summary>
        /// Gets or sets display date
        /// </summary>
        public DateTime DisplayDate { get; set; }

        #endregion Properties

        #region CreateSchedulerAppointmentCollection

        /// <summary>
        /// Method to create Scheduler appointment collection
        /// </summary>
        private void CreateSchedulerAppointments()
        {
            this.Events.Add(new Event()
            {
                From = DateTime.Now,
                To = DateTime.Now.AddHours(1),
                Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF339933")),
                EventName = "Conference",
                Reminders = new ObservableCollection<Reminder>
                {
                    new Reminder { TimeInterval = new TimeSpan(0)},
                }
            });

            this.Events.Add(new Event()
            {
                From = DateTime.Now.Date.AddDays(-2).AddHours(10),
                To = DateTime.Now.Date.AddDays(-2).AddHours(11),
                Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA2C139")),
                EventName = "Business Meeting",
                Reminders = new ObservableCollection<Reminder>
                {
                    new Reminder { TimeInterval = new TimeSpan(0, 15, 0)},
                }
            });

            this.Events.Add(new Event()
            {
                From = DateTime.Now.Date.AddDays(2).AddHours(12),
                To = DateTime.Now.Date.AddDays(2).AddHours(13),
                Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00ABA9")),
                EventName = "Medical check up",
                Reminders = new ObservableCollection<Reminder>
                {
                    new Reminder { TimeInterval = new TimeSpan(1, 0, 0, 0)},
                    new Reminder { TimeInterval = new TimeSpan(2, 0, 0, 0)},
                    new Reminder { TimeInterval = new TimeSpan(3, 0, 0)},
                }
            });

            this.Events.Add(new Event()
            {
                From = DateTime.Now.Date.AddDays(-10).AddHours(15),
                To = DateTime.Now.Date.AddDays(-10).AddHours(16),
                Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE671B8")),
                EventName = "Project Status Discussion",
                Notes = "provides an opportunity to share information across the whole team.",
                RecurrenceRule = "FREQ=WEEKLY;BYDAY=WE;INTERVAL=1;COUNT=20",
                Reminders = new ObservableCollection<Reminder>
                {
                    new Reminder { TimeInterval = new TimeSpan(0, 15, 0)},
                }
            });

            this.Events.Add(new Event()
            {
                From = DateTime.Now.Date.AddDays(3).AddHours(14),
                To = DateTime.Now.Date.AddDays(3).AddHours(15),
                Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD80073")),
                EventName = "GoToMeeting",
                Reminders = new ObservableCollection<Reminder>
                {
                    new Reminder { TimeInterval = new TimeSpan(0, 15, 0)},
                }
            });

        }

        #endregion CreateSchedulerAppointmentCollection
    }
}
