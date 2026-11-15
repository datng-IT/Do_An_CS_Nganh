namespace MoPhongThangMay.MoHinh
{
    /// <summary>
    /// Một cabin thang máy (bản Tuần 1: mới có dữ liệu và quản lý điểm dừng/hành khách).
    /// Tuần 2 sẽ bổ sung máy trạng thái CapNhat() và điều khiển cửa.
    /// </summary>
    public class ThangMay
    {
        public const double ThoiGianDongMoCua = 1.0;  // giây để mở / đóng cửa
        public const double ThoiGianGiuCua = 2.0;     // giây giữ cửa mở
        private const double SaiSo = 1e-6;

        private readonly List<YeuCau> _diemDung = new List<YeuCau>();
        private readonly List<HanhKhach> _khach = new List<HanhKhach>();

        public ThangMay(int ma, int soTang, int sucChua, double tocDo = 1.0)
        {
            Ma = ma;
            SoTang = soTang;
            SucChua = sucChua;
            TocDo = tocDo;
        }

        public int Ma { get; }
        public int SoTang { get; }
        public int SucChua { get; }
        public double TocDo { get; }  // tầng / giây
        /// <summary>Vị trí theo đơn vị tầng (số thực, ví dụ 2.5 là giữa tầng 3 và tầng 4).</summary>
        public double ViTri { get; private set; }
        public HuongDi HuongDi { get; set; } = HuongDi.KhongCo;
        public TrangThaiThang TrangThai { get; private set; } = TrangThaiThang.DungYen;

        /// <summary>Độ mở cửa: 0 = đóng hẳn, 1 = mở hẳn.</summary>
        public double DoMoCua { get; private set; }

        public double TongQuangDuong { get; private set; }
        public int SoLanDung { get; private set; }

        public IReadOnlyList<YeuCau> DiemDung => _diemDung;
        public IReadOnlyList<HanhKhach> KhachTrongThang => _khach;

        public bool DaDay => _khach.Count >= SucChua;
        public int TangHienTai => (int)Math.Round(ViTri);
        public bool DangODungTang => Math.Abs(ViTri - Math.Round(ViTri)) < SaiSo;
        public int TangCaoNhat => SoTang - 1;

        /// <summary>
        /// Các điểm dừng có hiệu lực. Khi thang đầy thì bỏ qua lời gọi ngoài tầng
        /// (dừng lại cũng không đón được ai), chỉ giữ yêu cầu trong cabin.
        /// </summary>
        public IEnumerable<YeuCau> DiemDungHieuLuc =>
            DaDay ? _diemDung.Where(s => s.Loai == LoaiYeuCau.TrongCabin) : _diemDung;

        // ===================== Quản lý điểm dừng =====================

        public bool ThemDiemDung(YeuCau yeuCau)
        {
            if (yeuCau.Tang < 0 || yeuCau.Tang > TangCaoNhat) return false;
            if (_diemDung.Any(s => s.Tang == yeuCau.Tang && s.Loai == yeuCau.Loai)) return false;
            _diemDung.Add(yeuCau);
            return true;
        }

        public void XoaDiemDung(int tang, LoaiYeuCau loai)
        {
            _diemDung.RemoveAll(s => s.Tang == tang && s.Loai == loai);
        }

        public bool CoDiemDungTai(int tang) => DiemDungHieuLuc.Any(s => s.Tang == tang);

        public bool CoDiemDungPhiaTruoc(HuongDi huong, double tuViTri)
        {
            switch (huong)
            {
                case HuongDi.Len: return DiemDungHieuLuc.Any(s => s.Tang > tuViTri + SaiSo);
                case HuongDi.Xuong: return DiemDungHieuLuc.Any(s => s.Tang < tuViTri - SaiSo);
                default: return false;
            }
        }

        // ===================== Quản lý hành khách =====================

        public void ThemKhach(HanhKhach p) => _khach.Add(p);

        public List<HanhKhach> ChoKhachRa(int tang)
        {
            var dsRa = _khach.Where(p => p.TangDen == tang).ToList();
            foreach (var p in dsRa) _khach.Remove(p);
            return dsRa;
        }
    }
}
