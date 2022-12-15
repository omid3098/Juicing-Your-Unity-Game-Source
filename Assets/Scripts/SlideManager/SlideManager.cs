using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideManager : MonoBehaviour
{
    // This class handled the slides in the presentation
    // It is attached to the SlideManager game object in the scene
    // All slides are children of the SlideManager game object and first slide is active at start
    // Slides are stored in a list and the index of the current slide is stored in the currentSlideIndex variable
    // there are show and hide methods that are called with slide instace and we can have tweening
    // or other animations in the show and hide methods
    // pressing left and right arrow keys will show the next and previous slides and hide the current slide
    // pressing the space bar will show the next slide and hide the current slide
    // pressing the backspace key will show the previous slide and hide the current slide
    // pressing the escape key will exit the application
    // showing and hiding slides have callbacks that are called when the animation is complete


    List<(KeyCode key, int slideIndex)> keyCodes = new List<(KeyCode, int)>()
    {
        (KeyCode.Alpha1, 0),
        (KeyCode.Alpha2, 1),
        (KeyCode.Alpha3, 2),
        (KeyCode.Alpha4, 3),
        (KeyCode.Alpha5, 4),
        (KeyCode.Alpha6, 5),
        (KeyCode.Alpha7, 6),
        (KeyCode.Alpha8, 7),
        (KeyCode.Alpha9, 8),
    };

    private List<Slide> slides;
    private int currentSlideIndex;

    private void Awake()
    {
        slides = new List<Slide>();
        // add all slides even if they are not active
        var _slides = gameObject.GetComponentsInChildren<Slide>(true);
        foreach (var slide in _slides)
        {
            slides.Add(slide);
        }
        currentSlideIndex = 0;

        // Hide all other slides
        foreach (var _slide in _slides)
        {
            _slide.gameObject.SetActive(false);
        }

        // show first slide
        slides[currentSlideIndex].Show(
            () => Debug.Log("Show complete " + slides[currentSlideIndex].name)
        );
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Backspace))
        {
            // Hide current slide and show previous slide when hide is complete
            Debug.Log("Trying to hide " + slides[currentSlideIndex].name);
            slides[currentSlideIndex].Hide(() =>
            {
                Debug.Log("Hide complete " + slides[currentSlideIndex].name);
                currentSlideIndex--;
                if (currentSlideIndex < 0) currentSlideIndex = slides.Count - 1;
                slides[currentSlideIndex].Show(
                    () => Debug.Log("Show complete " + slides[currentSlideIndex].name)
                );
            });
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            // Hide current slide and show next slide when hide is complete
            Debug.Log("Trying to hide " + slides[currentSlideIndex].name);
            slides[currentSlideIndex].Hide(() =>
            {
                Debug.Log("Hide complete " + slides[currentSlideIndex].name);
                currentSlideIndex++;
                if (currentSlideIndex >= slides.Count) currentSlideIndex = 0;
                slides[currentSlideIndex].Show(
                    () => Debug.Log("Show complete " + slides[currentSlideIndex].name)
                );
            });
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Exit application
            Application.Quit();
        }

        // and if we press numbers 1, 2, 3, 4, 5, 6, 7, 8, 9 we can go to the slide with that number
        // for example if we press 1 we go to the first slide
        // this methog is very efficient and we can have 9 slides in the presentation
        foreach (var keyCode in keyCodes)
        {
            if (Input.GetKeyDown(keyCode.key))
            {
                // Hide current slide and show next slide when hide is complete
                Debug.Log("Trying to hide " + slides[currentSlideIndex].name);
                slides[currentSlideIndex].Hide(() =>
                {
                    Debug.Log("Hide complete " + slides[currentSlideIndex].name);
                    currentSlideIndex = keyCode.slideIndex;
                    slides[currentSlideIndex].Show(
                        () => Debug.Log("Show complete " + slides[currentSlideIndex].name)
                    );
                });
            }
        }
    }
}
