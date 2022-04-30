using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;
    [SerializeField] private Cell CellPrefab;
    [SerializeField] private Cell CellPrefab2;
    [SerializeField] private Player PlayerPrefab;
    [SerializeField] private Enemy EnemigoPrefab;
    [SerializeField] private Cell salida;
    private Grid grid;
    private Player player;
    private Enemy monstruo, monstruo2, monstruo3, monstruo4;
    [SerializeField]
    private float moveSpeed = 2f;
    public Canvas canvas;
    public Button button;
    public Dropdown dropdown;
    public InputField input;
    public Timer other;
    public Text nivel,gameover;
    public int integer_Value_we_Want;
    public float P = 25;
    public GameObject gameOverText, restartButton;
    private int level = 1;





    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameOverText.SetActive(false);
        restartButton.SetActive(false);
        
        
        
        button.onClick.AddListener(() =>
        {
            canvas.gameObject.SetActive(false);
            int index = dropdown.value;
            int n = int.Parse(dropdown.options[index].text);
            P = P * ((n / 10));
            integer_Value_we_Want = int.Parse(input.text); //for integer 
            Debug.Log(integer_Value_we_Want);
            grid = new Grid(n, n, 1, CellPrefab, CellPrefab2);

            player = Instantiate(PlayerPrefab, new Vector2(0, 0), Quaternion.identity);


            other.StartCoroutine("StopWatch");

        }

        );


    }
    public void resetPos()
    {
        
        if (level == 1)
        {
            player = Instantiate(PlayerPrefab, new Vector2(0, 0), Quaternion.identity);
            createEnemy(0, 6);

        }
        else if (level == 2)
        {
            player = Instantiate(PlayerPrefab, new Vector2(0, 0), Quaternion.identity);
            createEnemy(4, 8);
        }
        else if (level == 3)
        {
            player = Instantiate(PlayerPrefab, new Vector2(0, 0), Quaternion.identity);
            createEnemy(10, 2);
        }
        else if (level == 4)
        {
            other.StartCoroutine("StopWatchStop");
        }


    }

    public void createEnemy(int posx, int posy)
    {
        monstruo = Instantiate(EnemigoPrefab, new Vector2(posx, posy), Quaternion.identity);
        //monstruo2.Instance.Update();
    }
    public void CellMouseClick(int x, int y)
    {
        List<Cell> path = PathManager.Instance.FindPath(grid, (int)player.GetPosition.x, (int)player.GetPosition.y, x, y);

        player.SetPath(path);
    }
    public int GetM()
    {
        return integer_Value_we_Want;
    }
    public float GetP()
    {
        return P;
    }
    public void updateLvl()
    {

        if (level < 4)
        {
            level++;
            nivel.text = "Nivel " + level;
        }
        else
        {
            gameover.text = "GANASTE!";
            gameOverText.SetActive(true);
        }
        
    }
    public void gameOver()
    {
        gameOverText.SetActive(true);
        restartButton.SetActive(true);
    }
}
