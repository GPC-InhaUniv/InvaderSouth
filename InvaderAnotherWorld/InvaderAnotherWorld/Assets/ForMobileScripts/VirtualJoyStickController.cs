using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;


public class VirtualJoyStickController : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler
{
    private Image bgImage;
    private Image joystickImage;
    private Vector3 inputVector;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Rigidbody playerRigidbody;
    private Vector3 moveVector;
    private float speed = 0.2f;


    private void Start()
    {
        bgImage = GetComponent<Image>();
        joystickImage = transform.GetChild(0).GetComponent<Image>();
        if (player == null)
            player = GameObject.Find("Player").gameObject;
        if (playerRigidbody == null)
            playerRigidbody = GameObject.Find("Player").GetComponent<Rigidbody>();

    }

    private void Update()
    {
       
        moveVector = MovePlayer();
        player.transform.Translate(new Vector3(moveVector.x, 0, moveVector.z) * speed);


    }


    private Vector3 MovePlayer()
    {
        Vector3 dir = Vector3.zero;
        dir.x = Horizontal();
        dir.z = Vertical();

        if (dir.magnitude > 1)
            dir.Normalize();

        return dir;
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);

    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector3.zero;
        joystickImage.rectTransform.anchoredPosition = Vector3.zero;

    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImage.rectTransform
            ,ped.position,ped.pressEventCamera,out pos))
        {
            pos.x = (pos.x / bgImage.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgImage.rectTransform.sizeDelta.y);

            inputVector = new Vector3(pos.x * 2+1 , 0, pos.y * 2-1 );
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            //move joystick image
            joystickImage.rectTransform.anchoredPosition =
                new Vector3(inputVector.x * (bgImage.rectTransform.sizeDelta.x / 2)
                            , inputVector.z * (bgImage.rectTransform.sizeDelta.y / 2));
        }


    }

    public float Horizontal()
    {
        if (inputVector.x != 0)
            return inputVector.x;
        else
            return Input.GetAxis("Horizontal");
        
    }

    public float Vertical()
    {
        if (inputVector.z != 0)
            return inputVector.z;
        else
            return Input.GetAxis("Vertical");
    }
}

