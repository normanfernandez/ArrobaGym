using System.Drawing;
using System.IO;

namespace ArrobaGym.Utils
{
    public class PictureBinary
    {
        private PictureBinary() {
        }

        public static System.Data.Linq.Binary GetBinary(string filename)
        {
            Image img = Image.FromFile(filename);
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.GetBuffer();
        }

        public static Image GetImage(System.Data.Linq.Binary binary)
        {
            MemoryStream ms = new MemoryStream(binary.ToArray());
            Image img = Image.FromStream(ms);
            return img;
        }
    }
}
