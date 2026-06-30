using Microsoft.Data.Sqlite;

namespace EquipmentManager.Data
{
    /// <summary>
    /// アプリ起動時に DB の初期化（テーブル作成・サンプルデータ投入）を行うクラス。
    /// DB ファイルが既に存在する場合は何もしない。
    /// </summary>
    public static class DatabaseInitializer
    {
        /// <summary>DB を初期化する。初回起動時のみ実際の処理が走る。</summary>
        public static void Initialize()
        {
            // DB ファイルが既にある場合はスキップ
            if (File.Exists(DatabaseConfig.DbFilePath))
                return;

            using var connection = new SqliteConnection(DatabaseConfig.ConnectionString);
            connection.Open();

            CreateTables(connection);
            InsertSampleData(connection);
        }

        // ─────────────────────────────────────────
        // テーブル作成
        // ─────────────────────────────────────────

        private static void CreateTables(SqliteConnection connection)
        {
            // SQLite は既定で外部キー制約が無効のため、明示的に有効化する
            ExecuteNonQuery(connection, "PRAGMA foreign_keys = ON;");

            // 社員テーブル
            ExecuteNonQuery(connection, @"
                CREATE TABLE IF NOT EXISTS Employees (
                    Id              INTEGER PRIMARY KEY AUTOINCREMENT,
                    EmployeeCode    TEXT    NOT NULL UNIQUE,
                    Name            TEXT    NOT NULL,
                    Department      TEXT    NOT NULL,
                    Email           TEXT,
                    Status          TEXT    NOT NULL DEFAULT '在籍中'
                );");

            // 備品テーブル
            ExecuteNonQuery(connection, @"
                CREATE TABLE IF NOT EXISTS Equipment (
                    Id              INTEGER PRIMARY KEY AUTOINCREMENT,
                    EquipmentCode   TEXT    NOT NULL UNIQUE,
                    Name            TEXT    NOT NULL,
                    Category        TEXT    NOT NULL,
                    Manufacturer    TEXT,
                    ModelNumber     TEXT,
                    SerialNumber    TEXT,
                    Status          TEXT    NOT NULL DEFAULT '利用可能',
                    RegisteredDate  TEXT    NOT NULL,
                    Note            TEXT
                );");

            // 貸出履歴テーブル
            ExecuteNonQuery(connection, @"
                CREATE TABLE IF NOT EXISTS RentalHistories (
                    Id                  INTEGER PRIMARY KEY AUTOINCREMENT,
                    EquipmentId         INTEGER NOT NULL,
                    EmployeeId          INTEGER NOT NULL,
                    RentalDate          TEXT    NOT NULL,
                    ExpectedReturnDate  TEXT    NOT NULL,
                    ActualReturnDate    TEXT,
                    RentalNote          TEXT,
                    ReturnNote          TEXT,
                    FOREIGN KEY (EquipmentId) REFERENCES Equipment(Id),
                    FOREIGN KEY (EmployeeId)  REFERENCES Employees(Id)
                );");
        }

        // ─────────────────────────────────────────
        // サンプルデータ投入
        // ─────────────────────────────────────────

        private static void InsertSampleData(SqliteConnection connection)
        {
            // サンプル社員
            ExecuteNonQuery(connection, @"
                INSERT INTO Employees (EmployeeCode, Name, Department, Email, Status) VALUES
                ('EMP001', '山田 太郎', '総務部',   'yamada@example.com',  '在籍中'),
                ('EMP002', '鈴木 花子', '営業部',   'suzuki@example.com',  '在籍中'),
                ('EMP003', '田中 一郎', '開発部',   'tanaka@example.com',  '在籍中');");

            // サンプル備品
            ExecuteNonQuery(connection, @"
                INSERT INTO Equipment
                    (EquipmentCode, Name, Category, Manufacturer, ModelNumber, SerialNumber, Status, RegisteredDate, Note)
                VALUES
                ('EQ001', 'ノートPC A',    'PC',           'メーカーA', 'Model-X100', 'SN-0001', '利用可能', '2024-04-01', ''),
                ('EQ002', 'ノートPC B',    'PC',           'メーカーA', 'Model-X100', 'SN-0002', '貸出中',   '2024-04-01', ''),
                ('EQ003', 'モバイルWi-Fi', 'ネットワーク機器', 'メーカーB', 'WR-300',     'SN-0010', '利用可能', '2024-05-15', ''),
                ('EQ004', 'プロジェクター', 'AV機器',       'メーカーC', 'PJ-500',     'SN-0020', '利用可能', '2024-06-01', '会議室A保管'),
                ('EQ005', 'ICレコーダー',  '録音機器',      'メーカーD', 'IC-100',     'SN-0030', '廃棄',     '2023-01-10', '老朽化のため廃棄');");

            // サンプル貸出履歴
            ExecuteNonQuery(connection, @"
                INSERT INTO RentalHistories
                    (EquipmentId, EmployeeId, RentalDate, ExpectedReturnDate, ActualReturnDate, RentalNote, ReturnNote)
                VALUES
                (2, 1, '2024-06-01', '2024-06-30', NULL,         '出張用',               ''),
                (3, 2, '2024-05-20', '2024-05-25', '2024-05-24', '外出先でのプレゼン用', '問題なし');");
        }

        // ─────────────────────────────────────────
        // ヘルパー
        // ─────────────────────────────────────────

        /// <summary>結果を返さない SQL を実行するヘルパーメソッド</summary>
        private static void ExecuteNonQuery(SqliteConnection connection, string sql)
        {
            using var command = new SqliteCommand(sql, connection);
            command.ExecuteNonQuery();
        }
    }
}
