using Syncfusion.UI.Xaml.Scheduler;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Scheduler_Reminder
{
    public class ReminderViewModel 
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ReminderViewModel" /> class.
        /// </summary>
        public ReminderViewModel()
        {
            this.Events = new ScheduleAppointmentCollection();
            this.CreateSchedulerAppointments();
            DisplayDate = DateTime.Now.Date.AddHours(9);
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets event collection.
        /// </summary>
        public ScheduleAppointmentCollection Events { get; set; } = new ScheduleAppointmentCollection();

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
            this.Events.Add(new ScheduleAppointment()
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(1),
                AppointmentBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF339933")),
                Subject = "Conference",
                Reminders = new ObservableCollection<SchedulerReminder>
                {
                    new SchedulerReminder { ReminderTimeInterval = new TimeSpan(0)},
                }
            });

            this.Events.Add(new ScheduleAppointment()
            {
                StartTime = DateTime.Now.Date.AddDays(-2).AddHours(10),
                EndTime = DateTime.Now.Date.AddDays(-2).AddHours(11),
                AppointmentBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA2C139")),
                Subject = "Business Meeting",
                Reminders = new ObservableCollection<SchedulerReminder>
                {
                    new SchedulerReminder { ReminderTimeInterval = new TimeSpan(0, 15, 0)},
                }
            });

            this.Events.Add(new ScheduleAppointment()
            {
                StartTime = DateTime.Now.Date.AddDays(2).AddHours(12),
                EndTime = DateTime.Now.Date.AddDays(2).AddHours(13),
                AppointmentBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00ABA9")),
                Subject = "Medical check up",
                Reminders = new ObservableCollection<SchedulerReminder>
                {
                    new SchedulerReminder { ReminderTimeInterval = new TimeSpan(1, 0, 0, 0)},
                    new SchedulerReminder { ReminderTimeInterval = new TimeSpan(2, 0, 0, 0)},
                    new SchedulerReminder { ReminderTimeInterval = new TimeSpan(3, 0, 0)},
                }
            });

            this.Events.Add(new ScheduleAppointment()
            {
                StartTime = DateTime.Now.Date.AddDays(-10).AddHours(15),
                EndTime = DateTime.Now.Date.AddDays(-10).AddHours(16),
                AppointmentBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE671B8")),
                Subject = "Project Status Discussion",
                Notes = "provides an opportunity to share information across the whole team.",
                RecurrenceRule = "FREQ=WEEKLY;BYDAY=WE;INTERVAL=1;COUNT=20",
                Reminders = new ObservableCollection<SchedulerReminder>
                {
                    new SchedulerReminder { ReminderTimeInterval = new TimeSpan(0, 15, 0)},
                }
            });

            this.Events.Add(new ScheduleAppointment()
            {
                StartTime = DateTime.Now.Date.AddDays(3).AddHours(14),
                EndTime = DateTime.Now.Date.AddDays(3).AddHours(15),
                AppointmentBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD80073")),
                Subject = "GoToMeeting",
                Reminders = new ObservableCollection<SchedulerReminder>
                {
                    new SchedulerReminder { ReminderTimeInterval = new TimeSpan(0, 15, 0)},
                }
            });

        }

        #endregion CreateSchedulerAppointmentCollection
    }
}
