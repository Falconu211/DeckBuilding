using TMPro;
using UnityEngine;

public class Cards : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI costText;
    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] TextMeshProUGUI myNumberText;

    public Vector2 startingCardPosition;

    public bool isCardInSetPosition = false;

    private Collider2D setPositonCollider;

    private int myCost;

    private SetTotalCost setTotalCost;

    public void SetCardParametor(CharactorParametor parametor, int myNumber)
    {
        myCost = parametor.charactorCost;
        costText.text = "Cost:" + myCost;
        hpText.text = "Hp:" + parametor.charactorHp;
        myNumberText.text = "No." + myNumber;
    }

    public void InitSetTotalCost(SetTotalCost setTotalCost)
    {
        this.setTotalCost = setTotalCost;
    }

    public void OnMouseDrag()
    {
        Vector3 mouse = Input.mousePosition;
        mouse.z = 10f;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mouse);
        transform.position = worldPosition;

        if (setPositonCollider != null)
        {
            setPositonCollider.enabled = true;
            setPositonCollider = null;
        }
    }

    public void OnMouseUp()
    {
        Collider2D myCollider = GetComponent<Collider2D>();

        myCollider.enabled = false;

        Vector2 direction = new Vector2(0, 1);

        float maxDistance = 1f;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, maxDistance);

        Debug.DrawRay(transform.position, direction * maxDistance, Color.red, 5f);

        if (hit.collider != null && hit.collider.gameObject.tag == "SetPosition")
        {
            setPositonCollider = hit.collider;
            setPositonCollider.enabled = false;

            transform.position = hit.collider.gameObject.transform.position;

            setTotalCost.AddCost(myCost);

            isCardInSetPosition = true;
        }
        else
        {
            if (setPositonCollider != null)
            {
                setPositonCollider.enabled = true;
                setPositonCollider = null;
            }

            setTotalCost.SubtractCost(myCost);

            transform.position = startingCardPosition;
            Debug.Log(startingCardPosition);
            isCardInSetPosition = false;
        }

        myCollider.enabled = true;

    }

}
