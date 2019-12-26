using UnityEngine;
using UnityEngine.UI;

namespace AsmdefLearning.UI
{
    /// <summary>
    /// タイマーを表示するビュー
    /// </summary>
    [RequireComponent(typeof(GameTimerPresenter))]
    public class GameTimerView : MonoBehaviour
    {
        [SerializeField] private Text _timerText = default;

        private GameTimerPresenter _presenter = null;

        private void Start()
        {
            _presenter = GetComponent<GameTimerPresenter>();
            _presenter.OnUpdateTimer += OnUpdateTimer;
        }

        private void OnUpdateTimer(float elapsed)
        {
            _timerText.text = $"[sec] elapsed {elapsed} ";
        }
    }
}