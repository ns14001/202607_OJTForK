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
            // メニュー画面を開き、このトップ画面を閉じる
            var menuView = new MenuView();
            menuView.Show();
            this.Close();
        }
    }
}
