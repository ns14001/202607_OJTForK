using System.Windows.Controls;

namespace EquipmentManager.Views
{
    /// <summary>
    /// 備品一覧を表示する UserControl。
    /// ShellView のコンテンツエリアに表示される。
    ///
    /// TODO: 以下を実装してください。
    ///   1. EquipmentService を使って DB から備品一覧を取得する
    ///   2. 取得したリストを DataGrid の ItemsSource にセットして一覧を表示する
    ///   3. 新規登録・編集・削除・貸出・返却・履歴表示ボタンを実装する
    ///
    /// 参考: Services/EquipmentService.cs に GetAll() が実装されているので参照してください。
    /// </summary>
    public partial class EquipmentListView : UserControl
    {
        public EquipmentListView()
        {
            InitializeComponent();
        }
    }
}
