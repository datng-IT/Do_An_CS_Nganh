using System.ComponentModel;
using MoPhongThangMay.MoHinh;

namespace MoPhongThangMay.GiaoDien
{
    /// <summary>
    /// Cửa sổ chính – bản Tuần 1: chỉ dùng để kiểm tra nhanh các lớp mô hình.
    /// Tuần 2 sẽ thay bằng vùng vẽ mô phỏng.
    /// </summary>
    [DesignerCategory("Code")]
    public class FormChinh : Form
    {
        public FormChinh()
        {
            Text = "Mô phỏng hệ thống điều khiển thang máy – Tuần 1";
            ClientSize = new Size(820, 420);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 11f);

            // ---- Tạo thử các đối tượng để kiểm tra ----
            var toaNha = new ToaNha(10, 2, 8);

            var p = new HanhKhach(0, 6, 0);              // Khách ở Tầng 1 muốn lên Tầng 7
            toaNha.CacTang[0].ThemKhachCho(p);
            toaNha.CacTang[0].DatGoi(p.HuongDi, true);

            var thangMay = toaNha.CacThang[0];
            thangMay.ThemDiemDung(new YeuCau(6, LoaiYeuCau.TrongCabin));
            thangMay.ThemDiemDung(new YeuCau(6, LoaiYeuCau.TrongCabin)); // trùng → không được thêm

            var thongTin = new Label
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(24),
                Text =
                    $"Tòa nhà: {toaNha.SoTang} tầng, {toaNha.CacThang.Count} thang máy\n\n" +
                    $"Hành khách #{p.Ma}: {ToaNha.TenTang(p.TangDi)} → {ToaNha.TenTang(p.TangDen)}, chiều {p.HuongDi}\n" +
                    $"{ToaNha.TenTang(0)}: {toaNha.CacTang[0].DemKhachCho(HuongDi.Len)} người chờ đi lên, " +
                    $"đèn gọi ▲ = {toaNha.CacTang[0].DenGoiLen}\n\n" +
                    $"Thang {thangMay.Ma}: vị trí {thangMay.ViTri}, sức chứa {thangMay.SucChua}\n" +
                    $"Điểm dừng: {string.Join(", ", thangMay.DiemDung)} (số điểm dừng = {thangMay.DiemDung.Count})\n" +
                    $"Còn điểm dừng phía trên? {thangMay.CoDiemDungPhiaTruoc(HuongDi.Len, thangMay.ViTri)}"
            };
            Controls.Add(thongTin);
        }
    }
}
