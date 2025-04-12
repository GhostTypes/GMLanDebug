using System.ComponentModel;

namespace GMLanDebug
{
    partial class MainWindow
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
            this.logList = new System.Windows.Forms.ListView();
            this.connectButton = new System.Windows.Forms.Button();
            this.startLoggingButton = new System.Windows.Forms.Button();
            this.pauseLoggingButton = new System.Windows.Forms.Button();
            this.resumeLoggingButton = new System.Windows.Forms.Button();
            this.stopLoggingButton = new System.Windows.Forms.Button();
            this.openFilteringMenuButton = new System.Windows.Forms.Button();
            this.messagesPerSecondLabel = new System.Windows.Forms.Label();
            this.totalMsgsLabel = new System.Windows.Forms.Label();
            this.filteredMsgsLabel = new System.Windows.Forms.Label();
            this.filterRateBox = new System.Windows.Forms.TextBox();
            this.filterRateLabel = new System.Windows.Forms.Label();
            this.applyFilterRateButton = new System.Windows.Forms.Button();
            this.stateLabel = new System.Windows.Forms.Label();
            this.maxMessagesLabel = new System.Windows.Forms.Label();
            this.maxMessagesBox = new System.Windows.Forms.TextBox();
            this.applyMaxMessagesButton = new System.Windows.Forms.Button();
            this.allowDuplicateMsg = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // logList
            // 
            this.logList.Location = new System.Drawing.Point(180, 12);
            this.logList.Name = "logList";
            this.logList.Size = new System.Drawing.Size(1194, 791);
            this.logList.TabIndex = 0;
            this.logList.UseCompatibleStateImageBehavior = false;
            this.logList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.logList_MouseClick);
            this.logList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.logList_MouseDoubleClick);
            // 
            // connectButton
            // 
            this.connectButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectButton.Location = new System.Drawing.Point(12, 12);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(152, 41);
            this.connectButton.TabIndex = 1;
            this.connectButton.Text = "Connect to COM";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // startLoggingButton
            // 
            this.startLoggingButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startLoggingButton.Location = new System.Drawing.Point(12, 59);
            this.startLoggingButton.Name = "startLoggingButton";
            this.startLoggingButton.Size = new System.Drawing.Size(152, 41);
            this.startLoggingButton.TabIndex = 2;
            this.startLoggingButton.Text = "Start Logging";
            this.startLoggingButton.UseVisualStyleBackColor = true;
            this.startLoggingButton.Click += new System.EventHandler(this.startLoggingButton_Click);
            // 
            // pauseLoggingButton
            // 
            this.pauseLoggingButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseLoggingButton.Location = new System.Drawing.Point(12, 106);
            this.pauseLoggingButton.Name = "pauseLoggingButton";
            this.pauseLoggingButton.Size = new System.Drawing.Size(152, 41);
            this.pauseLoggingButton.TabIndex = 3;
            this.pauseLoggingButton.Text = "Pause Logging";
            this.pauseLoggingButton.UseVisualStyleBackColor = true;
            this.pauseLoggingButton.Click += new System.EventHandler(this.pauseLoggingButton_Click);
            // 
            // resumeLoggingButton
            // 
            this.resumeLoggingButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resumeLoggingButton.Location = new System.Drawing.Point(12, 153);
            this.resumeLoggingButton.Name = "resumeLoggingButton";
            this.resumeLoggingButton.Size = new System.Drawing.Size(152, 41);
            this.resumeLoggingButton.TabIndex = 4;
            this.resumeLoggingButton.Text = "Resume Logging";
            this.resumeLoggingButton.UseVisualStyleBackColor = true;
            this.resumeLoggingButton.Click += new System.EventHandler(this.resumeLoggingButton_Click);
            // 
            // stopLoggingButton
            // 
            this.stopLoggingButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopLoggingButton.Location = new System.Drawing.Point(12, 200);
            this.stopLoggingButton.Name = "stopLoggingButton";
            this.stopLoggingButton.Size = new System.Drawing.Size(152, 41);
            this.stopLoggingButton.TabIndex = 5;
            this.stopLoggingButton.Text = "Stop Logging";
            this.stopLoggingButton.UseVisualStyleBackColor = true;
            this.stopLoggingButton.Click += new System.EventHandler(this.stopLoggingButton_Click);
            // 
            // openFilteringMenuButton
            // 
            this.openFilteringMenuButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openFilteringMenuButton.Location = new System.Drawing.Point(12, 247);
            this.openFilteringMenuButton.Name = "openFilteringMenuButton";
            this.openFilteringMenuButton.Size = new System.Drawing.Size(152, 41);
            this.openFilteringMenuButton.TabIndex = 6;
            this.openFilteringMenuButton.Text = "Configure Filters";
            this.openFilteringMenuButton.UseVisualStyleBackColor = true;
            this.openFilteringMenuButton.Click += new System.EventHandler(this.openFilteringMenuButton_Click);
            // 
            // messagesPerSecondLabel
            // 
            this.messagesPerSecondLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messagesPerSecondLabel.Location = new System.Drawing.Point(12, 303);
            this.messagesPerSecondLabel.Name = "messagesPerSecondLabel";
            this.messagesPerSecondLabel.Size = new System.Drawing.Size(152, 26);
            this.messagesPerSecondLabel.TabIndex = 7;
            this.messagesPerSecondLabel.Text = "Msg/s: ";
            // 
            // totalMsgsLabel
            // 
            this.totalMsgsLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalMsgsLabel.Location = new System.Drawing.Point(12, 329);
            this.totalMsgsLabel.Name = "totalMsgsLabel";
            this.totalMsgsLabel.Size = new System.Drawing.Size(152, 26);
            this.totalMsgsLabel.TabIndex = 8;
            this.totalMsgsLabel.Text = "Total: ";
            // 
            // filteredMsgsLabel
            // 
            this.filteredMsgsLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filteredMsgsLabel.Location = new System.Drawing.Point(12, 355);
            this.filteredMsgsLabel.Name = "filteredMsgsLabel";
            this.filteredMsgsLabel.Size = new System.Drawing.Size(152, 26);
            this.filteredMsgsLabel.TabIndex = 9;
            this.filteredMsgsLabel.Text = "Filtered: ";
            // 
            // filterRateBox
            // 
            this.filterRateBox.Location = new System.Drawing.Point(12, 474);
            this.filterRateBox.Name = "filterRateBox";
            this.filterRateBox.Size = new System.Drawing.Size(149, 20);
            this.filterRateBox.TabIndex = 10;
            // 
            // filterRateLabel
            // 
            this.filterRateLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterRateLabel.Location = new System.Drawing.Point(12, 428);
            this.filterRateLabel.Name = "filterRateLabel";
            this.filterRateLabel.Size = new System.Drawing.Size(152, 43);
            this.filterRateLabel.TabIndex = 11;
            this.filterRateLabel.Text = "Duplicate Filter Interval";
            this.filterRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // applyFilterRateButton
            // 
            this.applyFilterRateButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyFilterRateButton.Location = new System.Drawing.Point(42, 500);
            this.applyFilterRateButton.Name = "applyFilterRateButton";
            this.applyFilterRateButton.Size = new System.Drawing.Size(85, 32);
            this.applyFilterRateButton.TabIndex = 12;
            this.applyFilterRateButton.Text = "Apply";
            this.applyFilterRateButton.UseVisualStyleBackColor = true;
            this.applyFilterRateButton.Click += new System.EventHandler(this.applyFilterRateButton_Click);
            // 
            // stateLabel
            // 
            this.stateLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stateLabel.Location = new System.Drawing.Point(12, 381);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(152, 26);
            this.stateLabel.TabIndex = 13;
            this.stateLabel.Text = "State:";
            // 
            // maxMessagesLabel
            // 
            this.maxMessagesLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxMessagesLabel.Location = new System.Drawing.Point(12, 589);
            this.maxMessagesLabel.Name = "maxMessagesLabel";
            this.maxMessagesLabel.Size = new System.Drawing.Size(152, 43);
            this.maxMessagesLabel.TabIndex = 14;
            this.maxMessagesLabel.Text = "Max Messages";
            this.maxMessagesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // maxMessagesBox
            // 
            this.maxMessagesBox.Location = new System.Drawing.Point(12, 635);
            this.maxMessagesBox.Name = "maxMessagesBox";
            this.maxMessagesBox.Size = new System.Drawing.Size(149, 20);
            this.maxMessagesBox.TabIndex = 15;
            // 
            // applyMaxMessagesButton
            // 
            this.applyMaxMessagesButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyMaxMessagesButton.Location = new System.Drawing.Point(42, 661);
            this.applyMaxMessagesButton.Name = "applyMaxMessagesButton";
            this.applyMaxMessagesButton.Size = new System.Drawing.Size(85, 32);
            this.applyMaxMessagesButton.TabIndex = 16;
            this.applyMaxMessagesButton.Text = "Apply";
            this.applyMaxMessagesButton.UseVisualStyleBackColor = true;
            this.applyMaxMessagesButton.Click += new System.EventHandler(this.applyMaxMessagesButton_Click);
            // 
            // allowDuplicateMsg
            // 
            this.allowDuplicateMsg.Location = new System.Drawing.Point(15, 541);
            this.allowDuplicateMsg.Name = "allowDuplicateMsg";
            this.allowDuplicateMsg.Size = new System.Drawing.Size(148, 23);
            this.allowDuplicateMsg.TabIndex = 17;
            this.allowDuplicateMsg.Text = "Allow Duplicate";
            this.allowDuplicateMsg.UseVisualStyleBackColor = true;
            this.allowDuplicateMsg.Click += new System.EventHandler(this.allowDuplicateMsg_CheckedChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1386, 815);
            this.Controls.Add(this.allowDuplicateMsg);
            this.Controls.Add(this.applyMaxMessagesButton);
            this.Controls.Add(this.maxMessagesBox);
            this.Controls.Add(this.maxMessagesLabel);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.applyFilterRateButton);
            this.Controls.Add(this.filterRateLabel);
            this.Controls.Add(this.filterRateBox);
            this.Controls.Add(this.filteredMsgsLabel);
            this.Controls.Add(this.totalMsgsLabel);
            this.Controls.Add(this.messagesPerSecondLabel);
            this.Controls.Add(this.openFilteringMenuButton);
            this.Controls.Add(this.stopLoggingButton);
            this.Controls.Add(this.resumeLoggingButton);
            this.Controls.Add(this.pauseLoggingButton);
            this.Controls.Add(this.startLoggingButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.logList);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.Click += new System.EventHandler(this.MainWindow_Click);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.CheckBox allowDuplicateMsg;

        private System.Windows.Forms.Button applyMaxMessagesButton;

        private System.Windows.Forms.TextBox maxMessagesBox;

        private System.Windows.Forms.Label maxMessagesLabel;

        private System.Windows.Forms.Label stateLabel;

        private System.Windows.Forms.Button applyFilterRateButton;

        private System.Windows.Forms.TextBox filterRateBox;
        private System.Windows.Forms.Label filterRateLabel;

        private System.Windows.Forms.Label filteredMsgsLabel;

        private System.Windows.Forms.Label totalMsgsLabel;

        private System.Windows.Forms.Label messagesPerSecondLabel;

        private System.Windows.Forms.Button pauseLoggingButton;
        private System.Windows.Forms.Button resumeLoggingButton;
        private System.Windows.Forms.Button stopLoggingButton;
        private System.Windows.Forms.Button openFilteringMenuButton;

        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button startLoggingButton;

        private System.Windows.Forms.ListView logList;

        #endregion
    }
}