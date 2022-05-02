using UnityTemplateProjects.Player;

namespace Items
{
    public interface ITouchable
    {
        void Touch(PlayerContactDetector detector);
    }
}