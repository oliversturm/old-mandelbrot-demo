﻿namespace NicelyFunctional {
  partial class Form1 {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose( );
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent( ) {
      this.DrawButton = new System.Windows.Forms.Button( );
      this.ClearButton = new System.Windows.Forms.Button( );
      this.panel = new System.Windows.Forms.Panel( );
      this.SuspendLayout( );
      // 
      // DrawButton
      // 
      this.DrawButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.DrawButton.Location = new System.Drawing.Point(494, 12);
      this.DrawButton.Name = "DrawButton";
      this.DrawButton.Size = new System.Drawing.Size(75, 23);
      this.DrawButton.TabIndex = 0;
      this.DrawButton.Text = "Draw";
      this.DrawButton.UseVisualStyleBackColor = true;
      this.DrawButton.Click += new System.EventHandler(this.DrawButton_Click);
      // 
      // ClearButton
      // 
      this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.ClearButton.Location = new System.Drawing.Point(494, 41);
      this.ClearButton.Name = "ClearButton";
      this.ClearButton.Size = new System.Drawing.Size(75, 23);
      this.ClearButton.TabIndex = 1;
      this.ClearButton.Text = "Clear";
      this.ClearButton.UseVisualStyleBackColor = true;
      this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
      // 
      // panel
      // 
      this.panel.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.panel.Location = new System.Drawing.Point(12, 12);
      this.panel.Name = "panel";
      this.panel.Size = new System.Drawing.Size(476, 430);
      this.panel.TabIndex = 2;
      this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(581, 454);
      this.Controls.Add(this.panel);
      this.Controls.Add(this.ClearButton);
      this.Controls.Add(this.DrawButton);
      this.Name = "Form1";
      this.Text = "Nicely Functional";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button DrawButton;
    private System.Windows.Forms.Button ClearButton;
    private System.Windows.Forms.Panel panel;
  }
}

