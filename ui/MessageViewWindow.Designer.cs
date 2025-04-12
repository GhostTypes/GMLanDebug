using System.ComponentModel;

namespace GMLanDebug.ui
{
    partial class MessageViewWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.headerLabel = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.senderLabel = new System.Windows.Forms.Label();
            this.priorityLabel = new System.Windows.Forms.Label();
            this.dlcLabel = new System.Windows.Forms.Label();
            this.dataLabel = new System.Windows.Forms.Label();
            this.decimalLabel = new System.Windows.Forms.Label();
            this.asciiLabel = new System.Windows.Forms.Label();
            this.dataTranslated = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.Location = new System.Drawing.Point(12, 36);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(402, 27);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Header:";
            // 
            // idLabel
            // 
            this.idLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idLabel.Location = new System.Drawing.Point(12, 9);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(402, 27);
            this.idLabel.TabIndex = 1;
            this.idLabel.Text = "ID: ";
            // 
            // senderLabel
            // 
            this.senderLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.senderLabel.Location = new System.Drawing.Point(12, 63);
            this.senderLabel.Name = "senderLabel";
            this.senderLabel.Size = new System.Drawing.Size(402, 27);
            this.senderLabel.TabIndex = 2;
            this.senderLabel.Text = "Sender: ";
            // 
            // priorityLabel
            // 
            this.priorityLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priorityLabel.Location = new System.Drawing.Point(12, 90);
            this.priorityLabel.Name = "priorityLabel";
            this.priorityLabel.Size = new System.Drawing.Size(402, 27);
            this.priorityLabel.TabIndex = 3;
            this.priorityLabel.Text = "Priority: ";
            // 
            // dlcLabel
            // 
            this.dlcLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dlcLabel.Location = new System.Drawing.Point(12, 117);
            this.dlcLabel.Name = "dlcLabel";
            this.dlcLabel.Size = new System.Drawing.Size(402, 27);
            this.dlcLabel.TabIndex = 4;
            this.dlcLabel.Text = "DLC: ";
            // 
            // dataLabel
            // 
            this.dataLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataLabel.Location = new System.Drawing.Point(12, 144);
            this.dataLabel.Name = "dataLabel";
            this.dataLabel.Size = new System.Drawing.Size(402, 27);
            this.dataLabel.TabIndex = 5;
            this.dataLabel.Text = "Data: ";
            // 
            // decimalLabel
            // 
            this.decimalLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decimalLabel.Location = new System.Drawing.Point(12, 198);
            this.decimalLabel.Name = "decimalLabel";
            this.decimalLabel.Size = new System.Drawing.Size(402, 27);
            this.decimalLabel.TabIndex = 6;
            this.decimalLabel.Text = "Decimal: ";
            // 
            // asciiLabel
            // 
            this.asciiLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asciiLabel.Location = new System.Drawing.Point(12, 225);
            this.asciiLabel.Name = "asciiLabel";
            this.asciiLabel.Size = new System.Drawing.Size(402, 27);
            this.asciiLabel.TabIndex = 7;
            this.asciiLabel.Text = "Ascii: ";
            // 
            // dataTranslated
            // 
            this.dataTranslated.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataTranslated.Location = new System.Drawing.Point(12, 171);
            this.dataTranslated.Name = "dataTranslated";
            this.dataTranslated.Size = new System.Drawing.Size(402, 27);
            this.dataTranslated.TabIndex = 8;
            this.dataTranslated.Text = "Translation: ";
            // 
            // MessageViewWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 384);
            this.Controls.Add(this.dataTranslated);
            this.Controls.Add(this.asciiLabel);
            this.Controls.Add(this.decimalLabel);
            this.Controls.Add(this.dataLabel);
            this.Controls.Add(this.dlcLabel);
            this.Controls.Add(this.priorityLabel);
            this.Controls.Add(this.senderLabel);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.headerLabel);
            this.Name = "MessageViewWindow";
            this.Text = "MessageViewWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MessageViewWindow_FormClosed);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label decimalLabel;
        private System.Windows.Forms.Label asciiLabel;
        private System.Windows.Forms.Label dataTranslated;

        private System.Windows.Forms.Label senderLabel;
        private System.Windows.Forms.Label priorityLabel;
        private System.Windows.Forms.Label dlcLabel;
        private System.Windows.Forms.Label dataLabel;

        private System.Windows.Forms.Label idLabel;

        private System.Windows.Forms.Label headerLabel;

        #endregion
    }
}