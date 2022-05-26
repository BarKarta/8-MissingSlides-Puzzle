
using System.Windows.Forms;



namespace _8_Puzzle_Sliding_Tiles_Puzzle
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.durigGameLabel = new System.Windows.Forms.Label();
            this.guideLabel = new System.Windows.Forms.Label();
            this.location_7 = new System.Windows.Forms.Button();
            this.location_4 = new System.Windows.Forms.Button();
            this.location_8 = new System.Windows.Forms.Button();
            this.location_5 = new System.Windows.Forms.Button();
            this.emptyLocation = new System.Windows.Forms.Button();
            this.location_6 = new System.Windows.Forms.Button();
            this.location_3 = new System.Windows.Forms.Button();
            this.location_2 = new System.Windows.Forms.Button();
            this.location_1 = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            this.pickerPanel = new System.Windows.Forms.Panel();
            this.misplacedHeuristicbtn = new System.Windows.Forms.RadioButton();
            this.manhattanHeuristicbtn = new System.Windows.Forms.RadioButton();
            this.pickerLabel = new System.Windows.Forms.Label();
            this.pickerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // durigGameLabel
            // 
            this.durigGameLabel.AutoSize = true;
            this.durigGameLabel.Location = new System.Drawing.Point(56, 328);
            this.durigGameLabel.Name = "durigGameLabel";
            this.durigGameLabel.Size = new System.Drawing.Size(318, 13);
            this.durigGameLabel.TabIndex = 17;
            this.durigGameLabel.Text = "Click Space To Make the AI Move or Reset To start a New Game";
            // 
            // guideLabel
            // 
            this.guideLabel.AutoSize = true;
            this.guideLabel.Location = new System.Drawing.Point(128, 328);
            this.guideLabel.Name = "guideLabel";
            this.guideLabel.Size = new System.Drawing.Size(158, 13);
            this.guideLabel.TabIndex = 16;
            this.guideLabel.Text = "Click Space To Start The Game";
            this.guideLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // location_7
            // 
            this.location_7.Location = new System.Drawing.Point(59, 237);
            this.location_7.Name = "location_7";
            this.location_7.Size = new System.Drawing.Size(93, 76);
            this.location_7.TabIndex = 7;
            this.location_7.TabStop = false;
            this.location_7.UseVisualStyleBackColor = true;
            // 
            // location_4
            // 
            this.location_4.Location = new System.Drawing.Point(59, 155);
            this.location_4.Name = "location_4";
            this.location_4.Size = new System.Drawing.Size(93, 76);
            this.location_4.TabIndex = 8;
            this.location_4.TabStop = false;
            this.location_4.UseVisualStyleBackColor = true;
            // 
            // location_8
            // 
            this.location_8.Location = new System.Drawing.Point(158, 237);
            this.location_8.Name = "location_8";
            this.location_8.Size = new System.Drawing.Size(93, 76);
            this.location_8.TabIndex = 9;
            this.location_8.TabStop = false;
            this.location_8.UseVisualStyleBackColor = true;
            // 
            // location_5
            // 
            this.location_5.Location = new System.Drawing.Point(158, 155);
            this.location_5.Name = "location_5";
            this.location_5.Size = new System.Drawing.Size(93, 76);
            this.location_5.TabIndex = 10;
            this.location_5.TabStop = false;
            this.location_5.UseVisualStyleBackColor = true;
            // 
            // emptyLocation
            // 
            this.emptyLocation.Location = new System.Drawing.Point(257, 237);
            this.emptyLocation.Name = "emptyLocation";
            this.emptyLocation.Size = new System.Drawing.Size(93, 76);
            this.emptyLocation.TabIndex = 11;
            this.emptyLocation.TabStop = false;
            this.emptyLocation.UseVisualStyleBackColor = true;
            // 
            // location_6
            // 
            this.location_6.Location = new System.Drawing.Point(257, 155);
            this.location_6.Name = "location_6";
            this.location_6.Size = new System.Drawing.Size(93, 76);
            this.location_6.TabIndex = 12;
            this.location_6.TabStop = false;
            this.location_6.UseVisualStyleBackColor = true;
            // 
            // location_3
            // 
            this.location_3.Location = new System.Drawing.Point(257, 73);
            this.location_3.Name = "location_3";
            this.location_3.Size = new System.Drawing.Size(93, 76);
            this.location_3.TabIndex = 13;
            this.location_3.TabStop = false;
            this.location_3.UseVisualStyleBackColor = true;
            // 
            // location_2
            // 
            this.location_2.Location = new System.Drawing.Point(158, 73);
            this.location_2.Name = "location_2";
            this.location_2.Size = new System.Drawing.Size(93, 76);
            this.location_2.TabIndex = 14;
            this.location_2.TabStop = false;
            this.location_2.UseVisualStyleBackColor = true;
            // 
            // location_1
            // 
            this.location_1.Location = new System.Drawing.Point(59, 73);
            this.location_1.Name = "location_1";
            this.location_1.Size = new System.Drawing.Size(93, 76);
            this.location_1.TabIndex = 15;
            this.location_1.TabStop = false;
            this.location_1.UseVisualStyleBackColor = true;
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(158, 351);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(92, 23);
            this.resetBtn.TabIndex = 6;
            this.resetBtn.TabStop = false;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // pickerPanel
            // 
            this.pickerPanel.Controls.Add(this.misplacedHeuristicbtn);
            this.pickerPanel.Controls.Add(this.manhattanHeuristicbtn);
            this.pickerPanel.Controls.Add(this.pickerLabel);
            this.pickerPanel.Location = new System.Drawing.Point(11, 10);
            this.pickerPanel.Name = "pickerPanel";
            this.pickerPanel.Size = new System.Drawing.Size(394, 50);
            this.pickerPanel.TabIndex = 5;
            // 
            // misplacedHeuristicbtn
            // 
            this.misplacedHeuristicbtn.AutoSize = true;
            this.misplacedHeuristicbtn.Location = new System.Drawing.Point(274, 21);
            this.misplacedHeuristicbtn.Name = "misplacedHeuristicbtn";
            this.misplacedHeuristicbtn.Size = new System.Drawing.Size(117, 17);
            this.misplacedHeuristicbtn.TabIndex = 1;
            this.misplacedHeuristicbtn.Text = "Misplaced Heuristic";
            this.misplacedHeuristicbtn.UseVisualStyleBackColor = true;
            this.misplacedHeuristicbtn.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // manhattanHeuristicbtn
            // 
            this.manhattanHeuristicbtn.AutoSize = true;
            this.manhattanHeuristicbtn.Checked = true;
            this.manhattanHeuristicbtn.Location = new System.Drawing.Point(3, 21);
            this.manhattanHeuristicbtn.Name = "manhattanHeuristicbtn";
            this.manhattanHeuristicbtn.Size = new System.Drawing.Size(120, 17);
            this.manhattanHeuristicbtn.TabIndex = 1;
            this.manhattanHeuristicbtn.TabStop = true;
            this.manhattanHeuristicbtn.Text = "Manhattan Heuristic";
            this.manhattanHeuristicbtn.UseVisualStyleBackColor = true;
            this.manhattanHeuristicbtn.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // pickerLabel
            // 
            this.pickerLabel.AutoSize = true;
            this.pickerLabel.Location = new System.Drawing.Point(148, 3);
            this.pickerLabel.Name = "pickerLabel";
            this.pickerLabel.Size = new System.Drawing.Size(95, 13);
            this.pickerLabel.TabIndex = 0;
            this.pickerLabel.Text = "Choose Heuristics ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 390);
            this.Controls.Add(this.durigGameLabel);
            this.Controls.Add(this.guideLabel);
            this.Controls.Add(this.location_7);
            this.Controls.Add(this.location_4);
            this.Controls.Add(this.location_8);
            this.Controls.Add(this.location_5);
            this.Controls.Add(this.emptyLocation);
            this.Controls.Add(this.location_6);
            this.Controls.Add(this.location_3);
            this.Controls.Add(this.location_2);
            this.Controls.Add(this.location_1);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.pickerPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "8 Sliding Puzzle";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SlidingTilesPuzzle_KeyPress);
            this.pickerPanel.ResumeLayout(false);
            this.pickerPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label durigGameLabel;
        private Label guideLabel;
        private Button location_7;
        private Button location_4;
        private Button location_8;
        private Button location_5;
        private Button emptyLocation;
        private Button location_6;
        private Button location_3;
        private Button location_2;
        private Button location_1;
        private Button resetBtn;
        private Panel pickerPanel;
        private RadioButton misplacedHeuristicbtn;
        private RadioButton manhattanHeuristicbtn;
        private Label pickerLabel;
    }
}