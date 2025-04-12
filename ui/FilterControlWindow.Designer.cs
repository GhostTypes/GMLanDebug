using System.ComponentModel;

namespace GMLanDebug
{
    partial class FilterControlWindow
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
            this.headerList = new System.Windows.Forms.ListView();
            this.rbShowAll = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rbShowSelected = new System.Windows.Forms.RadioButton();
            this.rbHideSelected = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataFilterText = new System.Windows.Forms.Label();
            this.applyDataFilter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // headerList
            // 
            this.headerList.Location = new System.Drawing.Point(12, 57);
            this.headerList.Name = "headerList";
            this.headerList.Size = new System.Drawing.Size(620, 742);
            this.headerList.TabIndex = 0;
            this.headerList.UseCompatibleStateImageBehavior = false;
            this.headerList.View = System.Windows.Forms.View.List;
            // 
            // rbShowAll
            // 
            this.rbShowAll.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbShowAll.Location = new System.Drawing.Point(655, 281);
            this.rbShowAll.Name = "rbShowAll";
            this.rbShowAll.Size = new System.Drawing.Size(348, 37);
            this.rbShowAll.TabIndex = 1;
            this.rbShowAll.TabStop = true;
            this.rbShowAll.Text = "Show All";
            this.rbShowAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbShowAll.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(176, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Unique Headers";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbShowSelected
            // 
            this.rbShowSelected.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbShowSelected.Location = new System.Drawing.Point(655, 324);
            this.rbShowSelected.Name = "rbShowSelected";
            this.rbShowSelected.Size = new System.Drawing.Size(348, 37);
            this.rbShowSelected.TabIndex = 3;
            this.rbShowSelected.TabStop = true;
            this.rbShowSelected.Text = "Show Selected";
            this.rbShowSelected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbShowSelected.UseVisualStyleBackColor = true;
            // 
            // rbHideSelected
            // 
            this.rbHideSelected.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbHideSelected.Location = new System.Drawing.Point(655, 367);
            this.rbHideSelected.Name = "rbHideSelected";
            this.rbHideSelected.Size = new System.Drawing.Size(348, 37);
            this.rbHideSelected.TabIndex = 4;
            this.rbHideSelected.TabStop = true;
            this.rbHideSelected.Text = "Hide Selected";
            this.rbHideSelected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbHideSelected.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(655, 500);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(301, 20);
            this.textBox1.TabIndex = 5;
            // 
            // dataFilterText
            // 
            this.dataFilterText.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataFilterText.Location = new System.Drawing.Point(732, 475);
            this.dataFilterText.Name = "dataFilterText";
            this.dataFilterText.Size = new System.Drawing.Size(139, 22);
            this.dataFilterText.TabIndex = 6;
            this.dataFilterText.Text = "Data Filter";
            this.dataFilterText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // applyDataFilter
            // 
            this.applyDataFilter.Location = new System.Drawing.Point(748, 526);
            this.applyDataFilter.Name = "applyDataFilter";
            this.applyDataFilter.Size = new System.Drawing.Size(104, 24);
            this.applyDataFilter.TabIndex = 7;
            this.applyDataFilter.Text = "Apply";
            this.applyDataFilter.UseVisualStyleBackColor = true;
            // 
            // FilterControlWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 811);
            this.Controls.Add(this.applyDataFilter);
            this.Controls.Add(this.dataFilterText);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.rbHideSelected);
            this.Controls.Add(this.rbShowSelected);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbShowAll);
            this.Controls.Add(this.headerList);
            this.Name = "FilterControlWindow";
            this.Text = "FilterControlWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FilterControlWindow_FormClosed);
            this.Load += new System.EventHandler(this.FilterControlWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button applyDataFilter;

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label dataFilterText;

        private System.Windows.Forms.RadioButton rbShowSelected;
        private System.Windows.Forms.RadioButton rbHideSelected;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.ListView headerList;
        private System.Windows.Forms.RadioButton rbShowAll;

        #endregion
    }
}