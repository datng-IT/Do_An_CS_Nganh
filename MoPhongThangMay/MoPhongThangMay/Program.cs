using MoPhongThangMay.GiaoDien;

namespace MoPhongThangMay
{
    internal static class ChuongTrinh
    {
        /// <summary>Điểm khởi chạy chương trình.</summary>
        [STAThread]
        private static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormChinh());
        }
    }
}
