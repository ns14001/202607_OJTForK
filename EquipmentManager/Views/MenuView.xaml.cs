using System.Windows;

namespace EquipmentManager.Views
{
    public partial class MenuView : Window
    {
        public MenuView()
        {
            InitializeComponent();
        }

        private void EquipmentListButton_Click(object sender, RoutedEventArgs e)
        {
            // 備品一覧画面をモーダルで開く
            var view = new EquipmentListView();
            view.Owner = this;
            view.ShowDialog();
        }

        private void NotImplementedButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "この機能は未実装です。\n課題として実装してください。",
                "未実装",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}
