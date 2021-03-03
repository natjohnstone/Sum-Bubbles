using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    public float frequency = 3.0f; // Speed of sine movement
    public float magnitude = 0.5f; //  Size of sine movement, its the amplitude of the side curve
    public float speed = 0.9f;

    Vector3 pos;
    Vector3 axis;

    private float maxY = 6.0f;

    private bool moveAllowed;
    private Collider2D col;

    [SerializeField]
    private Transform pfBubbleNumber;
    private TextMeshPro textMesh;
    private Transform number;

    private int numberint;
    
    public void Setup(int amount)
    {
        textMesh.SetText(amount.ToString());
    }

    // Start is called before the first frame update
    private void Start()
    {
        //randomise movement speed and all
        RandomiseMovement();

        // intialization for zigzag parameters
        pos = transform.position;
        axis = transform.right;
        col = transform.GetComponent<Collider2D>();

        // add number to bubble
        number = Instantiate(pfBubbleNumber, transform.position, Quaternion.identity);
        textMesh = number.GetComponent<TextMeshPro>();
        numberint = GetRandomBubbleNumber();
        if (numberint == 0)
        {
            numberint = Random.Range(1, 10);
        }

        Setup(numberint);
    }

    private int GetRandomBubbleNumber()
    {
        if (Core.difficultySetting == "MEDIUM")
        {
            return Random.Range(1, 10);
        }
        else if (Core.difficultySetting == "HARD")
        {
            return Random.Range(1, 30);
        }

        return Random.Range(-5, 10);
    }

    private void RandomiseMovement()
    {
        frequency = Random.Range(2.0f, 4.0f);
        magnitude = Random.Range(0.3f, 0.7f); 
        speed = Random.Range(1.1f, 2.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if (col == touchedCollider)
                {
                    moveAllowed = true;
                    Core.IsDraggingBubble = true;
                }
            }

            if (touch.phase == TouchPhase.Moved)
            {
                if (moveAllowed)
                {
                    number.position = new Vector2(touchPosition.x, touchPosition.y);
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);
                    pos = transform.position;
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                if (moveAllowed)
                {
                    //var middle = new Vector2(0, 0);
                    if (col == Physics2D.OverlapArea(new Vector2(1.2f, 1.2f), new Vector2(-1.2f, -1.2f)))
                    {
                        ShrinkDestroyBubbleAndChildren();
                        Core.UpdateBubbleCount(numberint);
                    }
                }
                moveAllowed = false;
                Core.IsDraggingBubble = false;
            }
        }

        pos += Vector3.up * Time.deltaTime * speed;
        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude; // y = A sin(B(x)) , here A is Amplitude, and axis * magnitude is acting as amplitude. Amplitude means the depth of the sin curve

        if (number != null)
        {
            number.position = new Vector2(transform.position.x, transform.position.y);
        }

        //destroy once off screen
        if (transform.position.y > maxY)
        {
            DestroyBubbleAndChildren();
        }

    }

    private void DestroyBubbleAndChildren()
    {
        Destroy(textMesh);
        Destroy(number.gameObject);
        Destroy(transform.gameObject);
    }


    private void ShrinkDestroyBubbleAndChildren()
    {
        LeanTween.move(transform.gameObject, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeSpring);
        LeanTween.scale(transform.gameObject, new Vector3(0f, 0f, 0), 0.2f).setOnComplete(DestroyBubbleAndChildren);
        //Destroy(textMesh);
        //Destroy(number.gameObject);
        //Destroy(transform.gameObject);
    }
}