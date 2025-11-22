/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        var currentPosition = (_currX, _currY);
            
            // Access the Map 
            if (_mazeMap.ContainsKey(currentPosition))
            {
                var directions = _mazeMap[currentPosition];
                
                // Check index 0 for left direction
                if (directions[0])
                {
                    // Can move left - decrease x coordinate
                    _currX--;
                }
                else
                {
                    // Wall detected - cannot move left
                    throw new InvalidOperationException("Can't go that way!");
                }
            }
            else
            {
                throw new InvalidOperationException("Can't go that way!");
            }
        
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        var currentPosition = (_currX, _currY);
            
            // Access the Map 
            if (_mazeMap.ContainsKey(currentPosition))
            {
                var directions = _mazeMap[currentPosition];
                
                // Check index 1 for right direction
                if (directions[1])
                {
                    // Can move right - increase x coordinate
                    _currX++;
                }
                else
                {
                    // Wall detected - cannot move right
                    throw new InvalidOperationException("Can't go that way!");
                }
            }
            else
            {
                throw new InvalidOperationException("Can't go that way!");
            }
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        var currentPosition = (_currX, _currY);
            
            // Access the Map
            if (_mazeMap.ContainsKey(currentPosition))
            {
                var directions = _mazeMap[currentPosition];
                
                // Check index 2 for up direction
                if (directions[2])
                {
                    // Can move up - decrease y coordinate
                    _currY--;
                }
                else
                {
                    // Wall detected - cannot move up
                    throw new InvalidOperationException("Can't go that way!");
                }
            }
            else
            {
                throw new InvalidOperationException("Can't go that way!");
            }
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        var currentPosition = (_currX, _currY);
            
            // Access the Map 
            if (_mazeMap.ContainsKey(currentPosition))
            {
                var directions = _mazeMap[currentPosition];
                
                // Check index 3 for down direction
                if (directions[3])
                {
                    // Can move down - increase y coordinate
                    _currY++;
                }
                else
                {
                    // Wall detected - cannot move down
                    throw new InvalidOperationException("Can't go that way!");
                }
            }
            else
            {
                throw new InvalidOperationException("Can't go that way!");
            }
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}