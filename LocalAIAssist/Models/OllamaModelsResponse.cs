using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalAIAssist.Models
{
    public class OllamaModelsResponse
    {
        public ModelInfo[]? Models { get; set; }
    }

    public class ModelInfo
    {
        public string Name { get; set; } = string.Empty;
    }
}
