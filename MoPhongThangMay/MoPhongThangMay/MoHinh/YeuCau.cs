namespace MoPhongThangMay.MoHinh
{
    /// <summary>
    /// Một yêu cầu dừng tầng của thang máy.
    /// SoThuTu tăng dần theo thời gian tạo, dùng cho thuật toán FCFS.
    /// </summary>
    public class YeuCau
    {
        private static long _demYeuCau;

        public YeuCau(int tang, LoaiYeuCau loai)
        {
            Tang = tang;
            Loai = loai;
            SoThuTu = Interlocked.Increment(ref _demYeuCau);
        }

        public int Tang { get; }
        public LoaiYeuCau Loai { get; }
        public long SoThuTu { get; }

        /// <summary>Chiều của nút gọi ngoài tầng (KhongCo nếu là yêu cầu trong cabin).</summary>
        public HuongDi HuongGoiTang
        {
            get
            {
                switch (Loai)
                {
                    case LoaiYeuCau.GoiLen: return HuongDi.Len;
                    case LoaiYeuCau.GoiXuong: return HuongDi.Xuong;
                    default: return HuongDi.KhongCo;
                }
            }
        }

        public override string ToString()
        {
            string kieu = Loai == LoaiYeuCau.TrongCabin ? "cabin" : Loai == LoaiYeuCau.GoiLen ? "gọi lên" : "gọi xuống";
            return $"{ToaNha.TenTang(Tang)} ({kieu})";
        }
    }
}