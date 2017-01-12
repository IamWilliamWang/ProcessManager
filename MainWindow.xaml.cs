using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ProcessManager
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        CollectionViewSource view = new CollectionViewSource();
        ObservableCollection<Process> processesCollection = new ObservableCollection<Process>();
        System.Diagnostics.Process[] processes;
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Thread dialogThread = new Thread(new ThreadStart(ThreadProc));
            dialogThread.Start();

            processes = System.Diagnostics.Process.GetProcesses();
            this.textBlock1.Text = "进程任务管理器，这里显示所有的系统进程，共" + processes.Length + "个进程";
            
            processesCollection.Clear();
            
            foreach (System.Diagnostics.Process eachProcess in processes)
            {
                
                processesCollection.Add(new Process(eachProcess));
                
            }

            //processesCollection = new ObservableCollection<MyProcess>(processesCollection.OrderBy(item => item.进程名));

            view.Source = processesCollection;

            this.listView1.DataContext = view;
            
        }

        private void ThreadProc()
        {
            MessageBox.Show("程序正在响应,请等待3-10秒！", "进程管理器");
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Window_Loaded(sender, e);
        }

        private void btnKill_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("如果某个打开的程序与此进程关联，则会关闭此程序而且将丢失所有未保存的数据。如果结束某个系统进程，则可能导致系统不稳定。你确定要继续吗？", "你希望结束" + processesCollection[listView1.SelectedIndex].进程名 + ".exe吗？",MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                return;
            try
            {
                processes[listView1.SelectedIndex].Kill();
            }
            catch
            {
                MessageBox.Show("结束进程失败", "错误");
            }
        }

        private void btnNotepad_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe");
        }

        //强制结束新线程
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
