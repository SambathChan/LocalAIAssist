using LocalAIAssist.Helpers;
using Microsoft.Extensions.AI;

namespace LocalAIAssist
{
    public partial class FormMain : Form
    {
        private string apiUrl = "http://localhost:11434/";
        private OllamaChatClient chatClient;
        List<ChatMessage> chatHistory = [];
        CancellationTokenSource cts = new();

        public FormMain()
        {
            InitializeComponent();

            btnSubmitPrompt.Enabled = false;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var models = await OllamaHelper.GetAvailableModelsAsync();

                if (models is null)
                {
                    slbMessage.Text = "No model found";
                }
                else
                {
                    BindDataToDropDown([.. models.Select(m => m.Name)]);
                }
            }
            catch (Exception ex)
            {
                slbMessage.Text = ex.Message;
            }
        }

        private void BindDataToDropDown(List<string> data)
        {
            cbSwitchModel.Items.Clear();

            foreach (var item in data)
            {
                cbSwitchModel.Items.Add(item);
            }

            if(data.Count > 0)
            {
                cbSwitchModel.SelectedIndex = 0;
            }
            else
            {
                slbMessage.Text = "No model found";
            }            
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

                await foreach (var item in chatClient.GetStreamingResponseAsync(chatHistory, cancellationToken: cts.Token))
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
            if (e.KeyData == Keys.Enter && btnSubmitPrompt.Enabled)
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

        private void cbSwitchModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSwitchModel.SelectedItem is string selectedModel)
            {
                chatClient?.Dispose();
                chatClient = new OllamaChatClient(new Uri("http://localhost:11434/"), selectedModel);
                slbMessage.Text = $"Using model: {selectedModel}";
                btnSubmitPrompt.Enabled = true;
            }
        }
    }
}
