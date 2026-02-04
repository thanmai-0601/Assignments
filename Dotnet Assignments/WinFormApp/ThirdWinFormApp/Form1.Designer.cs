namespace ThirdWinFormApp
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
            txtCountry = new TextBox();
            txtState = new TextBox();
            listView1 = new ListView();
            cboState = new ComboBox();
            chkPostalMail = new CheckBox();
            chkEmail = new CheckBox();
            rdbMale = new RadioButton();
            rdbFemale = new RadioButton();
            btnAdd = new Button();
            btnRemoveCountry = new Button();
            btnRemoveState = new Button();
            btnShowDetails = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // txtCountry
            // 
            txtCountry.Location = new Point(283, 74);
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new Size(150, 31);
            txtCountry.TabIndex = 0;
            // 
            // txtState
            // 
            txtState.Location = new Point(283, 145);
            txtState.Name = "txtState";
            txtState.Size = new Size(150, 31);
            txtState.TabIndex = 1;
            // 
            // listView1
            // 
            listView1.CheckBoxes = true;
            listView1.Location = new Point(537, 30);
            listView1.Name = "listView1";
            listView1.Size = new Size(182, 146);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.List;
            // 
            // cboState
            // 
            cboState.FormattingEnabled = true;
            cboState.Location = new Point(537, 209);
            cboState.Name = "cboState";
            cboState.Size = new Size(182, 33);
            cboState.TabIndex = 3;
            // 
            // chkPostalMail
            // 
            chkPostalMail.AutoSize = true;
            chkPostalMail.Location = new Point(81, 281);
            chkPostalMail.Name = "chkPostalMail";
            chkPostalMail.Size = new Size(118, 29);
            chkPostalMail.TabIndex = 4;
            chkPostalMail.Text = "PostalMail";
            chkPostalMail.UseVisualStyleBackColor = true;
            // 
            // chkEmail
            // 
            chkEmail.AutoSize = true;
            chkEmail.Location = new Point(81, 332);
            chkEmail.Name = "chkEmail";
            chkEmail.Size = new Size(80, 29);
            chkEmail.TabIndex = 5;
            chkEmail.Text = "Email";
            chkEmail.UseVisualStyleBackColor = true;
            // 
            // rdbMale
            // 
            rdbMale.AutoSize = true;
            rdbMale.Location = new Point(283, 281);
            rdbMale.Name = "rdbMale";
            rdbMale.Size = new Size(75, 29);
            rdbMale.TabIndex = 6;
            rdbMale.TabStop = true;
            rdbMale.Text = "Male";
            rdbMale.UseVisualStyleBackColor = true;
            // 
            // rdbFemale
            // 
            rdbFemale.AutoSize = true;
            rdbFemale.Location = new Point(283, 332);
            rdbFemale.Name = "rdbFemale";
            rdbFemale.Size = new Size(93, 29);
            rdbFemale.TabIndex = 7;
            rdbFemale.TabStop = true;
            rdbFemale.Text = "Female";
            rdbFemale.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(80, 400);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 34);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnRemoveCountry
            // 
            btnRemoveCountry.Location = new Point(239, 405);
            btnRemoveCountry.Name = "btnRemoveCountry";
            btnRemoveCountry.Size = new Size(112, 34);
            btnRemoveCountry.TabIndex = 9;
            btnRemoveCountry.Text = "Remove Country";
            btnRemoveCountry.UseVisualStyleBackColor = true;
            btnRemoveCountry.Click += btnRemoveCountry_Click;
            // 
            // btnRemoveState
            // 
            btnRemoveState.Location = new Point(415, 402);
            btnRemoveState.Name = "btnRemoveState";
            btnRemoveState.Size = new Size(112, 34);
            btnRemoveState.TabIndex = 10;
            btnRemoveState.Text = "Remove State";
            btnRemoveState.UseVisualStyleBackColor = true;
            btnRemoveState.Click += btnRemoveState_Click;
            // 
            // btnShowDetails
            // 
            btnShowDetails.Location = new Point(594, 395);
            btnShowDetails.Name = "btnShowDetails";
            btnShowDetails.Size = new Size(112, 34);
            btnShowDetails.TabIndex = 11;
            btnShowDetails.Text = "Show Details";
            btnShowDetails.UseVisualStyleBackColor = true;
            btnShowDetails.Click += btnShowDetails_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(106, 80);
            label1.Name = "label1";
            label1.Size = new Size(75, 25);
            label1.TabIndex = 12;
            label1.Text = "Country";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(120, 150);
            label2.Name = "label2";
            label2.Size = new Size(51, 25);
            label2.TabIndex = 13;
            label2.Text = "State";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnShowDetails);
            Controls.Add(btnRemoveState);
            Controls.Add(btnRemoveCountry);
            Controls.Add(btnAdd);
            Controls.Add(rdbFemale);
            Controls.Add(rdbMale);
            Controls.Add(chkEmail);
            Controls.Add(chkPostalMail);
            Controls.Add(cboState);
            Controls.Add(listView1);
            Controls.Add(txtState);
            Controls.Add(txtCountry);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCountry;
        private TextBox txtState;
        private ListView listView1;
        private ComboBox cboState;
        private CheckBox chkPostalMail;
        private CheckBox chkEmail;
        private RadioButton rdbMale;
        private RadioButton rdbFemale;
        private Button btnAdd;
        private Button btnRemoveCountry;
        private Button btnRemoveState;
        private Button btnShowDetails;
        private Label label1;
        private Label label2;
    }
}
