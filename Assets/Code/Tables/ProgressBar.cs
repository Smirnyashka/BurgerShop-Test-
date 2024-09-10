using System;
using Code.Constants;
using Code.Hero;
using Code.Units.Chef;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Tables
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField]private Image _bar;

        private Chef _chef;

        [Inject]
        public void Construct(Chef chef)
        {
            _chef = chef;
        }

        private void Start()
        {
            HideProgressBar();
            ShowProgressBar();
        }

        private void OnEnable()
        {
            _chef.OnTaskStarted += ShowProgressBar;
            _chef.OnTaskStarted += FillProgress;
            _chef.OnTaskEnded += HideProgressBar;
            _chef.OnTaskEnded += ClearProgress;
        }

        private void OnDisable()
        {
            _chef.OnTaskStarted -= ShowProgressBar;
            _chef.OnTaskStarted -= FillProgress;
            _chef.OnTaskEnded -= HideProgressBar;
            _chef.OnTaskEnded -= ClearProgress;
        }

        private void HideProgressBar()
        {
            gameObject.SetActive(false);
            Debug.Log("progress bar hide");
        }


        private void ShowProgressBar()
        {
            gameObject.SetActive(true);
            Debug.Log("progress bar show");
        }
        
        private void FillProgress()
        {
            ClearProgress();
            _bar.DOFillAmount(ProgressBarConst.Max, 5);
        }

        private void ClearProgress()
        {
            _bar.fillAmount = ProgressBarConst.Min;
        }
    }
}