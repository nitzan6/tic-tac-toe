using TicTacToe.GameManagement.Players;
using UnityEngine;

public class AIDelaySettingsHandler : MonoBehaviour
{
    public void ApplyDelay(float delayTime)
    {
        AI[] AIComponents = FindObjectsOfType<AI>();

        if (AIComponents == null)
        {
            return;
        }

        foreach (AI AIComponent in AIComponents)
        {
            AIComponent.DelayInSeconds = delayTime;
        }
    }
}
