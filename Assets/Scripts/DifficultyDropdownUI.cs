using UnityEngine;
using TMPro;
using System;
using System.Linq;

public class DifficultyDropdownUI : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;

    public void OnDifficultyChanged(int index)
    {
        GameController.Instance.Difficulty = (DifficultyLevel)index;
    }


    private void Start()
    {
        dropdown.ClearOptions();

        var difficulties = Enum.GetValues(typeof(DifficultyLevel))
                               .Cast<DifficultyLevel>()
                               .ToList();

        dropdown.AddOptions(difficulties.Select(d => d.ToString()).ToList());

        // Setear valor inicial SIN disparar el evento
        dropdown.SetValueWithoutNotify(
            difficulties.IndexOf(GameController.Instance.Difficulty)
        );
        dropdown.RefreshShownValue();

    }


}


