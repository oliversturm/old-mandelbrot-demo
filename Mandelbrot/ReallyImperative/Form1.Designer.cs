namespace ReallyImperative {
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
      this.components = new System.ComponentModel.Container( );
      this.panel = new System.Windows.Forms.Panel( );
      this.DrawButton = new System.Windows.Forms.Button( );
      this.InvalidateTimer = new System.Windows.Forms.Timer(this.components);
      this.ClearButton = new System.Windows.Forms.Button( );
      this.SuspendLayout( );
      // 
      // panel
      // 
      this.panel.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.panel.Location = new System.Drawing.Point(12, 12);
      this.panel.Name = "panel";
      this.panel.Size = new System.Drawing.Size(343, 322);
      this.panel.TabIndex = 0;
      this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
      // 
      // DrawButton
      // 
      this.DrawButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.DrawButton.Location = new System.Drawing.Point(361, 12);
      this.DrawButton.Name = "DrawButton";
      this.DrawButton.Size = new System.Drawing.Size(75, 23);
      this.DrawButton.TabIndex = 1;
      this.DrawButton.Text = "Draw";
      this.DrawButton.UseVisualStyleBackColor = true;
      this.DrawButton.Click += new System.EventHandler(this.DrawButton_Click);
      // 
      // InvalidateTimer
      // 
      this.InvalidateTimer.Interval = 500;
      this.InvalidateTimer.Tick += new System.EventHandler(this.InvalidateTimer_Tick);
      // 
      // ClearButton
      // 
      this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.ClearButton.Location = new System.Drawing.Point(362, 42);
      this.ClearButton.Name = "ClearButton";
      this.ClearButton.Size = new System.Drawing.Size(75, 23);
      this.ClearButton.TabIndex = 2;
      this.ClearButton.Text = "Clear";
      this.ClearButton.UseVisualStyleBackColor = true;
      this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(448, 346);
      this.Controls.Add(this.ClearButton);
      this.Controls.Add(this.DrawButton);
      this.Controls.Add(this.panel);
      this.Name = "Form1";
      this.Text = "Really Imperative";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel;
    private System.Windows.Forms.Button DrawButton;
    private System.Windows.Forms.Timer InvalidateTimer;
    private System.Windows.Forms.Button ClearButton;

  }
}

