using UnityEngine;
public class GameManager : MonoBehaviour
{
    public GameObject player;

    public Sprite[] foodbarSprites;
    public SpriteRenderer foodBar;

    void Update()
    {
        int stamina = (int)Mathf.Ceil(player.GetComponent<PlayerController2D>().playerStamina);
        Debug.Log("int " + stamina);
        if (stamina > 9)
        {
            stamina = 9;
        }
        foodBar.sprite = foodbarSprites[stamina - 1];
    } 
}
