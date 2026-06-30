using System.Windows;

namespace EquipmentManager.Views
{
    public partial class TopView : Window
    {
        public TopView()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            // シェル画面（サイドバー付きメイン画面）を開き、トップ画面を閉じる
            var shellView = new ShellView();
            shellView.Show();
            this.Close();
        }
    }
}
