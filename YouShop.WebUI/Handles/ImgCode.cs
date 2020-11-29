using System;
using System.Drawing;
using System.IO;
using System.Web;

namespace YouShop.WebUI.Handles
{
    public class ImgCode
    {
        /// <summary>
        /// 验证码生成
        /// </summary>
        /// <returns></returns>
        public static string Get(string code)
        {
            try
            {
                Bitmap bmp = new Bitmap(120, 50);
                Graphics gh = Graphics.FromImage(bmp);
                gh.Clear(Color.LightBlue);

                for (int i = 0; i < code.Length; i++)
                {
                    var ran = new Random(Guid.NewGuid().GetHashCode());
                    Font font = new Font("Microsoft YaHei", ran.Next(14, 24));
                    SolidBrush solid = new SolidBrush(GetRanColor());
                    Point point = new Point(i * 25, 5);
                    gh.DrawString(code[i].ToString(), font, solid, point);
                }

                for (int i = 0; i < 25; i++)
                {
                    var ran = new Random(Guid.NewGuid().GetHashCode());
                    Pen pen = new Pen(GetRanColor());
                    Point p1 = new Point(ran.Next(0, bmp.Width), ran.Next(0, bmp.Height));
                    Point p2 = new Point(ran.Next(0, bmp.Width), ran.Next(0, bmp.Height));
                    gh.DrawLine(pen, p1, p2);
                }

                for (int i = 0; i < 150; i++)
                {
                    var ran = new Random(Guid.NewGuid().GetHashCode());
                    int x = ran.Next(0, bmp.Width);
                    int y = ran.Next(0, bmp.Height);
                    bmp.SetPixel(x, y, GetRanColor());
                }

                var real = HttpContext.Current.Server.MapPath("/");
                var dir = "/Code/";
                var name = Guid.NewGuid().ToString("N") + ".jpg";

                if (!Directory.Exists(real + dir))
                    Directory.CreateDirectory(real + dir);

                bmp.Save(real + dir + name);
                gh.Dispose();

                return dir + name;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        /// <summary>
        /// 验证码随机颜色
        /// </summary>
        /// <returns></returns>
        public static Color GetRanColor()
        {
            var ran = new Random(Guid.NewGuid().GetHashCode());
            var colors = new Color[] { Color.Red, Color.Yellow, Color.Green, Color.Blue, Color.Orange, Color.Violet };
            return colors[ran.Next(0, colors.Length)];
        }
    }
}