using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Pertanyaan : MonoBehaviour
{
    public static event System.Action<DataDikirim> AnswerChosen;
    private string _jawaban;
    private int indexPertanyaan;
    [SerializeField] private TextMeshProUGUI kontenJawaban;
    private QuestionData _CurrentQuestionData;
    private bool _nilaiBenar;
    
    public class DataDikirim
    {
        public string pesan;
        public bool jawabanBenar;
        public QuestionData _QuestionDataReference;
    }
    public void TekanTombol()
    {
        string nilaiJawaban = _nilaiBenar ? "benar" : "salah";
        string pesan = "Jawaban Anda adalah " + _jawaban + " \njawaban ini " + nilaiJawaban;
        if (_nilaiBenar)
        {
            Audio_Manager.instance.TriggerSFX(1);
        }
        else
        {
            Audio_Manager.instance.TriggerSFX(2);
        }
        AnswerChosen?.Invoke(new DataDikirim
        {
            pesan = pesan,
            jawabanBenar = _nilaiBenar,
            _QuestionDataReference = _CurrentQuestionData
        });
        /*
            Pesan_UI.instance.TampilPesan(pesan);
            if(nilaiBenar)
            {
                Pesan_UI.instance.Benar();
                Debug.Log("Jawaban Benar!");
            }
            else
            {
                Pesan_UI.instance.Salah();
                Debug.Log("Jawaban Salah!");
            }
        */
    }
    public void SetNilai(string jawaban, bool opsiBenar)
    {
        _jawaban = jawaban;
        kontenJawaban.text = jawaban;
        _nilaiBenar = opsiBenar;
    }
    public void SetJawaban(QuestionData questionData)
    {
        _CurrentQuestionData = questionData;
    }
}
