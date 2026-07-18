using System;
using System.Collections.Generic;
using System.Text;
using WeightedAndDirectedGraph;

namespace PathfindingVisualizer
{
	public class ButtonInfo
	{
		public Button Button;
		public Color BackColor { get => Button.BackColor; set => Button.BackColor = value; }
		public Color ForeColor { get => Button.ForeColor; set => Button.ForeColor = value; }
		public string Text { get => Button.Text; set => Button.Text = value; }

		public VertexState state;
		public bool isWall;
		public int index;
		public Point location;

		public ButtonInfo(int index, Point location, Button button)
		{
			state = VertexState.Undiscovered;
			isWall = false;
			this.index = index;
			this.location = location;
			Button = button;
		}

		public ButtonInfo(VertexState state)
		{
			this.state = state;
			isWall = false;
		}
	}
}
