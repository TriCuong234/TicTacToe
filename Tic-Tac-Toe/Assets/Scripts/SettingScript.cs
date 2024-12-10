using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public Slider bgmSlider;  // Slider để điều chỉnh âm lượng BGM
    public Slider sfxSlider;  // Slider để điều chỉnh âm lượng SFX

    public Button exitButton;

    public Button continueButton;

    public Button settingButton;
    void Start()
    {
        // Đặt giá trị mặc định cho Slider

        bgmSlider.value = AudioManager.Instance.bgmSource.volume;
        sfxSlider.value = AudioManager.Instance.sfxSource.volume;

        // // Gán hàm xử lý sự kiện khi giá trị Slider thay đổi
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        exitButton.onClick.AddListener(OnExitClick);
        continueButton.onClick.AddListener(OnContinueClick);
        settingButton.onClick.AddListener(OnSettingClick);

        this.gameObject.SetActive(false);
    }

    // Hàm thay đổi âm lượng của BGM
    void SetBGMVolume(float volume)
    {
        AudioManager.Instance.SetBGMVolume(volume);
        PlayerPrefs.SetFloat("BGMVolume", volume);
    }

    // Hàm thay đổi âm lượng của SFX
    void SetSFXVolume(float volume)
    {
        AudioManager.Instance.SetSFXVolume(volume);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    void OnExitClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void OnContinueClick()
    {
        this.gameObject.SetActive(false);
    }

    void OnSettingClick()
    {
        this.gameObject.SetActive(true);
    }

}
