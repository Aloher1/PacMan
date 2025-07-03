using System.CodeDom;
using System.Drawing;
using System.Net.Http.Headers;

namespace PacMan
{
    public partial class FormMain : Form
    {
        const int tileSize = 30;
        int startX = 10; int startY = 9;
        Map map;
        PacMan pacman;
        List<Enemy> enemyList;
        System.Windows.Forms.Timer timer;
        int dots = 0;
        int score = 0;
        bool gameOver = false;

        public FormMain()
        {
            InitializeComponent();
            StartGame();
        }

        private void StartGame()
        {
            score = 0;
            dots = 0;
            gameOver = false;
            map = new();

            map.map[startY, startX] = ' ';
            dots++;

            pacman = new(tileSize * 10, tileSize * 9, tileSize);
            enemyList = new List<Enemy>();
            enemyList.Add(new Enemy(8 * tileSize, 3 * tileSize, 3, Color.Red, tileSize));
            Draw();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 64;
            timer.Tick += Loop;
            timer.Start();
        }

        private void Loop(object sender, EventArgs e)
        {
            pacman.MoveTo(pacman.Direction, map);
            foreach (Enemy enemy in enemyList)
            {
                enemy.MoveTo(enemy.Direction, map);
            }
            UpdateMap();
        }

        private void UpdateMap()
        {
            int i = (pacman.GetY + pacman.GetSide / 2) / tileSize;
            int j = (pacman.GetX + pacman.GetSide / 2) / tileSize;
            if (map.map[i, j] == '.')
            {
                map.map[i, j] = ' ';
                dots++;
                score += 10;
            }
            toolStripStatusLabelScore.Text = "Score: " + score;
            if (dots >= map.DotCount)
            {
                gameOver = true;
            }
            Draw();
        }

        private void Draw()
        {
            Bitmap bitmap = new Bitmap(pictureBoxBoard.Width, pictureBoxBoard.Height);
            Graphics g = Graphics.FromImage(bitmap);
            map.DrawMap(g);
            pacman.Draw(g);
            DrawEnemies(enemyList, g);
            pictureBoxBoard.Image = bitmap;
            
            if (gameOver)
            {
                timer.Stop();
                // s
            }
        }

        private void DrawEnemies(List<Enemy> enemies, Graphics g)
        {
            foreach(Enemy enemy in enemies)
            {
                if (enemy != null)
                {
                    enemy.Draw(g);
                }
            }
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (pacman == null)
            {
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.Escape:
                    StartGame(); 
                    break;
                case Keys.Down:
                    pacman.MoveTo(DirectionType.Down, map);
                    break;
                case Keys.Up:
                    pacman.MoveTo(DirectionType.Up, map);
                    break;
                case Keys.Left:
                    pacman.MoveTo(DirectionType.Left, map);
                    break;
                case Keys.Right:
                    pacman.MoveTo(DirectionType.Right, map);
                    break;
            }
            Draw();
        }
    }
}

