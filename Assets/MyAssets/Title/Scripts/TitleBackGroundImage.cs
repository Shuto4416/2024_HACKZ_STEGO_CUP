using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class TitleBackGroundImage : MonoBehaviour
{
    public Image[] images;
    public float fadeDuration = 5;
    public float displayDuration = 5f;

    private void Start()
    {
        foreach (Image image in images)
        {
            Color color = image.color;
            color.a = 0f;
            image.color = color;
        }

        StartCoroutine(FadeImages());
    }

    private IEnumerator FadeImages()
    {
        int currentImageIndex = 0;

        while (true)
        {
            Image currentImage = images[currentImageIndex];

            yield return currentImage.DOFade(1f, fadeDuration).WaitForCompletion();

            // 一定時間表示
            yield return new WaitForSeconds(displayDuration);

            // フェードアウト
            yield return currentImage.DOFade(0f, fadeDuration).WaitForCompletion();

            // 次の画像へ
            currentImageIndex = (currentImageIndex + 1) % images.Length;
        }
    }
}
