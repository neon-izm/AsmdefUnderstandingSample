using UnityEngine;
using TMPro;
namespace AsmdefLearning.UI
{
    /// <summary>
    /// そんな使い分けはしないだろ、と思いつつ、サンプルとして別モジュールを参照するスクリプトを置く
    /// </summary>
    public class TimerTextViewTMPro : MonoBehaviour
    {
        [SerializeField] private TMP_Text _timerTextTMPro = default;

        private GameTimerPresenter _presenter = null;

        private void Start()
        {
            _presenter = GetComponent<GameTimerPresenter>();
            _presenter.OnUpdateTimer += OnUpdateTimer;
        }

        private void OnUpdateTimer(float elapsed)
        {
            _timerTextTMPro.text = $"[sec] elapsed {elapsed} ";
        }
    }
}