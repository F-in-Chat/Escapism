using ScriptableObjects;

namespace InGame.AI.Scripts
{
    public class HearFootsteps : ScriptableObjectList<FootStepListener>
    {
        private void OnEnable()
        {
            list.Clear();
        }

        private void OnDisable()
        {
            list.Clear();
        }
    }
}
