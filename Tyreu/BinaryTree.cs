using System;
using System.Collections;
using System.Collections.Generic;

namespace Tyreu
{
    public class BinaryTree<T> : ICollection<T>
    {
        protected class Node<TValue>
        {
            public TValue Value { get; set; }
            public Node<TValue> Left { get; set; }
            public Node<TValue> Right { get; set; }
            public Node(TValue value) => Value = value;
        }
        protected Node<T> root;
        protected IComparer<T> comparer;
        public BinaryTree() : this(Comparer<T>.Default) { }
        public BinaryTree(IComparer<T> defaultComparer) => comparer = defaultComparer ?? throw new ArgumentNullException("Default comparer is null");
        public BinaryTree(IEnumerable<T> collection) : this(collection, Comparer<T>.Default) { }
        public BinaryTree(IEnumerable<T> collection, IComparer<T> defaultComparer) : this(defaultComparer) => AddRange(collection);
        /// <summary>
        /// Максимальное значение в дереве
        /// </summary>
        public T MaxValue
        {
            get
            {
                if (root == null) throw new InvalidOperationException("Tree is empty");
                var current = root;
                while (current.Right != null)
                    current = current.Right;
                return current.Value;
            }
        }
        /// <summary>
        /// Добавить в дерево коллекцию элементов
        /// </summary>
        /// <param name="collection"></param>
        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var value in collection)
                Add(value);
        }
        /// <summary>
        /// Обратный обход дерева: левое поддерево – вершина – правое поддерево
        /// </summary>
        public IEnumerable<T> Inorder()
        {
            if (root == null)
                yield break;
            var stack = new Stack<Node<T>>();
            var node = root;
            while (stack.Count > 0 || node != null)
            {
                if (node == null)
                {
                    node = stack.Pop();
                    yield return node.Value;
                    node = node.Right;
                }
                else
                {
                    stack.Push(node);
                    node = node.Left;
                }
            }
        }
        /// <summary>
        /// Прямой обход дерева: вершина – левое поддерево – правое поддерево;
        /// </summary>
        public IEnumerable<T> Preorder()
        {
            if (root == null)
                yield break;
            var stack = new Stack<Node<T>>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                yield return node.Value;
                if (node.Right != null)
                    stack.Push(node.Right);
                if (node.Left != null)
                    stack.Push(node.Left);
            }
        }
        /// <summary>
        /// Концевой обход дерева: левое поддерево – правое поддерево – вершина
        /// </summary>
        public IEnumerable<T> Postorder()
        {
            if (root == null)
                yield break;
            var stack = new Stack<Node<T>>();
            var node = root;
            while (stack.Count > 0 || node != null)
            {
                if (node == null)
                {
                    node = stack.Pop();
                    if (stack.Count > 0 && node.Right == stack.Peek())
                    {
                        stack.Pop();
                        stack.Push(node);
                        node = node.Right;
                    }
                    else
                    {
                        yield return node.Value;
                        node = null;
                    }
                }
                else
                {
                    if (node.Right != null)
                        stack.Push(node.Right);
                    stack.Push(node);
                    node = node.Left;
                }
            }
        }
        /// <summary>
        /// Горизонтальный обход дерева по уровням: сначала обрабатываются все узлы текущего уровня, после чего осуществляется переход на нижний уровень
        /// </summary>
        public IEnumerable<T> Levelorder()
        {
            if (root == null)
                yield break;
            var queue = new Queue<Node<T>>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                yield return node.Value;
                if (node.Left != null)
                    queue.Enqueue(node.Left);
                if (node.Right != null)
                    queue.Enqueue(node.Right);
            }
        }
        /// <summary>
        /// Кол-во элементов
        /// </summary>
        public int Count { get; protected set; }
        /// <summary>
        /// Добавляет элемент item в дерево
        /// </summary>
        /// <param name="item">Элемент, который требуется добавить в дерево</param>
        public virtual void Add(T item)
        {
            var node = new Node<T>(item);
            if (root == null)
                root = node;
            else
            {
                Node<T> current = root, parent = null;
                int result = 0;
                while (current != null)
                {
                    parent = current;
                    result = comparer.Compare(item, current.Value);
                    current = result < 0 ? current.Left : current.Right;
                }
                if (comparer.Compare(item, parent.Value) < 0)
                    parent.Left = node;
                else
                    parent.Right = node;
            }
            ++Count;
        }
        /// <summary>
        /// Удаляет элемент item из дерева
        /// </summary>
        /// <param name="item">Элемент, который требуется удалить из дерева</param>
        public virtual bool Remove(T item)
        {
            if (root == null) return false;
            Node<T> current = root, parent = null;
            int result = 0;
            do
            {
                result = comparer.Compare(item, current.Value);
                current = result < 0 ? current.Left : current.Right;
                parent = current;
                if (current == null)
                    return false;
            } while (result != 0);

            if (current.Right == null)
            {
                if (current == root)
                    root = current.Left;
                else
                {
                    result = comparer.Compare(current.Value, parent.Value);
                    if (result < 0)
                        parent.Left = current.Left;
                    else
                        parent.Right = current.Left;
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;
                if (current == root)
                    root = current.Right;
                else
                {
                    result = comparer.Compare(current.Value, parent.Value);
                    if (result < 0)
                        parent.Left = current.Right;
                    else
                        parent.Right = current.Right;
                }
            }
            else
            {
                Node<T> min = current.Right.Left, prev = current.Right;
                while (min.Left != null)
                {
                    prev = min;
                    min = min.Left;
                }
                prev.Left = min.Right;
                min.Left = current.Left;
                min.Right = current.Right;
                if (current == root)
                    root = min;
                else
                {
                    result = comparer.Compare(current.Value, parent.Value);
                    if (result < 0)
                        parent.Left = min;
                    else
                        parent.Right = min;
                }
            }
            --Count;
            return true;
        }
        /// <summary>
        /// Очищает дерево и обнуляет корень
        /// </summary>
        public void Clear()
        {
            root = null;
            Count = 0;
        }
        /// <summary>
        /// Копировать элементы дерева в массив array
        /// </summary>
        /// <param name="array">Целевой массив</param>
        /// <param name="arrayIndex">Индекс с которого начнется вставка элементов дерева</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (var value in this)
                array[arrayIndex++] = value;
        }
        public virtual bool IsReadOnly => false;
        /// <summary>
        /// Проверяет содержит ли дерево элемент item
        /// </summary>
        /// <param name="item">Элемент, суещствование которого проверяется</param>
        public bool Contains(T item)
        {
            var current = root;
            while (current != null)
            {
                var result = comparer.Compare(item, current.Value);
                if (result == 0)
                    return true;
                current = result < 0 ? current.Left : current.Right;
            }
            return false;
        }
        public IEnumerator<T> GetEnumerator() => Inorder().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}