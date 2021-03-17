﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MusicDataBase : MonoBehaviour
{
    public string Name;

    public int Bpm;

  

    public int Score_easy;
    public int Score_normal;
    public int Score_hard;
    public int Score_expart;

    public int Combo_easy;
    public int Combo_normal;
    public int Combo_hard;
    public int Combo_expart;


    public bool FC_easy;
    public bool FC_normal;
    public bool FC_hard;
    public bool FC_expart;

    public bool AJ_easy;
    public bool AJ_normal;
    public bool AJ_hard;
    public bool AJ_expart;

    public string Path;

    public string ArtistName;

    public string ScoreArtistName;

    

    public Texture2D Texture;




    [SerializeField] TextMeshProUGUI Scoretxt;

    [SerializeField] TextMeshProUGUI Combotxt;


    [SerializeField] Toggle toggle;

    [SerializeField] DifficultToggle difficultToggle;
    [SerializeField] Image MusicStats;

   public RawImage Jacket;

    [SerializeField] Text Title;
    [SerializeField] Text Artist;
    [SerializeField] Text ScoreArtist;
    [SerializeField] Text BPM;


    [SerializeField] RawImage BackGroundJacket;
    

    [SerializeField] AudioSource audioSource;

    public AudioClip Music;
 
    // Start is called before the first frame update
    void Start()
    {
        difficultToggle = GameObject.FindGameObjectWithTag("DifficultToggle").GetComponent<DifficultToggle>();

        Scoretxt = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();

        Combotxt = GameObject.FindGameObjectWithTag("Combo").GetComponent<TextMeshProUGUI>();



        MusicStats = GameObject.FindGameObjectWithTag("Stats").GetComponent<Image>();
        Jacket = GameObject.FindGameObjectWithTag("Jacket").GetComponent<RawImage>();


        Title = GameObject.FindGameObjectWithTag("Title").GetComponent<Text>();
        Artist = GameObject.FindGameObjectWithTag("Artist").GetComponent<Text>();
        ScoreArtist = GameObject.FindGameObjectWithTag("ScoreArtist").GetComponent<Text>();
        BPM = GameObject.FindGameObjectWithTag("BPM").GetComponent<Text>();

        BackGroundJacket = GameObject.FindGameObjectWithTag("BackGroundJacket").GetComponent<RawImage>();
        


        CheckScoreCombo();

        DifficultToggle_isOn();

        CheckisOn();
       

    }

    // Update is called once per frame
    void Update()
    {
        DifficultToggle_isOn();

    }

    public void CheckisOn()
    {




        if (toggle.isOn == true)
        {
            BackGroundJacket.texture = Texture;



            Jacket.texture = Texture;

            Title.text = Name;

            Artist.text = ArtistName;

            ScoreArtist.text = "ScoreArtist:" + ScoreArtistName;

            BPM.text = "BPM:" + Bpm.ToString();

        

            PlayAudio();


           
        }
        else
        {

            

            audioSource.Stop();

        }



    }


    void PlayAudio()
    {

        audioSource.clip = Music;


        audioSource.Play();
    }


    void DifficultToggle_isOn()
    {
        if (toggle.isOn == true)
        {

            switch (difficultToggle.CurrentDifficulty)
            {
                case "easy":

                    if (Score_easy != 0)
                    {


                        Scoretxt.text = Score_easy.ToString("N0");

                        Combotxt.text = Combo_easy.ToString();

                        if (FC_easy)
                        {

                            if (AJ_easy)
                            {
                                MusicStats.sprite = Resources.Load<Sprite>("MusicSelect-AllParfect");

                            }
                            else
                            {
                                MusicStats.sprite = Resources.Load<Sprite>("MusicSelect-FullCombo");
                            }

                        }
                        
                    }
                    else
                    {


                        Scoretxt.text = "-";

                        Combotxt.text = "-";
                    }
                    break;



                case "normal":

                    if (Score_normal != 0)
                    {
                        Scoretxt.text = Score_normal.ToString("N0");

                        Combotxt.text = Combo_normal.ToString();

                        if (FC_normal)
                        {

                            if (AJ_normal)
                            {
                                MusicStats.sprite = Resources.Load<Sprite>("MusicSelect-AllParfect");

                            }
                            else
                            {
                                MusicStats.sprite = Resources.Load<Sprite>("MusicSelect-FullCombo");
                            }

                        }

                    }
                    else
                    {
                        Scoretxt.text = "-";

                        Combotxt.text = "-";
                    }

                    

                    break;



                case "hard":
                    if (Score_hard != 0)
                    {
                        Scoretxt.text = Score_hard.ToString("N0");

                        Combotxt.text = Combo_hard.ToString();
                        if (FC_hard)
                        {

                            if (AJ_hard)
                            {
                                MusicStats.sprite = Resources.Load<Sprite>("MusicSelect-AllParfect");

                            }
                            else
                            {
                                MusicStats.sprite = Resources.Load<Sprite>("MusicSelect-FullCombo");
                            }

                        }
                    }
                    else
                    {
                        Scoretxt.text = "-";

                        Combotxt.text = "-";


                    }

                    break;




                case "expart":
                    if (Score_expart != 0)
                    {
                        Scoretxt.text = Score_expart.ToString("N0");

                        Combotxt.text = Combo_expart.ToString();

                        if (FC_expart)
                        {

                            if (AJ_expart)
                            {
                                MusicStats.sprite = Resources.Load<Sprite>("MusicSelect-AllParfect");

                            }
                            else
                            {
                                MusicStats.sprite = Resources.Load<Sprite>("MusicSelect-FullCombo");
                            }

                        }
                    }
                    else
                    {

                        Scoretxt.text = "-";

                        Combotxt.text = "-";

                    }
                    break;








            }



        }

    }
    void CheckScoreCombo()
    {

       Score_easy =  PlayerPrefs.GetInt(Name + "_easy_BestScore", 0);

       Score_normal = PlayerPrefs.GetInt(Name + "_normal_BestScore", 0);

       Score_hard = PlayerPrefs.GetInt(Name + "_hard_BestScore", 0);

       Score_expart = PlayerPrefs.GetInt(Name + "_expart_BestScore", 0);


       Combo_easy = PlayerPrefs.GetInt(Name + "_easy_BestCombo", 0);

       Combo_normal = PlayerPrefs.GetInt(Name + "_normal_BestCombo", 0);

       Combo_hard = PlayerPrefs.GetInt(Name + "_hard_BestCombo", 0);

       Combo_expart = PlayerPrefs.GetInt(Name + "_expart_BestCombo", 0);

       switch(PlayerPrefs.GetString("easyAllJust",null))
        {
            case "true":

                AJ_easy = true;

                break;



            case "false":

                AJ_easy = false;


                break;

        }


        switch (PlayerPrefs.GetString("normalAllJust", null))
        {
            case "true":

                AJ_normal = true;

                break;



            case "false":

                AJ_normal = false;


                break;

        }

        switch (PlayerPrefs.GetString("hardAllJust", null))
        {
            case "true":

                AJ_hard = true;

                break;



            case "false":

                AJ_hard = false;


                break;

        }
        switch (PlayerPrefs.GetString("expartAllJust", null))
        {
            case "true":

                AJ_expart = true;

                break;



            case "false":


                AJ_expart = false;

                break;

        }
        switch (PlayerPrefs.GetString("easyFullCombo", null))
        {
            case "true":

                FC_easy = true;

                break;



            case "false":


                FC_easy = false;

                break;

        }
        switch (PlayerPrefs.GetString("normalFullCombo", null))
        {
            case "true":

                FC_normal = true;

                break;



            case "false":


                FC_normal = false;

                break;

        }

        switch (PlayerPrefs.GetString("hardFullCombo", null))
        {
            case "true":

                FC_hard = true;

                break;



            case "false":


                FC_hard = false;

                break;

        }
        switch (PlayerPrefs.GetString("expartFullCombo", null))
        {
            case "true":

                FC_expart = true;

                break;



            case "false":


                FC_expart = false;

                break;

        }

    }



    
}
