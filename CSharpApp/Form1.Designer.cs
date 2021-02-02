
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
            this.button_GetAnswer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_ForTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_GetAnswer
            // 
            this.button_GetAnswer.Location = new System.Drawing.Point(41, 48);
            this.button_GetAnswer.Name = "button_GetAnswer";
            this.button_GetAnswer.Size = new System.Drawing.Size(75, 23);
            this.button_GetAnswer.TabIndex = 0;
            this.button_GetAnswer.Text = "button1";
            this.button_GetAnswer.UseVisualStyleBackColor = true;
            this.button_GetAnswer.Click += new System.EventHandler(this.button_GetAnswer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "LeetCode Easy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Delegate委派";
            // 
            // button_ForTest
            // 
            this.button_ForTest.Location = new System.Drawing.Point(41, 130);
            this.button_ForTest.Name = "button_ForTest";
            this.button_ForTest.Size = new System.Drawing.Size(75, 23);
            this.button_ForTest.TabIndex = 3;
            this.button_ForTest.Text = "button1";
            this.button_ForTest.UseVisualStyleBackColor = true;
            this.button_ForTest.Click += new System.EventHandler(this.button_Delegate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(185, 203);
            this.Controls.Add(this.button_ForTest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_GetAnswer);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_GetAnswer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_ForTest;
    }
}

