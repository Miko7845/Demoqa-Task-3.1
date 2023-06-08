using Newtonsoft.Json;

namespace TestingProject.Utilities.Models
{
    public class TestDataModel
    {
        [JsonProperty("NestedFrames")]
        public NestedFramesModel NestedFrames;

        [JsonProperty("Alerts")]
        public AlertsModel Alerts;
    }

    public class NestedFramesModel
    {
        [JsonProperty("ParentFrameText")]
        public string ParentFrameText;

        [JsonProperty("ChildFrameText")]
        public string ChildFrameText;
    }

    public class AlertsModel
    {
        [JsonProperty("ToSeeAlert")]
        public string ToSeeAlert;

        [JsonProperty("ConfirmBox")]
        public string ConfirmBox;

        [JsonProperty("ConfirmText")]
        public string ConfirmText;

        [JsonProperty("PromptBoxText")]
        public string PromptBoxText;
    }
}
