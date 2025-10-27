using System.CodeDom;
using System.Drawing;
using System.Net.Http.Headers;
using System.Windows.Forms.Automation;

namespace PacMan
{
    public partial class FormMain : Form
    {
        const int tileSize = 30;
        int startX = 10; int startY = 9;
        Map map;
        PacMan pacman;
        List<Enemy> enemyList;
        private System.Windows.Forms.Timer timer;
        int dots = 0;
        int score = 0;
        int lives = 3;
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

            labelGameOver.Visible = false;
            map.map[startY, startX] = ' ';
            dots++;

            Reset();

            if (timer == null)
            {
                timer = new System.Windows.Forms.Timer();
                timer.Interval = 32;
                timer.Tick += Loop;
            }
            timer.Start();
        }

        private void Loop(object sender, EventArgs e)
        {
            pacman.MoveTo(pacman.Direction, map);
            foreach (Enemy enemy in enemyList)
            {
                float dx = enemy.GetX - pacman.GetX;
                float dy = enemy.GetY - pacman.GetY;
                if (dx == 0) 
                {
                    if (dy < 0) enemy.MoveTo(DirectionType.Down, map);
                    else        enemy.MoveTo(DirectionType.Up, map);
                }
                else if (dy == 0)
                {
                    if (dx < 0) enemy.MoveTo(DirectionType.Right, map);
                    else enemy.MoveTo(DirectionType.Left, map);
                }
                else enemy.MoveTo(enemy.Direction, map);
            }
            UpdateMap();
        }

        private void Reset()
        {
            enemyList = new List<Enemy>();
            enemyList.Add(new Enemy(8 * tileSize, 3 * tileSize, 5, Color.Red, tileSize));
            enemyList.Add(new Enemy(9 * tileSize, 3 * tileSize, 3, Color.Blue, tileSize));
            enemyList.Add(new Enemy(10 * tileSize, 3 * tileSize, 3, Color.Green, tileSize));
            pacman = new(tileSize * 10, tileSize * 9, tileSize);
            toolStripStatusLabelLives.Text = "Lives: " + lives;
            Draw();
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
            if (IsCollision(enemyList, pacman))
            {
                lives--;
                Reset();
            }
            if (dots >= map.DotCount || lives < 0)
            {
                gameOver = true;
            }
            Draw();
        }

        private void Draw()
        {
            if (gameOver)
            {
                timer.Stop();
                labelGameOver.Visible = true;
            }

            Bitmap bitmap = new Bitmap(pictureBoxBoard.Width, pictureBoxBoard.Height);
            Graphics g = Graphics.FromImage(bitmap);
            map.DrawMap(g);
            pacman.Draw(g);
            DrawEnemies(enemyList, g);
            pictureBoxBoard.Image = bitmap;
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

        private bool IsCollision(List<Enemy> enemies, PacMan player)
        {
            foreach(Enemy enemy in enemies)
            {
                if (enemy == null)
                    return false;
                float dx = Math.Abs(enemy.GetX - player.GetX);
                float dy = Math.Abs(enemy.GetY - player.GetY);
                if (dx < player.GetSide && dy < player.GetSide)
                    return true;
            }
            return false;
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

