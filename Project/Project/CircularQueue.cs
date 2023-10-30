public class CircularQueue<T>
{
    private List<T> items;
    private int currentIndex;

    public CircularQueue()
    {
        items = new List<T>();
        currentIndex = 0;
    }

    public void Enqueue(T item)
    {
        items.Add(item);
    }

    public T Peek()
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        return items[currentIndex];
    }

    public T Dequeue()
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        T item = items[currentIndex];
        currentIndex = (currentIndex + 1) % items.Count; // Circular increment

        return item;
    }
}
