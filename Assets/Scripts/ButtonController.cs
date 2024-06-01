using TMPro;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextRAM;
    [SerializeField] private TextMeshProUGUI TextCPU;
    [SerializeField] private TextMeshProUGUI TextSSD;
    [SerializeField] private GameObject TaskPaintImage;
    [SerializeField] private GameObject TaskWordImage;

    private bool _isClickedWord = false;
    private bool _isClickedPaint = false;

    private const int WordRAMIncrease = 15;
    private const int WordCPUIncrease = 12;
    private const int WordSSDIncrease = 25;

    private const int PaintRAMIncrease = 7;
    private const int PaintCPUIncrease = 15;
    private const int PaintSSDIncrease = 44;

    public void PressButtonWord()
    {
        _isClickedWord = !_isClickedWord;
        this.UpdateValues(WordRAMIncrease * (_isClickedWord ? 1 : -1),
                     WordCPUIncrease * (_isClickedWord ? 1 : -1),
                     WordSSDIncrease * (_isClickedWord ? 1 : -1));
        this.ToggleTaskImage(TaskWordImage, _isClickedWord);
    }

    public void PressButtonPaint()
    {
        _isClickedPaint = !_isClickedPaint;
        this.UpdateValues(PaintRAMIncrease * (_isClickedPaint ? 1 : -1),
                     PaintCPUIncrease * (_isClickedPaint ? 1 : -1),
                     PaintSSDIncrease * (_isClickedPaint ? 1 : -1));
        this.ToggleTaskImage(TaskPaintImage, _isClickedPaint);
    }

    private void ToggleTaskImage(GameObject taskImage, bool display)
    {
        taskImage.SetActive(display);
    }

    private void UpdateValues(int ramChange, int cpuChange, int ssdChange)
    {
        int currentRAM = int.Parse(TextRAM.text.Replace("%", ""));
        int currentCPU = int.Parse(TextCPU.text.Replace("%", ""));
        int currentSSD = int.Parse(TextSSD.text.Replace("%", ""));

        TextRAM.text = (currentRAM + ramChange).ToString() + "%";
        TextCPU.text = (currentCPU + cpuChange).ToString() + "%";
        TextSSD.text = (currentSSD + ssdChange).ToString() + "%";
    }
}
