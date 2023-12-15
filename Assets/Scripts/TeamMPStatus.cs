using System;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class TeamMPStatus : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private Button plusButton;
        [SerializeField] private Button minusButton;
        [SerializeField] private TextMeshProUGUI mpValueTMP;
        public Action<TeamMPStatus> OnMPAdded;
        public Action<TeamMPStatus> OnMPDeducted;

        private void Start()
        {
            plusButton.onClick.AddListener(AddScore);
            minusButton.onClick.AddListener(DeductedScore);
        }

        [Button]
        private void AddScore()
        {
            OnMPAdded.Invoke(this);
        }

        [Button]
        private void DeductedScore()
        {
            OnMPDeducted.Invoke(this);
        }

        public void UpdateMpBar(int mp, float topMp)
        {
            mpValueTMP.text = mp.ToString();
            image.fillAmount = mp / topMp;
        }
    }
}