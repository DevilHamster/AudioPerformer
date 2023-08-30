using System;
using System.Drawing;
using System.IO;

namespace AudioPerformer
{
    //从mp3文件中提取出标签信息
    static class Mp3FileReader
    {
        /// <summary>
        /// 通过mp3文件路径提取封面图片信息，返回字节流
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Bitmap GetCover(string path)
        {
            if (path.Substring(path.Length - 4, 4) == ".mp3")
            {
                MemoryStream stream; //声明内存流
                TagLib.File f = TagLib.File.Create(path);
                if (f.Tag.Pictures != null && f.Tag.Pictures.Length != 0)
                {
                    var bytes = (byte[])(f.Tag.Pictures[0].Data.Data);
                    //stream =  new MemoryStream(bin);
                    //如果能获取字节流，将其转换为内存流
                    if (bytes != null)
                    {
                        stream = new MemoryStream(bytes);
                        return new Bitmap((Image)new Bitmap(stream));
                    }
                    else { return null; }
                } 
                else
                {return null;}
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 处理图像，在“唱片机”图像上，把专辑封面裁切成圆形的并覆盖上
        /// </summary>
        /// <param name="raw">待裁剪图片</param>
        /// <param name="rec">定界矩形</param>
        /// <returns></returns>
        public static Bitmap CircularCut(Bitmap raw, Bitmap background)
        {
            Size size = new Size(150, 150); //控制封面大小

            //创建画板，在背景图片(唱片)上创建一个Graphic类型的可编辑图层g
            using (Graphics g = Graphics.FromImage(background))
            {
                //创建定界矩形，150*150
                Rectangle rec = new Rectangle(Point.Empty, size);
                //创建纹理笔刷，大小同封面图像，并用其填充图层g
                using (TextureBrush br = new TextureBrush(new Bitmap(raw,size), System.Drawing.Drawing2D.WrapMode.Clamp, rec))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.TranslateTransform(25, 25);
                    g.FillEllipse(br, rec);
                }
            }
            return background;
        }
        
        /// <summary>
        /// 提取曲目信息
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Tuple<string[], string[]> GetInfo(string path)
        {

            if (path.Substring(path.Length - 4, 4) == ".mp3")
            {
                TagLib.File f = TagLib.File.Create(path); //读取文件
                string[] info = new string[] { f.Tag.Album, f.Tag.TitleSort }; //作者、专辑、类别
                return new Tuple<string[], string[]>(f.Tag.Artists, info);
            }
            else
            {
                return null;
            }
        }
    }
}
