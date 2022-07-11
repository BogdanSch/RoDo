namespace RoDo
{
    partial class RoDo
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCreate = new System.Windows.Forms.Panel();
            this.bCreate = new System.Windows.Forms.Button();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.pnlTasks = new System.Windows.Forms.Panel();
            this.pnlGreetings = new System.Windows.Forms.Panel();
            this.lInfo = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlCreate.SuspendLayout();
            this.pnlGreetings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.25F));
            this.tableLayoutPanel1.Controls.Add(this.pnlCreate, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlTasks, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlGreetings, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pnlCreate
            // 
            this.pnlCreate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlCreate.Controls.Add(this.bCreate);
            this.pnlCreate.Controls.Add(this.tbInput);
            this.pnlCreate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCreate.Location = new System.Drawing.Point(3, 3);
            this.pnlCreate.Name = "pnlCreate";
            this.pnlCreate.Size = new System.Drawing.Size(240, 70);
            this.pnlCreate.TabIndex = 0;
            // 
            // bCreate
            // 
            this.bCreate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bCreate.Location = new System.Drawing.Point(179, 20);
            this.bCreate.Name = "bCreate";
            this.bCreate.Size = new System.Drawing.Size(58, 29);
            this.bCreate.TabIndex = 1;
            this.bCreate.Text = "Add";
            this.bCreate.UseVisualStyleBackColor = true;
            this.bCreate.Click += new System.EventHandler(this.bCreate_Click);
            // 
            // tbInput
            // 
            this.tbInput.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbInput.Location = new System.Drawing.Point(3, 20);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(170, 29);
            this.tbInput.TabIndex = 0;
            this.tbInput.Text = "Enter your task here...";
            this.tbInput.GotFocus += new System.EventHandler(this.RemoveText);
            this.tbInput.LostFocus += new System.EventHandler(this.AddText);
            // 
            // pnlTasks
            // 
            this.pnlTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTasks.Location = new System.Drawing.Point(249, 79);
            this.pnlTasks.Name = "pnlTasks";
            this.pnlTasks.Size = new System.Drawing.Size(548, 368);
            this.pnlTasks.TabIndex = 1;
            // 
            // pnlGreetings
            // 
            this.pnlGreetings.Controls.Add(this.lInfo);
            this.pnlGreetings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGreetings.Location = new System.Drawing.Point(249, 3);
            this.pnlGreetings.Name = "pnlGreetings";
            this.pnlGreetings.Size = new System.Drawing.Size(548, 70);
            this.pnlGreetings.TabIndex = 2;
            // 
            // lInfo
            // 
            this.lInfo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lInfo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lInfo.ForeColor = System.Drawing.Color.White;
            this.lInfo.Location = new System.Drawing.Point(0, 0);
            this.lInfo.Name = "lInfo";
            this.lInfo.Size = new System.Drawing.Size(548, 70);
            this.lInfo.TabIndex = 0;
            this.lInfo.Text = "My day";
            this.lInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RoDo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RoDo";
            this.Text = "RoDo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RoDo_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlCreate.ResumeLayout(false);
            this.pnlCreate.PerformLayout();
            this.pnlGreetings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlCreate;
        private System.Windows.Forms.Button bCreate;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Panel pnlTasks;
        private System.Windows.Forms.Panel pnlGreetings;
        private System.Windows.Forms.Label lInfo;
    }
}