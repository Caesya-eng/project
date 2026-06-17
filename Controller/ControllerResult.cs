namespace AgroWasteNexus.Controllers
{
    public class ControllerResult
    {
        public bool Sukses { get; set; }
        public string Pesan { get; set; }

        public static ControllerResult Berhasil(string pesan)
        {
            return new ControllerResult
            {
                Sukses = true,
                Pesan = pesan
            };
        }

        public static ControllerResult Gagal(string pesan)
        {
            return new ControllerResult
            {
                Sukses = false,
                Pesan = pesan
            };
        }
    }
}