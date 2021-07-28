using System.ComponentModel;
using System.Windows.Forms;

namespace LittleBigHouse.Views.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        void InitializeComponent()
        {
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "MainForm";
            this.Text = Resource.ProjectName;

            //
            // MessageBox
            //
            var dialogResult = MessageBox.Show(
                Resource.QuestionText, Resource.QuestionCaption,
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            switch (dialogResult)
            {
                case DialogResult.Yes:
                    InitializeInsideControl();
                    break;
                case DialogResult.No:
                    InitializeOutsideControl();
                    break;
                case DialogResult.Cancel:
                default:
                    break;
            }    
        }

        #endregion

        Controls.InsideControl insideControl;
        Controls.OutsideControl outsideControl;

        /// <summary>
        /// Initialize a new instance of InsideControl
        /// </summary>
        void InitializeInsideControl()
        {
            this.insideControl = new LittleBigHouse.Views.Controls.InsideControl();
            this.insideControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.insideControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.insideControl.DrawFPS = false;
            this.insideControl.Location = new System.Drawing.Point(0, 0);
            this.insideControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.insideControl.Name = "insideControl";
            this.insideControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.insideControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.insideControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.insideControl.Size = new System.Drawing.Size(800, 450);
            this.insideControl.TabIndex = 0;
            
            ((ISupportInitialize)(this.insideControl)).BeginInit();
            this.SuspendLayout();
            this.Controls.Add(this.insideControl);
            ((ISupportInitialize)(this.insideControl)).EndInit();
            this.ResumeLayout(false);
            this.Text = Resource.ProjectName + ": Inside";
        }

        /// <summary>
        /// Initialize a new instance of OutsideControl
        /// </summary>
        void InitializeOutsideControl()
        {
            this.outsideControl = new LittleBigHouse.Views.Controls.OutsideControl();
            this.outsideControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.outsideControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outsideControl.DrawFPS = false;
            this.outsideControl.Location = new System.Drawing.Point(0, 0);
            this.outsideControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.outsideControl.Name = "outsideControl";
            this.outsideControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.outsideControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.outsideControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.outsideControl.Size = new System.Drawing.Size(800, 450);
            this.outsideControl.TabIndex = 0;

            ((ISupportInitialize)(this.outsideControl)).BeginInit();
            this.SuspendLayout();
            this.Controls.Add(this.outsideControl);
            ((ISupportInitialize)(this.outsideControl)).EndInit();
            this.ResumeLayout(false);
            this.Text = Resource.ProjectName + ": Outside";
        }
    }
}