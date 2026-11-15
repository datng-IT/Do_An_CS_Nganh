namespace MoPhongThangMay.MoHinh
{
    /// <summary>
    /// Một tầng của tòa nhà: có nút gọi Lên/Xuống, hàng người chờ
    /// và ghi nhớ thang nào đã được giao phục vụ lời gọi.
    /// </summary>
    public class Tang
    {
        private readonly List<HanhKhach> _dsCho = new List<HanhKhach>();

        public Tang(int so)
        {
            ChiSoTang = so;
        }

        public int ChiSoTang { get; }
        public IReadOnlyList<HanhKhach> KhachDangCho => _dsCho;

        public bool DenGoiLen { get; private set; }
        public bool DenGoiXuong { get; private set; }
        public ThangMay ThangPhucVuLen { get; private set; }
        public ThangMay ThangPhucVuXuong { get; private set; }

        public void ThemKhachCho(HanhKhach p) => _dsCho.Add(p);
        public void XoaKhachCho(HanhKhach p) => _dsCho.Remove(p);
        public int DemKhachCho(HuongDi d) => _dsCho.Count(x => x.HuongDi == d);

        public bool CoGoi(HuongDi d)
        {
            return d == HuongDi.Len ? DenGoiLen : d == HuongDi.Xuong && DenGoiXuong;
        }

        public void DatGoi(HuongDi d, bool bat)
        {
            if (d == HuongDi.Len) DenGoiLen = bat;
            else if (d == HuongDi.Xuong) DenGoiXuong = bat;
        }

        public ThangMay LayThangPhucVu(HuongDi d)
        {
            return d == HuongDi.Len ? ThangPhucVuLen : d == HuongDi.Xuong ? ThangPhucVuXuong : null;
        }

        public void GanThangPhucVu(HuongDi d, ThangMay thangMay)
        {
            if (d == HuongDi.Len) ThangPhucVuLen = thangMay;
            else if (d == HuongDi.Xuong) ThangPhucVuXuong = thangMay;
        }
    }
}
