using System.Windows;
using System.Threading;
using System.Windows.Threading;

namespace ToolKitV
{
    public partial class App : Application
    {
        protected Mutex Mutex;
        protected override void OnStartup(StartupEventArgs e)
        {
            Mutex = new Mutex(true, ResourceAssembly.GetName().Name);

            if (!Mutex.WaitOne(0, false))
            {
                Current.Shutdown();
                return;
            }

            ShutdownMode = ShutdownMode.OnLastWindowClose;
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            //if (Mutex != null)
            //{
            //    Mutex.ReleaseMutex();
            //}

            base.OnExit(e);
        }

        public App()
        {
            DispatcherUnhandledException += App_DispatcherUnhandledException;
        }

        void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("오류 메시지:\n" + e.Exception.Message + "\n\n도움이 필요하시면 디스코드로 문의해주세요.\nDiscord: discord.gg/VzHq5ysheb", "시바서버 텍스처 최적화 오류", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
