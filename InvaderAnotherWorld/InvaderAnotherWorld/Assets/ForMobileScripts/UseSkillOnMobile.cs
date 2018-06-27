using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;


public class UseSkillOnMobile : MonoBehaviour,IPointerDownHandler
{
    private MastarPlayerController player;

   

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player").GetComponent<MastarPlayerController>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void OnPointerDown(PointerEventData eventData)
    {
        player.UseSkill();
    }
}

