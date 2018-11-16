using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviour {

    [SerializeField] private Player player;
    [SerializeField] private Dealer dealer;

    [SerializeField] private Button hitButton;
    [SerializeField] private Button standButton;
    [SerializeField] private Image maskImage;
    [SerializeField] private Text playerPointText;

    [SerializeField] private Card cardPrefab;

    private Deck deck;

    private void Awake() {
        deck = new Deck();
    }

    // Use this for initialization
    void Start () {
        hitButton.onClick.AddListener(PlayerDraw);
        standButton.onClick.AddListener(Duel);

        deck.Initialize();

        PlayerDraw();
        PlayerDraw();
        DelearDraw();
        DelearDraw(true);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene("Game");
        }
    }

    void PlayerDraw() {
        player.Draw(cardPrefab, deck);
        playerPointText.text = player.point.ToString();

        if (player.isBust) {
            GameOver();
        }
    }

    void DelearDraw(bool isReverse = false) {
        if (isReverse) {
            dealer.DrawReverse(cardPrefab, deck);
        } else {
            dealer.Draw(cardPrefab, deck);
        }
    }

    void Duel() {
        dealer.reverseCard.Reverse();
        while (dealer.point < Config.DEALER_DRAW_THRESHOLD) {
            dealer.Draw(cardPrefab, deck);
        }

        if (dealer.isBust) {
            Debug.Log("<color=red>Win!</color>");
        } else if (player.point > dealer.point) {
            Debug.Log("<color=red>Win!</color>");
        } else if (player.point < dealer.point) {
            Debug.Log("<color=blue>Lose...</color>");
        } else {
            Debug.Log("Draw");
        }

        Debug.Log("PlayerPoint: " + player.point.ToString());
        Debug.Log("DealerPoint: " + dealer.point.ToString());
    }

    void GameOver() {
        Debug.Log("GameOver");

        maskImage.gameObject.SetActive(true);
    }
}
