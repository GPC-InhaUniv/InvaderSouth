﻿using System.Collections;
using UnityEngine;



public class PlayerStatus : MonoBehaviour
{

    public float PlayerHp;
    public int Money;
    public int Score;
    public float SkillAmount;
    private bool isDamaged = false;


    [SerializeField]
    private MeshCollider meshCollider;
    [SerializeField]
    private MeshRenderer meshRenderer;
    private bool ReadyToSkill;

    // Use this for initialization
    void Start()
    {
        PlayerHp = 10f;
        Money = 0;
        Score = 0;

        if (GameManager.Instance.BuyItemList[1])
        {
            SkillAmount = 1.0f;
            GameManager.Instance.BuyItemList[1] = false;
        }
        else
            SkillAmount = 0.0f;
    }

    public void Damaged()
    {
        if (!isDamaged)
        {
            PlayerHp -= 1f;

            if (PlayerHp > 0)
            {
                isDamaged = true;
                meshCollider.enabled = false;
                StartCoroutine(OnOffPlayer());
            }

            if (PlayerHp <= 0)
            {
                return;
            }
        }
    }

    public void SetScoreSkill(int score, float skillAmount)
    {
        Score += score;
        SkillAmount += skillAmount;

        if (SkillAmount >= 1.0f)
            SkillAmount = 1.0f;
    }

    IEnumerator OnOffPlayer()
    {
        bool swtichOnOff = false;
        float frameCount = 0;
        while (isDamaged)
        {
            meshRenderer.enabled = swtichOnOff;
            swtichOnOff = !swtichOnOff;
            frameCount += 0.1f;
            if (frameCount >= 1.0f)
                isDamaged = false;
            yield return new WaitForSeconds(0.1f);
        }

        meshCollider.enabled = true;
        meshRenderer.enabled = true;
        gameObject.SetActive(true);
        yield return null;
    }

}
