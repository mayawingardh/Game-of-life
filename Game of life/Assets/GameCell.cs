using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameCell : ProcessingLite.GP21
{
	public float x, y;
	public float size;
	public int age;
	public bool alive = false;
	public int alpha = 255;

	public GameCell(float x, float y, float size)
	{
		this.x = x + size / 2;
		this.y = y + size / 2;
		this.size = size / 2;
	}

	public void Draw()
	{
		if (alive)
		{
			Stroke(255);
			Fill(255);
			Circle(x, y, size);
		}

		if (alive == false)
		{
			Fill(221, 160, 221, alpha);
			Stroke(221, 160, 221, alpha);
			Circle(x, y, size);

			alpha = alpha - 20;

			if (alpha == 0)
			{
				alpha += 2;
			}
		}
	}
}
