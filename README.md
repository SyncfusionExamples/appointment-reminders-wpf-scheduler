# How to add reminder for appointments in wpf scheduler?

## About the sample
This examples demonstrates to add reminder for appointments in wpf scheduler. There are two ways to add reminders for appointments,

* SchedulerReminder
* ReminderMapping
## SchedulerReminder
Define a ViewModel class that implements appoinments with reminders and its handled by scheduler reminder.

    public class ReminderViewModel : NotificationObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReminderViewModel" /> class.
        /// </summary>
        public ReminderViewModel()
        {
            this.Events = new ScheduleAppointmentCollection();
            this.CreateSchedulerAppointments();
            DisplayDate = DateTime.Now.Date.AddHours(9);
        }

        /// <summary>
        /// Gets or sets event collection.
        /// </summary>
        public ScheduleAppointmentCollection Events { get; set; }

        /// <summary>
        /// Gets or sets display date
        /// </summary>
        public DateTime DisplayDate { get; set; }

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

    }

And set the 'EnableReminder' property of scheduler as true.

    <Window x:Class="Scheduler_Reminder.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:system="clr-namespace:System;assembly=mscorlib" 
        xmlns:local="clr-namespace:Scheduler_Reminder"
        xmlns:syncfusion="http://schemas.syncfusion.com/wpf"
        mc:Ignorable="d" WindowStartupLocation="CenterScreen"
        Title="SchedulerReminder" Height="450" Width="800">

        <Window.DataContext>
            <local:ReminderViewModel/>
        </Window.DataContext>
    <Grid>
        <syncfusion:SfScheduler x:Name="Schedule" 
                                ItemsSource="{Binding Events}"
                                EnableReminder="True"
        </syncfusion:SfScheduler>
    </Grid>
</Window>

## ReminderMapping
Create ReminderModel and SchedulerModel classes to map business objects for ScheduleAppointment and ReminderMapping.Then, Define a ViewModel class that implements appoinments with reminders and its handled by reminder mapping.

    public class ReminderViewModel : NotificationObject
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ReminderViewModel" /> class.
        /// </summary>
        public ReminderViewModel()
        {
            this.Events = new ObservableCollection<SchedulerModel>();
            this.CreateSchedulerAppointments();
            DisplayDate = DateTime.Now.Date.AddHours(9);
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets event collection.
        /// </summary>
        public ObservableCollection<SchedulerModel> Events { get; set; }

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
            this.Events.Add(new SchedulerModel()
            {
                From = DateTime.Now,
                To = DateTime.Now.AddHours(1),
                Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF339933")),
                EventName = "Conference",
                Reminders = new ObservableCollection<ReminderModel>
                {
                    new ReminderModel { TimeInterval = new TimeSpan(0)},
                }
            });

            this.Events.Add(new SchedulerModel()
            {
                From = DateTime.Now.Date.AddDays(-2).AddHours(10),
                To = DateTime.Now.Date.AddDays(-2).AddHours(11),
                Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA2C139")),
                EventName = "Business Meeting",
                Reminders = new ObservableCollection<ReminderModel>
                {
                    new ReminderModel { TimeInterval = new TimeSpan(0, 15, 0)},
                }
            });

            this.Events.Add(new SchedulerModel()
            {
                From = DateTime.Now.Date.AddDays(2).AddHours(12),
                To = DateTime.Now.Date.AddDays(2).AddHours(13),
                Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00ABA9")),
                EventName = "Medical check up",
                Reminders = new ObservableCollection<ReminderModel>
                {
                    new ReminderModel { TimeInterval = new TimeSpan(1, 0, 0, 0)},
                    new ReminderModel { TimeInterval = new TimeSpan(2, 0, 0, 0)},
                    new ReminderModel { TimeInterval = new TimeSpan(3, 0, 0)},
                }
            });

            this.Events.Add(new SchedulerModel()
            {
                From = DateTime.Now.Date.AddDays(-10).AddHours(15),
                To = DateTime.Now.Date.AddDays(-10).AddHours(16),
                Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE671B8")),
                EventName = "Project Status Discussion",
                Notes = "provides an opportunity to share information across the whole team.",
                RecurrenceRule = "FREQ=WEEKLY;BYDAY=WE;INTERVAL=1;COUNT=20",
                Reminders = new ObservableCollection<ReminderModel>
                {
                    new ReminderModel { TimeInterval = new TimeSpan(0, 15, 0)},
                }
            });

            this.Events.Add(new SchedulerModel()
            {
                From = DateTime.Now.Date.AddDays(3).AddHours(14),
                To = DateTime.Now.Date.AddDays(3).AddHours(15),
                Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD80073")),
                EventName = "GoToMeeting",
                Reminders = new ObservableCollection<ReminderModel>
                {
                    new ReminderModel { TimeInterval = new TimeSpan(0, 15, 0)},
                }
            });

        }

        #endregion CreateSchedulerAppointmentCollection
    }

And set `EnableReminder` property of scheduler as true and  map properties in business object to ScheduleAppointment by configuring the AppointmentMapping property.

<Window x:Class="ReminderMapping.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:system="clr-namespace:System;assembly=mscorlib" 
        xmlns:local="clr-namespace:ReminderMapping"
        xmlns:syncfusion="http://schemas.syncfusion.com/wpf"
        mc:Ignorable="d" WindowStartupLocation="CenterScreen"
        Title="MainWindow" Height="450" Width="800">

    <Window.DataContext>
        <local:ReminderViewModel/>
    </Window.DataContext>
    <Grid>
        <syncfusion:SfScheduler x:Name="Schedule" 
                                ItemsSource="{Binding Events}"
                                EnableReminder="True">
            <syncfusion:SfScheduler.AppointmentMapping>
                <syncfusion:AppointmentMapping
                    Subject="EventName"
                    StartTime="From"
                    EndTime="To"
                    AppointmentBackground="Color"
                    Reminders="Reminders">
                    <syncfusion:AppointmentMapping.ReminderMapping>
                        <syncfusion:ReminderMapping IsDismissed="Dismissed"
                                                    ReminderTimeInterval="TimeInterval"/>
                    </syncfusion:AppointmentMapping.ReminderMapping>
                </syncfusion:AppointmentMapping>
            </syncfusion:SfScheduler.AppointmentMapping>
        </syncfusion:SfScheduler>
    </Grid>
</Window>
