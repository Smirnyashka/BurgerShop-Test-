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
        [SerializeField] private Image _bar;
        
        private IPlayer _chef;
        private Tweener _barFill;
        private bool IsActive { get; set; } = false;
        private readonly Vector3 _offset = new Vector3(0, 4, 0);


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
        
        private void Update()
        {
            if(IsActive) 
                SetPosition();    
        }

        private void OnDestroy()
        {
            _chef.TaskStarted -= ShowProgressBar;
            _chef.TaskStarted -= FillProgress;
            _chef.TaskEnded -= ClearProgress;
            _chef.TaskEnded -= HideProgressBar;
        }

        private void HideProgressBar()
        {
            IsActive = false;
            gameObject.SetActive(false);
            Debug.Log("progress bar hide");
        }

        private void ShowProgressBar(float taskTime)
        {
            IsActive = true;
            gameObject.SetActive(true);
            Debug.Log("progress bar show");
        }

        private void FillProgress(float taskTime)
        {
            ClearProgress();
            _barFill = _bar.DOFillAmount(ProgressBarConst.Max, taskTime);
        }

        private void ClearProgress()
        {
            _barFill.Kill(_bar);
            _bar.fillAmount = ProgressBarConst.Min;
        }

        private void SetPosition() => 
            gameObject.transform.position = _chef.Position + _offset;
    }
}