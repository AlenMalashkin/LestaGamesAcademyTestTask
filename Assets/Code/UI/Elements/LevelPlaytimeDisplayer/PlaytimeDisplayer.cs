using Code.Services;
using Code.Services.Timer;
using TMPro;
using UnityEngine;

namespace Code.UI.Elements.LevelPlaytimeDisplayer
{
    public class PlaytimeDisplayer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI playtimeTextField;

        private ITimerService _timerService;

        private void Awake()
        {
            _timerService = ServiceLocator.Container.Resolve<ITimerService>();
            DisplayPlaytime();
        }

        private void DisplayPlaytime()
        {
            float minutes = Mathf.FloorToInt(_timerService.CurrentTime / 60);
            float seconds = Mathf.FloorToInt(_timerService.CurrentTime % 60);
            playtimeTextField.text = $"{minutes:00} : {seconds:00}";
        }
    }
}