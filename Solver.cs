using System.Collections.Generic;
using System.IO;
using Stately;

public class Solver
{
    public Maze Maze { get; set; }
    public void Solve()
    {
        Space dest;

        foreach (var space in Maze.Spaces)
            if (space.Exit)
            {
                dest = space;
                break;
            }

        // DFS(Maze.Root, new List<Space>());
        BFS();
        // AStar();
    }

    public void BFS()
    {
        var queue = new Queue<List<Space>>();
        List<Space> initialPath = new List<Space>();
        initialPath.Add(Maze.Root);
        queue.Enqueue(initialPath);
        initialPath[0].Visited = true;

        while (queue.Count > 0)
        {
            var path = queue.Dequeue();
            var last = path[path.Count - 1];

            if (last.Exit)
            {
                foreach (var item in path)
                    item.IsSolution = true;
                break;
            }

            last.Visited = true;

            var options = new List<Space>();

            if (last.Top != null && !last.Top.Visited)
                options.Add(last.Top);
            if (last.Bottom != null && !last.Bottom.Visited)
                options.Add(last.Bottom);
            if (last.Left != null && !last.Left.Visited)
                options.Add(last.Left);
            if (last.Right != null && !last.Right.Visited)
                options.Add(last.Right);

            foreach (var child in options)
            {
                List<Space> newpath = new List<Space>(path);
                newpath.Add(child);
                queue.Enqueue(newpath);
            }
        }
    }

    public List<Space> DFS(Space current, List<Space> path)
    {
        current.Visited = true;
        
        if (current.Exit)
        {
            current.IsSolution = true;

            foreach (var child in path)
            {
                child.IsSolution = true;
            }

            return path;
        }

        path.Add(current);

        var options = new List<Space>();

        if (current.Top != null && !current.Top.Visited)
            options.Add(current.Top);
        if (current.Bottom != null && !current.Bottom.Visited)
            options.Add(current.Bottom);
        if (current.Left != null && !current.Left.Visited)
            options.Add(current.Left);
        if (current.Right != null && !current.Right.Visited)
            options.Add(current.Right);
    
        foreach (var opt in options)
        {
            var result = DFS(opt, path);

            if (result != null)
                return result;
        }

        path.RemoveAt(path.Count - 1);

        return null;
    }

    public void AStar()
    {
        var dist = new List<int>();

        var queue = new PriorityQueue<>();

        while (queue.Count > 0)
        {

        }
    }
}