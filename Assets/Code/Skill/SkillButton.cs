using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UI_Button;
using UI_Button.Utils;

public class SkillButton : MonoBehaviour
{
    public Image skillImage;
    public TextMeshProUGUI skillNameTxt;
    public TextMeshProUGUI skillDescriptionTxt;
    public int skillButtonID;

    public void SelectButton()
    {
        SkillManager.instance.skill = transform.GetComponent<Skill>();

        skillImage.sprite = SkillManager.instance.skills[skillButtonID].skillSprite;
        skillNameTxt.text = SkillManager.instance.skills[skillButtonID].skillName;
        skillDescriptionTxt.text = SkillManager.instance.skills[skillButtonID].skillText;
    } 
}
