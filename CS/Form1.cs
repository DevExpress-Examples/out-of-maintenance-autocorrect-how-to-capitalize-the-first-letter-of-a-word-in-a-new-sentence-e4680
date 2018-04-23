using System;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraRichEdit;

namespace RichEditCapitalization {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void richEditControl1_AutoCorrect(object sender, AutoCorrectEventArgs e) {
            AutoCorrectInfo info = e.AutoCorrectInfo;
            e.AutoCorrectInfo = null;
            int count = 0;

            if (info.Text.Length <= 0)
                return;

            if (char.IsLetter(info.Text[0])) {
                string replace = char.ToUpper(info.Text[0]).ToString();

                for (; ; ) {
                    if (!info.DecrementStartPosition())
                        break;

                    count++;

                    if (!char.IsWhiteSpace(info.Text[0])) {
                        if (info.Text[0] == '.')
                            break;
                        
                        return;
                    }
                }

                info.ReplaceWith = replace;
                e.AutoCorrectInfo = info;
            }

            for (int i = 0; i < count; i++)
                info.IncrementStartPosition();
        }
    }
}