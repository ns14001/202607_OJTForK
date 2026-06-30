namespace EquipmentManager.Data
{
    /// <summary>
    /// DB 接続に関する設定を一元管理するクラス。
    /// 接続文字列はここだけに書き、他のクラスはここを参照する。
    /// </summary>
    public static class DatabaseConfig
    {
        // DB ファイル名（アプリの実行フォルダに作成される）
        private const string DbFileName = "equipment_manager.db";

        /// <summary>SQLite への接続文字列</summary>
        public static string ConnectionString =>
            $"Data Source={DbFilePath}";

        /// <summary>DB ファイルのフルパス</summary>
        public static string DbFilePath =>
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DbFileName);
    }
}
