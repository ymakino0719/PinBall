using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //////////////////////////////////////////////////////////////////////////
    ////////////// ★あり…「課題：得点を追加しよう」の加筆部分 //////////////
    //////////////////////////////////////////////////////////////////////////

    // ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    // ゲームオーバーを表示するテキスト
    private GameObject gameoverText;

    // ★現在の合計得点（初期得点0で初期化）
    private int score = 0;

    // ★ゲーム進行中のスコアを表示するディスプレイ（※テキストコンポーネント）
    private Text scoreDisplay;

    // ★ゲームオーバー時のリザルトスコアを表示するテキスト
    private GameObject resultScoreText;

    // Start is called before the first frame update
    void Start()
    {
        // シーン中のGameOverTextを取得
        this.gameoverText = GameObject.Find("GameOverText");

        // ★シーン中のScoreDisplayのテキストコンポーネントを取得
        this.scoreDisplay = GameObject.Find("ScoreDisplay").GetComponent<Text>();

        // ★シーン中のResultScoreTextを取得
        this.resultScoreText = GameObject.Find("ResultScoreText");

        // ★ScoreDisplayに初期得点を代入
        this.scoreDisplay.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // ボールが画面外に出た場合
        if(this.transform.position.z < this.visiblePosZ)
        {
            // GameOverTextにゲームオーバーを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";

            // ★ResultScoreTextにゲームオーバー時点の点数を表示
            this.resultScoreText.GetComponent<Text>().text = "Result: " + score.ToString();
        }
    }

    // ★衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        // ★星または雲と衝突時に得点を加算
        if (other.gameObject.tag == "SmallStarTag") // ★小さな星に当たった場合：10点
        {
            this.score += 10;
        }
        else if(other.gameObject.tag == "LargeStarTag") // ★大きな星に当たった場合：50点
        {
            this.score += 50;
        }
        else if (other.gameObject.tag == "SmallCloudTag") // ★小さな雲に当たった場合：20点
        {
            this.score += 20;
        }
        else if (other.gameObject.tag == "LargeCloudTag") // ★大きな雲に当たった場合：100点
        {
            this.score += 100;
        }

        // ★点数が10000点を超過したとき
        if (this.score >= 10000)
        {
            score = 9999;
        }

        // ★ScoreDisplayに初期得点を代入
        this.scoreDisplay.text = score.ToString();
    }
}
