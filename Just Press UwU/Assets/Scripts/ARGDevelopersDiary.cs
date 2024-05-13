using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ARGDevelopersDiary : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    [SerializeField] private GameObject _omega;
    [SerializeField] private AudioSource _fxAS1;
    [SerializeField] private AudioSource _fxAS2;

    [Space]
    [SerializeField] private Sprite[] _photosFromTheDiary;
    [SerializeField] private Image _photosImage;

    private int _selectedImage = 0;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(600f);
        _omega.SetActive(false);
        _canvas.SetActive(true);
        _fxAS1.Stop();
        _fxAS2.Play();
    }

    public void OnLeftButtonDown()
    {
        _selectedImage--;
        if (_selectedImage <= 0)
        {
            _selectedImage = _photosFromTheDiary.Length - 1;
        }

        _photosImage.sprite = _photosFromTheDiary[_selectedImage];
        _photosImage.SetNativeSize();
    }
    public void OnRightButtonDown()
    {
        _selectedImage++;
        if (_selectedImage >= _photosFromTheDiary.Length)
        {
            _selectedImage = 0;
        }

        _photosImage.sprite = _photosFromTheDiary[_selectedImage];
        _photosImage.SetNativeSize();
    }
}
