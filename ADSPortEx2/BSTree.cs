using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx2
{

    class BSTree<T> : BinTree<T> where T : IComparable
    {

        public BSTree()
        {
            root = null;
        }

        public void InsertItem(T item)
        {
            insertItem(item, ref root);
        }

        private void insertItem(T item, ref Node<T> tree)
        {
            if (tree == null)
            {
                tree = new Node<T>(item);
                Console.WriteLine("");
                Console.WriteLine("Video Game added successfully!");
            }
            else
            {
                VideoGame currentGame = (VideoGame)(object)tree.Data;
                VideoGame newGame = (VideoGame)(object)item;

                if (currentGame.Title == newGame.Title)
                {
                    Console.WriteLine("");
                    Console.WriteLine("A game with this title already exists in the tree.");
                    return;
                }

                if (item.CompareTo(tree.Data) < 0)
                    insertItem(item, ref tree.Left);

                else if (item.CompareTo(tree.Data) > 0)
                    insertItem(item, ref tree.Right);
            }
        }
        public int Height()
        {
            return height(root);
        }

        private int height(Node<T> tree)
        {
            if (tree == null)
                return 0;
            else
                return 1 + Math.Max(height(tree.Left), height(tree.Right));
        }

        public T EarliestGame()
        {
            return earliestGame(root);
        }

        private T earliestGame(Node<T> tree)
        {
            if (tree == null)
                return default(T);

            VideoGame currentGame = tree.Data as VideoGame;

            if (currentGame == null)
                return default(T);

            if (tree.Left == null && tree.Right == null)
                return tree.Data;

            VideoGame leftEarliest = (tree.Left != null) ? earliestGame(tree.Left) as VideoGame : currentGame;
            VideoGame rightEarliest = (tree.Right != null) ? earliestGame(tree.Right) as VideoGame : currentGame;

            if (leftEarliest.Releaseyear < currentGame.Releaseyear)
                currentGame = leftEarliest;
            if (rightEarliest.Releaseyear < currentGame.Releaseyear)
                currentGame = rightEarliest;

            return (T)(object)currentGame;
        }

        public int Count()
        {
            return count(root);
        }

        private int count(Node<T> tree)
        {
            if (tree == null)
                return 0;

            return 1 + count(tree.Left) + count(tree.Right);
        }

        public void Update(T item)
        {
            update(item, ref root); 
        }

        private void update(T item, ref Node<T> tree)
        {
            if (tree == null)
            {
                Console.WriteLine("Game not found.");
                return;
            }

            VideoGame currentGame = (VideoGame)(object)tree.Data;
            VideoGame newGame = (VideoGame)(object)item;

            if (currentGame.Title == newGame.Title)
            {
                tree.Data = item;
                Console.WriteLine("Game updated successfully!");
            }
            else if (item.CompareTo(tree.Data) < 0)
            {
                update(item, ref tree.Left);
            }
            else
            {
                update(item, ref tree.Right);
            }
        }

        public void ListByYear(int year)
        {
            bool found = false;
            Console.WriteLine("");
            Console.WriteLine($"All games released in {year}:");
            Console.WriteLine("");

            listByYear(year, root, ref found);

            if (!found)
            {
                Console.WriteLine($"No games stored were released in {year}.");
                Console.WriteLine("");
            }
        }

        private void listByYear(int year, Node<T> tree, ref bool found)
        {
            if (tree == null)
                return;

            VideoGame currentGame = (VideoGame)(object)tree.Data;

            if (currentGame.Releaseyear == year)
            {
                if (!found)
                {
                    found = true;
                }

                Console.WriteLine(currentGame);
            }

            listByYear(year, tree.Left, ref found);
            listByYear(year, tree.Right, ref found);
        }
    }
}
