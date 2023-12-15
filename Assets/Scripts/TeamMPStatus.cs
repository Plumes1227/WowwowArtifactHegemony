using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class TeamMPStatus : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private Button plusButton;
        [SerializeField] private Button minusButton;
        public Action<int> OnMPUpdate;

        private int mp;
        private int TopMP;

        private void Start()
        {
            plusButton.onClick.AddListener(AddScore);
            minusButton.onClick.AddListener(DeductedScore);
        }

        [Button]
        private void AddScore()
        {
            mp++;
            OnMPUpdate.Invoke(mp);
        }

        [Button]
        private void DeductedScore()
        {
            mp--;
            OnMPUpdate.Invoke(mp);
        }

        public void UpdateMpBar(float topMp)
        {
            image.fillAmount = mp / topMp;
        }
    }
}