using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class CanvasController : MonoBehaviour
    {
        [SerializeField] private Canvas _teamCanvas;
        [SerializeField] private Canvas _cardCanvas;
        private bool isShowCard = false;

        private void Start()
        {
            SwitchShow();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SwitchShow();
            }
        }

        private void SwitchShow()
        {
            isShowCard = !isShowCard;
            _teamCanvas.enabled = isShowCard;
            _cardCanvas.enabled = !isShowCard;
        }
    }
}