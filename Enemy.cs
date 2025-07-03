namespace PacMan;

public class Enemy
{
    private readonly int tileSize;
    private readonly int _speed;
    private const int _side = 24;
    private int _x;
    private int _y;
    private Color _color;

    public int GetX => _x;
    public int GetY => _y;
    public int GetSide => _side;

    public DirectionType Direction { get; set; }

    public Enemy(int x, int y, int speed, Color color, int mapTileSize)
    {
        _x = x;
        _y = y;
        _speed = speed;
        _color = color;
        tileSize = mapTileSize;
        Direction = DirectionType.None;
    }

    public void Draw(Graphics g)
    {
        Brush br = new SolidBrush(_color);
        Brush brWhite = new SolidBrush(Color.White);
        Brush brBlack = new SolidBrush(Color.Black);
        int eyeChangeX = 0, eyeChangeY = 0;
        switch (Direction)
        {
            case DirectionType.Up:
                eyeChangeX = 0;
                eyeChangeY = -2;
                break;
            case DirectionType.Down:
                eyeChangeX = 0;
                eyeChangeY = 2;
                break;
            case DirectionType.Left:
                eyeChangeX = -2;
                eyeChangeY = 0;
                break;
            case DirectionType.Right:
                eyeChangeX = 2;
                eyeChangeY = 0;
                break;
            default:
                eyeChangeX = 0;
                eyeChangeY = 0;
                break;
        }
        g.FillRectangle(br, _x + 5, _y + 3, _side - 5, _side);
        g.FillEllipse(brWhite, _x + 9, _y + 4, 11, 11);
        g.FillEllipse(brBlack, _x + 12 + eyeChangeX, _y + 7 + eyeChangeY, 5, 5);
    }

    public void MoveTo(DirectionType direction, Map map)
    {
        switch (direction)
        {
            case DirectionType.Right:
                if (!map.IsWall(_x + tileSize, _y) && !map.IsWall(_x + tileSize, _y + tileSize - 1))
                {
                    _x += _speed;
                    break;
                }
                direction = DirectionType.None;
                break;
            case DirectionType.Left:
                if (!map.IsWall(_x - _speed, _y) && !map.IsWall(_x - _speed, _y + tileSize - 1))
                {
                    _x -= _speed;
                    break;
                }
                direction = DirectionType.None;
                break;
            case DirectionType.Up:
                if (!map.IsWall(_x, _y - _speed) && !map.IsWall(_x + tileSize - 1, _y - _speed))
                {
                    _y -= _speed;
                    break;
                }
                direction = DirectionType.None;
                break;
            case DirectionType.Down:
                if (!map.IsWall(_x, _y + tileSize) && !map.IsWall(_x + tileSize - 1, _y + tileSize))
                {
                    _y += _speed;
                    break;
                }
                direction = DirectionType.None;
                break;
            case DirectionType.None:
                Random random = new Random();
                direction = (DirectionType)random.Next(0, 4);
                break;
        }
        Direction = direction;
    }
}
