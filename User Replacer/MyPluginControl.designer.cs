namespace User_Replacer
{
    partial class MyPluginControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyPluginControl));
            this.textBoxOldUser = new System.Windows.Forms.TextBox();
            this.labelFirstUser = new System.Windows.Forms.Label();
            this.textBoxNewUser = new System.Windows.Forms.TextBox();
            this.labelNewUser = new System.Windows.Forms.Label();
            this.buttonResolveUser = new System.Windows.Forms.Button();
            this.buttonSearchOwner = new System.Windows.Forms.Button();
            this.listViewNewUser = new System.Windows.Forms.ListView();
            this.buttonReplace = new System.Windows.Forms.Button();
            this.checkedListBoxEntities = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxResolveEmail = new System.Windows.Forms.CheckBox();
            this.dataGridViewCustomEntities = new System.Windows.Forms.DataGridView();
            this.Entity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Field = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelCustom = new System.Windows.Forms.Label();
            this.buttonReplaceCustom = new System.Windows.Forms.Button();
            this.buttonSearchCustom = new System.Windows.Forms.Button();
            this.buttonCompareRoles = new System.Windows.Forms.Button();
            this.buttonCompareTeams = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listViewOldUser = new System.Windows.Forms.ListView();
            this.buttonLoadEntities = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomEntities)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxOldUser
            // 
            this.textBoxOldUser.Location = new System.Drawing.Point(16, 47);
            this.textBoxOldUser.Name = "textBoxOldUser";
            this.textBoxOldUser.Size = new System.Drawing.Size(198, 20);
            this.textBoxOldUser.TabIndex = 5;
            // 
            // labelFirstUser
            // 
            this.labelFirstUser.AutoSize = true;
            this.labelFirstUser.Location = new System.Drawing.Point(13, 22);
            this.labelFirstUser.Name = "labelFirstUser";
            this.labelFirstUser.Size = new System.Drawing.Size(109, 13);
            this.labelFirstUser.TabIndex = 6;
            this.labelFirstUser.Text = "Old User Name/Email";
            // 
            // textBoxNewUser
            // 
            this.textBoxNewUser.Location = new System.Drawing.Point(234, 47);
            this.textBoxNewUser.Name = "textBoxNewUser";
            this.textBoxNewUser.Size = new System.Drawing.Size(202, 20);
            this.textBoxNewUser.TabIndex = 7;
            // 
            // labelNewUser
            // 
            this.labelNewUser.AutoSize = true;
            this.labelNewUser.Location = new System.Drawing.Point(231, 22);
            this.labelNewUser.Name = "labelNewUser";
            this.labelNewUser.Size = new System.Drawing.Size(115, 13);
            this.labelNewUser.TabIndex = 8;
            this.labelNewUser.Text = "New User Name/Email";
            // 
            // buttonResolveUser
            // 
            this.buttonResolveUser.Location = new System.Drawing.Point(16, 400);
            this.buttonResolveUser.Name = "buttonResolveUser";
            this.buttonResolveUser.Size = new System.Drawing.Size(147, 23);
            this.buttonResolveUser.TabIndex = 9;
            this.buttonResolveUser.Text = "Resolve User";
            this.buttonResolveUser.UseVisualStyleBackColor = true;
            this.buttonResolveUser.Click += new System.EventHandler(this.ButtonResolveUser_Click);
            // 
            // buttonSearchOwner
            // 
            this.buttonSearchOwner.Location = new System.Drawing.Point(479, 430);
            this.buttonSearchOwner.Name = "buttonSearchOwner";
            this.buttonSearchOwner.Size = new System.Drawing.Size(227, 23);
            this.buttonSearchOwner.TabIndex = 12;
            this.buttonSearchOwner.Text = "Preview";
            this.buttonSearchOwner.UseVisualStyleBackColor = true;
            this.buttonSearchOwner.Click += new System.EventHandler(this.ButtonSearchOwner_Click);
            // 
            // listViewNewUser
            // 
            this.listViewNewUser.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewNewUser.HideSelection = false;
            this.listViewNewUser.Location = new System.Drawing.Point(234, 107);
            this.listViewNewUser.Name = "listViewNewUser";
            this.listViewNewUser.Size = new System.Drawing.Size(202, 272);
            this.listViewNewUser.TabIndex = 17;
            this.listViewNewUser.UseCompatibleStateImageBehavior = false;
            // 
            // buttonReplace
            // 
            this.buttonReplace.Location = new System.Drawing.Point(479, 469);
            this.buttonReplace.Name = "buttonReplace";
            this.buttonReplace.Size = new System.Drawing.Size(227, 23);
            this.buttonReplace.TabIndex = 18;
            this.buttonReplace.Text = "Replace (Owner)";
            this.buttonReplace.UseVisualStyleBackColor = true;
            this.buttonReplace.Click += new System.EventHandler(this.ButtonReplace_Click);
            // 
            // checkedListBoxEntities
            // 
            this.checkedListBoxEntities.FormattingEnabled = true;
            this.checkedListBoxEntities.Location = new System.Drawing.Point(479, 67);
            this.checkedListBoxEntities.Name = "checkedListBoxEntities";
            this.checkedListBoxEntities.Size = new System.Drawing.Size(227, 334);
            this.checkedListBoxEntities.TabIndex = 19;
            this.checkedListBoxEntities.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CheckedListBoxEntities_ItemCheck);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(476, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Entities (Owner based)";
            // 
            // checkBoxResolveEmail
            // 
            this.checkBoxResolveEmail.AutoSize = true;
            this.checkBoxResolveEmail.Location = new System.Drawing.Point(6, 19);
            this.checkBoxResolveEmail.Name = "checkBoxResolveEmail";
            this.checkBoxResolveEmail.Size = new System.Drawing.Size(116, 17);
            this.checkBoxResolveEmail.TabIndex = 22;
            this.checkBoxResolveEmail.Text = "Search User Email ";
            this.checkBoxResolveEmail.UseVisualStyleBackColor = true;
            // 
            // dataGridViewCustomEntities
            // 
            this.dataGridViewCustomEntities.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCustomEntities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCustomEntities.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Entity,
            this.Field});
            this.dataGridViewCustomEntities.Location = new System.Drawing.Point(750, 45);
            this.dataGridViewCustomEntities.Name = "dataGridViewCustomEntities";
            this.dataGridViewCustomEntities.RowHeadersVisible = false;
            this.dataGridViewCustomEntities.Size = new System.Drawing.Size(420, 334);
            this.dataGridViewCustomEntities.TabIndex = 23;
            this.dataGridViewCustomEntities.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCustomEntities_CellEnter);
            // 
            // Entity
            // 
            this.Entity.HeaderText = "Entity";
            this.Entity.Name = "Entity";
            // 
            // Field
            // 
            this.Field.HeaderText = "Field";
            this.Field.Name = "Field";
            // 
            // labelCustom
            // 
            this.labelCustom.AutoSize = true;
            this.labelCustom.Location = new System.Drawing.Point(747, 26);
            this.labelCustom.Name = "labelCustom";
            this.labelCustom.Size = new System.Drawing.Size(115, 13);
            this.labelCustom.TabIndex = 24;
            this.labelCustom.Text = "Entities (different fields)";
            // 
            // buttonReplaceCustom
            // 
            this.buttonReplaceCustom.Location = new System.Drawing.Point(750, 439);
            this.buttonReplaceCustom.Name = "buttonReplaceCustom";
            this.buttonReplaceCustom.Size = new System.Drawing.Size(227, 23);
            this.buttonReplaceCustom.TabIndex = 25;
            this.buttonReplaceCustom.Text = "Replace (Custom)";
            this.buttonReplaceCustom.UseVisualStyleBackColor = true;
            this.buttonReplaceCustom.Click += new System.EventHandler(this.ButtonReplaceCustom_Click);
            // 
            // buttonSearchCustom
            // 
            this.buttonSearchCustom.Location = new System.Drawing.Point(750, 400);
            this.buttonSearchCustom.Name = "buttonSearchCustom";
            this.buttonSearchCustom.Size = new System.Drawing.Size(227, 23);
            this.buttonSearchCustom.TabIndex = 26;
            this.buttonSearchCustom.Text = "Preview";
            this.buttonSearchCustom.UseVisualStyleBackColor = true;
            this.buttonSearchCustom.Click += new System.EventHandler(this.ButtonSearchCustom_Click);
            // 
            // buttonCompareRoles
            // 
            this.buttonCompareRoles.Location = new System.Drawing.Point(205, 400);
            this.buttonCompareRoles.Name = "buttonCompareRoles";
            this.buttonCompareRoles.Size = new System.Drawing.Size(107, 23);
            this.buttonCompareRoles.TabIndex = 27;
            this.buttonCompareRoles.Text = "Compare Roles";
            this.buttonCompareRoles.UseVisualStyleBackColor = true;
            this.buttonCompareRoles.Click += new System.EventHandler(this.ButtonCompareRoles_Click);
            // 
            // buttonCompareTeams
            // 
            this.buttonCompareTeams.Location = new System.Drawing.Point(329, 400);
            this.buttonCompareTeams.Name = "buttonCompareTeams";
            this.buttonCompareTeams.Size = new System.Drawing.Size(107, 23);
            this.buttonCompareTeams.TabIndex = 28;
            this.buttonCompareTeams.Text = "Compare Teams";
            this.buttonCompareTeams.UseVisualStyleBackColor = true;
            this.buttonCompareTeams.Click += new System.EventHandler(this.ButtonCompareTeams_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxResolveEmail);
            this.groupBox1.Location = new System.Drawing.Point(16, 439);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 49);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // listViewOldUser
            // 
            this.listViewOldUser.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewOldUser.HideSelection = false;
            this.listViewOldUser.Location = new System.Drawing.Point(16, 107);
            this.listViewOldUser.Name = "listViewOldUser";
            this.listViewOldUser.Size = new System.Drawing.Size(198, 272);
            this.listViewOldUser.TabIndex = 16;
            this.listViewOldUser.UseCompatibleStateImageBehavior = false;
            // 
            // buttonLoadEntities
            // 
            this.buttonLoadEntities.Location = new System.Drawing.Point(479, 47);
            this.buttonLoadEntities.Name = "buttonLoadEntities";
            this.buttonLoadEntities.Size = new System.Drawing.Size(227, 23);
            this.buttonLoadEntities.TabIndex = 35;
            this.buttonLoadEntities.Text = "Load";
            this.buttonLoadEntities.UseVisualStyleBackColor = true;
            this.buttonLoadEntities.Click += new System.EventHandler(this.buttonLoadEntities_Click);
            // 
            // MyPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonLoadEntities);
            this.Controls.Add(this.listViewOldUser);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonResolveUser);
            this.Controls.Add(this.buttonCompareRoles);
            this.Controls.Add(this.buttonCompareTeams);
            this.Controls.Add(this.buttonSearchCustom);
            this.Controls.Add(this.buttonReplaceCustom);
            this.Controls.Add(this.labelCustom);
            this.Controls.Add(this.dataGridViewCustomEntities);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBoxEntities);
            this.Controls.Add(this.buttonReplace);
            this.Controls.Add(this.listViewNewUser);
            this.Controls.Add(this.buttonSearchOwner);
            this.Controls.Add(this.labelNewUser);
            this.Controls.Add(this.textBoxNewUser);
            this.Controls.Add(this.labelFirstUser);
            this.Controls.Add(this.textBoxOldUser);
            this.Name = "MyPluginControl";
            this.PluginIcon = ((System.Drawing.Icon)(resources.GetObject("$this.PluginIcon")));
            this.Size = new System.Drawing.Size(1190, 682);
            this.TabIcon = ((System.Drawing.Image)(resources.GetObject("$this.TabIcon")));
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomEntities)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxOldUser;
        private System.Windows.Forms.Label labelFirstUser;
        private System.Windows.Forms.TextBox textBoxNewUser;
        private System.Windows.Forms.Label labelNewUser;
        private System.Windows.Forms.Button buttonResolveUser;
        private System.Windows.Forms.Button buttonSearchOwner;
        private System.Windows.Forms.ListView listViewNewUser;
        private System.Windows.Forms.Button buttonReplace;
        private System.Windows.Forms.CheckedListBox checkedListBoxEntities;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxResolveEmail;
        private System.Windows.Forms.DataGridView dataGridViewCustomEntities;
        private System.Windows.Forms.Label labelCustom;
        private System.Windows.Forms.Button buttonReplaceCustom;
        private System.Windows.Forms.Button buttonSearchCustom;
        private System.Windows.Forms.Button buttonCompareRoles;
        private System.Windows.Forms.Button buttonCompareTeams;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Entity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Field;
        private System.Windows.Forms.ListView listViewOldUser;
        private System.Windows.Forms.Button buttonLoadEntities;
    }
}
