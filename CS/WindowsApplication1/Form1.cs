using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.Utils.Text;
using DevExpress.Utils.Drawing;

namespace DXSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }

    public class MyLabel : LabelControl{
        
        public MyLabel() : base() {
            SetStyle(ControlStyles.Selectable, true);
            endX = invalidEndIndex;
            startX = invalidStartIndex;
            ProcessSelection();
        }

        int startX, endX;
        const int invalidStartIndex = -999;
        const int invalidEndIndex = -998;

        private int containsIndex = -1;

        private int ContainsIndex {
            get { return containsIndex; }
            set { containsIndex = value; }
        }
        string selectedText = string.Empty;
        
        private string SelectedText
        { 
            get{return selectedText;} 
            set{selectedText = value;} 
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                isMouseDowm = true;
                startX = e.X;
                endX = e.X;
                ProcessSelection();
                Invalidate();
            }
        }
        bool isMouseDowm = false;
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (isMouseDowm)
            {
                if (!ClientRectangle.Contains(e.Location)) return;
                endX = e.X;
                ProcessSelection();
                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            ProcessSelection();
            isMouseDowm = false;
        }

        protected void ProcessSelection()
        {

            int startIndex = GetIndex(startX);
            int lastIndex = GetIndex(endX);
            if (startX == invalidStartIndex || endX == invalidEndIndex)
            {
                SelectedText = string.Empty;
                ContainsIndex = -1;

            }
            else if (startIndex == lastIndex)
            {
                ContainsIndex = startIndex;
                SelectedText = Text[startIndex].ToString();
            }
            else if (startIndex < lastIndex)
            {
                ContainsIndex = startIndex;
                SelectedText = Text.Substring(startIndex, lastIndex - startIndex + 1);
            }
            else
            {
                ContainsIndex = lastIndex;
                SelectedText = Text.Substring(lastIndex, startIndex - lastIndex + 1);
            }
        }

        protected int[] GetCharWidths(){
            GraphicsInfo info = new GraphicsInfo();
            info.AddGraphics(null);
            int[] widths = TextUtils.GetMeasureString(info.Graphics, Text, Appearance.Font);
            info.ReleaseGraphics();
            return widths;
        }

        private int GetIndex(int x)
        {
            int[] widths = GetCharWidths();
            int n = 0, i = -1;
            while (n <= x )
            {
                if (i == (widths.Length - 1)) return i;
                n += widths[++i];
            }
            return i;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Color foreColor = DevExpress.LookAndFeel.LookAndFeelHelper.GetSystemColor(LookAndFeel, SystemColors.HighlightText);
            Color backColor = DevExpress.LookAndFeel.LookAndFeelHelper.GetSystemColor(LookAndFeel, SystemColors.Highlight);
            using (GraphicsCache cache = new GraphicsCache(e))
                cache.Paint.DrawMultiColorString(cache, ClientRectangle, Text, SelectedText,
                  Appearance, foreColor, backColor, false, ContainsIndex);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            Clipboard.SetDataObject(SelectedText, true);
        }
     }
}
