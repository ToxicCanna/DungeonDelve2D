using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleDialogBox : MonoBehaviour
{
    [SerializeField] int lettersPerSecond;
    [SerializeField] Color highlightedColor;

    [SerializeField] Text dialogText;
    [SerializeField] GameObject actionSelector;
    [SerializeField] GameObject skillSelector;
    [SerializeField] GameObject skillDetails;

    [SerializeField] List<Text> actionTexts;
    [SerializeField] List<Text> skillTexts;

    [SerializeField] Text manaText;
    [SerializeField] Text typeText;


    public void SetDialog(string dialog)
    {
        dialogText.text = dialog;
    }

    public IEnumerator TypeDialog(string dialog)
    {
        dialogText.text = "";
        foreach ( var letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds (1f/lettersPerSecond);
        }
    }

    public void EnableDialogText(bool enabled)
    {
        dialogText.enabled = enabled;
    }
    public void EnableActionSelector(bool enabled)
    {
        actionSelector.SetActive(enabled);
    }
    public void EnableSkillSelector(bool enabled)
    {
        skillSelector.SetActive(enabled);
        skillDetails.SetActive(enabled);
    }

    public void UpdateActionSelection(int selectedAction)
    {
        for (int i=0; i<actionTexts.Count; ++i)
        {
            if (i == selectedAction)
                actionTexts[i].color = highlightedColor;
            else
                actionTexts[i].color = Color.black;

        }

    }

    public void UpdateSkillSelection(int selectedSkill, Skill skill)
    {
        for (int i = 0; i < skillTexts.Count; ++i)
        {
            if (i == selectedSkill)
                skillTexts[i].color = highlightedColor;
            else
                skillTexts[i].color = Color.black;

        }
        manaText.text = $"Mana{skill.Mana}/{skill.Base.Mana}";
        typeText.text = skill.Base.Type.ToString();
    }

    public void SetSkillNames(List<Skill> skills)
    {
        for (int i = 0; i < skillTexts.Count; ++i)
        {
            if (i < skills.Count)
                skillTexts[i].text = skills[i].Base.Name;
            else
                skillTexts[i].text = "-";
        }
    }
}
