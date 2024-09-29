using Code.Constants;
using Code.Units.Chef;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Services.ProgressBarService
{
    public class ProgressBar: MonoBehaviour
    {
        private IPlayer _chef;
        
        [SerializeField] private Image _bar;
        
        private Tweener _barFill;

        [Inject]
        public void Construct(Chef chef)
        {
            _chef = chef;
            
            _chef.TaskStarted += ShowProgressBar;
            _chef.TaskStarted += FillProgress;
            _chef.TaskEnded += ClearProgress;
            _chef.TaskEnded += HideProgressBar;
        }

        private void Start() =>
            HideProgressBar();

        private void OnDestroy()
        {
            _chef.TaskStarted -= ShowProgressBar;
            _chef.TaskStarted -= FillProgress;
            _chef.TaskEnded -= ClearProgress;
            _chef.TaskEnded -= HideProgressBar;
        }
        
        
        public void HideProgressBar()
        {
            gameObject.SetActive(false);
            Debug.Log("progress bar hide");
        }

        public void ShowProgressBar(float taskTime)
        {
            gameObject.SetActive(true);
            Debug.Log("progress bar show");
        }

        public void FillProgress(float taskTime)
        {
            ClearProgress();
            _barFill = _bar.DOFillAmount(ProgressBarConst.Max, taskTime);
        }

        public void ClearProgress()
        {
            _barFill.Kill(_bar);
            _bar.fillAmount = ProgressBarConst.Min;
        }

        
    }
}