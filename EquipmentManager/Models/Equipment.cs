namespace EquipmentManager.Models
{
    /// <summary>備品情報を表すモデルクラス（Equipment テーブルに対応）</summary>
    public class Equipment
    {
        public int Id { get; set; }

        /// <summary>備品コード（例: EQ001）</summary>
        public string EquipmentCode { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public string ModelNumber { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;

        /// <summary>状態（例: "利用可能" / "貸出中" / "廃棄"）</summary>
        public string Status { get; set; } = string.Empty;

        /// <summary>登録日（SQLite では TEXT 型で "yyyy-MM-dd" 形式で保存）</summary>
        public string RegisteredDate { get; set; } = string.Empty;

        public string Note { get; set; } = string.Empty;
    }
}
