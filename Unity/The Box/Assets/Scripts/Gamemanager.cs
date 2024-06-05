using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    //壁　定義
    public const int WALL_FRONT = 1;
    public const int WALL_RIGHT = 2;
    public const int WALL_BACK = 3;
    public const int WALL_LEFT = 4;

    //ボタン色　定義
    public const int COLOR_GREEN = 0;
    public const int COLOR_RED = 1;
    public const int COLOR_BLUE = 2;
    public const int COLOR_WHITE = 3;



    public GameObject paneWalls; //壁

    public GameObject buttonHummer;
    public GameObject buttonKey;

    public GameObject imageHummerIcon;
    public GameObject imageKeyIcon;

    public GameObject buttonPig;

    public GameObject buttonMessage;
    public GameObject buttonMessageText;

    public GameObject[] buttonLamp = new GameObject[3];
    public Sprite[] buttonPicture = new Sprite[4];
    public Sprite hummerPicture;
    public Sprite keyPicture;

    private int wallNo;
    private bool doesHaveHummer;
    private bool doesHaveKey;
    private int[] buttonColor = new int[3];

    // Start is called before the first frame update
    void Start(){
        wallNo = WALL_FRONT;
        doesHaveHummer = false;
        doesHaveKey = false;


        buttonColor[0] = COLOR_GREEN;
        buttonColor[1] = COLOR_RED;
        buttonColor[2] = COLOR_BLUE;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //ボックスをタップ
    public void PushButtonBox(){
        if (doesHaveKey == false)
        {
            DisplayMessage("鍵がかかっている");
        }
        else {
            SceneManager.LoadScene("ClearScene");
        }
    }

    public void PushButtonLamp1() {
        ChangeButtonColor(0);
    }

    public void PushButtonLamp2(){
        ChangeButtonColor(1);
    }

    public void PushButtonLamp3(){
        ChangeButtonColor(2);
    }

    void ChangeButtonColor(int buttonNo) {
        buttonColor[buttonNo]++;
        //白→緑
        if (buttonColor[buttonNo] > COLOR_WHITE) {
            buttonColor[buttonNo] = COLOR_GREEN;
        }
        buttonLamp[buttonNo].GetComponent<Image>().sprite = buttonPicture[buttonColor[buttonNo]];

        //色チェック
        if((buttonColor[0] ==COLOR_BLUE) && (buttonColor[1] == COLOR_WHITE) && (buttonColor[2] == COLOR_RED))
        {
            //トンカチ有無
            if (doesHaveHummer == false) {
                DisplayMessage("トンカチ");
                buttonHummer.SetActive(true);
                imageHummerIcon.GetComponent<Image>().sprite = hummerPicture;
                doesHaveHummer = true;
            }
        }
    }

    //メモをタップ
    public void PushButtonMemo(){
        DisplayMessage("エッフェル塔");
    }

    //貯金箱をタップ
    public void PushButtonPig()
    {
        //トンカチの有無
        if (doesHaveHummer == false){
            DisplayMessage("素手では破らない");
        }else {
            DisplayMessage("鍵");
        }
        buttonPig.SetActive(false);
        buttonKey.SetActive(true);
        imageKeyIcon.GetComponent<Image>().sprite = keyPicture;
        doesHaveKey = true;
    }

    //トンカチをタップ
    public void PushButtonHammer() {
        buttonHummer.SetActive(false);
    }

    //鍵をタップ
    public void PushButtonKey() {
        buttonKey.SetActive(false);
    }

    //メッセージをタップ
    public void PushButtonMessage()
    {
        buttonMessage.SetActive(false);
    }

    //メッセージ表示
    void DisplayMessage(string mess)
    {
        buttonMessage.SetActive(true);
        buttonMessageText.GetComponent<Text>().text = mess;
    }

    //右ボタン
    public void PushButtonRoight()
    {
        wallNo++;
        if (wallNo > WALL_LEFT)
        {
            wallNo = WALL_FRONT;
        }
        DisplayWall();
        ClearButtons();
    }

    //左ボタン
    public void PushButtonLeft()
    {
        wallNo--;
        if (wallNo < WALL_FRONT)
        {
            wallNo = WALL_LEFT;
        }
        DisplayWall();
        ClearButtons();
    }

    //消す
    void ClearButtons() {
        buttonHummer.SetActive(false);
        buttonKey.SetActive(false);
        buttonMessage.SetActive(false);
    }

    //壁表示
    void DisplayWall()
    {
        switch (wallNo)
        {
            case WALL_FRONT:
                paneWalls.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                break;
            case WALL_RIGHT:
                paneWalls.transform.localPosition = new Vector3(-1000.0f, 0.0f, 0.0f);
                break;
            case WALL_BACK:
                paneWalls.transform.localPosition = new Vector3(-2000.0f, 0.0f, 0.0f);
                break;
            case WALL_LEFT:
                paneWalls.transform.localPosition = new Vector3(-3000.0f, 0.0f, 0.0f);
                break;
        }
    }
}
