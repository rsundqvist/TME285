using System;
namespace FaceRecognitionApplication
{
    /// <summary>
    /// Merge-Find implementation for use in TME285 IP1. 
    /// Based on http://algs4.cs.princeton.edu/15uf/ by Robert Sedgewick and Kevin Wayne
    /// </summary>
    public class UnionFind
    {
        private readonly int[] _parent;
        private readonly short[] _rank;
        public int NumComponents { get; private set; }

        public UnionFind(int size)
        {
            if (size < 0)
                throw new Exception("Size must be non-negative.");

            NumComponents = size;
            _parent = new int[size];
            _rank = new short[size];
            for (int i = 0; i < size; i++) //All items in individual sets
                _parent[i] = i;
        }

        public int[] ComponentSizes()
        {
            int[] sizes = new int[_parent.Length];

            foreach (int i in _parent)
                sizes[i]++;

            return sizes;
        }

        public int LargestComponent()
        {
            int[] sizes = ComponentSizes();
            int largestComponent = sizes[0];

            for (int i = 1; i < sizes.Length; i++)
                if (sizes[i] > largestComponent)
                    largestComponent = sizes[i];

            return largestComponent;
        }

        public int Find(int index)
        {
            CheckBounds(index);

            while (index != _parent[index]) //Compression
            {
                _parent[index] = _parent[_parent[index]];
                index = _parent[index];
            }

            return index;
        }

        public bool SameComponent(int index1, int index2)
        {
            return Find(index1) == Find(index2);
        }

        public int Union(int index1, int index2)
        {
            int root1 = Find(index1);
            int root2 = Find(index2);

            if (root1 == root2)
                return root1;

            // Merge into larger set
            if (_rank[root1] < _rank[root2])
                _parent[root1] = root2;
            else if (_rank[root1] > _rank[root2])
                _parent[root2] = root1;
            else
            {
                _parent[root2] = root1;
                _rank[root1]++;
            }
            NumComponents--;
            return _rank[root1] < _rank[root2] ? root2 : root1;
        }

        private void CheckBounds(int index)
        {
            if (index < 0 || index >= _parent.Length)
                throw new Exception("Out of bounds: " + index);
        }
    }
}
