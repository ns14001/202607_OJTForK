namespace EquipmentManager.Models
{
    /// <summary>社員情報を表すモデルクラス（Employees テーブルに対応）</summary>
    public class Employee
    {
        public int Id { get; set; }

        /// <summary>社員コード（例: EMP001）</summary>
        public string EmployeeCode { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        /// <summary>在籍状態（例: "在籍中" / "退職"）</summary>
        public string Status { get; set; } = string.Empty;
    }
}
