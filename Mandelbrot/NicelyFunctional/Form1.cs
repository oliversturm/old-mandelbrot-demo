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
using FCSlib;
using FCSlib.Data;
using FunctionalMandelbrot;

namespace NicelyFunctional {
  public partial class Form1 : Form {
    public Form1( ) {
      InitializeComponent( );
    }

    private void DrawButton_Click(object sender, EventArgs e) {
      int width = panel.Width;
      int height = panel.Height;
      double xstart = -2.1;
      double xend = 1.0;
      double ystart = -1.3;
      double yend = 1.3;

      Point startPoint = new Point(0, 0);
      var results = Calculator.CalcArea(width, height,
        new CalcInfo(xstart, (xend - xstart) / width,
          ystart, (yend - ystart) / height));
      var image = Calculator.CalcImage(results, startPoint, width, height);
      paintImage = image;
      panel.Invalidate( );
    }

    Image paintImage;

    private void ClearButton_Click(object sender, EventArgs e) {
      paintImage = null;
    }

    private void panel_Paint(object sender, PaintEventArgs e) {
      if (paintImage != null)
        e.Graphics.DrawImage(paintImage, 0, 0);
    }
  }
}