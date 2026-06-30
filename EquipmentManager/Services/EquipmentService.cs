using EquipmentManager.Data;
using EquipmentManager.Models;
using Microsoft.Data.Sqlite;

namespace EquipmentManager.Services
{
    /// <summary>
    /// 備品に関する DB アクセスをまとめたサービスクラス。
    /// View（画面）から直接 SQL を書くのではなく、このクラスを介して DB 操作を行う。
    /// 今後、備品の登録・更新・削除などのメソッドをここに追加していく。
    /// </summary>
    public class EquipmentService
    {
        /// <summary>備品一覧を全件取得して返す</summary>
        public List<Equipment> GetAll()
        {
            var list = new List<Equipment>();

            using var connection = new SqliteConnection(DatabaseConfig.ConnectionString);
            connection.Open();

            // SQLite は接続ごとに外部キー制約を有効化する必要がある
            using (var pragma = new SqliteCommand("PRAGMA foreign_keys = ON;", connection))
                pragma.ExecuteNonQuery();

            // 備品コード順に全件取得
            var sql = @"
                SELECT
                    Id,
                    EquipmentCode,
                    Name,
                    Category,
                    Manufacturer,
                    ModelNumber,
                    SerialNumber,
                    Status,
                    RegisteredDate,
                    Note
                FROM
                    Equipment
                ORDER BY
                    EquipmentCode";

            using var command = new SqliteCommand(sql, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                // NULL 値の列は IsDBNull() で確認してから読み取る
                var equipment = new Equipment
                {
                    Id             = reader.GetInt32(0),
                    EquipmentCode  = reader.GetString(1),
                    Name           = reader.GetString(2),
                    Category       = reader.GetString(3),
                    Manufacturer   = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                    ModelNumber    = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                    SerialNumber   = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                    Status         = reader.GetString(7),
                    RegisteredDate = reader.GetString(8),
                    Note           = reader.IsDBNull(9) ? string.Empty : reader.GetString(9),
                };
                list.Add(equipment);
            }

            return list;
        }

        // ───────────────────────────────────────────────────────────
        // TODO: 以下のメソッドを課題として実装してください
        // ───────────────────────────────────────────────────────────

        // public void Add(Equipment equipment)
        // {
        //     // INSERT INTO Equipment (...) VALUES (...)
        // }

        // public void Update(Equipment equipment)
        // {
        //     // UPDATE Equipment SET ... WHERE Id = @Id
        // }

        // public void Delete(int id)
        // {
        //     // DELETE FROM Equipment WHERE Id = @Id
        // }
    }
}
