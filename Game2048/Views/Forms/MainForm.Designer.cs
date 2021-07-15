namespace Game2048.Views.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.bannerControl = new Game2048.Views.Controls.BannerControl();
            this.centerTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.gameControl3D = new Game2048.Views.Controls.GameControl();
            this.rightTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.gameControl2D = new Game2048.Views.Controls.CameraControl();
            this.scoreControl = new Game2048.Views.Controls.TextControl();
            this.moveControl = new Game2048.Views.Controls.TextControl();
            this.topPanel = new System.Windows.Forms.Panel();
            this.mainTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bannerControl)).BeginInit();
            this.centerTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameControl3D)).BeginInit();
            this.rightTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameControl2D)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoreControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveControl)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 1;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Controls.Add(this.bannerControl, 0, 2);
            this.mainTableLayoutPanel.Controls.Add(this.centerTableLayoutPanel, 0, 1);
            this.mainTableLayoutPanel.Controls.Add(this.topPanel, 0, 0);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 3;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(800, 450);
            this.mainTableLayoutPanel.TabIndex = 0;
            // 
            // bannerControl
            // 
            this.bannerControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bannerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bannerControl.DrawFPS = false;
            this.bannerControl.Location = new System.Drawing.Point(6, 408);
            this.bannerControl.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.bannerControl.Name = "bannerControl";
            this.bannerControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.bannerControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.bannerControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.bannerControl.Size = new System.Drawing.Size(788, 36);
            this.bannerControl.TabIndex = 7;
            this.bannerControl.Value = 0;
            // 
            // centerTableLayoutPanel
            // 
            this.centerTableLayoutPanel.ColumnCount = 2;
            this.centerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.centerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.centerTableLayoutPanel.Controls.Add(this.gameControl3D, 0, 0);
            this.centerTableLayoutPanel.Controls.Add(this.rightTableLayoutPanel, 1, 0);
            this.centerTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerTableLayoutPanel.Location = new System.Drawing.Point(3, 48);
            this.centerTableLayoutPanel.Name = "centerTableLayoutPanel";
            this.centerTableLayoutPanel.RowCount = 1;
            this.centerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.centerTableLayoutPanel.Size = new System.Drawing.Size(794, 354);
            this.centerTableLayoutPanel.TabIndex = 4;
            // 
            // gameControl3D
            // 
            this.gameControl3D.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameControl3D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameControl3D.DrawFPS = false;
            this.gameControl3D.Location = new System.Drawing.Point(4, 3);
            this.gameControl3D.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gameControl3D.Name = "gameControl3D";
            this.gameControl3D.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.gameControl3D.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.gameControl3D.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.gameControl3D.Size = new System.Drawing.Size(547, 348);
            this.gameControl3D.TabIndex = 2;
            // 
            // rightTableLayoutPanel
            // 
            this.rightTableLayoutPanel.ColumnCount = 1;
            this.rightTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rightTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.rightTableLayoutPanel.Controls.Add(this.gameControl2D, 0, 1);
            this.rightTableLayoutPanel.Controls.Add(this.scoreControl, 0, 0);
            this.rightTableLayoutPanel.Controls.Add(this.moveControl, 0, 2);
            this.rightTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightTableLayoutPanel.Location = new System.Drawing.Point(558, 3);
            this.rightTableLayoutPanel.Name = "rightTableLayoutPanel";
            this.rightTableLayoutPanel.RowCount = 3;
            this.rightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.rightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.rightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.rightTableLayoutPanel.Size = new System.Drawing.Size(233, 348);
            this.rightTableLayoutPanel.TabIndex = 3;
            // 
            // gameControl2D
            // 
            this.gameControl2D.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameControl2D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameControl2D.DrawFPS = false;
            this.gameControl2D.Location = new System.Drawing.Point(4, 37);
            this.gameControl2D.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gameControl2D.Name = "gameControl2D";
            this.gameControl2D.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.gameControl2D.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.gameControl2D.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.gameControl2D.Size = new System.Drawing.Size(225, 272);
            this.gameControl2D.TabIndex = 3;
            // 
            // scoreControl
            // 
            this.scoreControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.scoreControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scoreControl.DrawFPS = false;
            this.scoreControl.Location = new System.Drawing.Point(4, 3);
            this.scoreControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.scoreControl.Name = "scoreControl";
            this.scoreControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.scoreControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.scoreControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.scoreControl.Size = new System.Drawing.Size(225, 28);
            this.scoreControl.TabIndex = 4;
            this.scoreControl.Number = 0;
            // 
            // moveControl
            // 
            this.moveControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.moveControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moveControl.DrawFPS = false;
            this.moveControl.Location = new System.Drawing.Point(4, 315);
            this.moveControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.moveControl.Name = "moveControl";
            this.moveControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.moveControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.moveControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.moveControl.Size = new System.Drawing.Size(225, 30);
            this.moveControl.TabIndex = 5;
            this.moveControl.Number = 0;
            // 
            // topPanel
            // 
            this.topPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.Location = new System.Drawing.Point(3, 3);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(794, 39);
            this.topPanel.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "2048";
            this.mainTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bannerControl)).EndInit();
            this.centerTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gameControl3D)).EndInit();
            this.rightTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gameControl2D)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoreControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel centerTableLayoutPanel;
        private Controls.GameControl gameControl3D;
        private Controls.BannerControl bannerControl;
        private System.Windows.Forms.TableLayoutPanel rightTableLayoutPanel;
        private Controls.CameraControl gameControl2D;
        private System.Windows.Forms.Panel topPanel;
        private Controls.TextControl scoreControl;
        private Controls.TextControl moveControl;
    }
}

