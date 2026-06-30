using EquipmentManager.Services;
using System.Windows;

namespace EquipmentManager.Views
{
    public partial class EquipmentListView : Window
    {
        // サービスクラスを通じて DB にアクセスする
        private readonly EquipmentService _equipmentService = new();

        public EquipmentListView()
        {
            InitializeComponent();
            LoadEquipmentList();
        }

        /// <summary>備品一覧を DB から読み込んで DataGrid に表示する</summary>
        private void LoadEquipmentList()
        {
            try
            {
                var equipmentList = _equipmentService.GetAll();
                EquipmentDataGrid.ItemsSource = equipmentList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"備品一覧の取得中にエラーが発生しました。\n{ex.Message}",
                    "エラー",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void NotImplementedButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "この機能は未実装です。\n課題として実装してください。",
                "未実装",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
