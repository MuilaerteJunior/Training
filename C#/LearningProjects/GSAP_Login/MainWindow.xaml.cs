using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//Faltando o capítulo de Deadlock


namespace GSAP_Login {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e) {
            //TaskUsingDispatcher();

            //TaskUsingTheAwaiter();

            //TaskUsingAwait();

            //TaskUsingAwaitThrowsException

            //await LastDemo();

            DeadlockBasicExample();
        }

        private void DeadlockBasicExample() {
            var task = Task.Delay(1).ContinueWith((t) => {
                //Calling the UI
                Dispatcher.Invoke(() => { });
            });

            //So this will wait for UI response
            task.Wait();
        }

        private async Task LastDemo() {
            try {
                btnLogin.IsEnabled = false;

                var result = await TaskUsingAwaitReturnsTask();

                btnLogin.Content = result;
                btnLogin.IsEnabled = true;
            }
            catch ( Exception ) {
                btnLogin.Content = "Internal erro!";
            }
        }

        private async void TaskUsingAwait() {
            var result = await Task.Run(() => {
                Thread.Sleep(2000);

                return "Login successful!";
            });

            btnLogin.Content = result;
        }
        private async Task<string> TaskUsingAwaitReturnsTask() {
            try {
                var result = await Task.Run(() => {
                    Thread.Sleep(2000);

                    return "Login successful!";
                });

                //UI
                await Task.Delay(2000); // Log the login successful
                //UI
                await Task.Delay(1000); //Another operation

                return result;
            }
            catch ( Exception ) {
                return "It fails!";
            }
        }
        private async Task<string> TaskUsingAwaitAlllReturnsTask() {
            try {
                var login = Task.Run(() => {
                    Thread.Sleep(2000);

                    return "Login successful!";
                });

                //UI
                var logTask = Task.Delay(2000); // Log the login successful
                //UI
                var otherOperationTask = Task.Delay(1000); //Another operation

                await Task.WhenAll(login, logTask, otherOperationTask);

                return login.Result;
            }
            catch ( Exception ) {
                return "It fails!";
            }
        }        
        private async Task TaskUsingAwaitThrowsException() {
            throw new UnauthorizedAccessException();

            var result = await Task.Run(() => {
                Thread.Sleep(2000);

                return "Login successful!";
            });

            btnLogin.Content = result;
        }
        private void TaskUsingTheAwaiter() {
            btnLogin.IsEnabled = false;
            var task = Task.Run(() => {

                Thread.Sleep(2000);
                return "Login successful!";
            });

            task.ConfigureAwait(true)
                .GetAwaiter()
                .OnCompleted(() => {
                    btnLogin.Content = task.Result;
                    btnLogin.IsEnabled = true;
                });
        }
        private void TaskUsingDispatcher() {
            btnLogin.IsEnabled = false;
            var task = Task.Run(() => {

                Thread.Sleep(2000);
                return "Login successful!";
            });

            task.ContinueWith((t) => {
                if ( t.IsFaulted ) {
                    Dispatcher.Invoke(() => {
                        btnLogin.Content = "Login failed!";
                        btnLogin.IsEnabled = true;
                    });
                }

                Dispatcher.Invoke(() => {
                    btnLogin.Content = t.Result;
                    btnLogin.IsEnabled = true;
                });
            });
        }
    }
}
