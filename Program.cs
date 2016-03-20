using System;
using System.Windows.Forms;

namespace Screen_Capture {
    static class Program {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Selector());
        }
    }
}
