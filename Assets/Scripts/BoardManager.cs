using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;
    [SerializeField] private Cell CellPrefab;
    [SerializeField] private Player PlayerPrefab;
    private Grid grid;
    private Player player;
    [SerializeField]
    private float moveSpeed = 2f;
    public Canvas canvas;
    public Button button;
    public Dropdown dropdown;
    public InputField input;
    public Timer other;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        button.onClick.AddListener(() =>
        {
            canvas.gameObject.SetActive(false);
            int index = dropdown.value;
            int n = int.Parse(dropdown.options[index].text);
            int integer_Value_we_Want = int.Parse(input.text); //for integer 
            Debug.Log(integer_Value_we_Want);
            grid = new Grid(n, n, 1, CellPrefab);

            player = Instantiate(PlayerPrefab, new Vector2(0, 0), Quaternion.identity);
            other.StartCoroutine("StopWatch");

        }

        );


    }

    public void CellMouseClick(int x, int y)
    {
        List<Cell> path = PathManager.Instance.FindPath(grid, (int)player.GetPosition.x, (int)player.GetPosition.y, x, y);

        player.SetPath(path);
    }

}
