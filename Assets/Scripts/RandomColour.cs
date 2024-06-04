using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RandomColour : MonoBehaviour
{
    private MaterialPropertyBlock propertyBlock;
    private Renderer rendered;
    
    void Start()
    {
        rendered = GetComponent<Renderer>();
        propertyBlock = new MaterialPropertyBlock();
        PickRandom();
    }

    public void PickRandom()
    {
        Color randomColour = Random.ColorHSV();
        propertyBlock.SetColor("_Color", randomColour);
        rendered.SetPropertyBlock(propertyBlock);
    }

    public void PickBlack()
    {
        Color randomColour = Color.black;
        //"_Colour" is albedo behind the scene's, propertyblock is the 
        propertyBlock.SetColor("_Color", randomColour);
        rendered.SetPropertyBlock(propertyBlock);
    }

    private float H = 0;
    public void SlideColour()
    {
        H += 0.1f * Time.deltaTime;
        if(H >= 1)
        {
            H = 0;
        }
        Color newColor = Color.HSVToRGB(H, 1, 1);
        propertyBlock.SetColor("_Color", newColor);
        rendered.SetPropertyBlock(propertyBlock);
    }

}
