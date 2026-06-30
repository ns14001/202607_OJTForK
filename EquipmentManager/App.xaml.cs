using EquipmentManager.Data;
using EquipmentManager.Views;
using System.Windows;

namespace EquipmentManager
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // 初回起動時にDBファイルを作成してテーブルとサンプルデータを投入する
            try
            {
                DatabaseInitializer.Initialize();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"DB の初期化中にエラーが発生しました。\n{ex.Message}",
                    "起動エラー",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                Shutdown();
                return;
            }

            // トップ画面を表示
            var topView = new TopView();
            topView.Show();
        }
    }
}
