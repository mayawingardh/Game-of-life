using UnityEngine;

public class GameOfLife : ProcessingLite.GP21
{
	GameCell[,] cells;
	public int[,] nextGeneration;

	float cellSize = 0.25f;
	int numberOfColums;
	int numberOfRows;
	int spawnChancePercentage = 30;

	void Start()
	{
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 10;

		numberOfColums = (int)Mathf.Floor(Width / cellSize);
		numberOfRows = (int)Mathf.Floor(Height / cellSize);

		cells = new GameCell[numberOfColums, numberOfRows];
		nextGeneration = new int[numberOfColums, numberOfRows];

		//create the first gen. gamecells.
		for (int y = 0; y < numberOfRows; ++y)
		{
			for (int x = 0; x < numberOfColums; ++x)
			{
				cells[x, y] = new GameCell(x * cellSize, y * cellSize, cellSize);

				if (Random.Range(0, 100) < spawnChancePercentage)
				{
					cells[x, y].alive = true;
				}
			}
		}
	}
	void Update()
	{
		Background(255, 192, 203);
		CalculateNextGeneration();
		ApplayRules();

		for (int y = 1; y < numberOfRows - 1; y++)
		{
			for (int x = 1; x < numberOfColums - 1; x++)
			{
				cells[x, y].Draw();
			}
		}
	}
	public void CalculateNextGeneration()

	{
		// 1, -1 to stay inside the grid.
		for (int y = 1; y < numberOfRows - 1; ++y)
		{
			for (int x = 1; x < numberOfColums - 1; ++x)
			{
				nextGeneration[x, y] = checkNeighbour(x, y);
			}
		}
	}

	public int checkNeighbour(int cellX, int cellY)
	{
		int neighbour = 0;
		int lenght = 2;

		for (int y = -1; y < lenght; y++)
		{
			for (int x = -1; x < lenght; x++)
			{
				if (x == 0 && y == 0)
				{
					continue;
				}

				if (cells[x + cellX, y + cellY].alive)
				{
					neighbour++;
				}
			}
		}

		return neighbour;
	}

	public void ApplayRules()

	{
		for (int y = 0; y < numberOfRows; y++)
		{
			for (int x = 0; x < numberOfColums; x++)
			{
				if (cells[x, y].alive == true && (nextGeneration[x, y] == 2 || nextGeneration[x, y] == 3))
				{
					cells[x, y].alive = true;
				}

				else if (cells[x, y].alive == false && nextGeneration[x, y] == 3)
				{
					cells[x, y].alive = true;
				}

				else
				{
					cells[x, y].alive = false;
				}
			}
		}
	}
}

