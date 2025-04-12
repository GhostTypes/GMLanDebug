using System.ComponentModel;

namespace GMLanDebug.ui
{
    partial class SerialDevicePicker
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
            this.serialDeviceList = new System.Windows.Forms.ListView();
            this.connectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serialDeviceList
            // 
            this.serialDeviceList.Location = new System.Drawing.Point(12, 12);
            this.serialDeviceList.Name = "serialDeviceList";
            this.serialDeviceList.Size = new System.Drawing.Size(436, 279);
            this.serialDeviceList.TabIndex = 0;
            this.serialDeviceList.UseCompatibleStateImageBehavior = false;
            this.serialDeviceList.View = System.Windows.Forms.View.List;
            this.serialDeviceList.SelectedIndexChanged += new System.EventHandler(this.serialDeviceList_SelectedIndexChanged);
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(140, 297);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(170, 29);
            this.connectButton.TabIndex = 1;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // SerialDevicePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 334);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.serialDeviceList);
            this.Name = "SerialDevicePicker";
            this.Text = "SerialDevicePicker";
            this.Load += new System.EventHandler(this.SerialDevicePicker_Load);
            this.Shown += new System.EventHandler(this.SerialDevicePicker_Shown);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ListView serialDeviceList;
        private System.Windows.Forms.Button connectButton;

        #endregion
    }
}