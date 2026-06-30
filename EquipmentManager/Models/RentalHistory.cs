namespace EquipmentManager.Models
{
    /// <summary>貸出履歴を表すモデルクラス（RentalHistories テーブルに対応）</summary>
    public class RentalHistory
    {
        public int Id { get; set; }

        /// <summary>貸し出した備品の Id（Equipment.Id への外部キー）</summary>
        public int EquipmentId { get; set; }

        /// <summary>借りた社員の Id（Employees.Id への外部キー）</summary>
        public int EmployeeId { get; set; }

        public string RentalDate { get; set; } = string.Empty;
        public string ExpectedReturnDate { get; set; } = string.Empty;

        /// <summary>実際の返却日。未返却の場合は null</summary>
        public string? ActualReturnDate { get; set; }

        public string RentalNote { get; set; } = string.Empty;
        public string ReturnNote { get; set; } = string.Empty;
    }
}
