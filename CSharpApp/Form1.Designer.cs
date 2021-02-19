
namespace CSharpApp
{
    partial class Form1
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
            this.button_LeetCodeEasy = new System.Windows.Forms.Button();
            this.button_Delegate = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_Event = new System.Windows.Forms.Button();
            this.button_Nullable = new System.Windows.Forms.Button();
            this.button_LeetCodeMedium = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button_Alogorithm = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_LeetCodeEasy
            // 
            this.button_LeetCodeEasy.Location = new System.Drawing.Point(3, 3);
            this.button_LeetCodeEasy.Name = "button_LeetCodeEasy";
            this.button_LeetCodeEasy.Size = new System.Drawing.Size(129, 23);
            this.button_LeetCodeEasy.TabIndex = 0;
            this.button_LeetCodeEasy.Text = "LeetCode Easy";
            this.button_LeetCodeEasy.UseVisualStyleBackColor = true;
            this.button_LeetCodeEasy.Click += new System.EventHandler(this.button_LeetCodeEasy_Click);
            // 
            // button_Delegate
            // 
            this.button_Delegate.Location = new System.Drawing.Point(3, 32);
            this.button_Delegate.Name = "button_Delegate";
            this.button_Delegate.Size = new System.Drawing.Size(75, 23);
            this.button_Delegate.TabIndex = 3;
            this.button_Delegate.Text = "Delegate委派";
            this.button_Delegate.UseVisualStyleBackColor = true;
            this.button_Delegate.Click += new System.EventHandler(this.button_Delegate_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.button_Alogorithm, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.button_Delegate, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_LeetCodeEasy, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_Event, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.button_Nullable, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.button_LeetCodeMedium, 0, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(159, 222);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // button_Event
            // 
            this.button_Event.Location = new System.Drawing.Point(3, 61);
            this.button_Event.Name = "button_Event";
            this.button_Event.Size = new System.Drawing.Size(75, 23);
            this.button_Event.TabIndex = 5;
            this.button_Event.Text = "Event";
            this.button_Event.UseVisualStyleBackColor = true;
            // 
            // button_Nullable
            // 
            this.button_Nullable.Location = new System.Drawing.Point(3, 90);
            this.button_Nullable.Name = "button_Nullable";
            this.button_Nullable.Size = new System.Drawing.Size(75, 23);
            this.button_Nullable.TabIndex = 7;
            this.button_Nullable.Text = "Nullable";
            this.button_Nullable.UseVisualStyleBackColor = true;
            this.button_Nullable.Click += new System.EventHandler(this.button_Nullable_Click);
            // 
            // button_LeetCodeMedium
            // 
            this.button_LeetCodeMedium.Location = new System.Drawing.Point(3, 119);
            this.button_LeetCodeMedium.Name = "button_LeetCodeMedium";
            this.button_LeetCodeMedium.Size = new System.Drawing.Size(129, 23);
            this.button_LeetCodeMedium.TabIndex = 8;
            this.button_LeetCodeMedium.Text = "LeetCode Medium";
            this.button_LeetCodeMedium.UseVisualStyleBackColor = true;
            this.button_LeetCodeMedium.Click += new System.EventHandler(this.button_LeetCodeMedium_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "label3";
            // 
            // button_Alogorithm
            // 
            this.button_Alogorithm.Location = new System.Drawing.Point(3, 149);
            this.button_Alogorithm.Name = "button_Alogorithm";
            this.button_Alogorithm.Size = new System.Drawing.Size(75, 23);
            this.button_Alogorithm.TabIndex = 9;
            this.button_Alogorithm.Text = "Algorithm";
            this.button_Alogorithm.UseVisualStyleBackColor = true;
            this.button_Alogorithm.Click += new System.EventHandler(this.button_Alogorithm_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 293);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_LeetCodeEasy;
        private System.Windows.Forms.Button button_Delegate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_Event;
        private System.Windows.Forms.Button button_Nullable;
        private System.Windows.Forms.Button e;
        private System.Windows.Forms.Button button_LeetCodeMedium;
        private System.Windows.Forms.Button button_Alogorithm;
    }
}

