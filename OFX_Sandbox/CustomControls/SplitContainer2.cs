using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OFX_Sandbox.CustomControls
{
    public partial class SplitContainer2 : SplitContainer
    {
        public HatchStyle hatchStyle { get; set; } = HatchStyle.BackwardDiagonal;
        public SplitContainer2()
        {
            InitializeComponent();
            SplitterDistance = Width / 2;            
            
            MouseDoubleClick += SplDetails_MouseDoubleClick;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            using (HatchBrush hb = new HatchBrush(hatchStyle, Color.White, Color.DarkBlue))
            {
                pe.Graphics.FillRectangle(hb, SplitterRectangle);
            }
        }


        private void SplDetails_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int int_ori = (int)Orientation;
            if (++int_ori > 1) int_ori = 0;
            Orientation = (Orientation)int_ori;
            if (Orientation == Orientation.Vertical)
            {
                SplitterDistance = Width / 2;
            }
            else
            {
                SplitterDistance = Height / 2;
            }
        }

        public void CycleyHatchStyle()
        {
            int count = Enum.GetNames(typeof(HatchStyle)).Length;
            if ((int)++hatchStyle >= count)
            {
                hatchStyle = 0;
            }            
            Refresh();
        }
    }
}
