using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form1 : Form
    {
        List<Rectangle> figure;
        public Form1()
        {
            InitializeComponent();
        }

        private void FiguresPaint()
        {

        }
        private void buttonDeskChange(object sender, EventArgs e)
        {
            DeskPaint();
            BorderPaint();
            TextPaint();
        }
        private void BorderPaint()
        {
            Graphics graphics = panel.CreateGraphics();
            Pen pen = new Pen(Color.Brown, (int)(panel.Width * 0.1) + 5);
            graphics.DrawRectangle(pen, new Rectangle(0, 0, panel.Width, panel.Height));
        }
        private void TextPaint()
        {
            Graphics graphics = panel.CreateGraphics();
            Font font = new Font("Calibry", (int)(panel.Width * 0.035), FontStyle.Bold);
            for (int i = 0; i < 8; i++)
            {
                graphics.DrawString($"{8 - i}", font, Brushes.LightGray, (int)(panel.Width * 0.007), (int)((panel.Height * 0.025) + panel.Height * 0.9 / 16 + (panel.Height * 0.9 / 8) * i));
            }
            for (int i = 0; i < 8; i++)
            {
                graphics.DrawString($"{(char)(65 + i)}", font, Brushes.LightGray, (int)((panel.Width * 0.03) + panel.Width * 0.9 / 16 + (panel.Width * 0.9 / 8) * i), (int)(panel.Height * 0.9475));
            }
        }
        private void DeskPaint()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (j % 2 == 0)
                    {
                        if (i % 2 == 0)
                            PaintFigure(@"Resourse\rectangleDark.png", (char)('A' + j), (char)('8' - i));
                        else
                            PaintFigure(@"Resourse\rectangleLight.png", (char)('A' + j), (char)('8' - i));
                    }
                    else
                    {
                        if (i % 2 == 0)
                            PaintFigure(@"Resourse\rectangleLight.png", (char)('A' + j), (char)('8' - i));
                        else
                            PaintFigure(@"Resourse\rectangleDark.png", (char)('A' + j), (char)('8' - i));
                    }
                }
            }
        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            Height = (int)(Height / 10) * 10;
            Width = Height;
            DeskPaint();
            BorderPaint();
            TextPaint();
        }

        private void buttonFigurePaint_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                PaintFigure(@"Resourse\Figure\Pawn_Black.gif", (char)('A' + i), '7');
            }
            PaintFigure(@"Resourse\Figure\Rook_Black.gif", 'A', '8');
            PaintFigure(@"Resourse\Figure\Rook_Black.gif", 'H', '8');
            PaintFigure(@"Resourse\Figure\Knight_Black.gif", 'B', '8');
            PaintFigure(@"Resourse\Figure\Knight_Black.gif", 'G', '8');
            PaintFigure(@"Resourse\Figure\Bishop_Black.gif", 'C', '8');
            PaintFigure(@"Resourse\Figure\Bishop_Black.gif", 'F', '8');
            PaintFigure(@"Resourse\Figure\Queen_Black.gif", 'D', '8');
            PaintFigure(@"Resourse\Figure\Knight_Black.gif", 'E', '8');

            for (int i = 0; i < 8; i++)
            {
                PaintFigure(@"Resourse\Figure\Pawn_White.gif", (char)('A' + i), '2');
            }
            PaintFigure(@"Resourse\Figure\Rook_White.gif", 'A', '1');
            PaintFigure(@"Resourse\Figure\Rook_White.gif", 'H', '1');
            PaintFigure(@"Resourse\Figure\Knight_White.gif", 'B', '1');
            PaintFigure(@"Resourse\Figure\Knight_White.gif", 'G', '1');
            PaintFigure(@"Resourse\Figure\Bishop_White.gif", 'C', '1');
            PaintFigure(@"Resourse\Figure\Bishop_White.gif", 'F', '1');
            PaintFigure(@"Resourse\Figure\Queen_White.gif", 'D', '1');
            PaintFigure(@"Resourse\Figure\Knight_White.gif", 'E', '1');
        }
        private void PaintFigure(string path, char pozition_X, char pozition_Y)
        {
            Graphics graphics = panel.CreateGraphics();
            Point startPoint = new Point((int)(panel.Width * 0.05) + 3, (int)(panel.Height * 0.05) + 3);
            Size size = new Size((int)(panel.Width * 0.9f / 8), (int)(panel.Height * 0.9f / 8));
            startPoint.X += size.Width * ((int)pozition_X - 65);
            startPoint.Y += size.Width * (8 - Convert.ToInt32(pozition_Y) + 48);
            Rectangle rectangle = new Rectangle(startPoint, size);
            TextureBrush texture = new TextureBrush(new Bitmap(path));
            texture.TranslateTransform(startPoint.X, startPoint.Y);
            texture.ScaleTransform((float)size.Width / texture.Image.Width, (float)size.Height / texture.Image.Height);
            graphics.FillRectangle(texture, rectangle);
        }
    }
}
