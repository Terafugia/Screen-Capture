using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Screen_Capture {
    public partial class Selector:Form {
        private SaveFileDialog savefiledialog = new SaveFileDialog();
        public Selector() {
            InitializeComponent();
            savefiledialog.FilterIndex = 4;
            savefiledialog.Filter = "Jpeg|*.jpg|Bmp|*.bmp|Gif|*.gif|Png|*.png";
            savefiledialog.Title = "Save Screenshot";
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e) {
            Bitmap screenshot = new Bitmap(this.ClientSize.Width,this.ClientSize.Height,PixelFormat.Format32bppArgb);
            Graphics graphicsScreenshot = Graphics.FromImage(screenshot);
            this.Hide();
            Point location = pictureBox1.PointToScreen(Point.Empty);
            graphicsScreenshot.CopyFromScreen(location.X,location.Y,0,0,this.Bounds.Size,CopyPixelOperation.SourceCopy);
            savefiledialog.ShowDialog();
            if(savefiledialog.FileName != "") {
                switch(savefiledialog.FilterIndex) {
                    case 1:
                        screenshot.Save(savefiledialog.FileName,ImageFormat.Jpeg);
                        break;
                    case 2:
                        screenshot.Save(savefiledialog.FileName,ImageFormat.Bmp);
                        break;
                    case 3:
                        screenshot.Save(savefiledialog.FileName,ImageFormat.Gif);
                        break;
                    case 4:
                        screenshot.Save(savefiledialog.FileName,ImageFormat.Png);
                        break;
                }
            }
            Application.Exit();
        }
    }
}