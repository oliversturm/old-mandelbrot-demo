#region Copyright
/* Copyright 2009 Oliver Sturm <oliver@sturmnet.org> All rights reserved. */
#endregion

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FCSlib;
using FCSlib.Data;
using FunctionalMandelbrot;
using FC = FCSlib.Data.Collections;
using System.Collections.Generic;
using System.Threading;

namespace ManualConcurrent {
  public partial class Form1 : Form {
    public Form1( ) {
      InitializeComponent( );
    }

    private void DrawButton_Click(object sender, EventArgs e) {
      int height = panel.Height;
      int width = panel.Width;
      paintImage = new Bitmap(width, height);
      int threads = (int) ThreadsUD.Value;
      int iterations = (int) IterationsUD.Value;
      Calculator.MaxIteration = iterations;

      Manager.CalculateImage(panel.Width, panel.Height, AcceptResult, threads);
    }

    private void AcceptResult(JobResult jobResult) {
      if (panel.InvokeRequired)
        panel.BeginInvoke((MethodInvoker) (( ) => AcceptResult(jobResult)));
      else {
        // since I'm always executing in the UI thread now, there's no need to
        // synchronize access to the paintImage.
        var g = Graphics.FromImage(paintImage);
        g.DrawImage(jobResult.Image, jobResult.Job.StartPoint);
        panel.Invalidate(new Rectangle(jobResult.Job.StartPoint, new Size(jobResult.Job.Width, jobResult.Job.Height)));
      }
    }

    Bitmap paintImage;

    private void ClearButton_Click(object sender, EventArgs e) {
      paintImage = null;
      panel.Invalidate( );
    }

    private void panel_Paint(object sender, PaintEventArgs e) {
      if (paintImage != null)
        e.Graphics.DrawImage(paintImage, 0, 0);
    }
  }

  public static class Manager {
    static IEnumerable<Job> Divider(int width, int height) {
      const int jobHeight = 100, jobWidth = 100;
      for (int y = 0; y < height; y += jobHeight) {
        for (int x = 0; x < width; x += jobWidth) {
          yield return new Job(new Point(x, y),
            Math.Min(jobWidth, width - x),
            Math.Min(jobHeight, height - y));
        }
      }
    }

    static FC::Queue<Job> jobs;
    static object jobLock = new object( );

    static Option<Job> GetJob( ) {
      Option<Job> result;
      lock (jobLock) {
        if (!jobs.IsEmpty) {
          result = Option.Some(jobs.Head);
          jobs = jobs.Tail;
        }
        else
          result = Option<Job>.None;
      }
      return result;
    }

    const double xstart = -2.1;
    const double xend = 1.0;
    const double ystart = -1.3;
    const double yend = 1.3;

    public static void CalculateImage(int width, int height, Action<JobResult> resultReceiver, int threads) {
      jobs = new FC::Queue<Job>(Divider(width, height));
      
      double xstep = (xend-xstart)/width;
      double ystep = (yend-ystart)/height;

      ThreadStart threadMethod = ( ) => {
        Option<Job> job;
        do {
          job = GetJob( );
          if (job.IsSome) {
            var calcInfo = new CalcInfo(job.Value.StartPoint.X * xstep + xstart, xstep, job.Value.StartPoint.Y * ystep + ystart, ystep);
            var results = Calculator.CalcArea(job.Value.Width, job.Value.Height, calcInfo);
            var jobResult = new JobResult(job.Value, Calculator.CalcImage(results, job.Value.StartPoint, job.Value.Width, job.Value.Height));
            resultReceiver(jobResult);
          }
        } while (job.IsSome);
      };

      for (int i = 0; i < threads; i++) {
        new Thread(threadMethod).Start( );
      }
    }
  }

  public class Job {
    public Job(Point startPoint, int width, int height) {
      StartPoint = startPoint;
      Width = width;
      Height = height;
    }
    public Point StartPoint { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }
  }

  public class JobResult {
    public JobResult(Job job, Image image) {
      Job = job;
      Image = image;
    }
    public Job Job { get; private set; }
    public Image Image { get; private set; }
  }
}