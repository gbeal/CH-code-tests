namespace TrainTest.Code
{
    using System.Collections.Generic;
    using System.Linq;

    public class Edge
    {
        public Vertex From { get; set; }

        private Vertex _to;
        public Vertex To
        {
            get
            {
                return _to;
            }
            set
            {
                _to = value;
                if (From != null)
                {
                    From.AdjacentVertexes.Add(_to);
                }
            }
        }
        public int Distance { get; set; }

        private Edge()
        { }
        public Edge(Vertex from, Vertex to, int distance)
        {
            From = from;
            To = to;
            Distance = distance;
        }
    }

    public class Vertex
    {
        public string Name { get; }
        public List<Vertex> AdjacentVertexes { get; set; }

        public Vertex()
        {
            AdjacentVertexes = new List<Vertex>();
        }
        public Vertex(string name) : this()
        {
            Name = name;
        }
    }

    public class Graph
    {
        List<Vertex> Vertexes;
        List<Edge> Edges;

        string[] GraphString;

        public Graph()
        {
            Vertexes = new List<Vertex>();
            Edges = new List<Edge>();
        }
        public Graph(params string[] graphString) : this()
        {
            GraphString = graphString;
        }

        public virtual void AddVertex(Vertex v)
        {
            Vertexes.Add(v);
        }

        public virtual void AddEdge(Vertex from, Vertex to, int distance)
        {
            Edges.Add(new Edge(from, to, distance));
        }
    }

    public class TrainRide
    {
        public Vertex From;
        public Vertex To;
        private Queue<Vertex> Stops;
        public void AddStop(Vertex stop)
        {
            Stops.Append(stop);
        }

        public TrainRide()
        {
            Stops = new Queue<Vertex>();
        }

        public TrainRide(Vertex from, Vertex to)
        {
            From = from;
            To = to;
        }
    }

    public class RoutingService
    {

    }
}