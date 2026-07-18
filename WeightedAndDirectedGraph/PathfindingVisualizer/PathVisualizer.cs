using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms.VisualStyles;
using WeightedAndDirectedGraph;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PathfindingVisualizer
{
    public partial class Visualizer : Form
    {
        public enum Pathfinder
        {
            None,
            AStar,
            Dijkstra,
            BFS,
            DFS
        }

        public Visualizer()
        {
            InitializeComponent();
        }

        List<Dictionary<Vertex<Point>, VertexState>> cool;
        List<Point> path;
        Graph<Point> graph = new();
        Vertex<Point> start = new(new(-1, 0));
        Vertex<Point> end = new(new(-1, 0));
        int gridSizeX = 0;
        int gridSizeY = 0;
        ButtonInfo[,] buttons = new ButtonInfo[10, 10];
        public bool selectingStart;
        public bool selectingEnd;
        public bool isGenerated = false;
        public bool isRunning = false;
        Pathfinder pathfinder = Pathfinder.None;


        private void Visualizer_Load(object sender, EventArgs e)
        {
        }

        private void ResetButton(ButtonInfo button)
        {
            Vertex<Point>[] vs = graph.Vertices.ToArray();
            button.isWall = false;
            button.state = VertexState.Undiscovered;
            button.BackColor = Color.White;
            button.ForeColor = Color.Black;
            button.Text = "Not a wall";
        }
        private void Wallify(ButtonInfo button)
        {
            if (button.state == VertexState.Start || button.state == VertexState.End) return;

            if (button.isWall)
            {
                ResetButton(button);
                return;
            }

            button.Text = "Wall";
            button.isWall = true;
            button.BackColor = Color.DarkGray;
            button.ForeColor = Color.Yellow;
        }

        private bool StartAndEndSelection(ButtonInfo button)
        {
            if (!(selectingStart | selectingEnd)) return false;
            Vertex<Point>[] vs = graph.Vertices.ToArray();

            button.isWall = false;
            button.ForeColor = Color.Black;

            if (selectingStart)
            {
                if (start.Value.X != -1)
                {
                    ResetButton(buttons[start.Value.X, start.Value.Y]);
                }
                button.state = VertexState.Start;
                button.BackColor = Color.Green;
                button.Text = "Start";
                selectingStart = false;
                start = vs[button.index];
                return true;
            }
            if (end.Value.X != -1)
            {
                ResetButton(buttons[end.Value.X, end.Value.Y]);
            }
            button.state = VertexState.End;
            button.BackColor = Color.Red;
            button.Text = "End";
            selectingEnd = false;
            end = vs[button.index];
            return true;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (isRunning) return;
            Button button = sender as Button;
            Point coords = (Point)button.Tag;
            if (StartAndEndSelection(buttons[coords.X, coords.Y])) return;

            Wallify(buttons[coords.X, coords.Y]);
        }

        public static float Manhattan(Vertex<Point> vertex, Vertex<Point> goal)
        {
            int dx = Math.Abs(vertex.Value.X - goal.Value.X);

            int dy = Math.Abs(vertex.Value.Y - goal.Value.Y);

            return dx + dy;
        }

        public static float Diagonal(Vertex<Point> vertex, Vertex<Point> goal)
        {
            int dx = Math.Abs(vertex.Value.X - goal.Value.X);
            int dy = Math.Abs(vertex.Value.Y - goal.Value.Y);
            return (dx + dy) + (1.41f - 2) * Math.Min(dx, dy);
        }

        private void IndividualGraphUpdate(ButtonInfo button)
        {
            int x = button.location.X;
            int y = button.location.Y;

            switch (button.state)
            {
                case VertexState.Frontier:
                    buttons[x, y].BackColor = Color.LightCyan;
                    buttons[x, y].Text = "Frontier";
                    break;

                case VertexState.Visited:
                    buttons[x, y].BackColor = Color.Turquoise;
                    buttons[x, y].Text = "Visited";
                    break;

                case VertexState.Path:
                    buttons[x, y].BackColor = Color.CornflowerBlue;
                    buttons[x, y].ForeColor = Color.White;
                    buttons[x, y].Text = "Path";
                    break;
            }
        }
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isRunning) return;
            if (start.Value.X == -1 || end.Value.X == -1) return;

            isRunning = true;
            Vertex<Point>[] vs = graph.Vertices.ToArray();

            int X = buttons.GetLength(0);
            int Y = buttons.GetLength(1);

            for (int y = 0; y < Y; y++)
            {
                for (int x = 0; x < X; x++)
                {
                    int index = (y * X) + x;

                    Vertex<Point> vertex = vs[index];

                    if (buttons[x, y].isWall) continue;

                    if (x != (X - 1) && !buttons[x + 1, y].isWall) { graph.AddEdge(vertex, vs[index + 1], 1); }
                    if (y != (Y - 1) && !buttons[x, y + 1].isWall) { graph.AddEdge(vertex, vs[index + X], 1); }
                    if (x != 0 && !buttons[x - 1, y].isWall) { graph.AddEdge(vertex, vs[index - 1], 1); }
                    if (y != 0 && !buttons[x, y - 1].isWall) { graph.AddEdge(vertex, vs[index - X], 1); }

                    if (x != 0 && y != (Y - 1) && !buttons[x - 1, y + 1].isWall) { graph.AddEdge(vertex, vs[index + (X - 1)], 1.41f); }
                    if (x != (X - 1) && y != (Y - 1) && !buttons[x + 1, y + 1].isWall) { graph.AddEdge(vertex, vs[index + (X + 1)], 1.41f); }
                    if (x != (X - 1) && y != 0 && !buttons[x + 1, y - 1].isWall) { graph.AddEdge(vertex, vs[index - (X - 1)], 1.41f); }
                    if (y != 0 && x != 0 && !buttons[x - 1, y - 1].isWall) { graph.AddEdge(vertex, vs[index - (X + 1)], 1.41f); }
                }
            }

            (cool, path) = graph.AStar(start, end, Manhattan);

            timer.Enabled = true;
        }
        private void selectStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isRunning) return;
            if (!isGenerated) return;

            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;

            selectingStart = true;
        }
        private void selectEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isRunning) return;
            if (!isGenerated) return;

            ToolStripMenuItem button = sender as ToolStripMenuItem;

            selectingEnd = true;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (cool.Count == 0)
            {
                foreach (Point point in path)
                {
                    VertexState state = buttons[point.X, point.Y].state;
                    if (state == VertexState.Start || state == VertexState.End) continue;

                    buttons[point.X, point.Y].state = VertexState.Path;
                    IndividualGraphUpdate(buttons[point.X, point.Y]);
                }

                timer.Enabled = false;
                return;
            }

            Dictionary<Vertex<Point>, VertexState> current = cool[0];

            foreach (Vertex<Point> vertex in current.Keys)
            {
                ButtonInfo button = buttons[vertex.Value.X, vertex.Value.Y];

                if (button.state == VertexState.Start || button.state == VertexState.End || button.state == VertexState.Visited) continue;

                button.state = current[vertex];

                IndividualGraphUpdate(button);
            }

            cool.Remove(current);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!int.TryParse(textBox.Text, out gridSizeX)) gridSizeX = 10;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!int.TryParse(textBox.Text, out gridSizeY)) gridSizeY = 10;
        }
        private void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isGenerated) return;
            buttons = new ButtonInfo[gridSizeX, gridSizeY];
            panel1.Hide();
            isGenerated = true;

            for (int y = 0; y < gridSizeY; y++)
            {
                for (int x = 0; x < gridSizeX; x++)
                {
                    grid.Width = (gridSizeX * 50) + 8;
                    grid.Height = (gridSizeY * 50) + 8;

                    ButtonInfo button = new ButtonInfo(y * gridSizeX + x, new Point(x, y), new Button()
                    {
                        Location = new Point(4 + x * 50, 4 + y * 50),
                        Size = new Size(46, 46),
                        Text = "Not a Wall",
                        BackColor = Color.White,
                        ForeColor = Color.Black,
                        Tag = new Point(x, y)
                    });

                    buttons[x, y] = button;
                    graph.AddVertex(new Vertex<Point>(new Point(x, y)));
                    button.Button.Click += Button_Click;
                    grid.Controls.Add(button.Button);
                }
            }

            Width = grid.Width + 16;
            Height = grid.Height + 111;
        }
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox comboBox = sender as ToolStripComboBox;

            pathfinder = (Pathfinder)comboBox.SelectedIndex;
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value == 0)
            {
                timer.Enabled = false;
                return;
            }

            timer.Interval = 500 / (trackBar1.Value + 1);
        }
        private void Visualizer_Resize(object sender, EventArgs e)
        {
            trackBar1.Location = new Point((Width / 2) - (trackBar1.Width / 2), Height - (2 * trackBar1.Height));
        }
    }
}
