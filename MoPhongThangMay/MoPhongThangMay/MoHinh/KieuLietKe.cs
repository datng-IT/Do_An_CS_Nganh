namespace MoPhongThangMay.MoHinh
{
    /// <summary>Chiều chuyển động của thang / chiều đi của hành khách.</summary>
    public enum HuongDi
    {
        KhongCo,
        Len,
        Xuong
    }

    /// <summary>Các trạng thái của máy trạng thái (state machine) thang máy.</summary>
    public enum TrangThaiThang
    {
        DungYen,         // Đứng yên, cửa đóng
        DangChay,       // Đang di chuyển
        DangMoCua,  // Đang mở cửa
        CuaMo,     // Cửa mở, chờ khách ra/vào
        DangDongCua   // Đang đóng cửa
    }

    /// <summary>Loại yêu cầu: bấm trong cabin hoặc gọi ở ngoài tầng (lên/xuống).</summary>
    public enum LoaiYeuCau
    {
        TrongCabin,      // Nút chọn tầng trong cabin
        GoiLen,   // Nút gọi đi lên ở tầng
        GoiXuong  // Nút gọi đi xuống ở tầng
    }

    public static class TienIchHuongDi
    {
        public static HuongDi NguocChieu(this HuongDi d)
        {
            switch (d)
            {
                case HuongDi.Len: return HuongDi.Xuong;
                case HuongDi.Xuong: return HuongDi.Len;
                default: return HuongDi.KhongCo;
            }
        }

        public static LoaiYeuCau ThanhLoaiGoiTang(this HuongDi d)
        {
            return d == HuongDi.Len ? LoaiYeuCau.GoiLen : LoaiYeuCau.GoiXuong;
        }
    }
}
