using System.Runtime.InteropServices;

namespace SnakeAndFoodGame;

public class Snake
{
    private LinkedList<Point> Body;

    public Snake(Point startingPosition)
    {
        Body = new LinkedList<Point>();
        Body.AddFirst(startingPosition);
    }

    public void Move(Point newHeadPosition, bool grow = false)
    {
        Body.AddFirst(newHeadPosition);

        if (!grow)
        {
            Body.RemoveLast();
        }
    }

    public bool IsCollision(Point newHeadPosition)
    {
        foreach (var point in Body)
        {
            if (point.X == newHeadPosition.X && point.Y == newHeadPosition.Y)
            {
                return true;
            }
        }

        return false;
    }

    public Point GetHeadPosition()
    {
        return Body.First.Value;
    }

    public List<Point> GetSnakePositions()
    {
        var positions = new List<Point>();
        foreach (var point in Body)
        {
            positions.Add(point);
        }
        return positions;
    }
}