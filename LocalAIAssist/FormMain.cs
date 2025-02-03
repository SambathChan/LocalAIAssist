using Microsoft.Extensions.AI;

namespace LocalAIAssist
{
    public partial class FormMain : Form
    {
        IChatClient chatClient = new OllamaChatClient(new Uri("http://localhost:11434/"), "phi3:mini");
        List<ChatMessage> chatHistory = new();
        CancellationTokenSource cts = new CancellationTokenSource();

        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                slbMessage.Text = string.Empty;

                var userPrompt = txtPrompt.Text;
                chatHistory.Add(new ChatMessage(ChatRole.User, userPrompt));

                var response = "";
                txtPrompt.Clear();

                rtbResponse.AppendText("Your prompt: " + userPrompt + "\r\n");
                rtbResponse.AppendText("Response: \r\n");

                await foreach (var item in chatClient.CompleteStreamingAsync(chatHistory, cancellationToken: cts.Token))
                {
                    rtbResponse.AppendText(item.Text);
                    response += item.Text;
                }

                rtbResponse.AppendText("\r\n");
                chatHistory.Add(new ChatMessage(ChatRole.Assistant, response));
            }
            catch (Exception ex)
            {
                slbMessage.Text = "Error: " + ex.Message;
            }
        }

        private void txtPrompt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnSubmitPrompt.PerformClick();
            }
        }

        private void btnStopPrompt_Click(object sender, EventArgs e)
        {
            cts.Cancel();
            cts.Dispose();

            cts = new CancellationTokenSource();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbResponse.Clear();
            chatHistory.Clear();
            slbMessage.Text = string.Empty;
        }
    }
}
