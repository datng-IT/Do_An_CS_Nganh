namespace MoPhongThangMay.MoHinh
{
    /// <summary>Tòa nhà: gồm danh sách tầng và danh sách thang máy.</summary>
    public class ToaNha
    {
        private readonly List<Tang> _cacTang = new List<Tang>();
        private readonly List<ThangMay> _cacThang = new List<ThangMay>();

        public ToaNha(int soTang, int soThang, int sucChua)
        {
            if (soTang < 2) throw new ArgumentOutOfRangeException(nameof(soTang));
            if (soThang < 1) throw new ArgumentOutOfRangeException(nameof(soThang));

            for (int i = 0; i < soTang; i++)
                _cacTang.Add(new Tang(i));

            for (int i = 0; i < soThang; i++)
                _cacThang.Add(new ThangMay(i + 1, soTang, sucChua));
        }

        public IReadOnlyList<Tang> CacTang => _cacTang;
        public IReadOnlyList<ThangMay> CacThang => _cacThang;
        public int SoTang => _cacTang.Count;
        public int TangCaoNhat => _cacTang.Count - 1;
        public int SoKhachDangCho => _cacTang.Sum(f => f.KhachDangCho.Count);

        /// <summary>Tên hiển thị của tầng (chỉ số 0 → "Tầng 1").</summary>
        public static string TenTang(int chiSo) => $"Tầng {chiSo + 1}";
    }
}
