using UnityTemplateProjects.Player;

namespace UnityTemplateProjects.Items
{
    public interface ITouchable
    {
        void Touch(PlayerContactDetector detector);
    }
}