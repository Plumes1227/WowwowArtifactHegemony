using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class CardStatus : MonoBehaviour
    {
        [SerializeField] private Button _totalButton;
        [SerializeField] private Button _foundButton;
        [SerializeField] private Button _useButton;
        [SerializeField] private TextMeshProUGUI _totalCountTMP;
        [SerializeField] private TextMeshProUGUI _foundCountTMP;
        [SerializeField] private TextMeshProUGUI _useCountTMP;
        [SerializeField] private int _defaultCount;
        private int _totalCount;
        private int _foundCount;
        private int _useCount;

        private bool isBack;

        private void Start()
        {
            _totalCount = _defaultCount;
            _totalCountTMP.text = _totalCount.ToString();
            _totalButton.onClick.AddListener(AddTotalCount);
            _foundButton.onClick.AddListener(AddFoundCount);
            _useButton.onClick.AddListener(AddUseCount);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
                isBack = true;
            if (Input.GetKeyUp(KeyCode.LeftControl))
                isBack = false;
        }

        private void AddTotalCount()
        {
            _totalCount += isBack ? -1 : 1;
            _totalCountTMP.text = _totalCount.ToString();
        }

        private void AddFoundCount()
        {
            _foundCount += isBack ? -1 : 1;
            _foundCountTMP.text = _foundCount.ToString();
        }

        private void AddUseCount()
        {
            _useCount += isBack ? -1 : 1;
            _useCountTMP.text = _useCount.ToString();
        }
    }
}