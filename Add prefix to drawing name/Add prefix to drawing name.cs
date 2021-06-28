using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tekla.Structures;
using Tekla.Structures.Drawing;
using TSD = Tekla.Structures.Drawing;
using Tekla.Structures.Geometry3d;
using TSG = Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using TSM = Tekla.Structures.Model;
using TSMUI = Tekla.Structures.Model.UI;

namespace Tekla.Technology.Akit.UserScript
{
    #region Windows Form Designer generated code etc.

    partial class TeklaWinFormsMacro : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(347, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TeklaWinFormsMacro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 123);
            this.Controls.Add(this.button1);
            this.Name = "TeklaWinFormsMacro";
            this.Text = "Add prefix to drawing name";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        public TeklaWinFormsMacro()
        {
            InitializeComponent();
        }

        private Button button1;
        static Tekla.Technology.Akit.IScript akit;

        public TeklaWinFormsMacro(Tekla.Technology.Akit.IScript RunMe)
        {
            InitializeComponent();

            akit = RunMe;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // variables to be defined on the form
            string prefix = "ABC";
            int startNumber = 7;

            // initialise new drawinghandler instance
            DrawingHandler drawingHandler = new DrawingHandler();

            // create enumerator of selected drawings
            DrawingEnumerator drawingEnumerator = drawingHandler.GetDrawingSelector().GetSelected();

            // process each drawing in enumerator
            while (drawingEnumerator.MoveNext())
            {
                // set current to drawing instance
                Drawing drawing = drawingEnumerator.Current;

                // format string and apply to drawing name
                drawing.Name = string.Format("{0}{1}", prefix, startNumber);

                // modify drawing
                drawing.Modify();

                // increment number for next drawing
                startNumber++;
            }
        }
    }

    static class Script
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TeklaWinFormsMacro());
        }

        static Tekla.Technology.Akit.IScript akit;

        /// <summary>
        /// Tekla calls the Run method from the $rootnamespace$ namespace
        /// </summary>
        /// <param name="RunMe"></param>
        public static void Run(Tekla.Technology.Akit.IScript RunMe)
        {
            akit = RunMe;
            Application.Run(new TeklaWinFormsMacro(akit));
        }
    }

    #endregion

    partial class TeklaWinFormsMacro
    {

    }
}
