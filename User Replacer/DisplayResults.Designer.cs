namespace User_Replacer
{
    partial class DisplayResultsForm
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
            this.DisplayResultsDataGriedView = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayResultsDataGriedView)).BeginInit();
            this.SuspendLayout();
            // 
            // DisplayResultsDataGriedView
            // 
            this.DisplayResultsDataGriedView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DisplayResultsDataGriedView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Name});
            this.DisplayResultsDataGriedView.Location = new System.Drawing.Point(12, 12);
            this.DisplayResultsDataGriedView.Name = "DisplayResultsDataGriedView";
            this.DisplayResultsDataGriedView.Size = new System.Drawing.Size(326, 447);
            this.DisplayResultsDataGriedView.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // Name
            // 
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            // 
            // DisplayResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 471);
            this.Controls.Add(this.DisplayResultsDataGriedView);
            this.Text = "DisplayResults";
            this.Load += new System.EventHandler(this.DisplayResults_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DisplayResultsDataGriedView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        public System.Windows.Forms.DataGridView DisplayResultsDataGriedView;
    }
}