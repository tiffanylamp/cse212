using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue them
    // Expected Result: Items should be dequeued in order of highest priority first
    // Defect(s) Found: Yes, the loop condition in Dequeue uses `index < _queue.Count - 1` instead of
    // `index < -.queue.Count`, causing it to skip the last item in the queue when finding the highest priority. 
    //Also, the item is not actually removed from the queue after being dequeued. 
    public void TestPriorityQueue_DifferentPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());

    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority
    // Expected Result: Items with the smae priority should be dequeued in FIFO order 
    // Defect(s) Found: The condiition uses `>=` instead of `>`, which causes later items with the 
    // same priority to be selected instead of the first one, violating FIFO for equal priorities. 
    public void TestPriorityQueue_SamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 3);
        priorityQueue.Enqueue("Second", 3);
        priorityQueue.Enqueue("Third", 3);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());

    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue
    // Expected Result: Should throw InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None - Exception is thrown correctly.

    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should've been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual('The queue is empty.', e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                    e.GetType(), e.Message)
            );
        }
    }


    [TestMethod]
    // Scenario: Mix of same and different priorities
    // Expected Result: Highest priority first, then FIFO for equal priorities
    // Defect(s) Found: Same as above - loop skips last item and uses >= instead of >, 
    // and items are not removed from queue.

    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 2);
        priorityQueue.Enqueue("D", 5);
        priorityQueue.Enqueue("E", 1);

        Assert.AreEqual("B", priorityQueue.Dequeue()); //First with priority 5
        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue()); //First with priority 2
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("E", priorityQueue.Dequeue()); //Priority 1

    }

    [TestMethod]
    // Scenario: Single item in queue
    // Expected Result: This should dequeue the only item successfully
    // Defect(s) Found: Item is not removed from the queue after dequeue.
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Only", 1);

        Assert.AreEqual("Only", priorityQueue.Dequeue());

        // Verify if queue is now empty
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Queue should be empty after dequeuing the only item.");
        }
        catch (InvalidOperationException)
        {
            // Expected reslt
        }
    }
    
    [TestMethod]
    // Scenario: Enqueue the items, then verify highest priority at end of queue is found
    // Expected Result: This should find and return the last item if it has highest priority
    // Defect(s) Found: Loop condition `index < _queue.Count - 1` skips the last element.
    public void TestPriorityQueue_HighestPriorityAtEnd()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low1", 1);
        priorityQueue.Enqueue("Low2", 2);
        priorityQueue.Enqueue("Highest", 10);

        Assert.AreEqual("Highest", priorityQueue.Dequeue());
    }


}