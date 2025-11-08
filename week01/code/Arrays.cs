public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // PLAN FOR SOLVING THIS PROBLEM:
        // Step 1: Create a new array of doubles with size equal to 'length'
        // Step 2: Use a loop to iterate 'length' times (from 0 to length-1)
        // Step 3: For each position i in the array:
        //         - Calculate the multiple by multiplying 'number' by (i + 1)
        //         - The first multiple is number * 1, second is number * 2, etc.
        // Step 4: Store each calculated multiple in the array at position i
        // Step 5: Return the completed array

        // Step 1: Creating an array to hold the multiples
        double[] multiples = new double[length];
        
        // Step 2-4: Loop through and calculate each multiple
        for (int i = 0; i < length; i++)
        {
            // Multiplying the number by (i + 1) to get the correct multiple
            // i = 0 gives us number * 1 (first multiple)
            // i = 1 gives us number * 2 (second multiple), etc.
            multiples[i] = number * (i + 1);
        }
        
        // Step 5: Return the array of multiples
        return multiples;
    }



    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // PLAN FOR SOLVING THIS PROBLEM:
        // Step 1: - Take the last 'amount' elements from the end
        //         - Move them to the front of the list
        //
        // Step 2: Calculate where to split the list
        //         - Split point = data.Count - amount
        //         - Everything from split point to end goes to front
        //         - Everything before split point goes to back
        //
        // Step 3: Extract the last 'amount' elements (this is the part that moves to front)
        //         - Use GetRange to get elements from (data.Count - amount) to end
        //
        // Step 4: Remove those elements from their current position at the end
        //         - Use RemoveRange to remove the last 'amount' elements
        //
        // Step 5: Insert the extracted elements at the beginning (index 0)
        //         - Use InsertRange to put them at the front
        
       
        int splitPoint = data.Count - amount;
        
        List<int> elementsToMove = data.GetRange(splitPoint, amount);
        
        data.RemoveRange(splitPoint, amount);
        
        data.InsertRange(0, elementsToMove);
    }
}
