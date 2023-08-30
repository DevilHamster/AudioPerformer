using System.Windows.Forms;
using System.Drawing;

namespace AudioPerformer
{
    static class PicControl
    {
        /// <summary>
        /// 把两个PictureBox的中心点对齐
        /// </summary>
        /// <param name="A">以其中心点为准</param>
        /// <param name="B"></param>
        public static void SetLocation(PictureBox A, PictureBox B)
        {
            B.Location = new Point(A.Location.X + (A.Width - B.Width) / 2, A.Location.Y + (A.Height - B.Height) / 2);
        }
    }
}
