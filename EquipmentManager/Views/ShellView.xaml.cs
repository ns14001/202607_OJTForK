using System.Windows;
using System.Windows.Controls;

namespace EquipmentManager.Views
{
    /// <summary>
    /// メインのシェル画面。
    /// 左のサイドバーでナビゲーションを行い、
    /// 右の ContentControl に各機能の UserControl を表示する。
    /// </summary>
    public partial class ShellView : Window
    {
        // 現在アクティブ（選択中）のナビゲーションボタン
        private Button? _activeNavButton;

        // コンテンツエリアに表示する UserControl のインスタンス
        // 画面を切り替えるたびに new するのではなく、インスタンスを使い回す
        private readonly EquipmentListView _equipmentListView = new();

        public ShellView()
        {
            InitializeComponent();

            // 起動時は備品一覧を表示する
            SetActiveNavButton(BtnEquipmentList);
            MainContent.Content = _equipmentListView;
        }

        // ─────────────────────────────────────────
        // ナビゲーションイベント
        // ─────────────────────────────────────────

        private void BtnEquipmentList_Click(object sender, RoutedEventArgs e)
        {
            SetActiveNavButton(BtnEquipmentList);
            MainContent.Content = _equipmentListView;
        }

        private void NotImplementedButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "この機能は未実装です。\n課題として実装してください。",
                "未実装",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        // ─────────────────────────────────────────
        // ヘルパー
        // ─────────────────────────────────────────

        /// <summary>
        /// 指定したボタンをアクティブ（選択中）スタイルに切り替える。
        /// 前回アクティブだったボタンは通常スタイルに戻す。
        ///
        /// TODO: 画面を追加するたびに、このメソッドを呼ぶナビゲーションハンドラを追加してください。
        /// </summary>
        private void SetActiveNavButton(Button button)
        {
            // 前のボタンを通常スタイルに戻す
            if (_activeNavButton != null)
                _activeNavButton.Style = (Style)FindResource("NavItemStyle");

            // 新しいボタンをアクティブスタイルに変更
            button.Style = (Style)FindResource("NavItemActiveStyle");
            _activeNavButton = button;
        }
    }
}
