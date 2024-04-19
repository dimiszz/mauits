﻿namespace MauiTs
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
        protected override Window CreateWindow(IActivationState? activationState)
        {
            Window window = base.CreateWindow(activationState);
            window.Activated += Window_Activated;
            return window;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        private async void Window_Activated(object sender, EventArgs e)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
#if WINDOWS
            const int DefaultWidth = 1024;
            const int DefaultHeight = 800;

            var window = sender as Window;

            // change window size.
            window.Width = DefaultWidth;
            window.Height = DefaultHeight;

            // give it some time to complete window resizing task.
            await window.Dispatcher.DispatchAsync(() => { });

            window.MinimumWidth = DefaultWidth/2;
            window.MinimumHeight = DefaultHeight/2;

            var disp = DeviceDisplay.Current.MainDisplayInfo;

            // move to screen center
            window.X = (disp.Width / disp.Density - window.Width) / 2;
            window.Y = (disp.Height / disp.Density - window.Height) / 2;
#endif
        }
    }
}
