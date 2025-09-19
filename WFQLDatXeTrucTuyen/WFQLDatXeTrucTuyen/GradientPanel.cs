using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFQLDatXeTrucTuyen
{
    public class GradientPanel : Panel
    {
        public Color gradientTop { get; set; }
        public Color gradientBottom { get; set; }
        // Create Constructor for the Gradient Panel Class
        public GradientPanel(){
            this.Resize += Grandient_Resize;
        }

        private void Grandient_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            LinearGradientBrush linear = new LinearGradientBrush(
                this.ClientRectangle,
                this.gradientTop,
                this.gradientBottom,
                90F

                );
            Graphics g = e.Graphics;
            g.FillRectangle(linear, this.ClientRectangle);


            base.OnPaint(e);
        }
    }
}
