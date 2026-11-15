namespace MoPhongThangMay.MoHinh
{
    /// <summary>Hành khách: xuất hiện ở một tầng, muốn đi đến tầng khác.</summary>
    public class HanhKhach
    {
        private static int _maTiepTheo = 1;

        public HanhKhach(int tangDi, int tangDen, double thoiDiem)
        {
            if (tangDi == tangDen)
                throw new ArgumentException("Tầng đi và tầng đến phải khác nhau.");

            Ma = _maTiepTheo++;
            TangDi = tangDi;
            TangDen = tangDen;
            ThoiDiemXuatHien = thoiDiem;
        }

        public int Ma { get; }
        public int TangDi { get; }
        public int TangDen { get; }

        public double ThoiDiemXuatHien { get; }
        public double ThoiDiemVaoThang { get; set; } = -1;
        public double ThoiDiemDenNoi { get; set; } = -1;

        public HuongDi HuongDi => TangDen > TangDi ? HuongDi.Len : HuongDi.Xuong;

        /// <summary>Thời gian chờ từ lúc xuất hiện tới lúc vào thang.</summary>
        public double ThoiGianCho => ThoiDiemVaoThang < 0 ? 0 : ThoiDiemVaoThang - ThoiDiemXuatHien;

        /// <summary>Thời gian ở trong thang.</summary>
        public double ThoiGianDi => ThoiDiemDenNoi < 0 ? 0 : ThoiDiemDenNoi - ThoiDiemVaoThang;
    }
}
