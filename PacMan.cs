namespace PacMan;

public class PacMan
{
    private readonly int tileSize;
    private const int _speed = 5;
    private const int _side = 24;
    private int _x;
    private int _y;

    public int GetX => _x;
    public int GetY => _y;
    public int GetSide => _side;

    public DirectionType Direction { get; set; }

    public PacMan(int x, int y, int mapTileSize)
    {
        _x = x;
        _y = y;
        tileSize = mapTileSize;
    }

    public void Draw(Graphics g)
    {
        Brush br = new SolidBrush(Color.Yellow);
        int startAngle, sweepAngle = 300;
        switch (Direction)
        {
            case DirectionType.Up:
                startAngle = 300;
                break;
            case DirectionType.Down:
                startAngle = 120;
                break;
            case DirectionType.Left:
                startAngle = 210;
                break;
            case DirectionType.Right:
                startAngle = 30;
                break;
            default:
                startAngle = 210;
                break;
        }
        g.FillPie(br, _x + 3, _y + 3, _side, _side, startAngle, sweepAngle);
    }

    public void MoveTo(DirectionType direction, Map map)
    {
        switch (direction)
        {
            case DirectionType.Right:
                if (!map.IsWall(_x + tileSize, _y) && !map.IsWall(_x + tileSize, _y + tileSize - 1))
                    _x += _speed;
                break;
            case DirectionType.Left:
                if (!map.IsWall(_x - _speed, _y) && !map.IsWall(_x - _speed, _y + tileSize - 1))
                    _x -= _speed;
                break;
            case DirectionType.Up:
                if (!map.IsWall(_x, _y - _speed) && !map.IsWall(_x + tileSize - 1, _y - _speed))
                    _y -= _speed;
                break;
            case DirectionType.Down:
                if (!map.IsWall(_x, _y + tileSize ) && !map.IsWall(_x + tileSize - 1, _y + tileSize))
                    _y += _speed;
                break;
        }
        Direction = direction;
    }
}
