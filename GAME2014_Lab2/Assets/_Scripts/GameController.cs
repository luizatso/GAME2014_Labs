using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] TMP_Text scoreLabel;
    [SerializeField] TMP_Text livesLabel;
    [SerializeField] TMP_Text screenLabel;

    private float scoreLabelHalfHeight;
    private float scoreLabelHalfWidth;
    private float livesLabelHalfHeight;
    private float livesLabelHalfWidth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreLabelHalfHeight = scoreLabel.rectTransform.rect.height * 0.5f;
        scoreLabelHalfWidth = scoreLabel.rectTransform.rect.width * 0.5f;

        livesLabelHalfHeight = livesLabel.rectTransform.rect.height * 0.5f;
        livesLabelHalfWidth = livesLabel.rectTransform.rect.width * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        scoreLabel.rectTransform.position = new Vector2(
            Screen.safeArea.xMax - scoreLabelHalfWidth,
            Screen.safeArea.yMax - scoreLabelHalfHeight);

        livesLabel.rectTransform.position = new Vector2(
            Screen.safeArea.xMin + livesLabelHalfWidth,
            Screen.safeArea.yMax - livesLabelHalfHeight);

        switch (Screen.orientation)
        {
            case ScreenOrientation.LandscapeLeft:
                screenLabel.text = "LandscapeLeft";
                break;

            case ScreenOrientation.LandscapeRight:
                screenLabel.text = "LandscapeRight";
                break;

            case ScreenOrientation.Portrait:
                screenLabel.text = "Portrait";
                break;

            case ScreenOrientation.PortraitUpsideDown:
                screenLabel.text = "PortraitUpsideDown";
                break;

            default:
                screenLabel.text = "Unknown";
                break;
        }
    }
}
