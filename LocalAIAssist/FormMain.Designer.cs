namespace LocalAIAssist
{
    partial class FormMain
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
            txtPrompt = new TextBox();
            btnSubmitPrompt = new Button();
            rtbResponse = new RichTextBox();
            btnStopPrompt = new Button();
            btnClear = new Button();
            statusStrip1 = new StatusStrip();
            slbMessage = new ToolStripStatusLabel();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtPrompt
            // 
            txtPrompt.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPrompt.Location = new Point(12, 362);
            txtPrompt.Multiline = true;
            txtPrompt.Name = "txtPrompt";
            txtPrompt.Size = new Size(677, 50);
            txtPrompt.TabIndex = 0;
            txtPrompt.KeyDown += txtPrompt_KeyDown;
            // 
            // btnSubmitPrompt
            // 
            btnSubmitPrompt.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSubmitPrompt.Location = new Point(694, 362);
            btnSubmitPrompt.Name = "btnSubmitPrompt";
            btnSubmitPrompt.Size = new Size(94, 50);
            btnSubmitPrompt.TabIndex = 1;
            btnSubmitPrompt.Text = "Submit";
            btnSubmitPrompt.UseVisualStyleBackColor = true;
            btnSubmitPrompt.Click += btnSubmit_Click;
            // 
            // rtbResponse
            // 
            rtbResponse.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbResponse.Location = new Point(12, 46);
            rtbResponse.Name = "rtbResponse";
            rtbResponse.ReadOnly = true;
            rtbResponse.Size = new Size(776, 310);
            rtbResponse.TabIndex = 2;
            rtbResponse.Text = "";
            // 
            // btnStopPrompt
            // 
            btnStopPrompt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStopPrompt.Location = new Point(694, 11);
            btnStopPrompt.Name = "btnStopPrompt";
            btnStopPrompt.Size = new Size(94, 29);
            btnStopPrompt.TabIndex = 7;
            btnStopPrompt.Text = "Stop";
            btnStopPrompt.UseVisualStyleBackColor = true;
            btnStopPrompt.Click += btnStopPrompt_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(595, 11);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 8;
            btnClear.Text = "Clear Chat";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { slbMessage });
            statusStrip1.Location = new Point(0, 424);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 26);
            statusStrip1.TabIndex = 9;
            statusStrip1.Text = "statusStrip1";
            // 
            // slbMessage
            // 
            slbMessage.Name = "slbMessage";
            slbMessage.Size = new Size(67, 20);
            slbMessage.Text = "Message";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip1);
            Controls.Add(btnClear);
            Controls.Add(btnStopPrompt);
            Controls.Add(rtbResponse);
            Controls.Add(txtPrompt);
            Controls.Add(btnSubmitPrompt);
            Name = "FormMain";
            Text = "Local AI Assist";
            Load += Form1_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPrompt;
        private Button btnSubmitPrompt;
        private RichTextBox rtbResponse;
        private Button btnStopPrompt;
        private Button btnClear;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel slbMessage;
    }
}
