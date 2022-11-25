#region Copyright
/* Copyright 2009 Oliver Sturm <oliver@sturmnet.org> All rights reserved. */
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace ReallyImperative {
  public partial class Form1 : Form {
    public Form1( ) {
      InitializeComponent( );
      InitColors( );
    }

    private void InitColors( ) {
      colors = new Color[COLOR_COUNT];
      colors[0] = Color.White;
      colors[1] = Color.FromArgb(0, 0, 25);
      colors[2] = Color.FromArgb(0, 0, 50);
      colors[3] = Color.FromArgb(0, 0, 75);
      colors[4] = Color.FromArgb(0, 0, 100);
      colors[5] = Color.FromArgb(0, 0, 125);
      colors[6] = Color.FromArgb(0, 0, 150);
      colors[7] = Color.FromArgb(0, 0, 175);
      colors[8] = Color.FromArgb(0, 0, 200);
      colors[9] = Color.FromArgb(0, 0, 255);
    }
    Color[] colors;
    const int COLOR_COUNT = 10;

    private void DrawButton_Click(object sender, EventArgs e) {
      waitEvent = new ManualResetEvent(false);
      ThreadPool.RegisterWaitForSingleObject(waitEvent, CalculationDone, null, -1, true);
      lastLine = 0;
      Thread thread = new Thread(CalculateImage);
      thread.Start( );
      InvalidateTimer.Start( );
    }

    private void CalculationDone(object irrelevant, bool timedOut) {
      InvalidateTimer.Stop( );
      panel.Invalidate( );
    }

    ManualResetEvent waitEvent;

    private void CalculateImage() {
      int width = panel.Width;
      int height = panel.Height;
      image = new Bitmap(width, height);
      const int MAX_ITERATION = 1000;

      double xstart = -2.1;
      double ystart = -1.3;
      double xend = 1.0;
      double yend = 1.3;

      double xstep = (xend - xstart) / width;
      double ystep = (yend - ystart) / height;

      double y = ystart;

      for (int py = 0; py < height; py++) {
        lock (lineLock) {
          currentLine = py;
        }
        double x = xstart;

        for (int px = 0; px < width; px++) {
          double tx = 0;
          double ty = 0;
          int iteration = 0;

          while (((tx * tx + ty * ty) < (2*2)) && iteration < MAX_ITERATION) {
            double xtemp = tx * tx - ty * ty + x;
            ty = 2 * tx * ty + y;
            tx = xtemp;
            iteration++;
          }

          Color color;


          if (iteration == MAX_ITERATION) {
            color = Color.Black;
          }
          else {
            int cind = iteration % COLOR_COUNT;
            color = colors[cind];
          }

          lock (imageLock) {
            image.SetPixel(px, py, color);
          }

          x += xstep;
        }
        y += ystep;
      }

      waitEvent.Set( );
    }

    int currentLine;
    Bitmap image;
    object imageLock = new object( );
    object lineLock = new object( );

    private void panel_Paint(object sender, PaintEventArgs e) {
      lock (imageLock) {
        if (image != null)
          e.Graphics.DrawImage(image, 0, 0);
      }
    }

    int lastLine;

    private void InvalidateTimer_Tick(object sender, EventArgs e) {
      int workLine;
      lock (lineLock)
        workLine = currentLine;

      panel.Invalidate(new Rectangle(0, lastLine, panel.Width, workLine - lastLine));
      lastLine = workLine;
    }

    private void ClearButton_Click(object sender, EventArgs e) {
      image = null;
      panel.Invalidate( );
    }
  }
}
