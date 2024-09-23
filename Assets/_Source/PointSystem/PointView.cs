using CometSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using VContainer;

public class PointView : MonoBehaviour
{
    [SerializeField] private TMP_Text _pointsText;

    private PointContainer _pointsContainer;


    [Inject]
    public void Construct(PointContainer pointsContainer)
    {
        _pointsContainer = pointsContainer;
    }

    private void OnEnable()
    {
        _pointsContainer.OnPointsCountChange += SetPointsCountText;
    }

    private void SetPointsCountText(int newCount)
    {
        _pointsText.text = $"Points: {newCount}";
    }

    private void OnDisable()
    {
        _pointsContainer.OnPointsCountChange -= SetPointsCountText;
    }
}
